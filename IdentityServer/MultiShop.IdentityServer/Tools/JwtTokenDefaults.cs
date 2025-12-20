namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidIssuer = "http://localhost";//tokeni kim oluşturdu
        public const string ValidAudience = "http://localhost";//tokeni kim kullanacak
        public const string Key = "MultiShop..0102030405Asp.NetCore6.0.28*/+-"; //tokenin şifrelenmesi için kullanılan anahtar
        public const int Expire = 60;
    }
}
