
create table Customer
(
id int IDENTITY(1,1) primary key,
name_ varchar(50),
phone varchar(20),
email varchar(100)
)

create table Car
(
id int IDENTITY(1,1) primary key,
id_customer int,
license_plate varchar(10),
brand int,
color varchar(50),
FOREIGN KEY (id_customer) REFERENCES Customer(id),
FOREIGN KEY (brand) REFERENCES Car_Type(id) 
)

create table Parking
(
id int IDENTITY(1,1) primary key,
name_ varchar(30),
status_ varchar(1)
)

create table Reservation
(
id int IDENTITY(1,1) primary key,
parking_id int,
car_id int,
reservation_start datetime,
reservation_end datetime,
foreign key (parking_id) references Parking (id),
foreign key (car_id) references Car(id)
)
