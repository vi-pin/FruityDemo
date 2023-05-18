FruityDemo API
This is a simple API that provides endpoints to retrieve information about fruits.

Endpoints
Get all fruits
URL: /api/fruit
Method: GET
Description: Retrieves a list of all fruits.
Response: 200 OK, with an array of fruits in the response body.
Get fruits by family
URL: /api/fruit/family
Method: POST
Description: Retrieves a list of fruits belonging to a specific fruit family.
Request Body: JSON object with the fruitFamily property specifying the fruit family.
Response: 200 OK, with an array of matching fruits in the response body.
Usage
Clone the repository to your local machine:

bash
Copy code
git clone <[repository_url](https://github.com/vi-pin/FruityDemo)>
Open the solution in your preferred development environment (e.g., Visual Studio).

Build the solution to restore NuGet packages and compile the project.

Set the necessary configuration settings, such as the FruityVice API URL, in the appsettings.json file.

Run the application.

Send HTTP requests to the API endpoints using your preferred tool (e.g., Postman, cURL, etc.).

Dependencies
.NET Core 3.1 or later
Fruityvice API


Configuration
The following configuration settings can be modified in the appsettings.json file:

{
  "FruityViceApiUrl": "https://www.fruityvice.com/api/fruit/"
}
