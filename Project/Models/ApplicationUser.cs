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
    }
}
