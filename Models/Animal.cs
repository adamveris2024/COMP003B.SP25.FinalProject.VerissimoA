using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required]
        [StringLength(50)]
        public string AnimalName { get; set; }

        [Required]
        public string AnimalDescription { get; set; }

        [Range(0, 20)]
        public int AnimalAge { get; set; }

        public string Status { get; set; }

        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }
}
