using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class CollectionImage
    {
        public const int MaxSize = 5 * 1_000_000;

        public CollectionImage(byte[] image, string contentType)
        {
            Image = image;
            ContentType = contentType;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxSize)]
        public byte[] Image { get; set; }

        [Required]
        [MaxLength(255)]
        public string ContentType { get; set; }

        public Collection? Collection { get; set; }
    }
}
