using CandidateTestTask.Controllers;
using CandidateTestTask.Modals;
using CandidateTestTask.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CandidateTestTask.Tests.Controllers
{
    [TestFixture]
    public class CandidatesControllerTests
    {
        private Mock<ICandidateService> _candidateServiceMock;
        private CandidatesController _controller;

        [SetUp]
        public void SetUp()
        {
            _candidateServiceMock = new Mock<ICandidateService>();
            _controller = new CandidatesController(_candidateServiceMock.Object);
        }

        [Test]
        public async Task AddOrUpdateCandidate_ValidCandidate_ReturnsOk()
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

            _candidateServiceMock.Setup(service => service.AddOrUpdateCandidateAsync(candidateDto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidateDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Candidate information successfully added/updated.", okResult.Value);
        }

        [Test]
        public async Task AddOrUpdateCandidate_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var candidateDto = new CandidateDto
            {
                FirstName = "Prabin",
                LastName = "Shrestha",
                Email = "pcstha01@gmail.com",
                // Missing required fields like PhoneNumber and PreferredCallTime to simulate an invalid model
            };

            _controller.ModelState.AddModelError("PhoneNumber", "Phone number is required");

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidateDto);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [Test]
        public async Task AddOrUpdateCandidate_ServiceThrowsException_ReturnsInternalServerError()
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

            _candidateServiceMock.Setup(service => service.AddOrUpdateCandidateAsync(candidateDto))
                .ThrowsAsync(new System.Exception("Service error"));

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidateDto);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = result as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(500, objectResult.StatusCode);
            Assert.AreEqual("An error occurred while processing the request.", objectResult.Value);
        }
    }
}
