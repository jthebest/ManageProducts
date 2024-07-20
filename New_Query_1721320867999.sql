-- Create the managers table
CREATE TABLE MANAGE (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

-- Create the products table
CREATE TABLE PRODUCT (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    content TEXT,
    update_time DATETIME,
    archived BOOLEAN DEFAULT FALSE,
    manage_id BIGINT,
    FOREIGN KEY (manage_id) REFERENCES MANAGE(id)
);

-- Optionally, add an index on the manage_id column for better performance
CREATE INDEX idx_product_manage_id ON PRODUCT(manage_id);


