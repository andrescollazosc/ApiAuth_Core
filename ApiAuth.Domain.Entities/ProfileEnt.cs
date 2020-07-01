using System.Collections.Generic;

namespace ApiAuth.Domain.Entities
{
    public class ProfileEnt
    {
        public ProfileEnt()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
