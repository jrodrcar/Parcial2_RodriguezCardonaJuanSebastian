using System.ComponentModel.DataAnnotations;

namespace Parcial2_RodriguezCardonaJuanSebastian.DAL.Entities
{
    public class ticket
    {
        [Key]
        [Required]
        [Display(Name = "Numero")]
        public int Id { get; set; }

        public DateTime? UseData { get; set; }
        public bool IsUsed { get; set; }

        [Display(Name = "Entrada")]
        public string? EntranceGate { get; set; }

    }
}
