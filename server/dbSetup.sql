CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(40) NOT NULL,
  instructions VARCHAR(500) NOT NULL,
  img VARCHAR(500) NOT NULL,
  category ENUM ("Cheese", "Italian", "Soup", "Mexican", "Specialty Coffee") DEFAULT "Soup",
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE recipes;
