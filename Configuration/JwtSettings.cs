namespace PDIv2.Configuration
{
    public class JwtSettings
    {
        public string Key { get; set; } = "ChaveSecreta";
        public string Issuer { get; set; } = "EmissoraSecreta";
        public string Audience { get; set; } = "AudienciaSecreta";
        public int DurationInMinutes { get; set; } = 60;

    }
}
