using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{
    public class Adopter
    {
        public int AdopterId { get; set; }

        [Required]
        public string AdopterName { get; set; }

        [EmailAddress]
        public string AdopterEmail { get; set; }

        public string AdopterAddress { get; set; }

        [Phone]
        public string AdopterPhone { get; set; }
        
        //breaks the code
        //public ICollection<AdoptionRequest> AdoptionRequests { get; set; }
    }
}
