using System;

namespace ApiAuth.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public int? UserTypeId { get; set; }
        public int? ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public DateTime? Date { get; set; }

        public ProfileEnt Profile { get; set; }
        public UserType UserType { get; set; }
    }
}
