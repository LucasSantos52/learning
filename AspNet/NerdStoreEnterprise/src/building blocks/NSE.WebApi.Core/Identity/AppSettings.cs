namespace NSE.WebApi.Core.Identity
{
    public class AppSettings
    {
        public string Secret { get; set; } // segredo
        public int ExpirationHours { get; set; } // tempo de expiração
        public string Issuer { get; set; } // gerado por
        public string Audience { get; set; } // valido em

    }
}
