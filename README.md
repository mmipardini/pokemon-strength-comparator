# WTSP - Pokemon Strength Comparison
**WTSP (*Who's The Strongest Pokemon*)** is a simple application that compares the strength of two Pokemons based on their **HP** (_Hit Points_) using data from the [PokéAPI](https://pokeapi.co).

# Technologies used
## Front-end
- **React**: For building the user interface.
- **JavaScript**: For application logic.
- **CSS**: For styling the components, with Bootstrap for layout.
- **HTML**: For structuring the web pages.
## Back-end
- **.NET 6**: The framework used to build the API.
- **C#**: The language for the backend development.
- **HttpClient**: To fetch data from the PokéAPI.
- **XUnit & Moq**: For unit testing and mocking dependencies.
# Installation
1. **Clone the repository:**
``` bash
git clone https://github.com/mmipardini/pokemon-strength-comparator
```
2. **Install dependencies:** Make sure you have .NET 6 SDK and Node.js 18 installed.
   - Restore back-end dependencies by running the following command:
     ``` bash
     dotnet restore
     ```
   - For the front-end dependencies, use this command:
     ``` bash
     npm install
     ```
3. **Build and run the application:**
  - Back-end:
    ``` bash
    dotnet build
    dotnet run
    ```
  - Front-end:
    ``` bash
    npm start
    ```
# Usage
Once the application is up and running, a Swagger UI page will open for the backend endpoints at (https://localhost:7205/swagger/index.html). Additionally, the frontend will launch at ([localhost](http://localhost:3000/)). 
The user interface features two dropdown selectors that allow you to choose a Pokemon from a list of names, along with a 'Compare' button. An example of the interface is shown in the image below:
![image](https://github.com/user-attachments/assets/d393c663-2a03-449b-ae0d-8d832dd4e05f)
# Tests
The backend includes unit tests to ensure functionality and reliability. To execute these tests, simply run the following command:
``` bash
dotnet test
```
# Conclusion
Thanks for checking out this application! Even though it's super simple, it was also very fun to develop. :) 
