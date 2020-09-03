using System.Collections.Generic;

namespace ApiAuth.Domain.Entities
{
    public class EditorialHouse
    {
        public EditorialHouse()
        {
            Hero = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string HouseName { get; set; }

        public ICollection<Hero> Hero { get; set; }
    }
}
