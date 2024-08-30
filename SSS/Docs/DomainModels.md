# User Domain Model

## Overview

The `User` domain model represents an individual user in the system. It encapsulates user-related information and behaviors within the application. This model is a crucial part of the authentication and authorization mechanisms.

## Properties

| Property Name      | Type             | Description                                         | Constraints                       |
|--------------------|------------------|-----------------------------------------------------|-----------------------------------|
| `Id`               | `Guid`           | Unique identifier for the user.                     | Primary Key                       |
| `Username`         | `string`         | Unique username chosen by the user.                 | Required, Unique                  |
| `Email`            | `string`         | User's email address.                               | Required, Unique                  |
| `PasswordHash`     | `string`         | Hashed password for user authentication.            | Required                          |
| `FirstName`        | `string`         | User's first name.                                 | Required                          |
| `LastName`         | `string`         | User's last name.                                  | Required                          |
| `CreatedAt`        | `DateTime`       | Date and time when the user was created.           | Required                          |
| `UpdatedAt`        | `DateTime`       | Date and time when the user's details were updated. | Required                          |
| `IsActive`         | `bool`           | Indicates if the user account is active.            | Default: true                     |
| `Role`             | `string`         | Role of the user in the system (e.g., Admin, User). | Required                          |

## Relationships

- **Roles**: A user can have one or more roles assigned for access control.
- **Tokens**: A user can have multiple authentication tokens for sessions.

## Methods

### 1. `GeneratePasswordHash(string password)`

- **Description**: Generates a hashed password from the provided plain text password.
- **Parameters**:
  - `password`: The plain text password to hash.
- **Returns**: A hashed string representing the password.

### 2. `ValidatePassword(string password)`

- **Description**: Validates the provided plain text password against the stored password hash.
- **Parameters**:
  - `password`: The plain text password to validate.
- **Returns**: `bool` indicating whether the password is valid.

## Validation Rules

- **Username**: Must be between 3 and 20 characters.
- **Email**: Must be in a valid email format.
- **Password**: Must contain at least 8 characters, including uppercase, lowercase, numbers, and special characters.

## Usage

### Example

```csharp
// Create a new user
var user = new User
{
    Id = Guid.NewGuid(),
    Username = "johndoe",
    Email = "johndoe@example.com",
    PasswordHash = GeneratePasswordHash("SecureP@ssw0rd"),
    FirstName = "John",
    LastName = "Doe",
    CreatedAt = DateTime.UtcNow,
    UpdatedAt = DateTime.UtcNow,
    IsActive = true,
    Role = "User"
};