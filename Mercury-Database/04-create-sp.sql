CREATE OR REPLACE PROCEDURE create_salary_package_items(idSalaryCond integer)
LANGUAGE SQL
AS $$
insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
            select idSalaryCond, salaryitem_id, defaultvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem where incauto = TRUE;
$$;


/*
DROP PROCEDURE create_salary_package_items(integer)
select * from salarypackage;
truncate table salarypackage;

call create_salary_package_items(1);
*/