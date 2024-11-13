# CandidateTestTask

This project is a .NET Core Web API application designed to manage job candidate information. It provides a REST API endpoint to add and update candidate details, including personal and contact information.

## Table of Contents
- [Project Description](#project-description)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Setup Instructions](#setup-instructions)
- [API Usage](#api-usage)
- [Assumptions](#assumptions)
- [Future Improvements](#future-improvements)

## Project Description

`CandidateTestTask` is a backend service that stores and updates candidate information in a SQL database. It follows RESTful principles, allowing other applications to integrate with it to manage candidate records. The application is built with scalability in mind, aiming to handle large datasets as it grows.

## Technologies Used
- .NET Core
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- NUnit for testing
- Moq for unit test mocking

## Project Structure

The project is organized as follows:

```
CandidateTestTask/
│
├── Controllers/
│   └── CandidatesController.cs       # Handles API requests for candidate data
│
├── Data/
│   └── CandidateDbContext.cs         # Database context for EF Core
│
├── Modals/
│   ├── Candidate.cs                  # Entity model for Candidate
│   └── CandidateDto.cs               # Data transfer object for API requests
│
├── Repositories/
│   ├── ICandidateRepository.cs       # Interface for repository pattern
│   └── CandidateRepository.cs        # Implementation of repository for data access
│
├── Services/
│   ├── ICandidateService.cs          # Interface for business logic layer
│   └── CandidateService.cs           # Implementation of business logic for managing candidates
│
├── CandidateTestTask.Tests/
│   └── Controllers/
│       └── CandidatesControllerTests.cs  # NUnit tests for CandidatesController
│   └── Services/
│       └── CandidateServiceTests.cs      # NUnit tests for CandidateService
│
└── appsettings.json                  # Configuration file for database connection
```

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/PrabinCode/CandidateTestTask.git
   cd CandidateTestTask
   ```

2. **Configure Database Connection**:
   - Open `appsettings.json` and set your SQL Server connection string under `DefaultConnection`.
   - Example:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=CandidateDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
     ```

3. **Run Database Migrations**:
   - Open the **Package Manager Console** in Visual Studio and run the following commands to create and apply migrations:
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```

4. **Run the Application**:
   - Press **F5** or **Ctrl+F5** in Visual Studio to start the application.
   - Use a tool like **Postman** or **Swagger** (auto-generated) to test the API endpoints.

5. **Run Unit Tests**:
   - Open the **Test Explorer** in Visual Studio and run the tests.

## API Usage

### Add or Update Candidate

- **Endpoint**: `POST /api/candidates`
- **Request Body** (JSON):
  
  ```json
  {
      "firstName": "Prabin",
      "lastName": "Shrestha",
      "phoneNumber": "1234567890",
      "email": "myemail@gmail.com",
      "preferredCallTime": "Morning",
      "linkedInProfile": "https://www.linkedin.com/in/pcshrestha/",
      "githubProfile": "https://github.com/PrabinCode",
      "comments": "New candidate entry."
  }
  ```

- **Response**: `200 OK` if the candidate is added or updated successfully. The response message will be `"Candidate information successfully added/updated."`

## Assumptions

1. **Unique Identifier**: Candidate `Email` is used as the unique identifier for each candidate, allowing the system to update records based on email.
2. **Database**: SQL Server is used with Entity Framework Core for this application, but the design allows for migration to other databases if needed.
3. **Caching**: No caching is implemented initially, as the primary goal is data consistency. Caching may be added for performance optimization in read-heavy scenarios.

## Future Improvements

1. **Implement Caching**:
   - Consider adding in-memory or distributed caching (e.g., Redis) for frequently accessed data, which can enhance performance, especially for read-heavy workloads.

2. **Enhanced Error Handling and Logging**:
   - Add detailed logging for better traceability and error diagnosis.
   - Implement a global error handling middleware for consistent error responses across the application.

3. **Expand Unit Tests**:
   - Add more unit tests to cover edge cases, such as invalid data inputs and database connection issues.

4. **Database Migration Support**:
   - Design the application to facilitate migration to a NoSQL database (e.g., MongoDB) for scalability if future requirements necessitate this.

5. **Add Validation and Security Features**:
   - Implement more comprehensive validation for fields like URLs, email, and phone number.
   - Use JWT authentication in production to secure the API.

6. **Documentation**:
   - Use Swagger or another documentation tool to generate API documentation, making the API more accessible for other developers.
