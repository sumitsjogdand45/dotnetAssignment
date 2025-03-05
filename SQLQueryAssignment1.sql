create database BookStoreDB;

--authors table
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY,
    Names VARCHAR(255) NOT NULL,
    Country VARCHAR(255) NOT NULL); 

--books table
create table Books(
    BookID int primary key,
    Title varchar(20) not null,
    Price varchar(20) not null,
    PublishedYear DATE not null,
    AuthorID int foreign key (AuthorID) references Authors(AuthorID));

-- Customers table
create table Customers (
    CustomerID int primary key,
    Names varchar(20)not null ,
    Email varchar(20) not null,
    PhoneNumber varchar(20)not null);

-- Orders table
	create table Orders (
    OrderID int primary key,
    OrderDate date not null ,
    TotalAmount int not null,
    CustomerID int foreign key (CustomerID) references Customers(CustomerID)
);

-- OrderItems table
	create table OrderItems(
    OrderItemID int primary key, 
    Quantity int,
    SubTotal int,
    OrderID int foreign key (OrderID) references Orders(OrderID),
    BookID int foreign key(BookID) references Books(BookID));

	--1.inserting in table Authors
	insert into Authors (AuthorID,Names,Country)
	values (1,'Ravi', 'India'),
		   (2,'Rahul', 'India'),
           (3,'Chetan', 'India'),
           (4,'Kiran', 'India'),
           (5,'Arun', 'India');

	--2.inserting in table books
	 insert into Books (BookID, Title, Price, PublishedYear, AuthorID)
     values
			(1, 'Gitanjali', '300', '1910-01-01', 1),   
			(2, 'Malgudi Days', '250', '1943-01-01', 2), 
			(3, 'Five Point Someone', '450', '2004-10-01', 3), 
			(4, 'The Shiva Trilogy', '350', '2006-01-01', 4), 
			(5, 'The White Tiger', '400', '1997-01-01', 5); 

  --inserting into customer table

	insert into Customers (CustomerID, Names, Email, PhoneNumber)
	values
	(1, 'Amit Deshmukh', 'amit.d@gmail.com', '9823123456'),
	(2, 'Priya Patil', 'priya.p@gmail.com', '9828765432'),
	(3, 'Ravi Kulkarni', 'ravi.k@gmail.com', '9834567890'),
	(4, 'Sneha Joshi', 'sneha.j@gmail.com', '9856789012'),
	(5, 'Vinayak More', 'vinayakm@gmail.com', '9865432109');

	--inserting table for orders table
	insert into Orders (OrderID, OrderDate, TotalAmount, CustomerID)
	values
	(1, '2025-03-01', 1500, 1),  
	(2, '2025-03-02', 2000, 2), 
	(3, '2025-03-03', 1200, 3), 
	(4, '2025-03-04', 1800, 4), 
	(5, '2025-03-05', 2500, 5); 

	--inserting table for orderitems table
	insert into OrderItems (OrderItemID, Quantity, SubTotal, OrderID, BookID)
	values
	(1, 2, 600, 1, 1),  
	(2, 1, 250, 2, 2), 
	(3, 3, 1350, 3, 3),  
	(4, 1, 350, 4, 4),  
	(5, 2, 800, 5, 5); 

	---------------------------------------------
	select * from Books

	--the title changed and price incremented by 10%
	update Books
	set Title='SQL Mastery',Price=Price*1.10
	where BookID=1;

	--datatype varchar changed to decimal
	alter table Books 
	alter column Price  DECIMAL(10, 2);

	select * from Orders;