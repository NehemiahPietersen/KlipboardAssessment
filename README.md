# KlipboardAssessment

## Customer Manager
A simple and efficient desktop application built with C# and Windows Forms for managing customer information and their related transactions. It uses a local database for reliable, offline data storage.

**NOTE: The file has been published to the "PublishFolder" of the Project**

## Features
1. Customer Management: Add, view, edit, and delete customer records.

2. Transaction Tracking: Record financial transactions linked to specific customers.

3. Offline-First Design: Uses a local SQL Server Database (LocalDB) for full functionality without an internet connection.

4. Easy Installation: Deployed via ClickOnce for simple installation and seamless updates.

5. Automatic Setup: The application automatically creates the necessary database and tables on the first run.

## Installation & Setup
This application is installed using ClickOnce technology.

Download & Run: Download and run the CustomerManager.application setup file from the provided location (e.g., a network share or website).

Follow the Prompts: The ClickOnce installer will guide you through the process. It will create a shortcut on your desktop and in your Start Menu.

First Launch: Upon first launch, the application will automatically create the LocalDB database file in your user directory. Please allow a moment for this setup to complete.

Note: Your system must have the .NET Desktop Runtime (appropriate version, e.g., .NET 6.0, 7.0, or 8.0) installed. The installer will typically prompt you to download this if it's missing.

## How to Use
Launch the Customer Manager from your Start Menu or desktop shortcut.

- Add a Customer: Click "New Customer" or similar, fill in the details (e.g., Name and Account), and save.

- Add a Transaction: Select a customer from the list and click "Add Transaction". Enter the transaction details (e.g., Date, Amount, Transaction Type) and save.

- View Data: Use the main window to browse your customer list. Select a customer to view their detailed information and transaction history.

- Data Storage
Your data is stored securely on your local machine in a Microsoft SQL Server LocalDB database file. The file is typically located in your user application data folder (e.g., C:\Users\[YourUsername]\AppData\Local\CustomerManager).

The automatic setup feature ensures you never have to manually configure the database.

## Known Issues & Notes
UI Alignment: I apologize for any user interface elements that may appear slightly off or misaligned. This is a known minor issue under review for a future update and does not impact the core functionality of the application.

This application is designed for and tested on Windows operating systems.

Troubleshooting
Application Won't Start: Ensure you have the correct .NET Desktop Runtime installed.

License
This application is provided as-is for internal/business use.

## Developer Information
### Built with:

C#

Windows Forms (WinForms)

.NET Framework / .NET

SQL Server LocalDB

ClickOnce Deployment Technology
