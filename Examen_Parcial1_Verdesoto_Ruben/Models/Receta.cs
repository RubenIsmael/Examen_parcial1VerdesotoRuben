using System.ComponentModel.DataAnnotations;

namespace Examen_Parcial1_Verdesoto_Ruben.Models
{
    public class Receta
    {
        [Key]
        public int Receta_Id { get; set; }

        [Required(ErrorMessage = "El nombre de la receta es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El tiempo de preparación es obligatorio.")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "El tiempo debe estar en formato HH:mm.")]
        public string Tiempo_Preparacion { get; set; }

        [Required(ErrorMessage = "La dificultad es obligatoria.")]
        [StringLength(50, ErrorMessage = "La dificultad no puede exceder los 50 caracteres.")]
        public string Dificultad { get; set; }

        public int Id_Chef { get; set; }
        public Chef Chef { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>(); 
    }
}