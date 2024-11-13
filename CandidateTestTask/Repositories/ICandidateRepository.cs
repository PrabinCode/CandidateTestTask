using CandidateTestTask.Modals;

namespace CandidateTestTask.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
        Task AddOrUpdateCandidateAsync(Candidate candidate);
    }
}
