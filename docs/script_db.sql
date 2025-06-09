create database myfinance; 

use myfinance; 

create table planoconta (
	id int identity(1,1) not null,
	nome varchar(50) not null,
	tipo char(1) not null,
	primary key (id)
);

create table transacao(
	id int identity(1,1) not null,
	historico varchar(100) null,
	data datetime null,
	valor decimal(9,2) not null,
	plano_conta_id int not null,
	primary key (id),
	foreign key (plano_conta_id) references planoconta(id)
);