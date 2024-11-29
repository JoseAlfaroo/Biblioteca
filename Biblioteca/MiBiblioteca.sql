-- 11/07/2024 --
Use Master;
Go

Drop Database If Exists MiBiblioteca;
Go

-- Create the database
Create Database MiBiblioteca
Go

-- Use the database
Use MiBiblioteca
Go

--------------------------------
-- Create Paises table
Create Table Paises (
    PaisID Int Identity(1,1) Not Null Primary Key,
    NombrePais NVarchar(Max) Not Null
)
Go

-- Insert records into Paises
Insert Into Paises (NombrePais) Values ('Brasil')
Insert Into Paises (NombrePais) Values ('SAJKJKSJB')
Insert Into Paises (NombrePais) Values ('sHBKBJKJKBl')
Insert Into Paises (NombrePais) Values ('SFKJSBA')
Insert Into Paises (NombrePais) Values ('SA3223F')
Go

-- Display records from Paises
Select * From Paises
Go

--------------------------------
-- Create Autores table
Create Table Autores (
    AutorID Int Identity(1,1) Not Null Primary Key,
    NombresAutor NVarchar(Max) Not Null,
    ApellidosAutor NVarchar(Max) Not Null,
    PaisID Int Null References Paises(PaisID) On Delete Set Null
)
Go

-- Insert records into Autores
Insert Into Autores (NombresAutor, ApellidosAutor, PaisID) Values ('Gabriel', 'Garcia Marquez', 1)
Insert Into Autores (NombresAutor, ApellidosAutor, PaisID) Values ('Haruki', 'Murakami', 2)
Insert Into Autores (NombresAutor, ApellidosAutor, PaisID) Values ('J.K.', 'Rowling', 3)
Insert Into Autores (NombresAutor, ApellidosAutor, PaisID) Values ('Isabel', 'Allende', 4)
Insert Into Autores (NombresAutor, ApellidosAutor, PaisID) Values ('Mark', 'Twain', 5)
Go

-- Display records from Autores
Select * From Autores
Go

-- 12/07/2024 --

-- Create Generos table
Create Table Generos (
    GeneroID Int Identity(1,1) Not Null Primary Key,
    NombreGenero NVarchar(Max) Not Null
)
Go

-- Insert records into Generos
Insert Into Generos (NombreGenero) Values ('Fiction')
Insert Into Generos (NombreGenero) Values ('Mystery')
Insert Into Generos (NombreGenero) Values ('Fantasy')
Insert Into Generos (NombreGenero) Values ('Non-fiction')
Insert Into Generos (NombreGenero) Values ('Sci-Fi')
Go

-- Display records from Generos
Select * From Generos
Go

--------------------------------
-- Create Libros table
Create Table Libros (
    LibroID Int Identity(1,1) Not Null Primary Key,
    Titulo NVarchar(Max) Not Null,
    AñoPublicacion Int Not Null,
    Portada NVarchar(Max),
    Descripcion NVarchar(Max)
)
Go

-- Insert records into Libros
Insert Into Libros (Titulo, AñoPublicacion, Portada, Descripcion) Values ('One Hundred Years of Solitude', 1967, 'URL_to_image', 'A novel by Gabriel García Márquez.')
Insert Into Libros (Titulo, AñoPublicacion, Portada, Descripcion) Values ('Kafka on the Shore', 2002, 'URL_to_image', 'A novel by Haruki Murakami.')
Insert Into Libros (Titulo, AñoPublicacion, Portada, Descripcion) Values ('Harry Potter and the Sorcerers Stone', 1997, 'URL_to_image', 'A fantasy novel by J.K. Rowling.')
Insert Into Libros (Titulo, AñoPublicacion, Portada, Descripcion) Values ('The House of the Spirits', 1982, 'URL_to_image', 'A novel by Isabel Allende.')
Insert Into Libros (Titulo, AñoPublicacion, Portada, Descripcion) Values ('Adventures of Huckleberry Finn', 1884, 'URL_to_image', 'A novel by Mark Twain.')
Go

-- Display records from Libros
Select * From Libros
Go

--------------------------------
-- Create GenerosLibro table (Many-to-Many between Generos and Libros)
Create Table GenerosLibro (
    Primary Key (LibroID, GeneroID),
    LibroID Int Not Null References Libros(LibroID),
    GeneroID Int Not Null References Generos(GeneroID)
)
Go

-- Insert records into GenerosLibro
Insert Into GenerosLibro (LibroID, GeneroID) Values (1, 1) -- One Hundred Years of Solitude - Fiction
Insert Into GenerosLibro (LibroID, GeneroID) Values (2, 2) -- Kafka on the Shore - Mystery
Insert Into GenerosLibro (LibroID, GeneroID) Values (3, 3) -- Harry Potter - Fantasy
Insert Into GenerosLibro (LibroID, GeneroID) Values (4, 1) -- The House of the Spirits - Fiction
Insert Into GenerosLibro (LibroID, GeneroID) Values (5, 1) -- Adventures of Huckleberry Finn - Fiction
Go

-- Display records from GenerosLibro
Select * From GenerosLibro
Go

--------------------------------
-- Create AutoresLibro table (Many-to-Many between Autores and Libros)
Create Table AutoresLibro (
    Primary Key (LibroID, AutorID), 
    LibroID Int Not Null References Libros(LibroID),
    AutorID Int Not Null References Autores(AutorID)
)
Go

-- Insert records into AutoresLibro
Insert Into AutoresLibro (LibroID, AutorID) Values (1, 1) -- One Hundred Years of Solitude - Gabriel García Márquez
Insert Into AutoresLibro (LibroID, AutorID) Values (2, 2) -- Kafka on the Shore - Haruki Murakami
Insert Into AutoresLibro (LibroID, AutorID) Values (3, 3) -- Harry Potter - J.K. Rowling
Insert Into AutoresLibro (LibroID, AutorID) Values (4, 4) -- The House of the Spirits - Isabel Allende
Insert Into AutoresLibro (LibroID, AutorID) Values (5, 5) -- Adventures of Huckleberry Finn - Mark Twain
Go

-- Display records from AutoresLibro
Select * From AutoresLibro
Go