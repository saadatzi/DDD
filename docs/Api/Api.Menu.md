# API Endpoints
### Retrieve All Menus

```js
GET /api/menus
```

Response:
```json
[
  {
    "id": "menu-12345",
    "name": "Delicious Bites Menu",
    "hostId": "host-67890",
    "dinnerIds": ["dinner-11111", "dinner-22222"],
    "menuReviewIds": ["review-33333", "review-44444"],
    "description": "A delightful selection of appetizers, main courses, desserts, and beverages.",
    "sections": [ /* sections array */ ]
  }
]
```

### Retrieve a Single Menu

```js
GET /api/menus/{menuId}
```

Response:

```json
{
  "id": "menu-12345",
  "name": "Delicious Bites Menu",
  "hostId": "host-67890",
  "dinnerIds": ["dinner-11111", "dinner-22222"],
  "menuReviewIds": ["review-33333", "review-44444"],
  "description": "A delightful selection of appetizers, main courses, desserts, and beverages.",
  "sections": [ /* sections array */ ]
}
```

```js
PUT /api/menus/{id}
```

Request:
```json
{
     "name": "Updated Menu Name",
     "hostId": "updated-hostId", 
     "dinnerIds": ["new-dinnerId"], 
     "menuReviewIds": ["new-reviewId"], 
     "description": "Updated menu description.", 
     "sections": [ /* updated sections array */ ] 
} 
```
     
Response: 
```json
{
    "message": "Menu updated successfully"
}
```

```js
DELETE /api/menus/{id}
```
(delete a menu by id) Request: 
No request body required 

Response: 
```json
{ 
    "message": "Menu deleted successfully"
}
```
