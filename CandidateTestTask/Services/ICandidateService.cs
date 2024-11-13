using CandidateTestTask.Modals;

namespace CandidateTestTask.Services
{
    public interface ICandidateService
    {
        Task AddOrUpdateCandidateAsync(CandidateDto candidateDto);

    }
}
