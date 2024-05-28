using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Domain
{
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
