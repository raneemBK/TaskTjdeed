# TaskTjdeed
## This is a simple E-Commerce API that allows users to register, log in, and place orders while using JWT authentication and Stripe for payments. The system includes user authentication, product management by admins, and order handling.

## 1- Featurs

User Authentication: Users can register and log in securely with password hashing and JWT tokens.

Product Management: Only admins can create, update, and delete products.

Order Management: Users can place multiple orders, which are stored in the database.

Payment Integration: Stripe is used to handle payments securely.

<img src="https://github.com/user-attachments/assets/82575666-e3c2-4c1e-b78e-50c6eb790192">

## 2- Configure Database
```
CREATE TABLE Users
(
  userID INT IDENTITY(1,1),
  fullName VARCHAR(250),
  email VARCHAR(250) NOT NULL,
  PasswordHash VARBINARY(MAX) NOT NULL,
  PasswordSalt VARBINARY(MAX) NOT NULL,
  phone VARCHAR(10),
  roleName VARCHAR(10),
  PRIMARY KEY (userID)
);


CREATE TABLE Products
(
  productID INT IDENTITY(1,1),
  name VARCHAR(250),
  description VARCHAR(250),
  price DECIMAL(9,2),
  stockQuantity INT ,
  PRIMARY KEY (productID)
);

CREATE TABLE Orders
(
  orderID INT IDENTITY(1,1),
  totalPrice DECIMAL(9,2) ,
  userID INT ,
  PRIMARY KEY (orderID),
  FOREIGN KEY (userID) REFERENCES Users(userID),
);

CREATE TABLE OrderProducts 
(
  OrderProductID INT IDENTITY(1,1),
  quantities INT,
  ProductID INT ,
  orderID INT,
  PRIMARY KEY (OrderProductID),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
  FOREIGN KEY (orderID) REFERENCES Orders(orderID)
);
```
<img src="https://github.com/user-attachments/assets/17ccadb3-fa49-4fa1-ae95-10ee4130f1d0" >

## 3- User Authentication: Rejister & Login
### Regiter: user can register by add his information and will be saved it in database with hashed password for security
### Login: user can login in webiste by email and password and will return a token (use JWT)
<div>
  <img src="https://github.com/user-attachments/assets/290dfa86-9e54-497c-bcd0-ad9afb40800b" width="400">
  <img src="https://github.com/user-attachments/assets/93380a55-9252-4b05-9f6c-61153bc4911a" width="400">
</div>

## 4- Authorization:
1- add a token in authorization
2- test a token
<div>
  <img src="https://github.com/user-attachments/assets/2736000a-6683-40fe-b615-3fd0b379f875" width="400">
  <img src="https://github.com/user-attachments/assets/ce33d9d5-a229-4b7e-922e-d6a35d3198d5" width="400">
</div>

## 5- Prodcuts
the admin only can add, update or delete a products, other users can display all products and product by id
 <img src="https://github.com/user-attachments/assets/624b46d1-ec5f-4bea-8be4-1566a1c8b375" width="400">

## 6- Orders:
only users authorized can be create order or delete order

 ## 7- Payment:
### 1- Create a payment intent and return the client secret
### 2- Test transation in stripe from step 1
<div>
  <img src="https://github.com/user-attachments/assets/9ece1cff-a727-4dcd-b41e-2c8df8e2da01" width="400">
  <img src="https://github.com/user-attachments/assets/0338758a-f9ca-40ac-bdb6-78e966a977aa" width="400">
</div>

### 3- Confirm a payment intent for testing in Swagger by take the paymentIntentId from step 1
### 4- Test transaction in stripe from step 3
<div>
  <img src="https://github.com/user-attachments/assets/a2487718-487a-4fc3-a3b0-48184466ae91" width="400">
  <img src="https://github.com/user-attachments/assets/01933a8d-accb-4eba-bbac-b7bb5f73fbfc" width="400">
</div>

## 8- My testing data in SQL Server:
 <img src="https://github.com/user-attachments/assets/362fea79-9192-4151-99d2-5f0033c295e1">
