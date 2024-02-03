create database BeautifulGirl COLLATE Cyrillic_General_CI_AS;
go

use BeautifulGirl

--удаление таблиц
drop table Orders;
drop table Services;
drop table Types;
drop table Intervals;
drop table Shifts;
drop table Users;
drop table Roles;

create table Users
(
    Id int primary key not null identity(1,1),
    ChatId int,
    UserName nvarchar(50) unique,
    Name nvarchar(50) not null,
    Phone nvarchar(30) not null unique,
    Mail nvarchar(30) unique,
    RoleId int not null,
    Salary decimal,
    IsBlocked bit default 0,
    IsDeleted bit default 0
)

create table Roles
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null unique,
    IsDeleted bit not null default 0
)

create table Shifts
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null,
    StartTime datetime not null,
    EndTime datetime not null,
    MasterId int,
    IsDeleted bit not null default 0
)

create table Intervals
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null,
    ShiftId int not null,
    StartTime datetime not null,
    IsBusy bit not null default 0,
    IsDeleted bit not null default 0
)

create table Services
(
    Id int primary key not null identity(1,1),
    Title nvarchar(50) not null unique,
    TypeId int not null,
    Duration nvarchar(20) not null,
    Price decimal not null,
    IsDeleted bit not null default 0
)

create table Types
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null unique,
    IsDeleted bit not null default 0
)

create table Orders
(
    Id int primary key not null identity(1,1),
    Date datetime not null,
    MasterId int not null,
    ClientId int not null,
    ServiceId int not null,
    StartIntervalId int not null,
    IsCompleted bit not null default 0,
    IsDeleted bit not null default 0
)

alter table Users add foreign key (RoleId) references Roles(Id)
alter table Shifts add foreign key (MasterId) references Users(Id)
alter table Intervals add foreign key (ShiftId) references Shifts(Id)
alter table Services add foreign key (TypeId) references Types(Id)
alter table Orders add foreign key (MasterId) references Users(Id)
alter table Orders add foreign key (ClientId) references Users(Id)
alter table Orders add foreign key (ServiceId) references Services(Id)
alter table Orders add foreign key (StartIntervalId) references Intervals(Id)


insert into Roles (Title) values('Администратор салона'), ('Мастер'), ('Клиент')

insert into Users (ChatId, UserName, Name, Phone, Mail, RoleId, Salary) values(1, '@yhgkli', 'Иван Петрович Веселов', '89663542334', 'gdeakueh@dsejdfek', 1, 50000),
                                                                              (2, '@w;kfop', 'Анна Петровна Брек', '8923467127', 'ewqgtg@fsfgs', 2, 50000), (3, '@;jxiqau', 'Ирина Васильевна Вассильева', '8924350512', 'hseyje@gesdtt', 2, 50000),
                                                                              (4, '@lraikv', 'Оксана Дмитриевна Кек', '877566588690', 'farse@hsdt6rh', 3, null), (5, '@yliivl;i', 'Снежанна Витальевна Соловьева', '892136234', 'gwghw5gh@dsejdfkrutek', 3, null),
                                                                              (6, '@goijrdnr', 'Кристина Валерьевна Заливняк', '642894209', 'fs5g@grq', 3, null)

insert into Shifts (Title, StartTime, EndTime, MasterId) values('УТРО (10:00 - 13:45)', '02/01/2024 10:00', '02/01/2024 13:45', 2),
                                                               ('ДЕНЬ (14:00 - 17:45)', '02/01/2024 14:00', '02/01/2024 17:45', 2),
                                                               ('ВЕЧЕР (18:00 - 21:45)', '02/01/2024 18:00', '02/01/2024 21:45', 3)

insert into Intervals (Title, ShiftId, StartTime) values('10:00', 1, '02/02/2024 10:00'), ('11:00', 1, '02/02/2024 11:00'), ('12:00', 1, '02/02/2024 12:00'),
                                                        ('13:00', 1, '02/02/2024 13:00'), ('14:00', 2, '02/02/2024 14:00'), ('15:00', 2, '02/02/2024 15:00'), ('16:00', 2, '02/02/2024 16:00'), ('17:00', 2, '02/02/2024 17:00'),
                                                        ('18:00', 3, '02/02/2024 18:00'), ('19:00', 3, '02/02/2024 19:00'), ('20:00', 3, '02/02/2024 20:00'), ('21:00', 3, '02/02/2024 21:00')

insert into Types (Title) values('Стрижка'), ('Покраска'), ('Укладка'), ('Макияж'), ('Маникюр'), ('Педикюр'), ('Эпиляция'),('Пиллинг'), ('Обертывание'),('Массаж')

insert into Services (Title, TypeId, Duration, Price) values('Подравнять кончики', 1, '01:00', 700), ('Стрижка машинкой', 1, '00:30', 500),
                                                            ('Стрижка до 25 см', 1, '00:45', 1000), ('Стрижка от 25 см', 1, '01:00', 1250), ('Стрижка от 50 см', 1, '01:15', 1500)

insert into Orders (Date, MasterId, ClientId, ServiceId, StartIntervalId) values('02/02/2024', 2, 4, 1, 1)
