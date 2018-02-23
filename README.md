# Hair Salon

#### C# Epicodus week 4 project, 02/23/2018

#### By **Nanette Girzi**

## Description

This application will allow employees of a hair salon see a list of stylists and see the stylists details and also a see a list of each stylists clients. New stylists will be able to be added to the system, and new clients can be added to specific stylists. Clients will be able to be updated or deleted from the system.


##MySQL Commands

- CREATE DATABASE nanette_girzi;
- USE nanette_girzi;
- CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
- CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), phone_number VARCHAR(255), stylist_id INT);


## Setup/Installation Requirements

* Clone this repository to your desktop
* Navigate to project folder on desktop
* In terminal, inside project folder, type command "dotnet resotore" "dotnet build", then "dotnet run"
* Open browser and go to http://localhost:5000

## Specifications

#### Both tables in database are empty
* Input: none
* Output : empty

#### Allow user to enter a new stylist
* Input: "Sue Smith"
* Output : "Sue Smith" is added on list and populated in database

#### User will click on stylist Name and see stylists details
* Input: click on stylists name
* Output : Stylist info(Name) and  list of clients(Name, Phone Number) are shown

#### User is able to add new clients to specific stylists
* Input: click on Add Client button
* Output : Client (Name, Phone Number) is added to Stylist list page

#### User is able to update Clients name or phone number
* Input: click edit button next to client name.
* Output : client information is changed and updated to database

#### User can delete  ALL clients
* Input: click on delete all clients button
* Output : all clients are deleted from a specific stylist list and database

#### User can delete  ALL stylists
* Input: click on delete all stylists button
* Output : all stylists are deleted from a specific stylist list and database


## Known Bugs

No known bugs at this time.

## Support and contact details

If you have suggestions please email ngirzi@gmail.com

## Technologies Used

* C#
* HTML
* CSS
* Bootstrap
* MVC  
* Razor

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **Nanette Girzi**
