-- Создание базы данных
Create database [Stomotologia]
on primary
(name='Stomotologia',filename='D:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Stomotologia.mdf', size=100mb, maxsize=400mb, filegrowth=10%)
log on
(name='Stomotologia_log',filename='D:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Stomotologia_log.ldf',size=50mb, maxsize=200mb, filegrowth=10%);
go
-- Выборка базы данных
USE [Stomotologia]
go
-- Создание таблицы Пациенты +
Create table Patients
(
ID int identity(1,1) not null primary key (ID),-- +
Surname nvarchar(MAX) not null CHECK(Surname !=''),-- +
Name nvarchar(MAX) not null CHECK(Name!=''),-- +
Middlename nvarchar(MAX) not null CHECK(Middlename !=''),-- +
Date_of_Birth date CHECK(Date_of_Birth <=GETDATE()) not null,-- +
Address nvarchar(MAX) not null CHECK(Address!=''),-- +
Phone nvarchar(50) not null CHECK(Phone !=''),-- +
Email nvarchar(100)
);
go
-- Создание таблицы Врачи +
CREATE TABLE Doctors
(
ID int identity(1,1) not null primary key (ID),-- +
Surname nvarchar(MAX) not null CHECK(Surname !=''),-- +
Name nvarchar(MAX) not null CHECK(Name!=''),-- +
Middlename nvarchar(MAX) not null CHECK(Middlename !=''),-- +
Specialty nvarchar(255) not null CHECK(Specialty !=''),-- +
Experience INT not null CHECK(Experience >= 0 and Experience <= 35),-- +
Category nvarchar(255) not null CHECK(Category !='')-- +
);
go
-- Создание таблицы Приемы +
CREATE TABLE Appointments(
ID int identity(1,1) not null primary key (ID),-- +
ID_Patient INT not null,-- +
ID_Doctor INT not null,-- +
Date_Appointment DATE not null,-- +
Diagnosis nvarchar(255) not null CHECK(Diagnosis !=''),-- +
Treatment nvarchar(255) default 'лечение не требуется',-- +
Cost DECIMAL(10, 2) not null,-- +
constraint FK_01 FOREIGN KEY (ID_Patient) REFERENCES Patients(ID),
constraint FK_02 FOREIGN KEY (ID_Doctor) REFERENCES Doctors(ID)
);
go
-- Создание таблицы Услуги +
CREATE TABLE Services(
ID int identity(1,1) not null primary key (ID),-- +
Name nvarchar(255) not null CHECK(Name!=''),-- +
Description nvarchar(MAX) CHECK(Description!=''),-- +
Price DECIMAL(10, 2) not null,-- +
ID_Appointment INT not null,-- +
constraint FK_06 FOREIGN KEY (ID_Appointment) REFERENCES Appointments(ID)
);
go
-- Создание таблицы Оборудование +
CREATE TABLE Equipment(
ID int identity(1,1) not null primary key (ID),-- +
Name nvarchar(255) not null CHECK(Name!=''),-- +
Model nvarchar(255) not null CHECK(Model !=''),-- +
InventoryNumber nvarchar(255) not null CHECK(InventoryNumber !=''),-- +
PurchaseDate DATE not null,-- +
ID_Appointment INT not null,-- +
constraint FK_07 FOREIGNKEY (ID_Appointment) REFERENCES Appointments(ID)
);
go
-- Создание таблицы Расходные_материалы +
CREATE TABLE Consumables(
ID int identity(1,1) not null primary key (ID),-- +
Name nvarchar(255) not null CHECK(Name!=''),-- +
Quantity INT not null,-- +
PricePerUnit DECIMAL(10, 2) not null,-- +
Supplier nvarchar(255) not null CHECK(Supplier !='')-- +
);
go
-- Создание таблицы Складской_учет +
CREATE TABLE StockRecord(
ID int identity(1,1) not null primary key (ID),-- +
ID_Consumable INT not null,-- +
DateReceipt DATE not null,-- +
Quantity INT not null,-- +
ID_Appointment INT not null,-- +
constraint FK_03 FOREIGN KEY (ID_Consumable)REFERENCES Consumables(ID),
constraint FK_04 FOREIGN KEY (ID_Appointment)REFERENCES Appointments(ID)
);
go
-- Создание таблицы Сотрудники +
CREATE TABLE Employees(
ID int identity(1,1) not null primary key (ID),-- +
Surname nvarchar(MAX) not null CHECK(Surname !=''),-- +
Name nvarchar(MAX) not null CHECK(Name!=''),-- +
Middlename nvarchar(MAX) not null CHECK(Middlename !=''),-- +
Position nvarchar(255) CHECK(Position !=''),-- +
Salary DECIMAL(10, 2) not null,-- +
DateOfEmployment DATE not null,-- +
ID_Appointment INT not null,-- +
constraint FK_08 FOREIGN KEY (ID_Appointment)REFERENCES Appointments(ID)
);
go
-- Создание таблицы Отзывы
CREATE TABLE Reviews(
ID int identity(1,1) not null primary key(ID),
ID_Patient INT not null,
TextReview nvarchar(255) not null CHECK(TextReview !=''),
Rating INT not null CHECK(Rating >= 0 and Rating <= 5),
DatePublication DATE not null,
constraint FK_05 FOREIGN KEY (ID_Patient) REFERENCES Patients(ID)
);
go
-- Создание таблицы Акции
CREATE TABLE Actions(
ID int identity(1,1) not null primary key(ID),
Name nvarchar(255) not null CHECK(Name!=''),
Description nvarchar(255) not null CHECK(Description!=''),
StartDate DATE not null,
EndDate DATE not null,
ID_Appointment INT not null,
constraint FK_09 FOREIGN KEY (ID_Appointment) REFERENCES Appointments(ID)
);
