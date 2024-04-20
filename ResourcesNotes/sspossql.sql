-- Create database SSPOS
CREATE DATABASE SSPOS;

-- Use the SSPOS database
USE SSPOS;

-- Create TableList table
CREATE TABLE TableList (
    TableID INT PRIMARY KEY IDENTITY,
    TableNo VARCHAR(10)
);

-- Create Products table
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    Code INT,
	UOM VARCHAR(50),
    Price DECIMAL(10,2),
    ProductType VARCHAR(50),
	Loose BOOLEAN,
	Category VARCHAR(20),
	Subcategory VARCHAR(20),
    RegularPrice DECIMAL(10,2),
    DirectPrice DECIMAL(10,2),
    OutsidePrice DECIMAL(10,2),
    CreatedBy VARCHAR(100),
    CreatedDate DATETIME DEFAULT GETDATE(),
    ModifiedBy VARCHAR(100),
    ModifiedDate DATETIME DEFAULT GETDATE() ,
    IsDeleted BOOLEAN
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    TableID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (TableID) REFERENCES TableList(TableID)
);

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL(10,2),
	Amount DECIMAL(10,2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);


-- Inserting data into the Product table
INSERT INTO Product (Name, Barcode, Price)
VALUES
('Khodays XXX Rum 375 MI (0001)', '00010300102', 179.69),
('Hercules Delux 3 X Rum 750 MI (0001)', '00010300301', 316.33),
('HERCULES XXX RUM 90MLx96Btls(0001)', '00010300252', 57.93),
('Hercules XXX Rum 180 MI (0001)', '00010300204', 115.84),
('Hercules XXX Rum 375 MI (0001)', '00010300202', 239.62),
('Hercules XXX Rum 750 MI (0001)', '00010300201', 479.24),
('Khodays XXX Rum 120MLx72Btls(0001)', '00010300181', 39.2),
('Khodays XXX Rum 90MLx96Btls (0001)', '00010300152', 53.12),
('Khodays XXX Rum 60MLx150Btls(0001)', '00010300107', 19.57),
('Khodays XXX Rum 1000MLx9Btls(0001)', '00010300105', 479.16),
('Khodays XXX Rum 180 MI (0001)', '00010300104', 86.76),
('Hercules Delux 3 X Rum 375 MI (0001)', '00010300302', 158.16),
('Khodays XXX Rum 750 MI (0001)', '00010300101', 359.37),
('Sovereign Pure Brandy-ASEPTIC Pack 90ML Aseptic pack(0001)', '00010290752', 53.12),
('Sovereign Pure Brandy-ASEPTIC Pack 180ML Aspetic Pack(0001)', '00010290704', 86.76),
('Sovereign Brandy-STANDY PACK 90MLx96Btls(0001)', '00010290152', 35.45),
('Sovereign Brandy-STANDY PACK 60MLx150Btls(0001)', '00010290107', 18.98),
('Sovereign Brandy-STANDY PACK 180ML(0001)', '00010290104', 57.42),
('Sovereign PURE Brandy-(Standy Pack) 90ML(0001)', '00010250752', 35.45),
('Sovereign PURE Brandy 120MLx72Btls(0001)', '00010200781', 39.2),
('Hercules Old Matured Deluxe 3X Rum 90MLx96Btls (0001)', '00010300852', 99.12),
('Sovereign PURE Brandy 180ML(0001)', '00010200704', 86.76),
('Sovereign PURE Brandy 375ML(0001)', '00010200702', 179.69),
('Crystal No 1 Cocktail Spl Dry Gin 180 MI (0001)', '00010400304', 41.88),
('Crystal No 1 Cocktail Spl Dry Gin 375 MI (0001)', '00010400302', 86.27),
('Crystal No 1 Cocktail Spl Dry Gin 750 MI (0001)', '00010400301', 172.55),
('Hercules Old Matured Deluxe 3X Rum-Aseptic pack 180ML Aseptic pack(0001)', '00010390804', 198.23),
('Khodays XXX Rum-(ASEPTIC PAK) 90ML Aseptic pack(0001)', '00010390152', 53.12),
('Khodays XXX Rum-(ASEPTIC PAK) 180ML(0001)', '00010390104', 86.76),
('Khodays XXX Rum 750MLx12Btls(0001)', '00010300901', 568.24),
('Hercules Old Matured Deluxe 3X Rum 120MLx72Btls(0001)', '00010300881', 82.53),
('Sovereign PURE Brandy 1000MLx9Btls(0001)', '00010200705', 479.16),
('Hercules Old Matured Deluxe 3X Rum 60MLx150Btls(0001)', '00010300807', 65.74),
('Hercules Old Matured Deluxe 3X Rum 1000MLx9Btls(0001)', '00010300805', 1095.67),
('Hercules Old Matured Deluxe 3X Rum 180ML(0001)', '00010300804', 220.45),
('Hercules Old Matured Deluxe 3X Rum 375ML(0001)', '00010300802', 410.87),
('Hercules Old Matured Deluxe 3X Rum 750ML(0001)', '00010300801', 821.74),
('KhodayS Five Star XXX Rum 180ml(0001)', '00010300704', 32.77),
('KhodayS Five Star XXX Rum 375ml (0001)', '00010300702', 67.6),
('KhodayS Five Star XXX Rum 750ml (0001)', '00010300701', 135.19),
('Hercules Delux 3 X Rum 180 MI (0001)', '00010300304', 76.77),
('Sovereign Deluxe Whisky 180 MI (0001)', '00010100704', 53.63),
('Khodays Five Star Whisky 180ML(0001)', '00010101004', 55.97),
('Khodays Five Star Whisky 375ML(0001)', '00010101002', 115.73),
('Khodays Five Star Whisky 750ML(0001)', '00010101001', 231.47),
('Red Knight Reserve Malt Blended Whisky 180ML(0001)', '00010100904', 123.81),
('Red Knight Reserve Malt Blended Whisky 375ML(0001)', '00010100902', 255.88);


update Product set RegularPrice=(price*1.1),DirectPrice=price*1.05,OutsidePrice=price*1.08;	