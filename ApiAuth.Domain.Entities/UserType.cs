using System.Collections.Generic;

namespace ApiAuth.Domain.Entities
{
    public class UserType
    {
        public UserType()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
