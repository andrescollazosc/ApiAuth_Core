using System.ComponentModel.DataAnnotations;

namespace ApiAuth.Services.Dto
{
    public class UserViewDto
    {
        public int Id { get; set; }
        public int? UserTypeId { get; set; }
        public int? ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }

}
