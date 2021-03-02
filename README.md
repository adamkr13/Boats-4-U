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

### Initial Setup and Account Setup

- Open the Boats-4-U solution in Visual Studio and run the program by pressing the icon in the image

![Run the program](/Images/RunSolution.jpg)

- This should ope your browser.
- Copy the URL _https://localhost:XXXXX_
- Open Postman
- Paste the URL into the address bar of Postman and make sure the HTTP drop-down is set to __POST__
- In the browser, click on API to check the documentation.

![API Click](/Images/APIDocumentationLink.jpg)

- Under Account you should see a Register endpoint. Click on it.

![Register Browser](/Images/RegisterBrowser.jpg)

- Go to Postman and paste the Register address into the address bar.
- Select body and x-www-form-urlencoded and enter the key information as in the image.
- Enter your email and password information.
- Make sure it is set to POST and send the request. You should get a 200 Ok Response.

![Register Postman](/Images/RegisterResponse.jpg)

- In Postman, replace the previous information in the address bar and table.with the information in the picture below.
- Key info is grant_type, username, and password. Uncheck any other fields in the body.
- Make sure to use the same username and password as previously

![Register Token](/Images/RegisterToken.jpg)

- Click on the __Headers__ tab, make sure __Content Type__ is checked, and press __Send__.

![Token Headers](/Images/RegisterTokenHeaders.jpg)

- You should get a reponse with a token.
- Copy the token (the characters inside the quotation marks) and save the Postman Request.
- The token will be used as the user login information.

![Token Response](/Images/TokenResponse.jpg)

- In Postman, click on the + to create a new request.

![New Request](/Images/PostmanNewRequest.jpg)

- In Header, add a Key for __Authorization__.
- For the Value, add Bearer followed by a space
- Paste the copied token after the space.

![Postman Authorization](/Images/PostmanAuthorization.jpg)

- You are now registered. Repeat these steps each time you are creating a new user account.

### Adding a Driver

After the program is running, and you have created a user account, the following steps may be used to create a driver
  - In Postman, ensure the token is entered, then click on the body.
  - The following may be discerned by examining the API documantation in the browser
  - Enter the request URL and the Key and Value information for the following as in the image
  - For DaysAvailable, enter numbers for days of the week separated by commas where
    - Sunday = 1, Monday = 2, Tuesday = 4, Wednesday = 8, Thursday = 16, Friday = 32, and Saturday = 64.
  - For TypeOfBoat, use the following:
    - FishingBoat = 1, HouseBoat = 2, PontoonBoat = 3, SailBoat = 4, SpeedBoat = 5.
 
![Create Driver](/Images/CreateDriver.jpg)
 
### Adding a Renter
 
- The following may be discerned by examining the API documantation in the browser
  - Enter the request URL and the Key and Value information for the following as in the image  
  - For DateOfBirth, the format should be: YYYY-MM-DD
  - CreditCardNumber should be 16 digits    
 
![Create Renter](/Images/CreateDriver.jpg)
 
### Getting a list of all Drivers
 
Send the Get request in Postman for the  URL https://localhost:44327/api/Driver/
 
![Get Drivers](/Images/GetAllDrivers.jpg)


## Resources

- General resources for creation of this README file are:
  - [Make a README](https://www.makeareadme.com/)
  - [Basic Syntax | Markdown Guide](https://www.markdownguide.org/basic-syntax/)
- This project was modeled after the Eleven-Fifty Academy Blue Badge tutorial Eleven Note
  - [Eleven Note Tutorial](https://elevenfifty.instructure.com/courses/517/pages/eleven-note-0-dot-00-introduction?module_item_id=35656)
  - The information in Eleven Note was also used to help create this README.
- Resources for implementing Day of the Week Availability for Drivers
  - [Enum, Flags, and Bitwise Operators](https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/)
  - [C# Json.NET Render Flags Enum as String Array](https://stackoverflow.com/questions/43143175/c-sharp-json-net-render-flags-enum-as-string-array)
  - [How do you pass multiple enum values in C#?](https://stackoverflow.com/questions/1030090/how-do-you-pass-multiple-enum-values-in-c)
