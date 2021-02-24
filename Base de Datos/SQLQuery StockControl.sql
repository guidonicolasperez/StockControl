-- Especifico la base de datos.
USE StockControl

drop table consumed
drop table item


-- Creo las tablas.
CREATE TABLE item (
	idItem int IDENTITY  NOT NULL,
	itemDescription varchar(max) NOT NULL,
	stock int NOT NULL,
	stockAlert int,
)

CREATE TABLE consumed (
	idConsumed int NOT NULL,
	idItem int NOT NULL,
	dateConsumed date NOT NULL,
	quantityConsumed int NOT NULL,	
)

-- Asigno las PK
ALTER TABLE item ADD PRIMARY KEY (idItem);
ALTER TABLE consumed ADD PRIMARY KEY (idConsumed);

-- Asigno las FK
ALTER TABLE consumed ADD FOREIGN KEY (idItem) REFERENCES item (idItem);

--DELETE FROM ITEM 

INSERT INTO ITEM VALUES ('Martillo', 100, 10);
INSERT INTO ITEM VALUES ('Destornillador', 20, 10);
INSERT INTO ITEM VALUES ('Alicate', 30, 10);
INSERT INTO ITEM VALUES ('Pinza', 40, 10);
INSERT INTO ITEM VALUES ('Llave Inglesa', 50, 10);


SELECT * FROM item

UPDATE ITEM SET ITEMDESCRIPTION ='Martillo', STOCK =400, STOCKALERT =10WHERE IDITEM = 1