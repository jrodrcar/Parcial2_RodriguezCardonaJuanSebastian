using System.ComponentModel.DataAnnotations;

namespace Parcial2_RodriguezCardonaJuanSebastian.DAL.Entities
{
    public class ticket
    {
        [Key]
        [Required]
        [Display(Name = "Numero")]
        public int Id { get; set; }

        [Display(Name = "Fecha de uso")]
        public DateTime? UseData { get; set; }

        [Display(Name = "Usado")]
        public bool IsUsed { get; set; }

        [Display(Name = "Entrada")]
        public string? EntranceGate { get; set; }

    }
}
