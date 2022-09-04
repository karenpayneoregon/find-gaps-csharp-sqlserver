/*
    Run this script before running the code in this project
*/
CREATE TABLE Customers
(
    [CustomerIdentifier] INT,
    [CompanyName] NVARCHAR(40),
    [Street] NVARCHAR(60),
    [City] NVARCHAR(15),
    [PostalCode] NVARCHAR(10)
);

INSERT INTO Customers
(
    [CustomerIdentifier],
    [CompanyName],
    [Street],
    [City],
    [PostalCode]
)
VALUES
(1, N'Alfreds Futterkiste', N'Obere Str. 58', N'Berlin', N'12209'),
(2, N'Ana Trujillo Emparedados y helados', N'Avda. de la ConstituciÃ³n 2222', N'MÃ©xico D.F.', N'05021'),
(5, N'Berglunds snabbkÃ¶p', N'BerguvsvÃ¤gen  8', N'LuleÃ¥', N'S-958 22'),
(6, N'Blauer See Delikatessen', N'Forsterstr. 57', N'Mannheim', N'68306'),
(9, N'Bon app''', N'12, rue des Bouchers', N'Marseille', N'13008'),
(11, N'Cactus Comidas para llevar', N'Cerrito 333', N'Buenos Aires', N'1010'),
(12, N'Centro comercial Moctezuma', N'Sierras de Granada 9993', N'MÃ©xico D.F.', N'05022'),
(13, N'Chop-suey Chinese', N'Hauptstr. 29', N'Bern', N'3012'),
(14, N'Consolidated Holdings', N'Berkeley Gardens 12  Brewery', N'London', N'WX1 6LT'),
(15, N'Drachenblut Delikatessen', N'Walserweg 21', N'Aachen', N'52066');

