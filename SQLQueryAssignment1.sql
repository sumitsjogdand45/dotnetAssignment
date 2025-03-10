create database BookStoreDB;
use BookStoreDB
create procedure GetAllBooks
as
begin
select * from Books
end;

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
	select * from Customers;

	Insert into Customers 
	values(6,'Bhavesh Joshi','Bhavesh@gmail.com',894857543);

	Delete from Customers
	where CustomerID not in(select CustomerID from Orders);

	--Operators
	--1. Retrieve all books with a price greater than 2000. 
	select * from Books
	where price>20;

	
	--2. Find the total number of books available. 
	select count(*) 
	from books

	--3. Find books published between 2015 and 2023. 
	select * from Books
	where PublishedYear between '01-Jan-2004' and '31-dec-2010'

	--4.Find all customers who have placed at least one order. 
	select * from Customers
	where CustomerID in(select CustomerID From Orders);

	--5. Retrieve books where the title contains the word "SQL"
		Select * from Books
		where Title Like 'SQL%'
		
	--6.Find the most expensive book in the store.
		select max(Price)
		from Books;

	--7.. Retrieve customers whose name starts with "A" or "J". 
		select * from customers
		where Names Like 'A%' or Names like 'V%';

	--8. Calculate the total revenue from all orders
		select Sum(TotalAmount) from Orders
		
select * from OrderItems
select * from Books
--Joins

--1. Retrieve all book titles along with their respective author names. 
	select b.Title,a.Names 
	from Books b
	left join Authors a
	on b.AuthorID=a.AuthorID  
	
--2. List all customers and their orders (if any). 
	select  c.*,b.OrderID
	from Customers c
	left join Orders b
	on c.CustomerID=b.CustomerID;


	insert into Books 
	values(6,'Wings of Fire',5,300,'2005-02-02') 

--3.Find all books that have never been ordered.
	select b.*
	from Books b
	left join OrderItems c
	on b.BookID=c.BookID
	where c.BookID is null;

--4. Retrieve the total number of orders placed by each customer.
	select a.CustomerID, b.Names,count(*) as ordercount
	from Orders a
	right join Customers b
	on a.CustomerID=b.CustomerID
	group By a.CustomerID,b.Names

--5. Find the books ordered along with the quantity for each order.
		select b.*,a.Quantity
		from OrderItems a
		left join Books b
		on a.BookID=b.BookID

--6. Display all customers, even those who haven’t placed any orders.

	insert into Customers 
	values(6,'sumit jogdand','sumit@gmail.com',985473223)
 
	select a.*
	from Customers a
	left join Orders b
	on a.CustomerID=b.CustomerID
	where b.OrderID is null;

--7. Find authors who have not written any books 
	select * from Authors
	insert into Authors values(6,'kapil lund','USA') 

	select a.*
	from Authors a
	left join Books b
	on a.AuthorID=b.AuthorID
	where BookID is null;

----------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------

--SUBQUERIES--

select* from Orders
select * from Customers
select * from OrderItems
select * from Books


--1. Find the customer(s) who placed the first order (earliest OrderDate). 
	--select OrderId,CustomerID
	--from Orders 
	--where OrderDate=(select min(OrderDate)
	--				 from Orders)

	select*
	from Customers
	where CustomerId =
	(select top 1 CustomerID
	from Orders 
	order by OrderDate asc)
	
	 update Orders
	 set OrderDate='2024-01-20'
	 where CustomerID=4;

--2. Find the customer(s) who placed the most orders. 

	select *
	from Customers c
	where c.CustomerID=(select max(quantity)
					    from OrderItems)

--3. Find customers who have not placed any orders 

	select *
	from Customers
	where CustomerID not in(select CustomerID from Orders)
	 
--4. Retrieve all books cheaper than the most expensive book written by( any  author based on your data)
	
	select * 
	from Books
	where price<(select max(price)
	from Books)

--5. List all customers whose total spending is greater than the average spending of all customers 
	
	select * from Customers where CustomerID in
	(Select CustomerID from Orders
	group by CustomerID
	having sum(TotalAmount)>(select avg(TotalAmount)
							from Orders))

 
 ----------------------------------------------------------------------------
 -----------------------Stored Procedures------------------------------------
 
 --1. Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer
 create Procedure SP1_CustomerID
 @CustomerID int
 as
 begin
 select * from Orders 
 where CustomerID=@CustomerID
 end

 exec SP1_CustomerID 5

 --2. Create a procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that range 
	
	create Procedure SP_Range
	@MaxPrice decimal (20,2),
	@MinPrice decimal (20,2)
	as
	begin
	select * from Books where Price between @MinPrice and @MinPrice
	end
	
	exec SP_Range 900,1000



	
 ----------------------------------------------------------------------------
 ----------------------------------Views------------------------------------
 

 --1.Create a view named AvailableBooks that shows only books that are in 
--stock, including BookID, Title, AuthorID, Price, and PublishedYear

alter table Books
add Stock int

 update Books set Stock=5 where BookID=1
  update Books set Stock=7 where BookID=2
   update Books set Stock=3 where BookID=3
  update Books set Stock=6 where BookID=4
  update Books set Stock=4 where BookID=5
  update Books set Stock=9 where BookID=6
  update Books set Stock=0 where BookID=10
  update Books set Stock=1 where BookID=11
  update Books set Stock=0 where BookID=12


  create view AvailableBooks
  as
  select BookID,Title,AuthorID,Price,PublishedYear
  from Books
  where Stock >0

  select * from AvailableBooks
  