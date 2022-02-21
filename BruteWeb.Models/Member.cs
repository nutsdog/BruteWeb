using System.ComponentModel.DataAnnotations;

namespace BruteWeb.Models
{
    public class Member
    {
        [Key]
        [Display(Name = "아이디")]
        [Required(ErrorMessage = "아이디를 입력하세요.")]
        public string MemberId { get; set; } = string.Empty;
        [MaxLength(100)]
        [Display(Name = "비밀번호")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "비밀번호를 입력하세요.")]
        public string Password { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
    }
}
