CREATE DATABASE FONCIER;

\c FONCIER;

CREATE TABLE TERRITORY (
    cin varchar(12) not null,
    localisation varchar(255) not null,
    adress_local varchar(255) not null,
    size int,
    form varchar,
    descri varchar(255),
    titre varchar(255) not null
);