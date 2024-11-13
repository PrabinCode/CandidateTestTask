using CandidateTestTask.Modals;
using CandidateTestTask.Repositories;

namespace CandidateTestTask.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            var candidate = new Candidate
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                PhoneNumber = candidateDto.PhoneNumber,
                Email = candidateDto.Email,
                PreferredCallTime = candidateDto.PreferredCallTime,
                LinkedInProfile = candidateDto.LinkedInProfile,
                GitHubProfile = candidateDto.GitHubProfile,
                Comments = candidateDto.Comments
            };

            await _candidateRepository.AddOrUpdateCandidateAsync(candidate);
        }
    }
}
