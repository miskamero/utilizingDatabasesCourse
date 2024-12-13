# Klinoff Calendar

Klinoff Accepted web application for managing events, built with ASP.NET Core and Blazor. Coding pattern used is Code-Behind.

## Table of Contents

- [Project Structure](#project-structure)
- [Information](#information)
- [Design Pattern](#design-pattern)
- [Features](#features)
- [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Setup](#setup)
    - [Usage](#usage)

## Project Structure

1. **Components** - Contains the layout and pages directories.
    - **Layout** - Contains the **MainLayout.razor** and **NavMenu.razor** files.
    - **Pages** - Contains the **AddEvent.razor, EditEvent.razor** and **EventList.razor** files.
2. **Data** - Contains the **Event** and **EventDbContext** classes.
3. **Migrations** - Contains the migration files for the database.
4. **appsettings.json** - Contains the configuration settings for the application.
5. **Program.cs** - Contains the entry point for the application.

#### [Project Files](ProjectFiles.md)

## Information

Klinoff Calendar is a web application for managing events. Users can add, edit, and delete events from the calendar. The application is built with ASP.NET Core and Blazor.
Adding events to the calendar is easy and intuitive. Users can view all the events in the calendar and edit them as needed. The application itself is a Blazor WebAssembly application. The application uses Entity Framework Core to manage the data.

Addition is done using
> Components/Pages/AddEvent.razor

Editing is done using
> Components/Pages/EditEvent.razor

Viewing, deleting and invoking editing all events is done using
> Components/Pages/EventList.razor

Filtering is done with methods found in
> Components/Pages/EventList.razor

Tools used in the project are:
- [Visual Studio](https://visualstudio.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
    - **Note:** SQL Server is configured in the appsettings.json file.

Data management is done using Entity Framework Core. The database context is defined in the EventDbContext class. The Event class defines the properties of an event.

Data model is defined at
> Data/Event.cs

Database context is defined using EFCore at
> Data/EventDbContext.cs

And it's migration files are found in the **Migrations** folder.

## Design Pattern

The application uses the code-behind pattern, where the UI logic and markup are typically separated into different files. In this application, however, both the UI logic and the UI markup are contained within the same Razor component files. This approach simplifies development by keeping related code together, making it easier to work with the UI and logic simultaneously. The Razor files define the UI layout and behavior, while the logic for handling events and interacting with the data is implemented directly within the @code section of the same file. This structure is common in Blazor applications, especially for smaller projects or when rapid development is a priority.

All in all, the approach I have utilized was chosen due to my lack of experience with Blazor, and C# in general. I wanted to keep the project as simple as possible, and I believe that the code-behind pattern with some adjustments was the best choice for this project.

## Features

Klinoff Calendar supports the following features:

1. **Adding Events** - Users can add new events to the calendar.
2. **Editing Events** - Users can edit existing events.
3. **Deleting Events** - Users can delete events from the calendar.
4. **Viewing your Events** - Users can view all the events in the calendar.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Setup

1. Clone the repository.
```bash	
git clone
cd <project-directory>
```

2. Install the required packages.
```bash
dotnet restore
```

3. Update the database.
```bash
dotnet ef database update
dotnet ef migrations add InitialCreate
```

4. Run the application.
```bash
dotnet run
```

### Usage

1. Start the application.
2. Navigate to the [Add Event](https://localhost:7047/) page.

## Built With Love Using

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

**All in one place, Using [Visual Studio](https://visualstudio.microsoft.com/)**