# C# Tasks

This repository contains multiple C# tasks, each with its own folder and .sln file. The tasks are developed using Visual Studio Code (VSCode) and compiled on Ubuntu 14.04 LTS using dotnet.

## Requirements

- Visual Studio Code: The tasks are designed to be edited and developed in VSCode.
- Ubuntu 14.04 LTS: The projects are compiled on this operating system using dotnet.
- README.md: Each task folder should include a README.md file at the root of the folder.

## Project Structure

Each task is organized in its own folder, which contains the necessary files for that task. The default C# files named Program.cs should be renamed to the name given in each task. Please ensure that the task names on the folders are correct when pushing them to your GitHub repository.

## Testing

For testing purposes, the tasks require the utilization of unit tests. Unit testing is done using NUnit framework. NUnit allows you to create and run tests effectively.

### Unit Testing Benefits

Unit testing provides several benefits, including:
- Ensuring the correctness of your code and reducing bugs.
- Facilitating code maintenance and refactoring.
- Enhancing code quality and readability.
- Enabling faster development cycles and continuous integration.

### Test Naming and Methodology

To write effective unit tests, consider the following guidelines:
- Utilize the Arrange, Act, Assert (AAA) methodology to structure your tests.
- Properly name your unit tests to describe the scenario being tested and the expected outcome.
- Follow XML documentation tags for public classes and their members.
- Document private classes and members without XML documentation tags.

### Test-Driven Development (TDD)

Consider adopting the Test-Driven Development (TDD) approach, where tests are written before the actual code implementation. TDD can help drive your development process and ensure code quality.

### Considering Edge Cases

When creating unit tests, it's essential to consider edge cases, which are scenarios that involve unusual or extreme inputs. Testing these edge cases helps uncover potential issues and ensures the robustness of your code.

Please refer to the individual task folders for specific instructions and details on each task.

