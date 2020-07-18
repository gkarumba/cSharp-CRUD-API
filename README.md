PRODUCT MANAGEMENT SYSTEM
===================
## Description
A simple crud application that allows users to register, login , view products, add products, edit products and delete products.

#### By **[GKarumba](https://github.com/gkarumba)**

## Features

+  User registration<http://localhost:4000/users/register>.
   ---PAYLOAD----
    {
    "firstName": "<>your firstname",
    "lastName": "<your lastname>",
    "username": "<your username>",
    "password": "<your password>"
   }
+  User login<http://localhost:4000/users/authenticate>.
  ---PAYLOAD----
    {
    "username": "<your username>",
    "password": "<your password>"
    }
+  User view all products: <http://localhost:4000/products>.
+  User view single product: <http://localhost:4000/products/<product id>>.
+  User add product: <http://localhost:4000/products/>
    ---PAYLOAD----
    {
    "name": "<your product name>",
    "description": "<your product description>",
    "user": <user id of user adding product>,
    "price": <price of product>
    }
+  User edit product: <http://localhost:4000/products/>
    ---PAYLOAD----
    {
    "name": "<your product name>",
    "description": "<your product description>",
    "user": <user id of user adding product>,
    "price": <price of product>
    }
 
 +  User delete product: <http://localhost:4000/products/<product id>>
   

## Technology used

* [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)

## Bugs

* CORS policy for adding product


