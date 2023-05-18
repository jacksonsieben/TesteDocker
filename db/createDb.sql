CREATE DATABASE IF NOT EXISTS teste;
USE teste;

CREATE TABLE IF NOT EXISTS pessoa(
    id INT (11) AUTO_INCREMENT,
    nome varchar(255) NOT NULL,
    sobrenome varchar(255) NOT NULL,
    PRIMARY KEY (id)
);

INSERT INTO pessoa VALUE(0, "Jackson", "Sieben");
INSERT INTO pessoa VALUE(0, "Gustavo", "Silva");