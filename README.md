# Assignment: Books CRUD

## Overview

This project implements a full CRUD (Create, Read, Update, Delete) feature for the **Book** entity using ASP.NET Core MVC and Entity Framework Core (Code First approach).

Scaffolding was NOT used. All controllers and Razor views were implemented manually as required in the assignment.

---

## Book Model

The `Book` class contains the following fields:

- Id (int, primary key)
- Name (string)
- Author (string)
- PublishDate (DateTime)
- PageCount (int)
- IsSecondHand (bool)

### Validation Rules

DataAnnotations were used:

- Name: Required, min length 2, max length 200
- Author: Required, min length 2, max length 200
- PublishDate: Required
- PageCount: Required, range between 1 and 10000
- IsSecondHand: Required

Validation works server-side and client-side.

---

## Implemented Pages

### 1) List Page

Route: `/Books` or `/Books/Index`

- Displays all books in a table
- Columns:
    - Name
    - Author
    - PublishDate
    - PageCount
    - IsSecondHand
- Each row includes:
    - Edit
    - Delete

---

### 2) Create Page

Route: `/Books/Create`

- Allows adding a new book
- Displays validation errors if input is invalid
- Redirects to list page after successful creation

---

### 3) Edit Page

Route: `/Books/Edit/{id}`

- Loads existing book data into the form
- Shows validation errors
- Updates the record in the database
- Returns `NotFound()` if invalid id is provided

---

### 4) Delete Page

Route: `/Books/Delete/{id}`

- Displays a confirmation page
- Deletes the record after confirmation
- Redirects to list page
- Returns `NotFound()` if invalid id is provided

---

## Entity Framework (Code First)

- `DbSet<Book>` added to `ApplicationDbContext`
- Migrations were created and applied
- Database schema updates successfully

---

## How to Run the Project

1. Clone the repository
2. Navigate to the project folder
3. Run the following commands:
