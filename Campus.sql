CREATE TABLE Country (
    Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);
CREATE TABLE State(
    Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50),
    IdcountryFk int NOT NULL,
    KEY IX_state_IdcountryFk (IdcountryFk),
    CONSTRAINT FK_state_country_IdcountryFk FOREIGN KEY (IdcountryFk) REFERENCES country (Id)
);
CREATE TABLE City(
    Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    IdStateFk int NOT NULL,
    KEY IX_City_IdstateFk (IdstateFk),
    CONSTRAINT FK_City_State_IdstateFk FOREIGN KEY (IdstateFk) REFERENCES state (Id)
);
CREATE TABLE Costumer(
    Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    IdCustomer varchar(255) NOT NULL,
    IdPersonTypeFk int NOT NULL,
    date_register date NOT NULL,
    IdCityFk int NOT NULL,
    KEY IX_Customer_IdCustomer (IdCustomer),
    KEY IX_customer_IdcityFk (IdcityFk),
    KEY IX_customer_IdPersonTypeFk (IdPersonTypeFk),
    CONSTRAINT FK_Customer_IdCustomer UNIQUE KEY U_IdCustomer (IdCustomer),
    CONSTRAINT FK_customer_city_IdcityFk FOREIGN KEY (IdcityFk) REFERENCES city (Id),
    CONSTRAINT FK_customer_PersonType_IdPersonTypeFk FOREIGN KEY (IdPersonTypeFk) REFERENCES PersonType (Id)
);
CREATE TABLE PersonType(
    Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL
);