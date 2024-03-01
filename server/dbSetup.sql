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

CREATE TABLE ingredients(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(40) NOT NULL,
  quantity VARCHAR(50) NOT NULL,
  recipeId INT,
  Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE favorites(
  id INT AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  recipeId int NOT NULL,
  Foreign Key (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE reviews(
  id INT AUTO_INCREMENT PRIMARY KEY,
  body VARCHAR(200) NOT NULL,
  score INT NOT NULL,
  recipeId INT NOT NULL,
  accountId VARCHAR(255) NOT NULL,
  Foreign Key (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE instruction(
  id INT AUTO_INCREMENT PRIMARY KEY,
  body VARCHAR(200) NOT NULL,
  step INT DEFAULT 0,
  recipeId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
        INSERT INTO reviews
        (body, score, recipeId, accountId)
        VALUES
        ('wow', 2, 141, '65837617fb48f6cd659dd941');
        
        SELECT
        reviews.*,
        accounts.*
        FROM reviews
        JOIN accounts ON reviews.accountId = accounts.id
        WHERE reviews.id = LAST_INSERT_ID()

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = 55


        UPDATE recipes SET
        title = "yes",
        instructions = "so cool",
        img = "wow",
        category = "Soup"
        WHERE id = 2;

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = 2

        INSERT INTO ingredients
        (name, quantity, recipeId)
        VALUES
        ("wow", "so cool", 5);


        SELECT
        ingredients.*,
        recipes.*
        FROM ingredients
        JOIN recipes ON ingredients.recipeId = recipes.id
        WHERE ingredients.recipeId = 55

        SELECT
        *
        FROM ingredients
        WHERE id = 5

       SELECT
        *
        FROM recipes
        WHERE category = 'Soup'


        SELECT
        *
        FROM recipes
        WHERE title LIKE 'lunch'