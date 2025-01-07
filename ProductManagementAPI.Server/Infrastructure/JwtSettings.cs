namespace ProductManagementAPI.Server.Infrastructure
{
    public class JwtSettings
    {
        public string Secret { get; set; } = "Your_Secret_Key_Here";
        public int ExpirationMinutes { get; set; } = 60;
    }
}
