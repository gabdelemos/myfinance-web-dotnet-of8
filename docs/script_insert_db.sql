insert into PlanoConta(descricao, tipo)
values('Juros', 'R')

select * from PlanoConta

insert into Transacao(historico, data, valor, planocontaid)
values('Almoco', '2024-05-20 14:00', 140, 2)

select * from Transacao