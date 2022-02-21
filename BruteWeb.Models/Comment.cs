using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BruteWeb.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Contents { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int BoardForeignKey { get; set; }
        [ForeignKey(nameof(BoardForeignKey))]
        public Board Board { get; set; }
    }
}