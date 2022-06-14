# SVT Robotics - Take Home

---

This project is an implementation of the SVT Robotics Take Home Recruiting Assessment (https://github.com/SVT-Robotics/recruiting-takehome-services).

It is designed as an example of querying an existing API to get a list of robots and then given a load determine which robot is closest. If there is more than one robot within 10 units, then it returns the one with the most battery remaining.

## Technologies

---

- Visual Studio Code
- .NET Core 3.1 SDK
- RestSharp (https://restsharp.dev/)

## Installation

---

Clone the Repository from GitHub
Open the folder in Visual Studio Code
From the terminal run:

```bash
dotnet run
```

## Testing

---

Endpoints:
http://localhost:5000/api/robots/closest/
https://localhost:5001/api/robots/closest/

Include in the body of the Post the load in json format like:
{ "loadId": 231, "x": 5, "y": 3 }

If you get "Unsupported Media Type" errors, check that you are including the load in the body and that it is in JSON format.

Note: Due to the development certificates that Visual Studio Code uses by default, you may see warning messages about a self signed certificate.

## Future Enhancements

---

- Unit Testing - For expediency, I wrote my initial tests in Postman rather than integrated into this project. Full coverage integrated unit testing would be a likely enhancement before such a project would go to production.
- API Security - Most such APIs require security to control access to sensitive data. A common implementation would be a token based authentication system like OAuth 2.0. This can also be used to handle role based security as well if different types of systems or users require different levels of access to the API.
- Logging - For a test project like this, Debug.WriteLine, breakpoints, and the stock logging work well enough. But when dealing with production deployment of larger APIs, using a more searchable and structured logging system like Serilog greatly improves the observability of what's going on at the backend.
- Error Handling - This project currently uses primarily the default error handling, with .Net Core handling the standard not found and server errors. However, it could definitely use more detailed error handling in areas such as pulling the list of robots from the external API.
- Versioning - If this API is designed to be publicly available or used in an environment where it is not practical to be able to keep all of the consuming applications up to date on the latest version, then versioning support may be a good enhancement in the future. As much as developers try to plan ahead and allow for future enhancements, breaking changes are pretty inevitable in a system with ongoing development. The versioning support in .Net Core is pretty robust and gives the API consumers the ability to target a specific version of the API or always run with the latest and greatest.
- Advanced Routing - Currently the closest robot is calculated based on the "as the crow flies" distance between the load and the robot. Depending on the environment, this may be perfectly adequate or it might be a considerable limitation to the accuracy of the results of the algorithm. For example, for navigating across a relatively open area this calculation is probably fine but if there are large obstacles (like long aisles in a warehouse) or the streets and speed limits of a vehicle in the city then a more complex routing system may be needed.
