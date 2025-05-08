using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VerissimoA.Models
{
    public class Staff
    {
        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public string MemberRole { get; set; }

        [EmailAddress]
        public string MemberEmail { get; set; }

        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }
    }
}
