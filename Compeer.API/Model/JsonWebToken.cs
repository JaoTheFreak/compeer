namespace Compeer.API.Model
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public string TokenType => "bearer";
        public long ExpiresIn { get; set; }
    }
}