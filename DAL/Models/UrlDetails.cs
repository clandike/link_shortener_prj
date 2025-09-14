using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.DAL.Models
{
    [Table("url_details")]
    public class UrlDetails
    {
    //    [Key]
    //    [Column("id")]
    //    public int Id { get; set; }

        [Key]
        [ForeignKey("Url")]
        [Column("url_id")]
        public int UrlId { get; set; }

        [Required]
        [Column("created_by")]
        public string CreatedBy { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("click_count")]
        public int ClickCount { get; set; } = 0;

        public Url Url { get; set; } = null!;
    }
}
