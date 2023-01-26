# TechTest
Web API for the program that plays Rock, Paper, Scissors against a human.

<a name="readme-top"></a>

<!-- TABLE OF CONTENTS -->

# 📗 Table of Contents

- [📖 About the Project](#about-project)
  - [🛠 Built With](#built-with)
    - [Tech Stack](#tech-stack)
    - [Key Features](#key-features)
- [💻 Getting Started](#getting-started)
  - [Setup](#setup)
  - [Prerequisites](#prerequisites)
  - [Install](#install)
  - [Usage](#usage)
- [👥 Authors](#authors)
- [⭐️ Show your support](#support)
- [❓ FAQ (OPTIONAL)](#faq)
- [📝 License](#license)

<!-- PROJECT DESCRIPTION -->

# 📖 AdvancedWebAPI <a name="about-project"></a>

**TechTest** is a .NET Solution that uses a layer architecture to expose a minimal Web API 
for the program that plays Rock, Paper, Scissors against a human..

# Web API Service Images:

## 🛠 Built With <a name="built-with"></a>

### Tech Stack <a name="tech-stack"></a>

.NET Core Minimal API, 

<details>
  <summary>Server</summary>
  <ul>
    <li><a href="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis">Minimal API</a></li>
  </ul>
</details>

<details>
<summary>Database</summary>
  <ul>
    <li><a href="https://www.microsoft.com/en-US/download/details.aspx?id=101064">SQL Server</a></li>
  </ul>
</details>

<!-- Features -->

### Key Features <a name="key-features"></a>

> Describe between 1-3 key features of the application.

- **EF Core Database First**
- **Unit of Work and Repository Pattern**
- **Services Dependency Injection**
- **Data Annotations**
- **Extension Methods**
- **Dependency Injection**
- **GIT Flow**

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## 💻 Getting Started <a name="getting-started"></a>

To get a local copy up and running, follow these steps:

### Prerequisites

In order to run this project you need:

- Visual Studio .NET 2022 updated to use NET Core 7
- SQL Server Database 

### Setup

1. Clone this repository to your desired folder:

```
  cd my-folder
  git clone https://github.com/NeckerFree/TechTest
```

2. Run next commands to generate the database from TT.DataAccess project:
```
   dotnet ef migrations add InitialCreate 
   dotnet ef database update
```

3. Create a User as db_owner of this batabase

4. Modify the connection string (GamesConnection) in the file \TT.MinApi\appsettings.json to point your database
### Install

Install this project with:
1. Build the solution and assure that doesn't have errors

2. Set the project TT.MinApi as default 

### Usage

To run the project, 

Start the application (F5), the /swagger/index.html page is displayed

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- AUTHORS -->

## 👥 Authors <a name="authors"></a>

👤 **Elio Cortés**

- GitHub: [@NeckerFree](https://github.com/NeckerFree)
- Twitter: [@ElioCortesM](https://twitter.com/ElioCortesM)
- LinkedIn: [elionelsoncortes](https://www.linkedin.com/in/elionelsoncortes/)


<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## 🤝 Contributing <a name="contributing"></a>

Contributions, issues, and feature requests are welcome!

Feel free to check the [issues page](../../issues/).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- SUPPORT -->

## ⭐️ Show your support <a name="support"></a>

If you like this project please start my project

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- FAQ (optional) -->

## ❓ FAQ (OPTIONAL) <a name="faq"></a>

- **What command are required to Scaffold from Scratch a DB First?**

  - Run next commands:
  ```
    dotnet add TT.DataAccess package Microsoft.EntityFrameworkCore.Design
    dotnet add TT.DataAccess package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add TT.DataAccess package Microsoft.EntityFrameworkCore.Tools
    dotnet tool update --global dotnet-ef
    dotnet ef dbcontext scaffold "Data Source=localhost\ELIO_SQL;Initial Catalog=[your DB]; User Id=[your User];Password=[your Pwd];Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer --project TT.DataAccess --output-dir "TT.Models\Models" --context-dir "TT.DataAccess\Data" --namespace TT.Models --context-namespace TT.DataAccess --context GamesContext -f --no-onconfiguring --data-annotations
    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef 
  ```
- **How to Implement Unit Of Work and Generic Repository pattern?**
   - [Unit Of Work And Generic Repository pattern](https://www.c-sharpcorner.com/article/implement-unit-of-work-and-generic-repository-pattern-in-a-web-api-net-core-pro)
   - [Repository Pattern and Unit of Work](https://enlear.academy/repository-pattern-and-unit-of-work-with-asp-net-core-web-api-6802e1aa4f78)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->

## 📝 License <a name="license"></a>

This project is [MIT](./LICENSE) licensed.

[MIT license](https://choosealicense.com/licenses/mit/) 

<p align="right">(<a href="#readme-top">back to top</a>)</p>
