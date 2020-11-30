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
	matricula_alumno varchar(7),
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

INSERT INTO Alumno Values('1851388', 'Ángel', 'Tejeda', 'Tiscareño', 'Rinconada Casa Blanca 954 Quintas los Nogales', '1555467822', 'angel@gmail.com', 'LCC', 5)
INSERT INTO Alumno Values('1234567', 'José Santos', 'Flores', 'Silva', 'Loma Bonita 2da. Sección 354 Cronos', '7154250925', 'josesant@hotmail.com', 'LCC', 5)
INSERT INTO Alumno Values('2234456', 'José Raúl', 'Evangelista', 'Mendoza', 'Los Pericos 029 Boca del Río Chico', '5108268360', 'joseraul@outlook.com', 'LCC', 5)
INSERT INTO Alumno Values('1122334', 'Sofía Alejandra', 'Gaytán', 'Díaz', 'Huizaista 180 Rogelio Montemayor', '8471598486', 'sofia@mail.com', 'LCC', 5)
INSERT INTO Alumno Values('5544321', 'Silvia Ivonne', 'Gonzáles', 'Flores', 'Las Juntas 162 Jesús Carranza', '0407594104', 'silvia@gmail.com', 'LCC', 5)
INSERT INTO Alumno Values('1011223', 'Edson Yael', 'García', 'Silva', 'Del Tedra 131 Ramón F. Balboa', '6182179011', 'edson@gmail.com', 'LCC', 5)
INSERT INTO Alumno Values('1123434', 'Ricardo', 'López', 'Gutierrez', 'San Martín Obispo 290 Santa Rita', '5858663664', 'ricardo@gmail.com', 'LA', 3)
INSERT INTO Alumno Values('2314234', 'Hugo Javier', 'Martínez', 'Moreno', 'El Plan 388 Rosario Ixtal', '2146557799', 'hugo@outlook.com', 'LF', 3)
INSERT INTO Alumno Values('4248642', 'Andrea Natalia', 'Morales', 'Guerra', 'Las Haciendas 800 Santa Rosa', '1619397254', 'andrea@yahoo.com', 'LM', 4)
INSERT INTO Alumno Values('8852162', 'Deno', 'Manzo', 'Bargas', 'Los Arrayanes 663 El Carmelo', '6589134619', 'deno@hotmail.com', 'LSTI', 4)
INSERT INTO Alumno Values('7321453', 'Andrés Eduardo', 'Garza', 'Solís', 'Altavista Residencial 648 El Tzay', '1550518266', 'andres@mail.com', 'LMAD', 3)
INSERT INTO Alumno Values('1552133', 'Rebeca', 'Rodriguez', 'Rodriguez', 'Villa del Lago (El Baratillo) 049 Ladrillera', '7087833912', 'rebeca@hotmail.com', 'LSTI', 5)
INSERT INTO Alumno Values('1234127', 'Jorge Andrés', 'Sólís', 'Sánchez', 'Parques Aldama 594 La Capilla', '8861471649', 'jorge@hotmail.com', 'LM', 5)

INSERT INTO Alumno Values('1667783', 'Heliodoro', 'González', 'Soto', 'Guanajuato Centro 277 Oscar Ornelas', '7776784361', 'heliodorogonzálezs9291@mail.com', 'LCC', 8)
INSERT INTO Alumno Values('9875993', 'Pedro Sandra', 'Márquez', 'Mora', 'La Providencia 835 Los Gobernadores', '9959575538', 'pedromárquezm84063176@mail.com', 'LSTI', 8)
INSERT INTO Alumno Values('0482243', 'Bárbara', 'Soto', 'Peña', 'Polo Habitacional La Esmeralda 058 Santa Bárbara', '3696382465', 'bárbarasotop0436284371@mail.com', 'LM', 3)
INSERT INTO Alumno Values('3873367', 'Agustín', 'Lorenzo', 'Soto', 'Santa Ofelia 713 Colima Centro', '8492394940', 'agustínlorenzos529079282@mail.com', 'LA', 1)
INSERT INTO Alumno Values('8207153', 'Alba Úrsula', 'Santana', 'Arias', 'San Marcos 859 Arroyo Sabinal', '8701254072', 'albasantanaa4219@mail.com', 'LSTI', 9)
INSERT INTO Alumno Values('0110812', 'Rogelio Inocencio', 'Muñoz', 'Ramos', 'Centro 588 El Rosario', '0924753972', 'rogeliomuñozr760474867@mail.com', 'LCC', 9)
INSERT INTO Alumno Values('9894398', 'Victoria Basileo', 'Cano', 'Gallardo', 'Punta Norte 003 San Fermín', '9555474057', 'victoriacanog9392009@mail.com', 'LA', 2)
INSERT INTO Alumno Values('3042218', 'Jonathan', 'Sáez', 'Reyes', 'La Garita 040 Quintas los Nogales', '9817595631', 'jonathansáezr70769@mail.com', 'LCC', 4)
INSERT INTO Alumno Values('9167019', 'Melchor', 'Santana', 'Nieto', 'La Cruz del Derramadero 390 Campo Setenta y Tres', '0017009547', 'melchorsantanan8640339253@mail.com', 'LA', 1)
INSERT INTO Alumno Values('7617325', 'Atanasio', 'Santos', 'Muñoz', 'Venustiano Carranza (El Seis) 759 Las Piedritas', '6142813041', 'atanasiosantosm457826@mail.com', 'LF', 4)
INSERT INTO Alumno Values('0148475', 'Evaristo', 'Márquez', 'Navarro', 'Del Tedra 250 Jerusalén', '8484989375', 'evaristomárquezn5510@mail.com', 'LCC', 5)
INSERT INTO Alumno Values('2292269', 'Camilo Noé', 'Garrido', 'Serrano', 'Cacalotepec 975 Álvaro Obregón', '1863702643', 'camilogarridos60545@mail.com', 'LF', 7)
INSERT INTO Alumno Values('1140052', 'Rocío', 'Morales', 'Vargas', 'Punta Norte 073 Oscar Ornelas', '4114784878', 'rocíomoralesv77826@mail.com', 'LCC', 2)
INSERT INTO Alumno Values('0047589', 'Leocadia Renato', 'Méndez', 'Durán', 'Santa Ana 217 Reforma', '9567052941', 'leocadiaméndezd028948@mail.com', 'LM', 2)
INSERT INTO Alumno Values('5963865', 'Miqueas César', 'Cabrera', 'Pastor', 'Los Olivos 880 Leonardo Gastélum Quinta Etapa', '1536682649', 'miqueascabrerap96473@mail.com', 'LA', 7)
INSERT INTO Alumno Values('4685882', 'Mateo', 'Pérez', 'Romero', 'San Pedro 940 San Pedro la Tejería', '9260709835', 'mateopérezr594626@mail.com', 'LM', 4)
INSERT INTO Alumno Values('8734332', 'Emiliano Lucía', 'Gallardo', 'Álvarez', 'Aquiles Serdán 940 Xoctón (Xoctoctic)', '7834273775', 'emilianogallardoá56616338@mail.com', 'LA', 4)
INSERT INTO Alumno Values('2883614', 'Sebastián', 'Ruiz', 'Méndez', 'Santo Toribio 381 El Pajarito', '1348540144', 'sebastiánruizm345174816@mail.com', 'LCC', 9)
INSERT INTO Alumno Values('1219558', 'Mar Raquel', 'Cambil', 'Cambil', 'Parque Industrial Santa Fe Ampliación 166 El Pajarito', '4977903657', 'marcambilc81@mail.com', 'LM', 1)
INSERT INTO Alumno Values('3748280', 'Constancio Sandra', 'Méndez', 'Márquez', 'Rafael Picazo (Santa Cruz) 724 San José Plan Ocotal', '6419295027', 'constancioméndezm49754@mail.com', 'LA', 1)
INSERT INTO Alumno Values('0993130', 'Tarsicio', 'Romero', 'Ibáñez', 'Laguna Seca 295 Zona Central', '5860100736', 'tarsicioromeroi177@mail.com', 'LCC', 1)
INSERT INTO Alumno Values('1809738', 'Fabiola', 'García', 'Cortés', 'El Playón 609 San Francisco', '4722065632', 'fabiolagarcíac1579348367@mail.com', 'LA', 1)
INSERT INTO Alumno Values('3150562', 'Alejo', 'Sánchez', 'Hernández', 'La Cacánicua de Arriba 351 Xitoltepeque', '8470648039', 'alejosánchezh00368626@mail.com', 'LM', 7)
INSERT INTO Alumno Values('9209724', 'Montserrat', 'Fernández', 'Domínguez', 'Las Cuatas 313 Doctor Manuel Velasco Suárez', '2187253136', 'montserratfernándezd052038@mail.com', 'LA', 1)
INSERT INTO Alumno Values('6677862', 'Bárbara', 'Ferrer', 'Carrasco', 'El Zapote del Milagro 441 Bellavista', '4449013605', 'bárbaraferrerc543383@mail.com', 'LMAD', 6)
INSERT INTO Alumno Values('4843800', 'Rocío Genoveva', 'Martínez', 'Navarro', 'De santa Cruz 392 Hacienda las Primaveras', '4352588356', 'rocíomartínezn34789@mail.com', 'LMAD', 5)
INSERT INTO Alumno Values('2032368', 'Cándida Montserrat', 'Marín', 'Lozano', 'Huixcomulco 341 Jardín las Flores', '1474890413', 'cándidamarínl728236543@mail.com', 'LM', 8)
INSERT INTO Alumno Values('8809647', 'Aurelio', 'Rodríguez', 'Lozano', 'Ampliación Loma Bonita 163 Saltillo Zona Centro', '0315914664', 'aureliorodríguezl42650804@mail.com', 'LM', 8)
INSERT INTO Alumno Values('5560365', 'Concepción Domingo', 'Sanz', 'Vázquez', 'Sierra Nogal 466 Zacualpa', '9617073616', 'concepciónsanzv899@mail.com', 'LA', 9)
INSERT INTO Alumno Values('7611452', 'Julián', 'Pastor', 'Cruz', 'Eulalio Ángeles Martínez 516 Álvaro Luna', '4289309713', 'juliánpastorc6286538887@mail.com', 'LSTI', 5)
INSERT INTO Alumno Values('3999903', 'Aristides', 'Vázquez', 'Ruiz', 'Ex-Hacienda de San Francisco 160 Zona Centro', '5121157234', 'aristidesvázquezr86255@mail.com', 'LF', 8)
INSERT INTO Alumno Values('7559955', 'Teófanes Petronila', 'Hidalgo', 'Ortega', 'Gallineros 375 San José Plan Ocotal', '3717566227', 'teófaneshidalgoo0491271618@mail.com', 'LA', 1)
INSERT INTO Alumno Values('7796368', 'Oswaldo', 'Sáez', 'Cano', 'Lomas del Álamo 529 Residencial Bosque Real', '8193464365', 'oswaldosáezc270480@mail.com', 'LMAD', 1)
INSERT INTO Alumno Values('9764683', 'Luisa', 'Iglesias', 'Pastor', 'Loma Escondida 784 Punta Oriente', '7546335448', 'luisaiglesiasp0555@mail.com', 'LCC', 6)
INSERT INTO Alumno Values('4775878', 'Lidia Leoncio', 'Ortega', 'Ferrer', 'Paso de Guadalupe 994 Corrala', '5577768043', 'lidiaortegaf3231335117@mail.com', 'LM', 2)
INSERT INTO Alumno Values('2160455', 'Nuria', 'Navarro', 'Montero', 'La Haciendita Fiereña 233 Los Olivos', '7429476127', 'nurianavarrom4@mail.com', 'LMAD', 8)
INSERT INTO Alumno Values('3864383', 'Honorato Cleofás', 'Vicente', 'Blesa', 'El Casaco (Platanitos) 099 El Tzay', '2853242389', 'honoratovicenteb017308@mail.com', 'LSTI', 3)
INSERT INTO Alumno Values('3086224', 'Sergio', 'González', 'Gallardo', 'San Juan Bautista 039 Rogelio Montemayor', '7288254470', 'sergiogonzálezg596239@mail.com', 'LF', 1)
INSERT INTO Alumno Values('6293252', 'Guido', 'Romero', 'Hernández', 'Parque Industrial Santa Fe Ampliación 038 Miramar', '7141447451', 'guidoromeroh569218@mail.com', 'LM', 7)
INSERT INTO Alumno Values('2346185', 'Carina', 'Giménez', 'Ruiz', 'Santo Toribio 167 Guadalupe', '0663215073', 'carinagiménezr566891924@mail.com', 'LM', 1)
INSERT INTO Alumno Values('9404992', 'Victoria', 'Cano', 'Cambil', 'Pochotitán 810 Playa de Piedra 2da. Sección', '3232389338', 'victoriacanoc5605626@mail.com', 'LMAD', 1)
INSERT INTO Alumno Values('7376031', 'Clotilde Eulalia', 'Gallardo', 'Iglesias', 'Colonia Flores 969 Autopista', '7598787611', 'clotildegallardoi859347@mail.com', 'LA', 8)
INSERT INTO Alumno Values('7289352', 'Celso', 'Soto', 'Cabrera', 'Los Arrayanes 586 Vega de Guerrero', '9085051027', 'celsosotoc0995538711@mail.com', 'LSTI', 6)
INSERT INTO Alumno Values('8429804', 'Marta', 'Cano', 'Benítez', 'El Zapote del Milagro 800 Nuevo Porvenir', '0001984425', 'martacanob90475600@mail.com', 'LCC', 4)
INSERT INTO Alumno Values('1431238', 'Primo', 'Vidal', 'Cortés', 'El Sabino 139 Cabeza de Agua (San Antonio)', '9657185158', 'primovidalc0249516@mail.com', 'LA', 1)
INSERT INTO Alumno Values('4234172', 'Edgar Otilia', 'Gallardo', 'Cano', 'Los Placeres 198 Zona Central', '2683208370', 'edgargallardoc6745@mail.com', 'LCC', 2)
INSERT INTO Alumno Values('8966761', 'Cayetano Alejandro', 'Santiago', 'Vargas', 'Bordo la Luz 997 Loma de Caballo 2a. Sección', '9409095004', 'cayetanosantiagov887057@mail.com', 'LMAD', 2)
INSERT INTO Alumno Values('6340889', 'Joel Julián', 'Moreno', 'Ferrer', 'Los Pericos 573 El Edén', '3148363376', 'joelmorenof32293192@mail.com', 'LCC', 9)
INSERT INTO Alumno Values('4981323', 'Cristóbal Clara', 'Soler', 'Fernández', 'La Estancia 923 Magdalena', '4119447562', 'cristóbalsolerf921423865@mail.com', 'LM', 1)
INSERT INTO Alumno Values('9925312', 'Genoveva Yolanda', 'Velasco', 'Bravo', 'Bordo la Luz 452 Álvaro Luna', '8506812720', 'genovevavelascob9150190990@mail.com', 'LSTI', 9)
