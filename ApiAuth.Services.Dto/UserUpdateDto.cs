using System.ComponentModel.DataAnnotations;

namespace ApiAuth.Services.Dto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es requerido.")]
        public int? UserTypeId { get; set; }

        [Required(ErrorMessage = "El perfil de usuario es requerido.")]
        public int? ProfileId { get; set; }

        [Required(ErrorMessage = "Los nombres son requeridos.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El email es requeridos.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        [MinLength(6)]
        [MaxLength(20)]
        public string UserName { get; set; }
    }
}
