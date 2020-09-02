using System.Collections.Generic;

namespace ApiAuth.Services.Dto
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int PatherId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }


        public List<ChildMenuDto> ChildMenu { get; set; }
    }

    public class ChildMenuDto : MenuDto
    {
    }
}
