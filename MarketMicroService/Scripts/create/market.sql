CREATE TABLE markets (
    id VARCHAR(255) PRIMARY KEY,
    name VARCHAR(255),
    description TEXT,
    city VARCHAR(100),
    address VARCHAR(255),
    createdAt DATETIME,
    updatedAt DATETIME
);