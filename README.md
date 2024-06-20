![View submission](https://github.com/Jainharshit09/-desktop-app/assets/114314853/e3806b4d-6c40-40cb-9745-b7fee59de71d)# Desktop Form Application

This repository contains the frontend implementation of a desktop form application built for Slidely Task 2.

## Description

This desktop application allows users to create new submissions and view existing submissions. It communicates with a backend API to store and retrieve data.

## Features

- Create new submissions with fields for Name, Email, Phone Number, GitHub Link, and Stopwatch Time.
- View existing submissions with navigation controls (Previous and Next).
- Start and stop a stopwatch to track time.

## Technologies Used

- Visual Basic .NET (WinForms) for the frontend application.
- Newtonsoft.Json for JSON serialization.
- HttpClient for API communication.

## How to Use

### Prerequisites

- Windows operating system (the application is built for Windows).
- Visual Studio with Visual Basic .NET support.

### Installation

1. **Clone the Repository**
   - Open your command line interface.
   - Navigate to the directory where you want to clone the repository.
   - Run the following command:
     ```bash
     git clone https://github.com/Jainharshit09/-desktop-app.git
     ```
   - Navigate into the cloned repository:
     ```bash
     cd -desktop-app
     ```

2. **Open the Solution in Visual Studio**
   - Open Visual Studio.
   - Click on `File` -> `Open` -> `Project/Solution`.
   - Navigate to the cloned directory and select `CreateSubmissionForm.sln`.

### Configuration

1. Ensure your backend API (specified in the `SubmitToBackend` method) is running and accessible.
2. Modify the endpoint URL in `SubmitToBackend` if necessary.

### Running the Application

1. **Build the Solution**
   - In Visual Studio, click on `Build` -> `Build Solution`.

2. **Start the Application**
   - Press `F5` or click on `Debug` -> `Start Debugging`.

### Usage

- **Create New Submission**: Fill out the form fields and click the "Submit" button or use Ctrl + S shortcut.
- **View Submissions**: Navigate through existing submissions using Ctrl + P (Previous) and Ctrl + N (Next).
- **Stopwatch**: Click "Start/Stop" to toggle the stopwatch.

### Backend Setup

To fully use this application, you need to set up the backend API. Follow the instructions in the [backend repository](https://github.com/Jainharshit09/submission-backend) to clone, install, and run the backend server.

### WORKING
![slidely task2](https://github.com/Jainharshit09/-desktop-app/assets/114314853/a5c246ac-ef7a-420b-ae4f-b52414bff71c)
![View submission](https://github.com/Jainharshit09/-desktop-app/assets/114314853/12311185-1e3c-4658-a77a-a9bb6cfb2a09)
![create form](https://github.com/Jainharshit09/-desktop-app/assets/114314853/b5d9db5c-c884-4181-b9a8-4ca3307ea64c)



### Known Issues

- No known issues at this time.

## Contributing

Contributions are welcome. Please fork the repository, make changes, and submit a pull request. For major changes, please open an issue first to discuss what you would like to change.

## Acknowledgments

- Thanks to Slidely for providing the opportunity to work on this task.
