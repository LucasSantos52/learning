using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSemTemplate.Extensions
{
    public class FiltroAuditoria : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // traz diversas opções de analize para auditoria
            // documentação - https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-8.0
            var t = context.HttpContext;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = context.HttpContext.User.Identity.Name + " Acessou: " +
                              context.HttpContext.Request.GetDisplayUrl();

                // salva o log em algum local para auditoria se for o caso
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
