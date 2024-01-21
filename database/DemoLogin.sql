create database SalvationStore
go

use SalvationStore
go

create table Account (
	Id bigint not null primary key identity,
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
	Id bigint not null primary key identity,
	Name varchar(50) not null unique,
	Image varchar(200) not null unique,
	ParentId bigint default 0,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table Manufacture (
	Id bigint not null primary key identity,
	Name varchar(50) not null unique,
	Image varchar(200) not null unique,
	Website varchar(200) not null unique,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table Product (
	Id bigint not null primary key identity,
	CategoryId bigint not null foreign key references Category(Id),
	ManufactureId bigint not null foreign key references Manufacture(Id),
	Name varchar(50) not null unique,
	FeatureImage varchar(200) not null unique,
	Price bigint not null default 0,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table ProductProperty (
	Id bigint not null primary key identity,
	CategoryId bigint not null foreign key references Category(Id),
	Name varchar(50) not null unique,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table ProductDetail (
	Id bigint not null primary key identity,
	ProductId bigint not null foreign key references Product(Id),
	CategoryId bigint not null foreign key references Category(Id),
	ProductPropertyId bigint not null foreign key references ProductProperty(Id),
	ProductProperty varchar(50), -- Thêm vào để giảm tải việc truy vấn sẽ phải join với bảng ProductProperty
	Value varchar(50),
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

create table ProductImage (
	Id bigint not null primary key identity,
	ProductId bigint not null foreign key references Product(Id),
	Image varchar(200) not null unique,
	IsActived bit not null default 1,
	IsDeleted bit not null default 0
)
go

insert into Account values
('quandh@gmail.com', N'Dư Hồng Quân', '123123', null, null, 1, 0);

select * from Account

insert into Category values
('Son', 'something1', 0, 1, 0),
('Phan', 'something2', 0, 1, 0),
('Nuoc hoa', 'something3', 0, 1, 0),
('Kem', 'something4', 0, 1, 0);