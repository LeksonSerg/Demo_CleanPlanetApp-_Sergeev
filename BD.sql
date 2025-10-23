CREATE DATABASE CleanPlanet;
GO

USE CleanPlanet;
GO

CREATE TABLE Partners (
    PartnerId INT IDENTITY(1,1) PRIMARY KEY,
    PartnerType NVARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Director NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    LegalAddress NVARCHAR(200) NOT NULL,
    INN NVARCHAR(20) NOT NULL,
    Rating INT NOT NULL CHECK (Rating >= 0)
);

CREATE TABLE ServiceTypes (
    ServiceTypeId INT IDENTITY(1,1) PRIMARY KEY,
    ServiceTypeName NVARCHAR(50) NOT NULL,
    ComplexityCoefficient FLOAT NOT NULL
);

CREATE TABLE Services (
    ServiceId INT IDENTITY(1,1) PRIMARY KEY,
    ServiceTypeId INT NOT NULL,
    ServiceName NVARCHAR(100) NOT NULL,
    ServiceCode NVARCHAR(20) NOT NULL,
    MinimalCost DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (ServiceTypeId) REFERENCES ServiceTypes(ServiceTypeId)
);

CREATE TABLE Materials (
    MaterialId INT IDENTITY(1,1) PRIMARY KEY,
    MaterialType NVARCHAR(50) NOT NULL,
    OverheadPercent FLOAT NOT NULL
);

CREATE TABLE PartnerServices (
    PartnerServiceId INT IDENTITY(1,1) PRIMARY KEY,
    PartnerId INT NOT NULL,
    ServiceId INT NOT NULL,
    Quantity INT NOT NULL,
    ExecutionDate DATETIME NOT NULL,
    FOREIGN KEY (PartnerId) REFERENCES Partners(PartnerId),
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId)
);

INSERT INTO Partners (PartnerType, Name, Director, Email, Phone, LegalAddress, INN, Rating)
VALUES 
('ИП', 'Чистый Мир', 'Смирнова Ольга Викторовна', 'olga.smirnova@cm.ru', '495 111 22 33', '123456, г. Москва, ул. Чистая, д. 10', '1234567890', 9),
('ООО', 'Блеск и Глянец', 'Комаров Денис Игоревич', 'denis.komarov@bg.ru', '812 444 55 66', '190000, г. Санкт-Петербург, Невский пр-т, д. 50', '2345678901', 8),
('ИП', 'Свежесть Плюс', 'Николаева Анна Сергеевна', 'anna.nikolaeva@sp.ru', '383 777 88 99', '630000, г. Новосибирск, ул. Лазурная, д. 25', '3456789012', 7),
('ЗАО', 'Уютный Дом', 'Фролов Артем Васильевич', 'artem.frolov@ud.ru', '843 222 33 44', '420000, г. Казань, ул. Уютная, д. 15', '4567890123', 6),
('ООО', 'ЭкоТекстиль', 'Васнецова Ирина Петровна', 'irina.vasnecova@et.ru', '351 555 66 77', '454000, г. Челябинск, пр-т Победы, д. 100', '5678901234', 10);

INSERT INTO ServiceTypes (ServiceTypeName, ComplexityCoefficient)
VALUES 
('Стирка', 1),
('Химчистка', 2.5),
('Ремонт', 3),
('Аквачистка', 1.8),
('Сушка', 0.5);

INSERT INTO Services (ServiceTypeId, ServiceName, ServiceCode, MinimalCost)
VALUES 
(1, 'Стирка постельного белья (до 10 кг)', 'SRV-001', 500),
(1, 'Стирка верхней одежды (куртки, пальто)', 'SRV-002', 800),
(2, 'Химчистка костюма', 'SRV-003', 1200),
(2, 'Химчистка ковра (за кв.м)', 'SRV-004', 300),
(3, 'Ремонт молнии на брюках', 'SRV-005', 250),
(4, 'Аквачистка пуховика', 'SRV-006', 1500),
(5, 'Сушка в барабанной сушилке (цикл)', 'SRV-007', 200);

INSERT INTO Materials (MaterialType, OverheadPercent)
VALUES 
('Порошок', 0.05),
('Растворитель', 0.08),
('Отбеливатель', 0.1),
('Кондиционер', 0.03),
('Пятновыводитель', 0.07),
('Упаковка', 0.02);

INSERT INTO PartnerServices (PartnerId, ServiceId, Quantity, ExecutionDate)
SELECT 
    p.PartnerId,
    s.ServiceId,
    ps.Quantity,
    ps.ExecutionDate
FROM (
    VALUES 
    (1, 1, 150, '2023-03-23T00:00:00'),
    (1, 3, 85, '2023-12-18T00:00:00'),
    (1, 2, 120, '2024-06-07T00:00:00'),
    (2, 4, 350, '2022-12-02T00:00:00'),
    (2, 5, 45, '2023-05-17T00:00:00'),
    (2, 1, 200, '2024-06-07T00:00:00'),
    (2, 6, 30, '2024-07-01T00:00:00'),
    (3, 1, 300, '2023-01-22T00:00:00'),
    (3, 3, 60, '2024-07-05T00:00:00'),
    (4, 2, 180, '2023-03-20T00:00:00'),
    (4, 1, 250, '2024-03-12T00:00:00'),
    (4, 6, 25, '2024-05-14T00:00:00'),
    (5, 1, 500, '2023-09-19T00:00:00'),
    (5, 2, 320, '2023-11-10T00:00:00'),
    (5, 3, 150, '2024-04-15T00:00:00'),
    (5, 4, 420, '2024-06-12T00:00:00')
) AS ps(PartnerIndex, ServiceIndex, Quantity, ExecutionDate)
INNER JOIN Partners p ON p.PartnerId = ps.PartnerIndex
INNER JOIN Services s ON s.ServiceId = ps.ServiceIndex;

CREATE TABLE ServiceMaterials (
    ServiceMaterialId INT IDENTITY(1,1) PRIMARY KEY,
    ServiceId INT NOT NULL,
    MaterialId INT NOT NULL,
    ConsumptionRate FLOAT NOT NULL, -- норма расхода на одну услугу
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId),
    FOREIGN KEY (MaterialId) REFERENCES Materials(MaterialId)
);

CREATE TABLE MaterialPrices (
    MaterialPriceId INT IDENTITY(1,1) PRIMARY KEY,
    MaterialId INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL, -- текущая цена
    EffectiveDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (MaterialId) REFERENCES Materials(MaterialId)
);

INSERT INTO MaterialPrices (MaterialId, Price) VALUES
(1, 150.00), -- Порошок
(2, 300.00), -- Растворитель
(3, 200.00), -- Отбеливатель
(4, 180.00), -- Кондиционер
(5, 250.00), -- Пятновыводитель
(6, 50.00);  -- Упаковка

INSERT INTO ServiceMaterials (ServiceId, MaterialId, ConsumptionRate) VALUES
-- Стирка постельного белья
(1, 1, 0.1), -- Порошок
(1, 4, 0.05), -- Кондиционер
(1, 6, 1),   -- Упаковка

(2, 1, 0.15), -- Порошок
(2, 4, 0.08), -- Кондиционер
(2, 6, 1),    -- Упаковка

(3, 2, 0.2),  -- Растворитель
(3, 5, 0.05), -- Пятновыводитель
(3, 6, 1),    -- Упаковка

(4, 2, 0.1),  -- Растворитель
(4, 5, 0.02), -- Пятновыводитель

(5, 6, 1),    -- Упаковка

(6, 1, 0.2),  -- Порошок
(6, 3, 0.05), -- Отбеливатель
(6, 6, 1);    -- Упаковка