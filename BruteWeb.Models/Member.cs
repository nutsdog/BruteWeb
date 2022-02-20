using System.ComponentModel.DataAnnotations;

namespace BruteWeb.Models
{
    public class Member
    {
        [Key]
        [Required(ErrorMessage = "아이디를 입력하세요.")]
        public string Id { get; set; } = string.Empty;
        [Required(ErrorMessage = "비밀번호를 입력하세요.")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
    }
}
