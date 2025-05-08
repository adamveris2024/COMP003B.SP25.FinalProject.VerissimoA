using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{
    public class Shelter
    {
        public int ShelterId { get; set; }

        [Required]
        public string ShelterName { get; set; }

        [Required]
        public string ShelterAddress { get; set; }

        [Phone]
        public string ShelterPhone { get; set; }

        [EmailAddress]
        public string ShelterEmail { get; set; }

        public ICollection<Animal>? Animals { get; set; }
        public ICollection<Staff>? StaffMembers { get; set; }
    }
}
