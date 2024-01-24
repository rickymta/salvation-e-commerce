create database SalvationStore
go

use SalvationStore
go

create table Account (
	Id varchar(200) not null primary key,
	Email varchar(50) not null unique,
	Fullname nvarchar(200) not null,
	Password varchar(200) not null,
	Address ntext,
	Avatar varchar(200),
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table Category (
	Id varchar(200) not null primary key,
	Name varchar(50) not null unique,
	Slug varchar(50) not null unique,
	Image varchar(200) not null unique,
	ParentId bigint default 0,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table Manufacture (
	Id varchar(200) not null primary key,
	Name varchar(50) not null unique,
	Slug varchar(50) not null unique,
	Image varchar(200) not null unique,
	Website varchar(200) not null unique,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table Product (
	Id varchar(200) not null primary key,
	Slug varchar(50) not null unique,
	CategoryId varchar(200) not null foreign key references Category(Id),
	ManufactureId varchar(200) not null foreign key references Manufacture(Id),
	Name varchar(50) not null unique,
	FeatureImage varchar(200) not null unique,
	Price bigint not null default 0,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table ProductProperty (
	Id varchar(200) not null primary key,
	Slug varchar(50) not null unique,
	CategoryId varchar(200) not null foreign key references Category(Id),
	Name varchar(50) not null unique,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table ProductDetail (
	Id varchar(200) not null primary key,
	ProductId varchar(200) not null foreign key references Product(Id),
	CategoryId varchar(200) not null foreign key references Category(Id),
	ProductPropertyId varchar(200) not null foreign key references ProductProperty(Id),
	ProductProperty varchar(50), -- Thêm vào để giảm tải việc truy vấn sẽ phải join với bảng ProductProperty
	Value varchar(50),
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table ProductImage (
	Id varchar(200) not null primary key,
	ProductId varchar(200) not null foreign key references Product(Id),
	Image varchar(200) not null unique,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

insert into Account values
('f856dc10-17ee-4763-bf3d-6e741c6ddfd4', 'quandh@gmail.com', N'Dư Hồng Quân', '123123', null, null, 1, 0);

select * from Account

insert into Category values
('8da3f556-7903-4240-b58f-bfe0b94a6c69', 'Son', 'son', 'something1', 0, 1, 0),
('31723894-0272-4cea-ad07-720d7d8996ed', 'Phan', 'phan', 'something2', 0, 1, 0),
('084f7797-b704-4dd5-9758-a98ab0a1d843', 'Nuoc hoa', 'nuoc-hoa', 'something3', 0, 1, 0),
('1ae16808-bd2f-4be0-ad3b-e25adb35a8c9', 'Kem', 'kem', 'something4', 0, 1, 0);