# End-of-Semester Project: Health Condition-Based Hospital Recommendation System

## Table of Contents
- [Objective](#objective)
- [Project Overview](#project-overview)
- [Key Requirements](#key-requirements)
- [Advanced Features](#advanced-features)
- [Project Setup](#project-setup)
- [API Documentation](#api-documentation)
- [Folder Structure](#folder-structure)
- [Usage Instructions](#usage-instructions)
- [Technology Stack](#technology-stack)
- [Team Contributions](#team-contributions)
- [GitHub Version Control](#github-version-control)
- [Presentation Guidelines](#presentation-guidelines)
- [Contact Information](#contact-information)

## Objective
This project aims to develop a Health Condition-Based Hospital Recommendation System using a RESTful Web API built with .NET 6 and MongoDB. The system will provide recommendations for hospitals based on user health conditions, demonstrating proficiency in CRUD operations, MongoDB integration, dependency injection, and other key concepts covered in class.

## Project Overview
Our API will allow users to input their health conditions and receive hospital recommendations tailored to their needs. The API includes CRUD operations for managing hospital information, health condition categories, and user accounts. MongoDB will be used to store hospital and health-related data.

## Key Requirements
1. **CRUD Operations:**
   - Implement Create, Read, Update, and Delete operations for resources such as Hospitals and Health Conditions.

2. **MongoDB Integration:**
   - Utilize MongoDB to store and retrieve hospital, health condition, and user account data.
   - Ensure well-structured collections and relationships.

3. **Dependency Injection:**
   - Implement DI for MongoDB services.

4. **Separation of Concerns:**
   - Ensure a clear separation between controller, service, and model layers.

5. **Error Handling:**
   - Handle errors gracefully with appropriate HTTP status codes.

6. **API Documentation:**
   - Include clear API documentation using Swagger or a detailed README.

## Advanced Features
- **Account Management:**
  - Allow users to create, update, and delete their accounts.
  - Secure user data with authentication and password management.
- **Search and Filtering Functionality:** Allow users to search for hospitals based on location, specialties, and health conditions.
- **Pagination:** Implement pagination for handling large hospital datasets efficiently.
- **Input Validation:** Validate incoming request data to ensure data integrity.
- **Authentication/Authorization:** Secure endpoints for hospital management with authentication mechanisms.
- **Dockerization:** Provide a Dockerfile for containerized deployment.

## Project Setup
1. Clone the repository:
   ```bash
   git clone [repository-url]
   cd [repository-folder]
   ```
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Set up MongoDB connection in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "MongoDb": "mongodb://localhost:27017/hospital_recommendation_db"
     }
   }
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Access the API documentation at `http://localhost:5000/swagger`.

## API Documentation
- **Swagger:** Detailed API documentation is available through Swagger at `http://localhost:5000/swagger`.
- **Endpoints:**
  - **GET `/api/hospitals`**: Retrieve a list of hospitals.
  - **POST `/api/hospitals`**: Add a new hospital.
  - **GET `/api/hospitals/{id}`**: Retrieve a specific hospital by ID.
  - **PUT `/api/hospitals/{id}`**: Update hospital information.
  - **DELETE `/api/hospitals/{id}`**: Delete a hospital.
  - **POST `/api/recommendations`**: Get hospital recommendations based on health conditions.
  - **POST `/api/accounts`**: Create a new user account.
  - **GET `/api/accounts/{id}`**: Retrieve a specific user account.
  - **PUT `/api/accounts/{id}`**: Update account information.
  - **DELETE `/api/accounts/{id}`**: Delete a user account.
  - **POST `/api/search`**: Search for healthcare centers based on various criteria.

## Folder Structure
```
├── Controllers
├── Models
├── Services
├── Data
├── appsettings.json
└── Program.cs
```

## Usage Instructions
1. **Creating a Hospital:**
   - Endpoint: POST `/api/hospitals`
   - Request Body: 
     ```json
     {
       "name": "General Hospital",
       "location": "123 Main St, City, Country",
       "specialties": ["Cardiology", "Orthopedics"],
       "contact": "123-456-7890"
     }
     ```

2. **Getting Hospital Recommendations:**
   - Endpoint: POST `/api/recommendations`
   - Request Body: 
     ```json
     {
       "healthCondition": "Heart Disease"
     }
     ```

3. **Creating a User Account:**
   - Endpoint: POST `/api/accounts`
   - Request Body:
     ```json
     {
       "username": "john_doe",
       "password": "securePassword123",
       "email": "john.doe@example.com"
     }
     ```

4. **Searching for Healthcare Centers:**
   - Endpoint: POST `/api/search`
   - Request Body:
     ```json
     {
       "location": "New York",
       "specialties": ["Cardiology"]
     }
     ```

5. **Updating a Hospital:**
   - Endpoint: PUT `/api/hospitals/{id}`

6. **Deleting a Hospital:**
   - Endpoint: DELETE `/api/hospitals/{id}`

## Technology Stack
- **Backend:** .NET 6
- **Database:** MongoDB
- **Documentation:** Swagger
- **Containerization:** Docker (optional)
- **Version Control:** GitHub

## Team Contributions
- **[Member 1 Name]:** Backend development and MongoDB integration
- **[Member 2 Name]:** API design and documentation
- **[Member 3 Name]:** Advanced features implementation (search, filtering, authentication)
- **[Member 4 Name]:** Deployment and presentation preparation

## GitHub Version Control
- Ensure a clear commit history to track development progress.
- Use branches for feature development and merge changes through pull requests.
- Maintain a well-organized folder structure.

## Presentation Guidelines
- Duration: 3 minutes
- Highlight key functionalities and technical challenges addressed.
- Be prepared for oral questions about the implementation.

## Contact Information
- **Instructor:** Beimnet Girma
  - Email: [beimnet.girma@aau.edu.et](mailto:beimnet.girma@aau.edu.et)
  - Telegram: [@beimn_et](https://t.me/beimn_et)

