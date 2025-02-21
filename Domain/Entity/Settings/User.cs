using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entity.Settings
{
    public class User:BaseEntity
    {
        public long UserId { get; set; }
        public Guid? UserKey { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Phone No is Required")]
        public string UserPhoneNo { get; set; }
        [Required(ErrorMessage = "User Password is Required")]
        public string UserPassword { get; set; }
        public string? UserDesignation { get; set; }
        public string? UserImgLink { get; set; }

        [NotMapped]
        public int total_row { get; set; }
        [NotMapped]
        public bool RememberMe { get; set; } = false;
    }
}
