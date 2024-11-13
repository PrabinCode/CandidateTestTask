using CandidateTestTask.Data;
using CandidateTestTask.Modals;
using Microsoft.EntityFrameworkCore;

namespace CandidateTestTask.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _context;

        public CandidateRepository(CandidateDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await GetCandidateByEmailAsync(candidate.Email);
            if (existingCandidate == null)
            {
                await _context.Candidates.AddAsync(candidate);
            }
            else
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.PreferredCallTime = candidate.PreferredCallTime;
                existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                existingCandidate.GitHubProfile = candidate.GitHubProfile;
                existingCandidate.Comments = candidate.Comments;
            }

            await _context.SaveChangesAsync();
        }
    }
}
