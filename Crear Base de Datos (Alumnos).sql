USE master
GO

DROP DATABASE IF EXISTS [LMP-Examen]
GO

CREATE DATABASE [LMP-Examen]
GO

USE [LMP-Examen]
GO

DROP TABLE IF EXISTS dbo.Alumno
CREATE TABLE Alumno (
	matricula_alumno int,
	nombre_alumno varchar(40) NOT NULL,
	apellido_paterno_alumno varchar(40) NOT NULL,
	apellido_materno_alumno varchar(40) NOT NULL,
	direccion_alumno varchar(MAX) NOT NULL,
	telefono_alumno varchar(10) NOT NULL,
	correo_alumno varchar(100) NOT NULL,
	carrera varchar(4) NOT NULL,
	semestre_alumno int NOT NULL

	PRIMARY KEY(matricula_alumno),

	CHECK(LEN(matricula_alumno) = 7),
	CHECK(LEN(nombre_alumno) > 0),
	CHECK(LEN(apellido_paterno_alumno) > 0),
	CHECK(LEN(apellido_materno_alumno) > 0),
	CHECK(LEN(direccion_alumno) > 0),
	CHECK(telefono_alumno LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CHECK(correo_alumno LIKE '%@%.com'),
	UNIQUE(correo_alumno),
	CHECK(carrera IN ('LCC', 'LSTI', 'LMAD', 'LM', 'LF', 'LA')),
	CHECK(semestre_alumno >= 1 AND semestre_alumno <= 9)
)

INSERT INTO Alumno Values(1851388, 'Ángel', 'Tejeda', 'Tiscareño', 'Dirección 1', '5555467822', 'angel@gmail.com', 'LCC', 5)
INSERT INTO Alumno Values(1234567, 'José Santos', 'Flores', 'Silva', 'Dirección 2', '7154250925', 'josesant@hotmail.com', 'LCC', 5)
INSERT INTO Alumno Values(2234456, 'José Raúl', 'Evangelista', 'Mendoza', 'Dirección 3', '5108268360', 'joseraul@outlook.com', 'LCC', 5)
INSERT INTO Alumno Values(1122334, 'Sofía Alejandra', 'Gaytán', 'Díaz', 'Dirección 4', '8471598486', 'sofia@mail.com', 'LCC', 5)
INSERT INTO Alumno Values(5544321, 'Silvia Ivonne', 'Gonzáles', 'Flores', 'Dirección 5', '0407594104', 'silvia@gmail.com', 'LCC', 5)
INSERT INTO Alumno Values(1011223, 'Edson Yael', 'García', 'Silva', 'Dirección 6', '6182179011', 'edson@gmail.com', 'LCC', 5)
INSERT INTO Alumno Values(1123434, 'Ricardo', 'López', 'Gutierrez', 'Dirección 7', '5858663664', 'ricardo@gmail.com', 'LA', 3)
INSERT INTO Alumno Values(2314234, 'Hugo Javier', 'Martínez', 'Moreno', 'Dirección 8', '2146557799', 'hugo@outlook.com', 'LF', 3)
INSERT INTO Alumno Values(4248642, 'Andrea Natalia', 'Morales', 'Guerra', 'Dirección 9', '1619397254', 'andrea@yahoo.com', 'LM', 4)
INSERT INTO Alumno Values(8852162, 'Deno', 'Manzo', 'Bargas', 'Dirección 10', '6589134619', 'deno@hotmail.com', 'LSTI', 4)
INSERT INTO Alumno Values(7321453, 'Andrés Eduardo', 'Garza', 'Solís', 'Dirección 11', '1550518266', 'andres@mail.com', 'LMAD', 3)
INSERT INTO Alumno Values(1552133, 'Rebeca', 'Rodriguez', 'Rodriguez', 'Dirección 12', '7087833912', 'rebeca@hotmail.com', 'LSTI', 5)
INSERT INTO Alumno Values(1234127, 'Jorge Andrés', 'Sólís', 'Sánchez', 'Dirección 13', '8861471649', 'jorge@hotmail.com', 'LM', 5)