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
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
	IsDeleted bit not null default 0
)
go

create table Category (
	Id varchar(200) not null primary key,
	Name varchar(50) not null unique,
	Slug varchar(50) not null unique,
	Image varchar(200) not null unique,
	ParentId varchar(200) default 0,
	IsActived bit not null default 1,
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
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
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
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
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
	IsDeleted bit not null default 0
)
go

create table ProductProperty (
	Id varchar(200) not null primary key,
	Slug varchar(50) not null unique,
	CategoryId varchar(200) not null foreign key references Category(Id),
	Name varchar(50) not null unique,
	IsActived bit not null default 1,
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
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
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
	IsDeleted bit not null default 0
)
go

create table ProductImage (
	Id varchar(200) not null primary key,
	ProductId varchar(200) not null foreign key references Product(Id),
	Image varchar(200) not null unique,
	IsActived bit not null default 1,
	CreatedAt datetime default getdate(),
	CreatedBy varchar(200),
	UpdatedAt datetime,
	UpdatedBy varchar(200),
	DeletedAt datetime,
	DeleedBy varchar(200),
	IsDeleted bit not null default 0
)
go