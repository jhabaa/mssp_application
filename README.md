# Maison de la Santé Saint-Paul (mssp_application)

![Last Commit](https://img.shields.io/github/last-commit/jhabaa/mssp_application)

[![SonarQube Cloud](https://sonarcloud.io/images/project_badges/sonarcloud-highlight.svg)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)

[![.NET](https://github.com/jhabaa/mssp_application/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jhabaa/mssp_application/actions/workflows/dotnet.yml)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=bugs)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=jhabaa_mssp_application&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=jhabaa_mssp_application)





A web application for the Maison de la Santé Saint-Paul, a community health center in Yaoundé, Cameroon. The app provides information about the clinic, its activities, and allows for dynamic display of news and activities from a MongoDB database.

## Features

- Modern Blazor-based web UI
- Dynamic activities section loaded from MongoDB
- Responsive layout with custom navigation and footer
- Integration with external news APIs
- Docker support for easy deployment

## Project Structure

- `Components/` - Blazor components (pages, layouts, navigation, etc.)
- `Models/` - C# models and MongoDB connection logic
- `wwwroot/` - Static files (CSS, JS, images)
- `Program.cs` - Application entry point and configuration
- `Dockerfile` - Containerization setup

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MongoDB Atlas](https://www.mongodb.com/atlas) or a MongoDB instance
- (Optional) [Docker](https://www.docker.com/) for containerized deployment

### Configuration

Set the following environment variables or add them to your `appsettings.Development.json`:

- `MONGODB_PASSWORD` - Password for the MongoDB user
- `MONGODB_NAME` - Name of the MongoDB database

Example for `appsettings.Development.json`:
```json
{
  "MONGODB_PASSWORD": "your_password",
  "MONGODB_NAME": "your_db_name"
}
```

## Running Locally
### 1. Restore dependanceies:
```powershell
dotnet restore
```
### 2. Build and run the application
```powershell
dotnet run
```
### 3. Open your browser at: http://localhost:5010

## Using Docker
### Build and run the container

```powershell
docker build -t mssp_application .
docker run -p 5010:5010 -e MONGODB_PASSWORD=your_password -e MONGODB_NAME=your_db_name mssp_application
```

# MongoDB Integration

The app connects to MongoDB using the `MongoConnection` service. Activities are loaded from the `Activities` collection and displayed in the UI.

# Customization
-  Update content and images in the `Components/Pages` and `wwwroot/images` folders.
-  Modify styles in wwwroot/app.css or component-specific CSS files.

# License
The project is licensed under the MIT License.

