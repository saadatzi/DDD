
```markdown
# API Documentation

## Authentication API

This API provides endpoints for user authentication, including registration and login.

### Base URL
```
@host= http://localhost:5034
```

---

## Register User

### Endpoint
```
POST {{host}}/auth/register
```

### Request

#### Headers
- `Content-Type: application/json`

#### Body
```json
{
  "username": "string",
  "email": "string",
  "password": "string"
}
```

#### Example
```json
{
  "username": "john_doe",
  "email": "john@example.com",
  "password": "securePassword123",
  "firstname": "john",
  "lastname": "doe",
}
```

### Response

#### Success (201 Created)
```json
{
  "message": "User registered successfully.",
  "user": {
    "id": "string",
    "username": "john_doe",
    "email": "john@example.com",
    "firstname": "john",
    "lastname": "doe",
    "createdAt": "2023-08-29T12:00:00Z"
  },
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
}
```

#### Error (400 Bad Request)
```json
{
  "error": {
    "code": "USER_ALREADY_EXISTS",
    "message": "A user with this email already exists."
  }
}
```

---

## Login User

### Endpoint
```
POST {{host}}/auth/login
```

### Request

#### Headers
- `Content-Type: application/json`

#### Body
```json
{
  "email": "string",
  "password": "string"
}
```

#### Example
```json
{
  "email": "john@example.com",
  "password": "securePassword123"
}
```

### Response

#### Success (200 OK)
```json
{
  "message": "Login successful.",
  "user": {
    "id": "string",
    "username": "john_doe",
    "email": "john@example.com",
    "lastLogin": "2023-08-29T12:30:00Z"
  },
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"

}
```

#### Error (401 Unauthorized)
```json
{
  "error": {
    "code": "INVALID_CREDENTIALS",
    "message": "The provided email or password is incorrect."
  }
}
```

### Error (400 Bad Request)
```json
{
  "error": {
    "code": "MISSING_FIELDS",
    "message": "Email and password are required."
  }
}
```

---

## Notes
- Ensure that passwords are hashed before storing them in the database.
- Use HTTPS to protect user credentials during transmission.
- JWT tokens should be securely stored on the client-side.
```

### Explanation of the Document Structure

- **Base URL**: Specifies the base URL for the API.
- **Endpoints**: Each section outlines a specific endpoint for registration and login, including:
  - **HTTP Method**: The HTTP method used (e.g., POST).
  - **Request**: Details about headers and the body format.
  - **Response**: Examples of successful and error responses, including status codes and JSON structures.
- **Notes**: Additional information for implementation considerations.