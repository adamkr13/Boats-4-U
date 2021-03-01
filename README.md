# Boats-4-U

Boats-4-U is an ASP.NET Web Application (.NET Framework) in the C# programming language.
The purpose of this application is to create a platform in which would-be boat enthusiasts can safely connect with boat owners/operators for the purpose of water recreation.

## Description

This app enables the creation, management, and deletion of: boat driver profiles, boat renter profiles, and boat reservations.

More specifically, boat drivers can create, update, and delete a profile that includes:
- the driver's name
- the hourly rental rate
- the body of water the boat travels
- the type of boat
- the days of the week the driver is available
- the maximum capacity of the boat

Renters can create, update and delete a profile that includes:
- the renter's name
- the renter's date of birth
- the credit card number

In order to assist in making reseervations, renters can also view boat drivers filtered by:
- day of the week available
- boat type
- maximum occupants
- lake/river location

Renters can create, update, and delete reservations. Drivers may view reservations that involve them. Reservations include:
- The renter name
- The driver name
- The date the reservation is for
- The duration of the reservation
- The number of passengers
- A note containing details about the reservation
- The last 4 digits of the renter's credit card number
- The estimated total cost of the reservation

## Installations

This app was optimized for running with Visual Studio Community 2019 Version 16.8.5

Instructions for downloading and installing it are [here.](https://visualstudio.microsoft.com/vs/community/)
Microsoft .NET Framework Version 4.8 was used

A web browser (Chrome, Edge, Firefox, etc) is required.

Information is entered and viewed with Postman.
Resources for installing and using Postman are [here.](https://www.postman.com/)

Download the Boats-4-U repository from GitHub [here.](https://github.com/adamkr13/Boats-4-U.git)

Load the file Boats-4-U.sln by opening it in Visual Studio Community or by double clicking it in Windows Explorer.

### Requirements

The following Nuget packages may need to be loaded/updated for Visual Studio:
- Microsoft.AspNet.Identity.EntityFramework by Microsoft, Version: 2.2.3
- Microsoft.AspNet.Identity.Owin by Microsoft, Version: 2.2.3
- Microsoft.AspNet.WebApi.Owin by Microsoft, Version 5.2.7

## Usage

### Initial Setup

- Open the Boats-4-U solution in Visual Studio and run the program by pressing the icon in the image

![Run the program](/images/RunSolution.jpg)
