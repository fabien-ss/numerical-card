CREATE DATABASE BANQUE;

\c BANQUE;

CREATE TABLE BANQUE(
    id_banque SERIAL PRIMARY KEY,
    banque_name VARCHAR(255) NOT NULL
);

insert into banque(nom) values("BOI");

CREATE sequence seq_banque;

CREATE TABLE INPUT_MONEY(
    cin VARCHAR(12) NOT NULL,
    money_value decimal NOT NULL,
    date_input timestamp NOT NULL,
    id_banque INTEGER REFERENCES BANQUE(id_banque)
);

insert into INPUT_MONEY(cin, money_value, date_input, id_banque)
values('000000000002', 2000000, now(), 1);

CREATE TABLE OUTPUT_MONEY(
    cin VARCHAR(12) NOT NULL,
    money_value decimal NOT NULL,
    date_output timestamp NOT NULL,
    id_banque INTEGER REFERENCES BANQUE(id_banque)
);

insert into OUTPUT_MONEY(cin, money_value, date_output, id_banque)
values('000000000001', 2000000, now(), 1);

CREATE VIEW V_TRANSACTION AS 
    SELECT * FROM INPUT_MONEY UNION SELECT * FROM OUTPUT_MONEY;

CREATE VIEW USER_TOTAL_INPUT AS
    SELECT SUM(money_value) money_value, cin, id_banque FROM INPUT_MONEY
        GROUP BY CIN, id_banque;
    
CREATE VIEW USER_TOTAL_OUTPUT AS
    SELECT SUM(money_value) money_value, cin, id_banque FROM OUTPUT_MONEY
        GROUP BY cin, id_banque;

CREATE VIEW V_MONEY AS
    SELECT (I.money_value - O.money_value) money_total, I.id_banque, B.banque_name, I.cin FROM USER_TOTAL_INPUT I
    JOIN USER_TOTAL_OUTPUT O ON I.cin = O.cin
    JOIN BANQUE B ON I.id_banque = B.id_banque
    group by I.id_banque, I.money_value, O.money_value, I.cin, B.banque_name
    ;