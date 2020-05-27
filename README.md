# Welcome to Blazor Outlook Calendar!

With the power of WebAssembly that lets you run C# code in the browser, Blazor Outlook Calendar comes to show you the results of that power while building Single Page Applications very smoothly and easily with .NET and C# our favorite programming language.

Blazor Outlook Calendar is a Single Page Application built with C# as a demo and a full course on my YouTube Channel 'AK Academy' you can find it here 

[Full Course on AK Academy Channel](https://www.youtube.com/watch?v=5ouXHtzKL5o&list=PLFJQnCcZXWjv89uDubYW7NniK8mEl4sWQ)

It's a Calendar and events application that is synced and integrated with Microsoft Outlook Calendar using Microsoft Graph API.
It's teaches you how to render and create a Calendar component from scratch and more

![The Main App UI for authenticated users](https://github.com/aksoftware98/BlazorOutlookCalendar/blob/master/images/1.png?raw=true)

![App UI for not authenticated users](https://github.com/aksoftware98/BlazorOutlookCalendar/blob/master/images/2.png?raw=true)

# What you will learn

 - Developing Client Side Web Apps with Blazor WebAssembly.
 - Authenticating users with Microsoft Azure Active Directory.
 - Fetching and adding data to Microsoft 365 with Microsoft Graph API.
 - Learn how to design and develop a Calendar control from scratch.
 - Learn how you manipulate the DOM in Blazor WebAssembly.
 - Design a full web page from scratch with HTML, CSS, Bootstrap and the Microsoft Design Language (Fluent UI).
 - Implement communication between Blazor Web App components.
 - Manage the states of the components within the Blazor WebAssembly app. 


## How to make this app works

 - Clone this repository locally to your machine.
 - Make sure you have the latest version of .NET Core 3.1, you can find it [here](https://dotnet.microsoft.com/download) 
 - Sign in to your Microsoft Azure account or create a new free account.
 - Go to your Azure Active Directory then AppRegistrations 
 - Click on create a new registration
 - Call the app what ever you want 
 - Set the account type to Multi-Tenant (Microsoft Personal Accoutns)
 - In the  *Redirect URI*  section: Choose Single Page Application and set the URI to https://locahost:5001/authentication/login-callback
 - Click Register
 - Copy the Application Id that appears in the overview section and paste it within the *AppSettings.json* file in the wwwroot folder inside the BlazorCalendar project.
 - Back to your Azure application go to the *Authentication* page from the left side menu within your app.
 - Go to *Implicit grant* section and check *Access Token and ID Tokens* and save the changes 
 - Go to API Permissions page from the left side menu.
 - Add Permissions then Microsoft Graph and Add *Calendars.ReadWrite* permission.
 - Go back to your project folder and open the cmd then the run the command dotnet run. 
 And ready to go.

### Enjoy the course and hope you get all the benefits within your journey in Blazor WebAssembly 
