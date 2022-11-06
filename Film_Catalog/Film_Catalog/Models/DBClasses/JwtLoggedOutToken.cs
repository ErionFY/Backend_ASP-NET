using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models.DBClasses
{
    public class JwtLoggedOutToken
    {
        [Key]
        public string Token { get; set; }
    }
}
