
CREATE TABLE Person
(
	Identification NVARCHAR(10) NOT NULL,
	Name NVARCHAR(30) NULL,
	Age INT NULL,
	Sex NVARCHAR(1) NULL,
	Pulsation DECIMAL(3,1) NULL

)

ALTER TABLE Person ADD CONSTRAINT PK_Identification PRIMARY KEY(Identification);
SELECT * FROM Person;