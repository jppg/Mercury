CREATE OR REPLACE PROCEDURE populateTables()
LANGUAGE plpgsql
AS $$
DECLARE 
    cnt NUMERIC;
    client_id NUMERIC;
    emp_id NUMERIC;
    fc_id NUMERIC;
    maritalstatus_id NUMERIC;
    rec_emp   RECORD;
    cur_emps CURSOR FOR 
		SELECT Num,Nome,Cliente,SSConjuge,SSFilhos,SB,SBAnual,IHT,IHTAnual,TSUAnual,SRAnual,DespesasAC,DespesasACAnual,ChequeCrecheAnual,BonusPCPremio,ViaturaAnual,TA,SeguroSaude, SegATAnual,SHST,CustoAnual,CustoMedioMensal,DataInicio
		FROM loadData;
BEGIN
    -- Open the cursor
   OPEN cur_emps;
   
   LOOP
	   -- fetch row into the record
	   FETCH cur_emps INTO rec_emp;
	   -- exit when no more row to fetch
	   EXIT WHEN NOT FOUND;
	   
	   -- build the output
       select client.client_id into client_id from client where client_name = rec_emp.Cliente;

       if (client_id is null) then
        insert into client(client_name, startdate) values (rec_emp.Cliente, current_timestamp);
       end if;

       select client.client_id into client_id from client where client_name = rec_emp.Cliente;

       maritalstatus_id = 0;
       if(rec_emp.SSConjuge > 0) then
        maritalstatus_id = 1;
       end if;

       insert into employee(employee_name, nchildren, maritalstatus_id, startdate) values (rec_emp.Nome, rec_emp.SSFilhos, maritalstatus_id, to_date(rec_emp.DataInicio, 'DD-MM-YY'));

       select employee.employee_id into emp_id from employee where employee_name = rec_emp.Nome;

       insert into allocation(employee_id, client_id, dayrate, startdate) values (emp_id, client_id, 0, to_date(rec_emp.DataInicio, 'DD-MM-YY'));

       insert into finantialcondition(employee_id, startdate) values (emp_id, current_timestamp);

       select finantialcondition.finantialcondition_id into fc_id from finantialcondition where employee_id = emp_id;

       if(COALESCE(rec_emp.TSUAnual, 0) = 0) then
            -- 'Recibos Verdes'
            insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, rec_emp.SB, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Recibos Verdes';
        else         
            -- 'Vencimento Base'
            insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, rec_emp.SB, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Vencimento Base';

                -- 'Isencao de Horario Trabalho'
            insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, COALESCE (rec_emp.IHT, 0), percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Isencao de Horario Trabalho';

                -- 'Subsidio de Natal'
            insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, rec_emp.SB, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Subsidio de Natal';

                -- 'Subsidio de Ferias'
            insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, rec_emp.SB + COALESCE (rec_emp.IHT, 0), percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Subsidio de Ferias';

                -- 'Ajudas de Custo'
            insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, rec_emp.DespesasAC, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Ajudas de Custo';

                -- 'Cheques Creche'
                if(rec_emp.ChequeCrecheAnual is not null) then
                    insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                            select fc_id, salaryitem_id, COALESCE (rec_emp.ChequeCrecheAnual, 0)/12, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                            where salaryitem_name = 'Cheques Creche';
                end if;

                -- 'Premio'
                if(rec_emp.BonusPCPremio is not null) then
                    insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                            select fc_id, salaryitem_id, COALESCE (rec_emp.BonusPCPremio, 0), percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                            where salaryitem_name = 'Premio';
                end if;

                -- 'Viatura'
                if(rec_emp.ViaturaAnual is not null) then
                    insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                            select fc_id, salaryitem_id, COALESCE (rec_emp.ViaturaAnual, 0)/12, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                            where salaryitem_name = 'Viatura';
                end if;

                -- 'Seguro de Saude Colaborador'
                insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, defaultvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Seguro de Saude Colaborador';

                -- 'Seguro de Saude Conjugue'
                if(rec_emp.SSConjuge > 0) then
                insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, defaultvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Seguro de Saude Conjugue';
                end if;

                -- 'Seguro de Saude Filhos'
                if(rec_emp.SSFilhos > 0) then
                insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                    select fc_id, salaryitem_id, defaultvalue * rec_emp.SSFilhos, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                    where salaryitem_name = 'Seguro de Saude Filhos';
                end if;

                 -- Others
                insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
                        select fc_id, salaryitem_id, defaultvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem 
                        where salaryitem_name in('Subsidio Refeicao', 'Comunicacoes', 'Telemovel', 'Computador');

        end if;

        

        cnt := 0;
        
       
        
            
   END LOOP;
  
   -- Close the cursor
   CLOSE cur_emps;

END $$;


/*
insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
            select idSalaryCond, salaryitem_id, defaultvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem where incauto = TRUE;
*/

/*
DROP PROCEDURE create_salary_package_items(integer)
select * from salarypackage;
truncate table salarypackage;

set client_min_messages = 'debug';
call populateTables();

truncate client cascade;
truncate employee cascade;
truncate allocation cascade;
truncate finantialcondition cascade;
truncate salarypackage cascade;

select * from client;
select * from employee;
select * from allocation;
select * from finantialcondition;

*/