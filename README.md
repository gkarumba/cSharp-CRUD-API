PRODUCT MANAGEMENT SYSTEM
===================
## Description
A simple crud application that allows users to register, login , view products, add products, edit products and delete products.

#### By **[GKarumba](https://github.com/gkarumba)**

## Features

+  User registration: <API> <http://localhost:4000/users/register>.
   ---PAYLOAD----
    {
    "firstName": "<your firstname>",
    "lastName": "<your lastname>",
    "username": "<your username>",
    "password": "<your password>"
   }
+  User login: <API> <http://localhost:4000/users/authenticate>.
  ---PAYLOAD----
    {
    "username": "<your username>",
    "password": "<your password>"
    }
+  User view all products: <API> <http://localhost:4000/products>.
+  User view single product: <API> <http://localhost:4000/products/<product id>>.
+  User add product: <API> <http://localhost:4000/products/>
    ---PAYLOAD----
    {
    "name": "<your product name>",
    "description": "<your product description>",
    "user": <user id of user adding product>,
    "price": <price of product>
    }
+  User edit product: <API> <http://localhost:4000/products/>
    ---PAYLOAD----
    {
    "name": "<your product name>",
    "description": "<your product description>",
    "user": <user id of user adding product>,
    "price": <price of product>
    }
 
 +  User delete product: <API> <http://localhost:4000/products/<product id>>
   

## Technology used

* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [Angular 9](https://angular.io/)

## Bugs

* CORS policy for adding product


