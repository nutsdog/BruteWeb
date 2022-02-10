using System.ComponentModel.DataAnnotations;

namespace BruteWeb.Models
{
    public class Board
    {
        [Key]
        [Display(Name = "번호")]
        public int Number { get; set; }
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
    }
}