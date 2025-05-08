using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{
    public class AdoptionRequest
    {
        public int AdoptionId { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public int AdopterId { get; set; }

        public DateTime DateRequested { get; set; }

        [Required]
        public string Status { get; set; }

        public Animal Animal { get; set; }
        public Adopter Adopter { get; set; }
    }
}
