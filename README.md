# ShoppingCartAPI

## Overview
ShoppingCartAPI is a simple web API for managing a shopping cart. It allows users to add items to their shopping cart and view the items in the cart using session storage to maintain state across multiple HTTP requests.

## Folder Structure
![Screenshot 2024-07-03 at 2 25 52 PM](https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/7c899536-2c72-4a8e-a7dd-93b32db8a9a6)

## Functions Added
### ShoppingCartService

- **`AddItem(ISession session, Items item)`**
  - Adds an item to the shopping cart stored in the session.

- **`ViewCart(ISession session)`**
  - Retrieves the current shopping cart from the session.

- **`Getcart(ISession session)`**
  - Helper function to get the cart from the session. Deserializes the JSON string to a list of items.

- **`Savecart(ISession session, List<Items> cart)`**
  - Helper function to save the cart to the session. Serializes the list of items to a JSON string.

### ShoppingController

- **`AddItem([FromBody] Items item)`**
  - HTTP POST endpoint to add an item to the shopping cart.
  - API Endpoint: http://localhost:5132/api/Shopping/add

- **`ViewCart()`**
  - HTTP GET endpoint to view the items in the shopping cart.
  - Api Endpoint: http://localhost:5132/api/Shopping/items
 


