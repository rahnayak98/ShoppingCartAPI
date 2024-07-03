# ShoppingCartAPI

## Overview
ShoppingCartAPI is a web API for managing a shopping cart. It allows users to add items to their shopping cart and view the items in the cart using session storage to maintain state across multiple HTTP requests.

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

 
## Testing 
- The testing was done using Postman HTTP client that was consuming the service.
  Once the application is built we get the locol host port on which it is hosted
![Screenshot 2024-07-03 at 4 09 23 PM](https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/e3016548-1588-4ea6-b072-e62800e3ff83)

- **`Tests Implemented`**
  - Initial Get all items(Returns a empty list) indicating empty cart
    <img width="1241" alt="Screenshot 2024-07-03 at 4 13 18 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/6bbf1517-71da-49c1-91ad-d66b0af3e17a">
  - Added a Apple to the cart.
<img width="1217" alt="Screenshot 2024-07-03 at 4 37 02 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/6ff530d0-e5e4-4b40-9772-b54f9c5b986a">
  - Added a Orange to the cart.
    <img width="1246" alt="Screenshot 2024-07-03 at 4 15 34 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/5339408c-067e-4f70-85c9-89d65d382eed">
  - Viewed the items in the cart after adding Apple and orange.
<img width="1261" alt="Screenshot 2024-07-03 at 4 17 22 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/a2a41d04-9391-4d2c-99f9-e945fc4ccead">
  - Invalid Request body by not entering name(which is a required field). The server did not crash it can be seen below instead returned a HTTP 400 error
<img width="1265" alt="Screenshot 2024-07-03 at 4 18 32 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/ac5e0578-0ed7-4848-96a9-fec70a16782f">
  - When a negative value for price was entered a similar HTTP 400 error was thrown.
<img width="1258" alt="Screenshot 2024-07-03 at 4 25 58 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/134e3943-9ecd-47e4-b971-bf698a4b785f">
 - When a number for the quantity entered was greater than the integer max value. A similar HTTP 400 error was thrown
   <img width="1222" alt="Screenshot 2024-07-03 at 4 31 09 PM" src="https://github.com/rahnayak98/ShoppingCartAPI/assets/22400467/2d12e7d4-cf31-4b8b-aeb8-a8e7bc58e0d0">





