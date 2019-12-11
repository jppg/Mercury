/*
drop table loadData;
*/

create table loadData(
    id serial PRIMARY KEY,
    Num varchar(5),
    Nome varchar(100),
    Cliente varchar(50),
    SSConjuge int,
    SSFilhos int,
    SB numeric,
    SBAnual numeric,
    IHT numeric,
    IHTAnual numeric,
    TSUAnual numeric,
    SRAnual numeric,
    DespesasAC numeric,
    DespesasACAnual numeric,
    ChequeCrecheAnual numeric,
    BonusPCPremio numeric,
    ViaturaAnual numeric,
    TA numeric,
    SeguroSaude numeric,
    SegATAnual numeric,
    SHST numeric,
    CustoAnual numeric,
    CustoMedioMensal numeric,
    DataInicio varchar(50),
    Provisoes numeric
);

copy loadData(Num,Nome,Cliente,SSConjuge,SSFilhos,SB,SBAnual,IHT,IHTAnual,TSUAnual,SRAnual,DespesasAC,DespesasACAnual,ChequeCrecheAnual,BonusPCPremio,ViaturaAnual,TA,SeguroSaude,SegATAnual,SHST,CustoAnual,CustoMedioMensal,DataInicio,Provisoes)
from '/var/lib/postgresql/data/pgdata/MapaCustos2020.csv' DELIMITER ',' CSV HEADER encoding 'ISO-8859-1';

select * from loadData;

SELECT Num,Nome,Cliente,SSConjuge,SSFilhos,SB,SBAnual,IHT,IHTAnual,TSUAnual,SRAnual,DespesasAC,DespesasACAnual,ChequeCrecheAnual,BonusPCPremio,ViaturaAnual,TA,SeguroSaude, SegATAnual,SHST,CustoAnual,CustoMedioMensal,DataInicio
		FROM loadData;