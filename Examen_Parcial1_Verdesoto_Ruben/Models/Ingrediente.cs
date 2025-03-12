using System.ComponentModel.DataAnnotations;

namespace Examen_Parcial1_Verdesoto_Ruben.Models
{
    public class Ingrediente
    {
        [Key]
        public int Ingrediente_Id { get; set; }

        [Required(ErrorMessage = "El nombre del ingrediente es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "La unidad es obligatoria.")]
        [RegularExpression(@"^(gramos|kilos|libras|litros|galones|onza)$", ErrorMessage = "La unidad debe ser 'gramos', 'kilos','litros','galones,'onza' o 'libras'.")]
        public string Unidad { get; set; }

        [Required(ErrorMessage = "Las calorías son obligatorias.")]
        [Range(0, int.MaxValue, ErrorMessage = "Las calorías deben ser un número positivo.")]
        public int Calorias { get; set; }
    }
}