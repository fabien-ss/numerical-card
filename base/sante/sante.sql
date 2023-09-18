CREATE DATABASE SANTE;

\c SANTE;

CREATE TABLE CIVIL(
    cin varchar(12) PRIMARY KEY,
    name varchar(255) NOT NULL,
    first_name varchar(255),
    date_of_birth timestamp NOT NULL,
    place_of_birth varchar(255),
    address_local varchar(255),
    father varchar(255),
    mother varchar(255),
    date_delivery timestamp NOT NULL
);

CREATE TABLE DISEASE(
    id int(11) SERIAL PRIMARY KEY,
    name varchar(255) NOT NULL
);

CREATE TABLE PERSON_DESEASE(
    cin varchar(255) FOREIGN KEY CIVIL(cin),
    id_desease varchar(255) FOREIGN KEY DISEASE(id),
    date_start timestamp,
    date_end timestamp
);