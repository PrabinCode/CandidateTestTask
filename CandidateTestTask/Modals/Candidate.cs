using System.ComponentModel.DataAnnotations;

namespace CandidateTestTask.Modals
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Unique Identifier

        public string PreferredCallTime { get; set; }

        [Url]
        public string LinkedInProfile { get; set; }

        [Url]
        public string GitHubProfile { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comments { get; set; }
    }
}
