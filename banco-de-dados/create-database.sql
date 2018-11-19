create database if not exists bikesegura;
use bikesegura;

create table aros (
  Id int(11) not null auto_increment,
  Medida varchar(15) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table cambiosdianteiros (
  Id int(11) not null auto_increment,
  Velocidade varchar(20) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table cambiostraseiros (
  Id int(11) not null auto_increment,
  Velocidade varchar(20) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table freios (
  Id int(11) not null auto_increment,
  Nome varchar(30) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table quadros (
  Id int(11) not null auto_increment,
  Material varchar(30) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table suspensoes (
  Id int(11) not null auto_increment,
  Nome varchar(30) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table tipos (
  Id int(11) not null auto_increment,
  Nome varchar(40) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table marcas (
  Id int(11) not null auto_increment,
  Nome varchar(30) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table bicicletas (
  Id int(11) not null auto_increment,
  MarcasId int(11) not null,
  Modelo varchar(45) not null,
  TiposId int(11) not null,
  Cor varchar(40) default null,
  CambiosDianteirosId int(11) default null,
  CambiosTraseirosId int(11) default null,
  FreiosId int(11) default null,
  SuspensoesId int(11) default null,
  ArosId int(11) default null,
  QuadrosId int(11) default null,
  Tamanho varchar(20) default null,
  Informacoes longtext,
  AlertaRoubo int(11) not null,
  Vendendo int(11) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id),
  key ArosId (ArosId),
  key CambiosDianteirosId (CambiosDianteirosId),
  key CambiosTraseirosId (CambiosTraseirosId),
  key FreiosId (FreiosId),
  key MarcasId (MarcasId),
  key QuadrosId (QuadrosId),
  key SuspensoesId (SuspensoesId),
  key TiposId (TiposId),
  constraint Bicicletas_Aros foreign key (ArosId) references aros (id),
  constraint Bicicletas_CambiosDianteiros foreign key (CambiosDianteirosId) references cambiosdianteiros (id),
  constraint Bicicletas_CambiosTraseiros foreign key (CambiosTraseirosId) references cambiostraseiros (id),
  constraint Bicicletas_Freios foreign key (FreiosId) references freios (id),
  constraint Bicicletas_Marcas foreign key (MarcasId) references marcas (id) on delete cascade,
  constraint Bicicletas_Quadros foreign key (QuadrosId) references quadros (id),
  constraint Bicicletas_Suspensoes foreign key (SuspensoesId) references suspensoes (id),
  constraint Bicicletas_Tipos foreign key (TiposId) references tipos (id) on delete cascade
);

create table imagens (
  Id int(11) not null auto_increment,
  Imagem longtext,
  BicicletasId int(11) not null,
  primary key (Id),
  unique key Id (Id),
  key BicicletasId (BicicletasId),
  constraint Imagens_Bicicletas foreign key (BicicletasId) references bicicletas (id) on delete cascade
);

create table numerosseries (
  Id int(11) not null auto_increment,
  Numero varchar(50) not null,
  BicicletasId int(11) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id),
  key BicicletasId (BicicletasId),
  constraint NumerosSeries_Bicicletas foreign key (BicicletasId) references bicicletas (id) on delete cascade
);

create table pessoas (
  Id int(11) not null auto_increment,
  Nome varchar(100) not null,
  Email varchar(255) not null,
  ConfirmaEmail varchar(255) not null,
  Senha longtext not null,
  ConfirmaSenha longtext not null,
  Endereco varchar(150) default null,
  Numero varchar(10) default null,
  Complemento varchar(100) default null,
  Cep varchar(9) default null,
  Bairro varchar(50) default null,
  Cidade varchar(50) default null,
  Estado int(11) default null,
  Telefone varchar(14) not null,
  Celular varchar(15) default null,
  Cpf varchar(14) not null,
  DataNascimento datetime default null,
  Genero int(11) default null,
  Imagem longtext,
  NomeContato varchar(100) default null,
  TelefoneContato varchar(14) default null,
  CelularContato varchar(15) ,
  TipoUsuario int(11) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id)
);

create table informacoesroubos (
  Id int(11) not null auto_increment,
  Cidade varchar(50) not null,
  Estado int(11) not null,
  Relato longtext not null,
  LocalAdicional varchar(150) default null,
  DataRoubo datetime not null,
  BicicletasId int(11) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id),
  key BicicletasId (BicicletasId),
  constraint InformacoesRoubos_Bicicletas foreign key (BicicletasId) references bicicletas (id) on delete cascade
);

create table relatosroubos (
  Id int(11) not null auto_increment,
  Cidade varchar(50) not null,
  Estado int(11) not null,
  Relato longtext not null,
  LocalAdicional varchar(150) default null,
  DataRelato datetime not null,
  PessoasId int(11) not null,
  InformacoesRoubosId int(11) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id),
  key InformacoesRoubosId (InformacoesRoubosId),
  key PessoasId (PessoasId),
  constraint RelatosRoubos_InformacoesRoubos foreign key (InformacoesRoubosId) references informacoesroubos (id) on delete cascade,
  constraint RelatosRoubos_Pessoas foreign key (PessoasId) references pessoas (id) on delete cascade
);

create table historicos (
  Id int(11) not null auto_increment,
  TipoTransferencia int(11) not null,
  DataAquisicao datetime not null,
  DataTransferencia datetime not null,
  BicicletasId int(11) not null,
  VendedorId int(11) not null,
  CompradorId int(11) not null,
  Ativo int(11) not null,
  primary key (Id),
  unique key Id (Id),
  key BicicletasId (BicicletasId),
  key CompradorId (CompradorId),
  key VendedorId (VendedorId),
  constraint Historicos_Bicicletas foreign key (BicicletasId) references bicicletas (id) on delete cascade,
  constraint Historicos_Comprador foreign key (CompradorId) references pessoas (id) on delete cascade,
  constraint Historicos_Vendedor foreign key (VendedorId) references pessoas (id) on delete cascade
);