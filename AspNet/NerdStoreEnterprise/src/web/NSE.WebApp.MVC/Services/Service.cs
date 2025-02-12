using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace NSE.WebApp.MVC.Services
{
    public abstract class Service
    {
        protected StringContent GetContent(object data)
        {
            return new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");
        }

        protected async Task<T> DeserializeResponseObject<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TreatErrorsResponse(HttpResponseMessage response)
        {
            switch ((int) response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode(); // retorna exception caso o codigo nesse momento não seja de sucesso. isso pode acontecer caso de um tipo de erro não esperado/tratado no switch
            return true;
        }
    }
}
