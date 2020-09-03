using System.ComponentModel.DataAnnotations;

namespace ApiAuth.Services.Dto
{
    public class HeroViewDto {
        public string Id { get; set; }
        public int? EditorialId { get; set; }
        public string HeroName { get; set; }
        public string SuperHero { get; set; }
        public int? YearOfAppearance { get; set; }
        public string History { get; set; }
        public string UrlImage { get; set; }
        public bool? Active { get; set; }

        public EditorialHouseDto Editorial { get; set; }
    }


    public class HeroRegisterDto {
        [Required(ErrorMessage = "The field [Id] is requiered.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The field [EditorialId] is requiered.")]
        public int? EditorialId { get; set; }

        [Required(ErrorMessage = "The field [HeroName] is requiered.")]
        public string HeroName { get; set; }

        [Required(ErrorMessage = "The field [SuperHero] is requiered.")]
        public string SuperHero { get; set; }

        [Required(ErrorMessage = "The field [YearOfAppearance] is requiered.")]
        public int? YearOfAppearance { get; set; }

        [Required(ErrorMessage = "The field [History] is requiered.")]
        public string History { get; set; }

        [Required(ErrorMessage = "The field [UrlImage] is requiered.")]
        public string UrlImage { get; set; }
    }

}
