CREATE FUNCTION update_salarypackage() RETURNS trigger AS $$
    BEGIN
        insert into salarypackage(finantialcondition_id, salaryitem_id, itemvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec)
            select NEW.finantialcondition_id, salaryitem_id, defaultvalue, percentvalue, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec from salaryitem where incauto = TRUE;
    END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER generate_salarypackage_items AFTER INSERT ON finantialcondition
    FOR EACH ROW EXECUTE PROCEDURE update_salarypackage();