using System.ComponentModel.DataAnnotations;

namespace Examen_Parcial1_Verdesoto_Ruben.Models
{
    public class Chef
    {
        [Key]
        public int Id_Chef { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(25, ErrorMessage = "El nombre no puede exceder los 25 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(25, ErrorMessage = "El apellido no puede exceder los 25 caracteres.")]
        public string Apellido { get; set; }
    }
}