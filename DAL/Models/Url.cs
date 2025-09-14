using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.DAL.Models
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

        public IEnumerable<UrlDetails> Details { get; set; } = null!;
    }
}
