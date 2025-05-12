using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{     
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null;

        [Required]
        public string Role { get; set; } = null;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null;

        public int ShelterId { get; set; }
        public Shelter? Shelter { get; set; }
    }
}
