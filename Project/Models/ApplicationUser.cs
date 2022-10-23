using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime LastLogin { get; set; }

        public DateTime Created { get; set; }

        public bool Blocked { get; set; }

        [ForeignKey("AuthorId")]
        public List<Collection> Collections { get; set; } = new List<Collection>();

        public List<Like> Likes { get; set; } = new List<Like>();

        public async Task<bool> OwnsCollectionAsync(Collection collection, UserManager<ApplicationUser> userManager)
        {
            return await userManager.IsInRoleAsync(this, "Admin") || Id == collection.AuthorId;
        }
    }
}
