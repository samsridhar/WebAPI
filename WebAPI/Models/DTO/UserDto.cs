using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO
{
    public class UserDto
    {
        [Key]
        public Guid activeDirectoryUserId { get; set; }
        public string samAccountName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }
        public string telephoneNumber { get; set; }
        public string password { get; set; }
        public string roles { get; set; }
    }
}
