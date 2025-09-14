using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.DAL.DbUrlModels
{
    [Table("urls")]
    public class Url
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("url")]
        public required string OriginalUrl { get; set; }

        [Column("shorted_url")]
        public required string ShortedUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("created_by")]
        public required int CreatedBy { get; set; }
    }
}
