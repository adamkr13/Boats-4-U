# Boats-4-U

Boats-4-U is an ASP.NET Web Application (.NET Framework) in the C# programming language.
The purpose of this application is to create a platform in which would-be boat enthusiasts can safely connect with boat owners/operators for the purpose of water recreation.

## Description

This app enables the creation, management, and deletion of: boat driver profiles, boat renter profiles, and boat reservations.

More specifically, boat drivers can create, update, and delete a profile that includes:
- the driver's name
- the hourly rental rate
- the body of water the boat travels (location)
- the type of boat
- the days of the week the driver is available
- the maximum capacity of the boat

Renters can create, update, and delete a profile that includes:
- the renter's name
- the renter's date of birth
- the credit card number

In order to assist in making reservations, renters can also view boat drivers filtered by:
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

- This should open your browser.
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

- In Postman, replace the previous information in the address bar and table with the information in the picture below.
- Key info is grant_type, username, and password. Uncheck any other fields in the body.
- Make sure to use the same username and password as previously

![Register Token](/Images/RegisterToken.jpg)

- Click on the __Headers__ tab, make sure __Content Type__ is checked, and press __Send__.

![Token Headers](/Images/RegisterTokenHeaders.jpg)

- You should get a reponse with a token, as seen below.
- Copy the token (the characters inside the quotation marks) and save the Postman Request.
- The token will be used as the user login information.

![Token Response](/Images/TokenResponse.jpg)

- In Postman, click on the + to create a new request.

![New Request](/Images/PostmanNewRequest.jpg)

- In Header, add a Key for __Authorization__.
- For the Value, add Bearer followed by a space.
- Paste the copied token after the space.
- Send the request.

![Postman Authorization](/Images/PostmanAuthorization.jpg)

- You are now registered. Repeat these steps each time you are creating a new user account.

### Adding a Driver

After the program is running, and you have created a user account, the following steps may be used to create a driver
  - In Postman, ensure the token is entered, then click on the body.
  - The following may be discerned by examining the API documentation in the browser.
  - Enter the request URL and the Key and Value information for the following as in the image.
  - Make sure that **POST** is selected
  - For DaysAvailable, enter numbers for days of the week separated by commas where
    - Sunday = 1, Monday = 2, Tuesday = 4, Wednesday = 8, Thursday = 16, Friday = 32, and Saturday = 64.
  - For TypeOfBoat, use the following:
    - FishingBoat = 1, HouseBoat = 2, PontoonBoat = 3, SailBoat = 4, SpeedBoat = 5.
 
![Create Driver](/Images/CreateDriver.jpg)
 
### Adding a Renter
 
- The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Key and Value information for the following as in the image
  - Make sure that **POST** is selected  
  - For DateOfBirth, the format should be: YYYY-MM-DD
  - CreditCardNumber must be 16 digits    
 
![Create Renter](/Images/CreateRenter.jpg)
 
### Getting a list of all Drivers
 
Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/
 
![Get Drivers](/Images/GetAllDrivers.jpg)

### Getting a list of Drivers by Boat Type

Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/GetByBoatType/1
For TypeOfBoat (the number at the end), use the following:

- FishingBoat = 1, HouseBoat = 2, PontoonBoat = 3, SailBoat = 4, SpeedBoat = 5.

![Get Drivers By Boat Type](/Images/GetDriversByBoatType.jpg)

### Getting a list of Drivers by Occupancy

Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/GetByOccupancy/24
This returns all drivers with a maximum occupancy at least as high as the number entered

![Get Drivers By Occupancy](/Images/GetDriversByOccupancy.jpg)

### Getting a list of Drivers by Location

It may be useful to get a list of all drivers to see what locations are available before using this.
Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/GetByLocation/location

- Where: location is the text of the location you'd like to go

![Get Drivers By Location](/Images/GetDriversByLocation.jpg)

### Getting a list of Drivers by Day of the Week

Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/GetByDaysOfWeek/dayOfWeek

- Where: dayOfWeek is an integer with Sunday = 1, Monday = 2, Tuesday = 4, Wednesday = 8, Thursday = 16, Friday = 32, and Saturday = 64.

![Get Drivers By Day of the Week](/Images/GetDriversByDayOfWeek.jpg)

### Get a Driver by ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/ID

- Where ID is the integer ID of the desired Driver.

![Get Driver By ID](/Images/GetDriverByID.JPG)

### Getting a list of all Renters
 
Send the **Get** request in Postman for the URL https://localhost:44327/api/Renter/
 
![Get a list of all Renters](/Images/GetAllRenters.JPG)

### Get a Renter by ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/Renter/ID

- Where ID is the integer ID of the desired Renter.

![Get Renter By ID](/Images/GetRenterByID.JPG)

### Creating a Reservation

- In Postman, ensure the token is entered, then click on the body.
  - The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Key and Value information for the following as in the image
  - Make sure that **POST** is selected
  - Enter the DateReservedFor as YYYY-MM-DD
  - Enter the ReservationDuration in hours
  - ReservationDetails is a field to enter whatever text one wants to use to describe the reservation
  
![Create Reservation](/Images/CreateReservation.jpg)

### Creating a Driver Rating

- In Postman, ensure the token is entered, then click on the body.
  - The following may be discerned by examining the API documentation in the browser.
  - Enter the request URL and the Key and Value information for the following as in the image
  - Make sure that **POST** is selected.
  - For DriverCleanlinessScore, DriverSafetyScore, and DriverFunScore; enter numbers 0.0 through 10.0.

![Create Driver Rating](/Images/CreateDriverRating.jpg)

### Creating a Renter Rating

- In Postman, ensure the token is entered, then click on the body.
  - The following may be discerned by examining the API documentation in the browser.
  - Enter the request URL and the Key and Value information for the following as in the image
  - Make sure that **POST** is selected.
  - For RenterCleanlinessScore, RenterSafetyScore, and RenterPunctualityScore; enter numbers 0.0 through 10.0.

![Create Renter Rating](/Images/EditRenterRating.JPG)

### Getting a list of all Drivers
 
Send the **Get** request in Postman for the URL https://localhost:44327/api/Driver/

![Get a list of all Drivers](/Images/GetAllDrivers.jpg)

### Get a Reservation by ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/Reservation/ID

- Where ID is the integer ID of the desired Reservation.

![Get Reservation By ID](/Images/GetResByID.JPG)

### Get a Driver Rating by ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/DriverRating/ID

- Where ID is the integer ID of the desired Driver Rating.

![Get Driver Rating By ID](/Images/GetDriverByRating.JPG)

### Get a Renter Rating by ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/RenterRating/ID

- Where ID is the integer ID of the desired Driver Rating.

![Get Renter Rating By ID](/Images/GetRenterRating.JPG)

### Get a Reservation by Driver ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/Reservation/GetByDriverId/ID

- Where ID is the integer ID of the desired Driver.

![Get Reservation By Driver ID](/Images/GetResByDriver.JPG)

### Get a Reservation by Renter ID

Send the **Get** request in Postman for the URL https://localhost:44327/api/Reservation/GetByRenterId/ID

- Where ID is the integer ID of the desired Driver.

![Get Reservation By Renter ID](/Images/GetResbyRenter.JPG)

### Get a Reservation by Date

Send the **Get** request in Postman for the URL https://localhost:44327/api/Reservation/GetByDate/ID

- Where ID is the integer ID of the desired Driver.

![Get Reservation By Date](/Images/GetResByDate.JPG)

### Editing a Driver

- In Postman, ensure the token is entered and **PUT** is selected, then click on the body.
  - The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Updated Key and Value information for the following as in the image
  
![Update Driver](/Images/UpdateDriver.jpg)

### Editing a Renter

- In Postman, ensure the token is entered and **PUT** is selected, then click on the body.
  - The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Updated Key and Value information for the following as in the image
  - For DateOfBirth, the format should be: YYYY-MM-DD
  - CreditCardNumber must be 16 digits
  
![Update Renter](/Images/UpdateRenter.jpg)

### Editing a Reservation

- In Postman, ensure the token is entered and **PUT** is selected, then click on the body.
  - The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Key and Value information for the following as in the image
  - Enter the DateReservedFor as YYYY-MM-DD
  - Enter the ReservationDuration in hours
  - ReservationDetails is a field to enter whatever text one wants to use to describe the reservation
  
![Update Reservation](/Images/UpdateReservation.jpg)

### Editing a Driver Rating

- In Postman, ensure the token is entered and **PUT** is selected, then click on the body.
  - The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Updated Key and Value information for the following as in the image
  - Enter the DriverFunScore, DriverSafetyScore, and DriverCleanlinessScore as a number from 0.0 through 10.0

![Update Driver Rating](/Images/EditDriverRating.jpg)

### Editing a Renter Rating

- In Postman, ensure the token is entered and **PUT** is selected, then click on the body.
  - The following may be discerned by examining the API documentation in the browser
  - Enter the request URL and the Updated Key and Value information for the following as in the image
  - Enter the RenterCleanlinessScore, RenterSafetyScore, and RenterPunctualityScore as a number from 0.0 through 10.0

![Update Renter Rating](/Images/EditRenterRating.JPG)

### Deleting a Driver

Send the **Delete** request in Postman for the URL https://localhost:44327/api/Driver/id

- Where id is the Driver Id

![Delete Driver](/Images/DeleteDriver.jpg)

### Deleting a Renter

Send the **Delete** request in Postman for the URL https://localhost:44327/api/Renter/id

- Where id is the Renter Id

![Delete Renter](/Images/DeleteRenter.jpg)

### Deleting a Reservation

Send the **Delete** request in Postman for the URL https://localhost:44327/api/Reservation/id

- Where id is the Reservation Id

![Delete Driver](/Images/DeleteReservation.jpg)

### Deleting a Driver Rating

Send the **Delete** request in Postman for the URL https://localhost:44327/api/DriverRating/id

- Where id is the Driver Rating Id

![Delete Driver Rating](/Images/DeleteDriverRating.jpg)

### Deleting a Renter Rating

Send the **Delete** request in Postman for the URL https://localhost:44327/api/RenterRating/id

- Where id is the Renter Rating Id

![Delete Renter Rating](/Images/DeleteRenterRating.jpg)


## Resources

- General resources for creation of this README file are:
  - [Make a README](https://www.makeareadme.com/)
  - [Basic Syntax | Markdown Guide](https://www.markdownguide.org/basic-syntax/)
- This project was modeled after the Eleven-Fifty Academy Blue Badge tutorial for Eleven Note
  - [Eleven Note Tutorial](https://elevenfifty.instructure.com/courses/517/pages/eleven-note-0-dot-00-introduction?module_item_id=35656)
  - The information in Eleven Note was also used to help create this README.
- Resources for implementing Day of the Week Availability for Drivers
  - [Enum.HasFlag(Enum) Method](https://docs.microsoft.com/en-us/dotnet/api/system.enum.hasflag?view=net-5.0)
  - [Enum, Flags, and Bitwise Operators](https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/)
  - [C# Json.NET Render Flags Enum as String Array](https://stackoverflow.com/questions/43143175/c-sharp-json-net-render-flags-enum-as-string-array)
  - [How do you pass multiple enum values in C#?](https://stackoverflow.com/questions/1030090/how-do-you-pass-multiple-enum-values-in-c)
