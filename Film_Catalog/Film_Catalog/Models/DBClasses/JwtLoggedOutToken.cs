using Microsoft.EntityFrameworkCore;


namespace Film_Catalog.Models.DBClasses
{
    [Keyless]
    public class JwtLoggedOutToken
    {
        public string Token { get; set; }
    }
}
