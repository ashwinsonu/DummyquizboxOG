use chaats;

CREATE TABLE Logintbl (
    Username nvarchar(50) PRIMARY KEY NOT NULL,
    Password nvarchar(50) NOT NULL,
   );

   INSERT INTO  Logintbl VALUES ('admin','1234')
   INSERT INTO  Logintbl VALUES ('ash','5678')
   INSERT INTO  Logintbl VALUES ('jewel','1234')
   INSERT INTO  Logintbl VALUES ('ashley','5678')
   SELECT * FROM Logintbl

CREATE TABLE Orders (
    Id Int PRIMARY KEY,
    Item varchar(20),
    TOA DateTime,
   
);
INSERT INTO Orders  VALUES(1,'PAANI PURI','17:00')
INSERT INTO Orders  VALUES(2,'DAAHI PURI','16:30')
INSERT INTO Orders  VALUES(3,'BHEL PURI','16:00')
INSERT INTO Orders  VALUES(4,'SEV PURI','16:45')
INSERT INTO Orders  VALUES(5,'RAGDA TIKKI','17:15')
   SELECT * FROM Orders
drop table Orders

CREATE TABLE Chaats (
    CId Int PRIMARY KEY ,   
	CName varchar(20),
	 CImage nvarchar(20),
    CPrice float
    
);

INSERT INTO Chaats VALUES(1,'PAANI PURI','\assets\Images\panipuri.jpg',30)
INSERT INTO Chaats VALUES(2,'DAHI PURI','\assets\Images\dahipuri.jpg',40)
INSERT INTO Chaats VALUES(3,'SEV PURI','\assets\Images\chaats.jpg',50)
INSERT INTO Chaats VALUES(4,'BHEL PURI','\assets\Images\bhelpuri.jpg',50)
INSERT INTO Chaats VALUES(5,'VADA PAV','\assets\Images\vadapav.jpg',20)

INSERT INTO Chaats VALUES(6,'RAGDA TIKKI','\assets\Images\ragda.jpg',60)
   SELECT * FROM Chaats
drop table Chaats

CREATE TABLE Drinks (
    DId Int PRIMARY KEY,
    DName varchar(20),
	DImage nvarchar(20),
    Dprice Float,
   
);
INSERT INTO Drinks VALUES(1,'TEA','\assets\Images\tea.jfif',10)
INSERT INTO Drinks VALUES(2,'COFFEE','\assets\Images\coffee.jpg',20)
INSERT INTO Drinks VALUES(3,'LASSI','\assets\Images\Lassi.jpg',40)
INSERT INTO Drinks VALUES(4,'Virgin Mojito','\assets\Images\mojito.jpg',50)
   SELECT * FROM Drinks
DROP TABLE Drinks 