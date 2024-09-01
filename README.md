# MyAspMvc

## Overview

`MyAspMvc` is an ASP.NET MVC application designed for managing books, faculties, and orders within a library system. It provides functionalities for CRUD (Create, Read, Update, Delete) operations on books and faculties, as well as order management with image uploads.

## Features

- **Book Management**: Add, view, edit, and delete books.
- **Faculty Management**: Add, view, edit, and delete faculties.
- **Order Management**: Create, view, edit, and delete orders. Also supports image uploads and retrieval of related books and faculties.
- **AJAX Operations**: Fetch books and faculties dynamically using AJAX.

## Controllers

### BookController

- **Index**: Displays a list of all books.
- **Details**: Shows details of a specific book.
- **Create**: Allows the creation of a new book.
- **Edit**: Allows editing an existing book.
- **Delete**: Allows deleting a specific book.

### FacultyController

- **Index**: Displays a list of all faculties.
- **Details**: Shows details of a specific faculty.
- **Create**: Allows the creation of a new faculty.
- **Edit**: Allows editing an existing faculty.
- **Delete**: Allows deleting a specific faculty.

### OrderController

- **Index**: Main view for managing orders.
- **getBookFaculties**: Returns a list of faculties in JSON format.
- **getBooks**: Returns a list of books filtered by faculty ID in JSON format.
- **Save**: Saves an order and handles image upload. Returns success status in JSON format.

### OrderMasterController

- **Index**: Displays a list of all orders.
- **Details**: Shows details of a specific order.
- **OrderDetails**: Returns detailed information of order items in JSON format.
- **Create**: Allows the creation of a new order.
- **Edit**: Allows editing an existing order.
- **Delete**: Allows deleting a specific order.

## Setup

### Prerequisites

- .NET Framework 4.7.2 or later
- Visual Studio 2019 or later

### Installation

1. **Clone the Repository**

    ```bash
    git clone https://github.com/yourusername/MyAspMvc.git
    ```

2. **Open the Project**

    Open the solution file (`.sln`) in Visual Studio.

3. **Restore NuGet Packages**

    NuGet packages will be restored automatically when you build the project. If needed, you can manually restore packages via the NuGet Package Manager.

4. **Build the Project**

    ```bash
    Build > Build Solution
    ```

5. **Run the Application**

    Start the application using Visual Studio’s Debug or Run options.

## Usage

- **Books**: Manage books through the Book section. You can add, view, edit, and delete book records.
- **Faculties**: Manage faculties in the Faculty section. Create new faculties or modify existing ones.
- **Orders**: In the Order section, you can create new orders, manage existing ones, and upload images associated with orders.

## AJAX Endpoints

- `GET /Order/getBookFaculties`: Returns a list of faculties in JSON format.
- `GET /Order/getBooks?facultyId={id}`: Returns a list of books for the specified faculty ID in JSON format.
- `POST /Order/Save`: Saves an order and handles image uploads. Returns a JSON status response.

## Contributing

Contributions are welcome! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your changes to your forked repository.
5. Submit a pull request to the main repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please contact [your.email@example.com](mailto:your.email@example.com).

