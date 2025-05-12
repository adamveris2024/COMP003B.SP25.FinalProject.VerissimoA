using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public int AdopterId { get; set; }

        [Required]
        public string Status { get; set; }

        public string DateRequested { get; set; }

        public Animal? Animal { get; set; }
        public Adopter? Adopter { get; set; }
    }
}
