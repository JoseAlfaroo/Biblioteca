-- 06/12/2024 --

Use Master;
Go

Drop Database If Exists MiBiblioteca;
Go

Create Database MiBiblioteca;
Go

Use MiBiblioteca;
Go

Create Table Paises (
    PaisID Int Identity(1,1) Not Null Primary Key,
    NombrePais NVarchar(100) Not Null
);
Go

Insert Into Paises (NombrePais) Values 
('Brasil'),
('Japón'),
('Reino Unido'),
('Chile'),
('Estados Unidos'),
('Colombia'),
('México'),
('Francia'),
('Alemania'),
('Canadá');
Go

Select * From Paises;
Go

Create Table Autores (
    AutorID Int Identity(1,1) Not Null Primary Key,
    NombresAutor NVarchar(100) Not Null,
    ApellidosAutor NVarchar(100) Not Null,
    PaisID Int Null References Paises(PaisID) On Delete Set Null
);
Go

Insert Into Autores (NombresAutor, ApellidosAutor, PaisID) Values 
('Gabriel', 'García Márquez', 6),
('Haruki', 'Murakami', 2),
('J.K.', 'Rowling', 3),
('Isabel', 'Allende', 4),
('Mark', 'Twain', 5),
('Carlos', 'Fuentes', 7),
('Victor', 'Hugo', 8),
('Hermann', 'Hesse', 9),
('Margaret', 'Atwood', 10),
('Paulo', 'Coelho', 1);
Go

Select * From Autores;
Go

Create Table Generos (
    GeneroID Int Identity(1,1) Not Null Primary Key,
    NombreGenero NVarchar(100) Not Null
);
Go

Insert Into Generos (NombreGenero) Values 
('Fiction'),
('Mystery'),
('Fantasy'),
('Non-fiction'),
('Sci-Fi'),
('Historical Fiction'),
('Biography'),
('Thriller'),
('Romance'),
('Horror');
Go

Select * From Generos;
Go

Create Table Libros (
    LibroID Int Identity(1,1) Not Null Primary Key,
    Titulo NVarchar(200) Not Null,
    AñoPublicacion Int Not Null,
    Portada NVarchar(Max),
    Descripcion NVarchar(Max)
);
Go

Insert Into Libros (Titulo, AñoPublicacion, Portada, Descripcion) Values 
('One Hundred Years of Solitude', 1967, 'URL_to_image', 'A novel by Gabriel García Márquez.'),
('Kafka on the Shore', 2002, 'URL_to_image', 'A novel by Haruki Murakami.'),
('Harry Potter and the Sorcerers Stone', 1997, 'URL_to_image', 'A fantasy novel by J.K. Rowling.'),
('The House of the Spirits', 1982, 'URL_to_image', 'A novel by Isabel Allende.'),
('Adventures of Huckleberry Finn', 1884, 'URL_to_image', 'A novel by Mark Twain.'),
('The Alchemist', 1988, 'URL_to_image', 'A novel by Paulo Coelho.'),
('Les Misérables', 1862, 'URL_to_image', 'A novel by Victor Hugo.'),
('Siddhartha', 1922, 'URL_to_image', 'A novel by Hermann Hesse.'),
('The Handmaids Tale', 1985, 'URL_to_image', 'A novel by Margaret Atwood.'),
('Aura', 1962, 'URL_to_image', 'A novel by Carlos Fuentes.');
Go

Select * From Libros;
Go

Create Table GenerosLibro (
    Primary Key (LibroID, GeneroID),
    LibroID Int Not Null References Libros(LibroID),
    GeneroID Int Not Null References Generos(GeneroID)
);
Go

Insert Into GenerosLibro (LibroID, GeneroID) Values 
(1, 1), (1, 6),
(2, 2),
(3, 3), (3, 9),
(4, 1),
(5, 1), (5, 6),
(6, 1), (6, 5),
(7, 1), (7, 6),
(8, 1), (8, 7),
(9, 1), (9, 4),
(10, 1), (10, 2);
Go

Select * From GenerosLibro;
Go

Create Table AutoresLibro (
    Primary Key (LibroID, AutorID),
    LibroID Int Not Null References Libros(LibroID),
    AutorID Int Not Null References Autores(AutorID)
);
Go

Insert Into AutoresLibro (LibroID, AutorID) Values 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 10),
(7, 7),
(8, 8),
(9, 9),
(10, 6);
Go

Select * From AutoresLibro;
Go

Create Table Roles (
    RolId Int Identity(1,1) Not Null Primary Key,
    NombreRol NVarchar(50) Not Null Unique
);
Go

Insert Into Roles (NombreRol) Values 
('Administrador'),
('Usuario');
Go

Select * From Roles;
Go

Create Table Usuarios (
    UsuarioId Int Identity(1,1) Not Null Primary Key,
    Nombres NVarchar(100) Not Null,
    Apellidos NVarchar(100) Not Null,
    Username Varchar(50) Not Null Unique,
    Email Varchar(100) Not Null Unique,
    Password Varchar(255) Not Null,
    FechaRegistro DateTime Not Null Default GetDate(),
    FechaActualizacion DateTime Not Null Default GetDate(),
    IntentosFallidos Int Not Null Default 0,
    UltimoIntento DateTime Null Default GetDate(),
    RolId Int Not Null References Roles(RolId) On Delete Cascade
);
Go

Insert Into Usuarios (Nombres, Apellidos, Username, Email, Password, RolId) Values
('Juan', 'Pérez', 'jperez', 'juan.perez@example.com', 'hashed_password_1', 1),
('María', 'García', 'mgarcia', 'maria.garcia@example.com', 'hashed_password_2', 2),
('Luis', 'Ramírez', 'lramirez', 'luis.ramirez@example.com', 'hashed_password_3', 2),
('Ana', 'López', 'alopez', 'ana.lopez@example.com', 'hashed_password_4', 2);
Go

Select * From Usuarios;
Go
