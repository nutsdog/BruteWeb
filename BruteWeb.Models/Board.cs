using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruteWeb.Models
{
    public class Board
    {
        [Key]
        [Display(Name = "번호")]
        public int BoardId { get; set; }
        [Display(Name = "제목")]
        [MaxLength(50)]
        [Required(ErrorMessage = "제목을 입력하세요.")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "내용")]
        [MaxLength(1000)]
        [Required(ErrorMessage = "내용을 입력하세요.")]
        public string Contents { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Display(Name = "생성일")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }

        [Display(Name = "조회수")]
        public int ViewCount { get; set; }

        public IEnumerable<Comment>? Comments { get; set; }
    }
}