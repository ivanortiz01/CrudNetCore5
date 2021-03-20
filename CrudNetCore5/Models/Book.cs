using System;
using System.ComponentModel.DataAnnotations;

namespace CrudNetCore5.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El titulo es requerido.")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos de {2}, máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Título")]
        public string title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [Display(Name = "Descripción")]
        public string description { get; set; }

        [Display(Name = "Fecha Lanzamiento")]
        [Required(ErrorMessage = "La Fecha Lanzamiento es obligatoria.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]                
        public DateTime releaseDate { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [Display(Name = "Autor")]
        public string author { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Display(Name = "Precio")]
        public int price { get; set; }

    }
}
