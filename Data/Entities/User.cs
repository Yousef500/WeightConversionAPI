using Microsoft.AspNetCore.Identity;

namespace WeightConversion.Data.Entities
{
    public class User : IdentityUser
    {
        public string? GoogleId { get; set; }
    }
}