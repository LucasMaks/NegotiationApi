API Documentation - Price Negotiations

Introduction
This Web API is designed for price negotiations between customers and store employees in an online store.

Authorization
Client - no login required.

Store Employee - authentication required (JWT token).

Product Module

1. Get the list of products
GET /api/products

Response:
[
  {
    "id": 1,
    "name": "Laptop",
    "price": 2500.0
  }
]

2. Get product by ID
GET /api/products/{id}

Response:
{
  "id": 1,
  "name": "Laptop",
  "price": 2500.0
}

3. Add a product (requires authorization)
POST /api/products

Body:
{
  "name": "Smartphone",
  "price": 1500.0
}
Response: 201 Created

Negotiation Module
4. Submit a price proposal
POST /api/negotiations

Body:

{
  "productId": 1,
  "proposedPrice": 2200.0
}
Response:
{
  "id": 1,
  "productId": 1,
  "proposedPrice": 2200.0,
  "status": "Pending",
  "attemptCount": 1
}
5. Respond to negotiation (requires authorization)
PUT /api/negotiations/{id}

Body:
{
  "accepted": true
}
Response:
{
  "id": 1,
  "productId": 1,
  "proposedPrice": 2200.0,
  "status": "Accepted"
}
6. List negotiations for a product
GET /api/negotiations/product/{productId}

Response:
[
  {
    "id": 1,
    "productId": 1,
    "proposedPrice": 2200.0,
    "status": "Pending",
    "attemptCount": 1
  }
]

Error Codes
Code	Description
400	Invalid input data
401	Unauthorized
404	Resource not found
500	Server error
Additional Information
Maximum of 3 negotiation attempts.

A new price proposal must be submitted within 7 days.

Author: Łukasz Maksymiuk @ 2025
