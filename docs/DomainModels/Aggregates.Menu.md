# Domain Models

## Menu

```csharp
```

```json
{
  "id": "menu-12345",
  "name": "Delicious Bites Menu",
  "hostId": "host-67890",
  "dinnerIds": ["dinner-11111", "dinner-22222"],
  "menuReviewIds": ["review-33333", "review-44444"],
  "description": "A delightful selection of appetizers, main courses, desserts, and beverages.",
  "sections": [
    {
      "id": "section-appetizers",
      "name": "Appetizers",
      "description": "Start your meal with our delicious appetizers.",
      "items": [
        {
          "id": "item-garlic-bread",
          "name": "Garlic Bread",
          "description": "Toasted bread with garlic butter and herbs",
          "price": 4.99
        }, 
        {
          "id": "item-bruschetta",
          "name": "Bruschetta",
          "description": "Grilled bread topped with tomatoes, basil, and olive oil",
          "price": 5.99
        }
      ]
    },
    {
      "id": "section-main-courses",
      "name": "Main Courses",
      "description": "Satisfy your hunger with our hearty main courses.",
      "items": [
        {
          "id": "item-spaghetti-carbonara",
          "name": "Spaghetti Carbonara",
          "description": "Pasta with eggs, cheese, pancetta, and black pepper",
          "price": 12.99
        },
        {
          "id": "item-chicken-alfredo",
          "name": "Chicken Alfredo",
          "description": "Grilled chicken with creamy Alfredo sauce over fettuccine",
          "price": 14.99
        }
      ]
    },
    {
      "id": "section-desserts",
      "name": "Desserts",
      "description": "End your meal on a sweet note with our delectable desserts.",
      "items": [
        {
          "id": "item-tiramisu",
          "name": "Tiramisu",
          "description": "Classic Italian dessert with coffee-soaked ladyfingers and mascarpone cheese",
          "price": 6.99
        },
        {
          "id": "item-chocolate-fondue",
          "name": "Chocolate Fondue",
          "description": "Warm chocolate fondue with assorted fruits and marshmallows",
          "price": 8.99
        }
      ]
    },
    {
      "id": "section-beverages",
      "name": "Beverages",
      "description": "Quench your thirst with our refreshing beverages.",
      "items": [
        {
          "id": "item-coca-cola",
          "name": "Coca-Cola",
          "description": "Classic cola soda",
          "price": 2.49
        },
        {
          "id": "item-orange-juice",
          "name": "Orange Juice",
          "description": "Freshly squeezed orange juice",
          "price": 3.49
        }
      ]
    }
  ]
}
```