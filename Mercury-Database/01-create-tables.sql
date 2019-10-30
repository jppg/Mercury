/*
drop table if exists taxrate;
drop table if exists salarypackage;
drop table if exists salaryitem;
drop table if exists finantialcondition;
drop table if exists allocation;
drop table if exists employee;
drop table if exists client;
drop table if exists maritalstatus;

*/

CREATE TABLE maritalstatus
(
   maritalstatus_id serial PRIMARY KEY,
   maritalstatus_name varchar(100) NOT NULL
);

CREATE TABLE taxrate(
   taxrate_id serial PRIMARY KEY,
   salarymin NUMERIC NOT NULL,
   salarymax NUMERIC NOT NULL,
   maritalstatus INT NOT NULL,
   nchildrenmin INT NOT NULL,
   nchildrenmax INT NOT NULL,
   taxvalue NUMERIC NOT NULL,
   startdate DATE NOT NULL,
   enddate DATE,
   CONSTRAINT taxrate_maritalstatus_fkey FOREIGN KEY (maritalstatus)
      REFERENCES maritalstatus (maritalstatus_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);


CREATE TABLE client(
   client_id serial PRIMARY KEY,
   client_name varchar(100) NOT NULL,
   startdate DATE NOT NULL,
   enddate DATE
);


CREATE TABLE employee(
   employee_id serial PRIMARY KEY,
   employee_name varchar(100) NOT NULL,
   nchildren INT NOT NULL,
   maritalstatus_id INT NOT NULL,
   startdate DATE NOT NULL,
   enddate DATE,
    CONSTRAINT employee_maritalstatus_fkey FOREIGN KEY (maritalstatus_id)
      REFERENCES maritalstatus (maritalstatus_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE allocation(
   allocation_id serial PRIMARY KEY,
   employee_id INT NOT NULL,
   client_id INT NOT NULL,
   dayrate NUMERIC, 
   startdate DATE NOT NULL,
   enddate DATE,
    CONSTRAINT allocation_employee_fkey FOREIGN KEY (employee_id)
      REFERENCES employee(employee_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT allocation_client_fkey FOREIGN KEY (client_id)
      REFERENCES client (client_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

/*
CREATE table direction(
    direction_id SERIAL PRIMARY KEY,
    direction_name varchar(10) NOT NULL,
    direction_code char(1) NOT NULL,
    rate numeric NOT NULL
);
*/

create TABLE salaryitem(
    salaryitem_id serial PRIMARY KEY,
    salaryitem_name VARCHAR(100) NOT NULL,
    istaxed BOOLEAN NOT NULL,
    firmcostrate NUMERIC,
    employeecostrate NUMERIC,
    defaultvalue NUMERIC,
    percentvalue NUMERIC,
    incauto BOOLEAN,
    jan BOOLEAN NOT NULL DEFAULT FALSE,
    feb BOOLEAN NOT NULL DEFAULT FALSE,
    mar BOOLEAN NOT NULL DEFAULT FALSE,
    apr BOOLEAN NOT NULL DEFAULT FALSE,
    may BOOLEAN NOT NULL DEFAULT FALSE,
    jun BOOLEAN NOT NULL DEFAULT FALSE,
    jul BOOLEAN NOT NULL DEFAULT FALSE,
    aug BOOLEAN NOT NULL DEFAULT FALSE,
    sep BOOLEAN NOT NULL DEFAULT FALSE,
    oct BOOLEAN NOT NULL DEFAULT FALSE,
    nov BOOLEAN NOT NULL DEFAULT FALSE,
    dec BOOLEAN NOT NULL DEFAULT FALSE,
    startdate DATE NOT NULL,
    enddate DATE
);

create TABLE finantialcondition(
    finantialcondition_id serial PRIMARY KEY,
    employee_id INT NOT NULL,    
    startdate DATE NOT NULL,
    enddate DATE,
    CONSTRAINT finantialcondition_employee_fkey FOREIGN KEY (employee_id)
      REFERENCES employee (employee_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

create TABLE salarypackage(
    finantialcondition_id INT NOT NULL,
    salaryitem_id INT NOT NULL,
    itemvalue NUMERIC,
    notes VARCHAR(100),
    percentvalue NUMERIC,
    jan BOOLEAN NOT NULL DEFAULT FALSE,
    feb BOOLEAN NOT NULL DEFAULT FALSE,
    mar BOOLEAN NOT NULL DEFAULT FALSE,
    apr BOOLEAN NOT NULL DEFAULT FALSE,
    may BOOLEAN NOT NULL DEFAULT FALSE,
    jun BOOLEAN NOT NULL DEFAULT FALSE,
    jul BOOLEAN NOT NULL DEFAULT FALSE,
    aug BOOLEAN NOT NULL DEFAULT FALSE,
    sep BOOLEAN NOT NULL DEFAULT FALSE,
    oct BOOLEAN NOT NULL DEFAULT FALSE,
    nov BOOLEAN NOT NULL DEFAULT FALSE,
    dec BOOLEAN NOT NULL DEFAULT FALSE,
    PRIMARY KEY (finantialcondition_id, salaryitem_id),
    CONSTRAINT salarypackage_finantialcondition_fkey FOREIGN KEY (finantialcondition_id)
      REFERENCES finantialcondition (finantialcondition_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT salarypackage_salaryitem_fkey FOREIGN KEY (salaryitem_id)
      REFERENCES salaryitem (salaryitem_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);