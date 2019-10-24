/*
drop table if exists taxrate;
drop table if exists salarypackage;
drop table if exists salaryitem;
drop table if exists simulation;
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
   client_id INT, 
   startdate DATE NOT NULL,
   enddate DATE,
    CONSTRAINT employee_maritalstatus_fkey FOREIGN KEY (maritalstatus_id)
      REFERENCES maritalstatus (maritalstatus_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT employee_client_fkey FOREIGN KEY (client_id)
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
    startdate DATE NOT NULL,
    enddate DATE
);

create TABLE simulation(
    simulation_id serial PRIMARY KEY,
    employee_id INT NOT NULL,    
    startdate DATE NOT NULL,
    enddate DATE,
    CONSTRAINT simulation_employee_fkey FOREIGN KEY (employee_id)
      REFERENCES employee (employee_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

create TABLE salarypackage(
    simulation_id INT NOT NULL,
    salaryitem_id INT NOT NULL,
    itemvalue NUMERIC,
    PRIMARY KEY (simulation_id, salaryitem_id),
    CONSTRAINT salarypackage_simulation_fkey FOREIGN KEY (simulation_id)
      REFERENCES simulation (simulation_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT salarypackage_salaryitem_fkey FOREIGN KEY (salaryitem_id)
      REFERENCES salaryitem (salaryitem_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);