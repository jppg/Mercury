/*
truncate table client;
truncate table maritalstatus;
truncate table direction;

select * from client;
select * from maritalstatus;
select * from direction;
*/

insert into client(client_name, startdate) values ('Interno', current_timestamp);
insert into client(client_name, startdate) values ('MG', current_timestamp);

insert into maritalstatus(maritalstatus_id, maritalstatus_name) values (0,'Solteiro');
insert into maritalstatus(maritalstatus_id, maritalstatus_name) values (1,'Casado unico titular');
insert into maritalstatus(maritalstatus_id, maritalstatus_name) values (2,'Casado dois titulares');

/*
insert into direction(direction_id, direction_name, direction_code, rate) values (1, 'Debito','D', -1);
insert into direction(direction_id, direction_name, direction_code, rate) values (2, 'Credito', 'C', 1);
*/

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Vencimento Base', TRUE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Isencao de Horario Trabalho', TRUE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Subsidio de Natal', TRUE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Subsidio de Ferias', TRUE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Ajudas de Custo', FALSE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Cheques Creche', FALSE, 0.04, 1, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Seguro de Saude Colaborador', FALSE, 1, 0, 24.57, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Seguro de Saude Familia', FALSE, 0.5, 0.5, 24.57, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Viatura', FALSE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Premio', FALSE, 1, 0, 0, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Comunicacoes', FALSE, 1, 0, 10.34, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Telemovel', FALSE, 1, 0, 0.03, current_timestamp);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate) 
values ('Computador', FALSE, 1, 0, 0, current_timestamp);

insert into employee(employee_name, nchildren, maritalstatus_id, client_id, startdate)
values ('JG', 3, 2, 1, current_timestamp);

insert into simulation(employee_id, startdate)
values (1, current_timestamp);

insert into salarypackage(simulation_id, salaryitem_id, itemvalue)
values (1, 1, 1500);
