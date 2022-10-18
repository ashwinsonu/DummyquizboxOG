use sampl
Create Table sam.tblProducts
(
 [Id] int identity primary key,
 [Name] nvarchar(50),
 [Description] nvarchar(250)
)

Create Table sam.tblProductSales
(
 Id int primary key identity,
 ProductId int foreign key references sam.tblProducts(Id),
 UnitPrice int,
 QuantitySold int
)

Insert into sam.tblProducts values ('TV', '52 inch black color LCD TV')
Insert into sam.tblProducts values ('Laptop', 'Very thin black color acer laptop')
Insert into sam.tblProducts values ('Desktop', 'HP high performance desktop')

Insert into sam.tblProductSales values(3, 450, 5)




Insert into sam.tblProductSales values(2, 250, 7)
Insert into sam.tblProductSales values(3, 450, 4)
Insert into sam.tblProductSales values(3, 450, 9)

select Id,Name,Description from sam.tblProducts where id not in 
(Select ProductId from sam.tblProductSales)

select Name,(select SUM(QuantitySold)as quantity_sold from sam.tblProductSales where ProductId=tblProducts.Id)
from sam.tblProducts
