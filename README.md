# Hotel Reservation System - DevOps Assignment Part 1

This repository contains the **Hotel Reservation System** web app, set up for deployment in a Docker container and configured for Azure DevOps. This web app provides an API for hotel reservation bookings, demonstrating key concepts in containerization and deployment to Kubernetes.

## Table of Contents

- [Hotel Reservation System - DevOps Assignment Part 1](#hotel-reservation-system---devops-assignment-part-1)
  - [Table of Contents](#table-of-contents)
  - [Project Overview](#project-overview)
  - [Technologies Used](#technologies-used)
  - [Setup and Installation](#setup-and-installation)
  - [Dockerization](#dockerization)
    - [Dockerfile Overview](#dockerfile-overview)
    - [Building and Running the Docker Image](#building-and-running-the-docker-image)
  - [Azure DevOps CI/CD Pipeline](#azure-devops-cicd-pipeline)
    - [Setting Up the Pipeline](#setting-up-the-pipeline)
  - [Deployment to AKS](#deployment-to-aks)
  - [Testing the Application](#testing-the-application)
- [Legal Notices](#legal-notices)

---

## Project Overview

The **Hotel Reservation System** is a sample .NET Core application that provides RESTful API endpoints to create and retrieve hotel bookings. The project is Dockerized and configured for deployment on Azure Kubernetes Service (AKS) through a CI/CD pipeline in Azure DevOps.

> **Note:** This is a sample application, and the reservations data is not persisted. The app returns dummy data for demonstration purposes.

## Technologies Used

- **.NET Core SDK**: 2.2
- **Docker**: Containerizes the application
- **Azure Kubernetes Service (AKS)**: Hosts the Dockerized application
- **Azure DevOps**: Manages CI/CD pipeline for automatic deployment
- **GitHub**: Source code management

## Setup and Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/hotel-reservation-system.git
   
   cd hotel-reservation-system/src
   ```

2.  **Install .NET Core SDK** (if not already installed)

    *   Ensure .NET Core SDK 2.2 is installed. Download it from [here](https://dotnet.microsoft.com/download).
3.  **Install Docker**

    *   Ensure Docker Desktop is running on your machine.

Dockerization
-------------

The application is containerized with a **Dockerfile** that installs the necessary dependencies, builds the application, and prepares it for deployment.

### Dockerfile Overview

*   **Base Image**: Uses .NET Core SDK 2.2
*   **Build Steps**:
    *   Restores dependencies
    *   Builds and publishes the app
    *   Exposes port 80

### Building and Running the Docker Image

1.  **Build the Docker Image**

    ```bash
    docker build -t hotelreservationsystem .
    ```

2.  **Run the Docker Container Locally**

    ```bash
    docker run -p 8080:80 -d --name reservations hotelreservationsystem
    ```

3.  **Verify the Container**

    *   Access the API endpoint in your browser: [http://localhost:8080/api/reservations/1](http://localhost:8080/api/reservations/1)

Azure DevOps CI/CD Pipeline
---------------------------

This project uses Azure DevOps for Continuous Integration and Continuous Deployment (CI/CD) with the following steps:

1.  **Build Stage**: Builds the Docker image from the Dockerfile.
2.  **Push to ACR**: Tags and pushes the Docker image to **Azure Container Registry**.
3.  **Deploy to AKS**: Deploys the Dockerized app to **Azure Kubernetes Service (AKS)**.

### Setting Up the Pipeline

*   Configure the pipeline in Azure DevOps using the **Deploy to AKS** template.
*   Ensure you have service connections set up for ACR and AKS.
*   Push any changes to the `main` branch to trigger the pipeline automatically.

Deployment to AKS
-----------------

To deploy the application to Azure Kubernetes Service:

1.  **Azure CLI or Azure DevOps**: Use the configured CI/CD pipeline to deploy the Dockerized app to AKS.
2.  **Kubernetes Manifests**:
    *   Deployment and Service YAML files are located in the `/manifests` folder for Kubernetes setup.

Testing the Application
-----------------------

After deployment, you can test the API endpoint by accessing the **External IP** of your AKS service.

1.  Retrieve the External IP:

    ```bash
    kubectl get services
    ```

2.  Access the application:

    ```plaintext
    http://<External-IP>/api/reservations/1
    ```

# Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content
in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode),
see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the
[LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation
may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries.
The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks.
Microsoft's general trademark guidelines can be found at http://go.microsoft.com/fwlink/?LinkID=254653.

Privacy information can be found at https://privacy.microsoft.com/en-us/

Microsoft and any contributors reserve all other rights, whether under their respective copyrights, patents,
or trademarks, whether by implication, estoppel or otherwise.
