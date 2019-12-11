/*
truncate table client;
truncate table config;
truncate table maritalstatus;
truncate table direction;

select * from client;
select * from maritalstatus;
select * from salaryitem;
*/

insert into config(keyname, keyvalue, startdate) values ('TSU', 0.2375, current_timestamp);
insert into config(keyname, keyvalue, startdate) values ('SEG_ACID_TRAB', 0.0035, current_timestamp);
insert into config(keyname, keyvalue, startdate) values ('SEG_HIG_TRAB', 2.07, current_timestamp);
insert into config(keyname, keyvalue, startdate) values ('ANUAL_DAYS', 231, current_timestamp);

/*
insert into client(client_name, startdate) values ('Interno', current_timestamp);
insert into client(client_name, startdate) values ('MG', current_timestamp);
*/

insert into maritalstatus(maritalstatus_id, maritalstatus_name) values (0,'Solteiro');
insert into maritalstatus(maritalstatus_id, maritalstatus_name) values (1,'Casado unico titular');
insert into maritalstatus(maritalstatus_id, maritalstatus_name) values (2,'Casado dois titulares');

/*
insert into direction(direction_id, direction_name, direction_code, rate) values (1, 'Debito','D', -1);
insert into direction(direction_id, direction_name, direction_code, rate) values (2, 'Credito', 'C', 1);
*/

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Vencimento Base', TRUE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Isencao de Horario Trabalho', TRUE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, dec) 
values ('Subsidio de Natal', TRUE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, aug) 
values ('Subsidio de Ferias', TRUE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, sep, oct, nov, dec) 
values ('Subsidio Refeicao', FALSE, 1, 0, 160.23, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Ajudas de Custo', FALSE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Cheques Creche', FALSE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Seguro de Saude Colaborador', FALSE, 1, 0, 27.03, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Seguro de Saude Conjugue', FALSE, 0.5, 0.5, 27.03, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Seguro de Saude Filhos', FALSE, 0.5, 0.5, 21.08, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Viatura', FALSE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, dec) 
values ('Premio', FALSE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Comunicacoes', FALSE, 1, 0, 10.34, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Telemovel', FALSE, 1, 0, 0.03, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Computador', FALSE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Recibos Verdes', FALSE, 1, 0, 0, current_timestamp, 1, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);


/*
insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Seguro Acidentes Trabalho', FALSE, 1, 0, 0, current_timestamp, 0.0035, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Seguranca Higiene Trabalho', FALSE, 1, 0, 2.07, current_timestamp, 0, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);

insert into salaryitem(salaryitem_name, istaxed, firmcostrate, employeecostrate, defaultvalue, startdate, percentvalue, incauto, jan, feb, mar, may, jun, jul, aug, sep, oct, nov, dec) 
values ('Taxa Social Unica - Empresa', FALSE, 1, 0, 0, current_timestamp, 0.2375, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE, TRUE);
*/

/*
insert into employee(employee_name, nchildren, maritalstatus_id, startdate)
values ('JG', 3, 1, current_timestamp);

insert into allocation(employee_id, client_id, dayrate, startdate) values (1, 2, 250, current_timestamp);
*/