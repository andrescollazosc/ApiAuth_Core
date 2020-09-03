namespace ApiAuth.Domain.Entities
{
    public partial class Hero
    {
        public string Id { get; set; }
        public int? EditorialId { get; set; }
        public string HeroName { get; set; }
        public string SuperHero { get; set; }
        public int? YearOfAppearance { get; set; }
        public string History { get; set; }
        public string UrlImage { get; set; }
        public bool? Active { get; set; }

        public EditorialHouse Editorial { get; set; }
    }
}
