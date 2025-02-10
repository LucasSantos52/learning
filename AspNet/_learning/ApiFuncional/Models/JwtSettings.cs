namespace ApiFuncional.Models
{
    public class JwtSettings
    {
        public string? Segredo { get; set; } // key de criptografia
        public int ExpiracaoHoras { get; set; } // duração do token
        public string? Emissor { get; set; } // o app que emitiu o token
        public string? Audiencia { get; set; } // as aplicacoes onde o token é valido
    }
}
