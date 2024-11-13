using CandidateTestTask.Modals;
using CandidateTestTask.Repositories;
using CandidateTestTask.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTestTask.Tests.Services
{
    [TestFixture]
    public class CandidateServiceTests
    {
        private Mock<ICandidateRepository> _candidateRepositoryMock;
        private CandidateService _candidateService;

        [SetUp]
        public void SetUp()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object);
        }

        [Test]
        public async Task AddOrUpdateCandidateAsync_NewCandidate_CallsAddMethod()
        {
            // Arrange
            var candidateDto = new CandidateDto
            {
                FirstName = "Prabin",
                LastName = "Shrestha",
                Email = "pcstha01@gmail.com",
                PhoneNumber = "1234567890",
                PreferredCallTime = "Morning",
                LinkedInProfile = "https://www.linkedin.com/in/pcshrestha/",
                GitHubProfile = "https://github.com/PrabinCode",
                Comments = "New candidate entry."
            };

            // Act
            await _candidateService.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            _candidateRepositoryMock.Verify(repo => repo.AddOrUpdateCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }

        [Test]
        public async Task AddOrUpdateCandidateAsync_UpdateExistingCandidate_CallsRepositoryUpdate()
        {
            // Arrange
            var existingCandidate = new Candidate
            {
                Id = 1,
                FirstName = "Prabin",
                LastName = "Shrestha",
                Email = "pcstha01@gmail.com"
            };

            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(existingCandidate.Email))
                                    .ReturnsAsync(existingCandidate);

            var candidateDto = new CandidateDto
            {
                FirstName = "Prabin",
                LastName = "Shrestha",
                Email = "pcstha01@gmail.com",
                PhoneNumber = "1234567890",
                PreferredCallTime = "Morning",
                LinkedInProfile = "https://www.linkedin.com/in/pcshrestha/",
                GitHubProfile = "https://github.com/PrabinCode",
                Comments = "Updating candidate info."
            };

            // Act
            await _candidateService.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            _candidateRepositoryMock.Verify(repo => repo.AddOrUpdateCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }
    }
}
