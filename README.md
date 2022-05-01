# Qoniac
## Exercise: converts a currency (dollars) from numbers into words 

Assumptions and measurements have been taken before/while the implementation of the task:

- As shown in the PDF file of the task the numbers have spaces and commas in between. The expectation of this number is an output of another service in this format. Therefore the input is taken as a string by the Backend service and the validation is done accordingly. 
- One Currency which is **Dollar**.
- Max limit of dollars is (999 999 999)

## Stack

- .NET Core 3.1 for the Backend
- WPF for the Frontend

## Architectural Decisions 
###### Due to the simplicity of the task the below decision were taken:
- Not to Apply Object Orenited Modeling to modulurize the project  
- Not to use CQRS as the task is simple and to avoid over engineering . 
- Not to use dependency injection for loosly coupling the services.


###### other pro were taken:
- Develop with consideration to have high cohesive services/objects..
- use of MVVM architecture for frontend project.
- Objects and Method creation respects the reusability and maintainability aspects of good software architecture. 
- Decoupling the task logic into service and generalizing that service with an interface.
- Develop Unit testing
- Enable Swagger documentation


## Prerequisites
	- Visual Studio (recommended) or any code editor
	- Git
	-.NET Core 3.1 

 
## Installation
Clone the main project from the Github repository:

```sh
$ git clone https://github.com/CardoAI/emporium_backend.git
```
Open the SLN file and configure your solution tun multipe project at once then run

