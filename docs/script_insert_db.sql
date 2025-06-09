insert into planoconta (
    nome, 
    tipo
)
values 
    ('Combustível', 'D'),
    ('Aluguel', 'D'),
    ('Manutenção Carro', 'D'),
    ('Alimentação', 'D'),
    ('Saúde', 'D'),
    ('Viagens', 'D'),
    ('Salário', 'R'),
    ('Créditos de Dividendos', 'R'),
    ('Restituição de IR', 'R');

select * from planoconta;

insert into transacao (
    historico, 
    data,
    valor,
    plano_conta_id
)
values 
    ('Combustível Audi', getdate(), 489, 1),
    ('Almoço domingo', '18-05-2025 12:00', 150, 4),
    ('Peças do Audi', '10-05-2025 03:00', 1800, 3),
    ('Salário', '02-06-2025', 10000, 7),
    ('ITAUSA', '14-05-2025', 678, 8);

select * from transacao