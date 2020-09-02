using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuth.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public int PatherId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }


        public List<ChildMenu> ChildMenu { get; set; }
    }

    public class ChildMenu : Menu
    {
    }
}
