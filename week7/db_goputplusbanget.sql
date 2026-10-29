-- Database Creation
CREATE DATABASE IF NOT EXISTS db_goputplusbanget;
USE db_goputplusbanget;

-- Table: Restaurants
CREATE TABLE Restaurants (
    RestaurantID VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    OpeningHours VARCHAR(50) NOT NULL
);

INSERT INTO Restaurants (RestaurantID, Name, Address, Phone, Email, OpeningHours) VALUES
('RES001', 'Pizza Palace', 'Jl. Pizza No. 11, Jakarta', '081234567890', 'contact@pizzapalace.com', '10:00 - 22:00'),
('RES002', 'Sushi World', 'Jl. Sushi No. 22, Bandung', '081298765432', 'contact@sushiworld.com', '11:00 - 21:00'),
('RES003', 'Snack Heaven', 'Jl. Snack No. 33, Surabaya', '081223344556', 'contact@snackheaven.com', '09:00 - 20:00'),
('RES004', 'Burger Joint', 'Jl. Burger No. 44, Bali', '081987654321', 'contact@burgerjoint.com', '10:00 - 23:00'),
('RES005', 'Healthy Bites', 'Jl. Health No. 55, Yogyakarta', '081112223344', 'contact@healthybites.com', '08:00 - 18:00');

-- Table: MenuItems
CREATE TABLE MenuItems (
    MenuID VARCHAR(10) PRIMARY KEY,
    RestaurantID VARCHAR(10) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Price INT NOT NULL,
    Category ENUM('Makanan', 'Minuman', 'Snack') NOT NULL,
    IsVegan BOOLEAN NOT NULL,
    FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID)
);

INSERT INTO MenuItems (MenuID, RestaurantID, Name, Price, Category, IsVegan) VALUES
('MEN001', 'RES001', 'Pepperoni Pizza', 89900, 'Makanan', 0),
('MEN002', 'RES001', 'Cheese Pizza', 79900, 'Makanan', 1),
('MEN003', 'RES002', 'Salmon Sushi', 129900, 'Makanan', 0),
('MEN004', 'RES002', 'Avocado Roll', 69900, 'Makanan', 1),
('MEN005', 'RES003', 'Potato Chips', 29900, 'Snack', 1),
('MEN006', 'RES003', 'Chocolate Bar', 19900, 'Snack', 1),
('MEN007', 'RES004', 'Classic Burger', 99900, 'Makanan', 0),
('MEN008', 'RES004', 'Vegan Burger', 109900, 'Makanan', 1),
('MEN009', 'RES005', 'Caesar Salad', 79900, 'Makanan', 0),
('MEN010', 'RES005', 'Smoothie', 49900, 'Minuman', 1);

-- Table: Orders
CREATE TABLE Orders (
    OrderID VARCHAR(10) PRIMARY KEY,
    RestaurantID VARCHAR(10) NOT NULL,
    CustomerName VARCHAR(100) NOT NULL,
    CustomerAddress VARCHAR(255) NOT NULL,
    CustomerPhone VARCHAR(15) NOT NULL,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    OrderStatus ENUM('Berhasil', 'Gagal', 'Pending') DEFAULT 'Pending',
    FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID)
);

INSERT INTO Orders (OrderID, RestaurantID, CustomerName, CustomerAddress, CustomerPhone, OrderDate, OrderStatus) VALUES
('ORD001', 'RES001', 'John Doe', 'Jl. Mangga No. 11, Jakarta', '081234567890', '2023-11-25 12:30:00', 'Berhasil'),
('ORD002', 'RES002', 'Jane Doe', 'Jl. Durian No. 22, Bandung', '081298765432', '2023-11-25 13:45:00', 'Pending'),
('ORD003', 'RES003', 'Alice Wonder', 'Jl. Apel No. 33, Surabaya', '081223344556', '2023-11-26 14:00:00', 'Gagal'),
('ORD004', 'RES004', 'Bob Marley', 'Jl. Nanas No. 44, Bali', '081987654321', '2023-11-26 15:15:00', 'Berhasil'),
('ORD005', 'RES005', 'Charlie Zee', 'Jl. Anggur No. 55, Yogyakarta', '081112223344', '2023-11-27 16:00:00', 'Pending'),
('ORD006', 'RES001', 'Diana Prince', 'Jl. Sakura No. 10, Jakarta', '081345678910', '2023-11-28 10:00:00', 'Pending'),
('ORD007', 'RES002', 'Bruce Wayne', 'Jl. Mawar No. 20, Bandung', '081223344556', '2023-11-28 11:30:00', 'Berhasil'),
('ORD008', 'RES003', 'Clark Kent', 'Jl. Anggrek No. 15, Surabaya', '081567890123', '2023-11-29 12:00:00', 'Gagal'),
('ORD009', 'RES004', 'Tony Stark', 'Jl. Melati No. 25, Bali', '081987654321', '2023-11-29 13:45:00', 'Berhasil'),
('ORD010', 'RES005', 'Steve Rogers', 'Jl. Kenanga No. 30, Yogyakarta', '081112223344', '2023-11-30 15:30:00', 'Berhasil');
('ORD011', 'RES001', 'Peter Parker', 'Jl. Mawar No. 12, Jakarta', '081345678901', '2023-12-01 12:00:00', 'Berhasil'),
('ORD012', 'RES002', 'Natasha Romanoff', 'Jl. Melati No. 22, Bandung', '081223344567', '2023-12-02 13:30:00', 'Pending'),
('ORD013', 'RES003', 'Stephen Strange', 'Jl. Cemara No. 33, Surabaya', '081998877665', '2023-12-03 14:45:00', 'Gagal'),
('ORD014', 'RES004', 'Wanda Maximoff', 'Jl. Anggrek No. 44, Bali', '081667788990', '2023-12-04 15:15:00', 'Berhasil'),
('ORD015', 'RES005', 'Sam Wilson', 'Jl. Durian No. 55, Yogyakarta', '081556677889', '2023-12-05 16:00:00', 'Pending');

-- Table: HTransOrder
CREATE TABLE HTransOrder (
    HTransID VARCHAR(10) PRIMARY KEY,
    OrderID VARCHAR(10) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

INSERT INTO HTransOrder (HTransID, OrderID) VALUES
('HT001', 'ORD001'),
('HT002', 'ORD002'),
('HT003', 'ORD003'),
('HT004', 'ORD004'),
('HT005', 'ORD005'),
('HT006', 'ORD006'),
('HT007', 'ORD007'),
('HT008', 'ORD008'),
('HT009', 'ORD009'),
('HT010', 'ORD010');
('HT011', 'ORD011'),
('HT012', 'ORD012'),
('HT013', 'ORD013'),
('HT014', 'ORD014'),
('HT015', 'ORD015');

-- Table: DTransOrder
CREATE TABLE DTransOrder (
    DTransID VARCHAR(10) PRIMARY KEY,
    HTransID VARCHAR(10) NOT NULL,
    MenuID VARCHAR(10) NOT NULL,
    Quantity INT NOT NULL,
    Subtotal INT NOT NULL,
    FOREIGN KEY (HTransID) REFERENCES HTransOrder(HTransID),
    FOREIGN KEY (MenuID) REFERENCES MenuItems(MenuID)
);

INSERT INTO DTransOrder (DTransID, HTransID, MenuID, Quantity, Subtotal) VALUES
('DT001', 'HT001', 'MEN001', 2, 179800),
('DT002', 'HT001', 'MEN002', 1, 79900),
('DT003', 'HT001', 'MEN005', 3, 89900),
('DT004', 'HT002', 'MEN003', 1, 129900),
('DT005', 'HT002', 'MEN004', 3, 209700),
('DT006', 'HT002', 'MEN006', 2, 39900),
('DT007', 'HT003', 'MEN005', 6, 119400),
('DT008', 'HT003', 'MEN008', 2, 219800),
('DT009', 'HT003', 'MEN001', 3, 269700),
('DT010', 'HT004', 'MEN007', 5, 499500),
('DT011', 'HT004', 'MEN009', 2, 159800),
('DT012', 'HT005', 'MEN005', 4, 119600),
('DT013', 'HT005', 'MEN010', 3, 149700),
('DT014', 'HT005', 'MEN004', 2, 139800),
('DT015', 'HT005', 'MEN006', 1, 19900),
('DT016', 'HT006', 'MEN007', 1, 99900),
('DT017', 'HT006', 'MEN009', 2, 159800),
('DT018', 'HT006', 'MEN002', 3, 239700),
('DT019', 'HT007', 'MEN003', 2, 259800),
('DT020', 'HT007', 'MEN004', 1, 69900),
('DT021', 'HT007', 'MEN005', 3, 89900),
('DT022', 'HT008', 'MEN006', 2, 39900),
('DT023', 'HT008', 'MEN007', 4, 399600),
('DT024', 'HT008', 'MEN008', 2, 219800),
('DT025', 'HT009', 'MEN009', 1, 79900),
('DT026', 'HT009', 'MEN010', 5, 249500),
('DT027', 'HT009', 'MEN002', 3, 239700),
('DT028', 'HT010', 'MEN001', 2, 179800),
('DT029', 'HT010', 'MEN003', 1, 129900),
('DT030', 'HT010', 'MEN004', 1, 69900),
('DT031', 'HT001', 'MEN005', 2, 59900),
('DT032', 'HT002', 'MEN010', 3, 149700),
('DT033', 'HT003', 'MEN008', 1, 109900),
('DT034', 'HT004', 'MEN007', 1, 99900),
('DT035', 'HT005', 'MEN006', 1, 19900),
('DT036', 'HT006', 'MEN009', 2, 159800),
('DT037', 'HT007', 'MEN001', 3, 269700),
('DT038', 'HT008', 'MEN005', 3, 89900),
('DT039', 'HT009', 'MEN002', 2, 159800),
('DT040', 'HT010', 'MEN004', 2, 139800);
('DT041', 'HT011', 'MEN001', 1, 89900),
('DT042', 'HT011', 'MEN002', 2, 159800),
('DT043', 'HT012', 'MEN003', 1, 129900),
('DT044', 'HT012', 'MEN004', 1, 69900),
('DT045', 'HT012', 'MEN005', 3, 89900),
('DT046', 'HT013', 'MEN006', 2, 39900),
('DT047', 'HT013', 'MEN007', 2, 199800),
('DT048', 'HT013', 'MEN008', 3, 329700),
('DT049', 'HT014', 'MEN009', 1, 79900),
('DT050', 'HT014', 'MEN010', 2, 99900),
('DT051', 'HT014', 'MEN002', 4, 319600),
('DT052', 'HT015', 'MEN001', 3, 269700),
('DT053', 'HT015', 'MEN003', 1, 129900),
('DT054', 'HT015', 'MEN004', 2, 139800),
('DT055', 'HT015', 'MEN005', 1, 29900);