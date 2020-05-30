CREATE DATABASE IF NOT EXISTS bikesegura;

USE bikesegura;

CREATE TABLE aros (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Medida varchar(15) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE cambiosdianteiros (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Velocidade varchar(20) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE cambiostraseiros (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Velocidade varchar(20) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE freios (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Nome varchar(30) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE quadros (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Material varchar(30) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE suspensoes (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Nome varchar(30) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE tipos (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Nome varchar(40) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE marcas (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Nome varchar(30) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE pessoas (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Nome varchar(100) NOT NULL,
    Email varchar(255) NOT NULL,
    ConfirmaEmail varchar(255) NOT NULL,
    Senha longtext NOT NULL,
    ConfirmaSenha longtext NOT NULL,
    Endereco varchar(150) DEFAULT NULL,
    Numero varchar(10) DEFAULT NULL,
    Complemento varchar(100) DEFAULT NULL,
    Cep varchar(9) DEFAULT NULL,
    Bairro varchar(50) DEFAULT NULL,
    Cidade varchar(50) DEFAULT NULL,
    Estado int(11) DEFAULT NULL,
    TelefoneUm varchar(15) DEFAULT NULL,
    TelefoneDois varchar(15) DEFAULT NULL,
    Cpf varchar(14) NOT NULL,
    DataNascimento datetime DEFAULT NULL,
    Genero int(11) DEFAULT NULL,
    Imagem longtext,
    NomeContato varchar(100) DEFAULT NULL,
    TelefoneContatoUm varchar(15) DEFAULT NULL,
    TelefoneContatoDois varchar(15),
    TipoUsuario int(11) NOT NULL,
    Ativo int(11) NOT NULL,
    CodigoValidarEmail longtext,
    CodigoEsqueceuSenha longtext,
    DataCadastro datetime DEFAULT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id)
);

CREATE TABLE bicicletas (
    Id int(11) NOT NULL AUTO_INCREMENT,
    MarcasId int(11) NOT NULL,
    Modelo varchar(45) NOT NULL,
    TiposId int(11) NOT NULL,
    Cor varchar(40) DEFAULT NULL,
    CambiosDianteirosId int(11) DEFAULT NULL,
    CambiosTraseirosId int(11) DEFAULT NULL,
    FreiosId int(11) DEFAULT NULL,
    SuspensoesId int(11) DEFAULT NULL,
    ArosId int(11) DEFAULT NULL,
    QuadrosId int(11) DEFAULT NULL,
    Tamanho varchar(20) DEFAULT NULL,
    Informacoes longtext,
    AlertaRoubo int(11) NOT NULL,
    Vendendo int(11) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id),
    KEY ArosId (ArosId),
    KEY CambiosDianteirosId (CambiosDianteirosId),
    KEY CambiosTraseirosId (CambiosTraseirosId),
    KEY FreiosId (FreiosId),
    KEY MarcasId (MarcasId),
    KEY QuadrosId (QuadrosId),
    KEY SuspensoesId (SuspensoesId),
    KEY TiposId (TiposId),
    CONSTRAINT Bicicletas_Aros FOREIGN KEY (ArosId) REFERENCES aros (id),
    CONSTRAINT Bicicletas_CambiosDianteiros FOREIGN KEY (CambiosDianteirosId) REFERENCES cambiosdianteiros (id),
    CONSTRAINT Bicicletas_CambiosTraseiros FOREIGN KEY (CambiosTraseirosId) REFERENCES cambiostraseiros (id),
    CONSTRAINT Bicicletas_Freios FOREIGN KEY (FreiosId) REFERENCES freios (id),
    CONSTRAINT Bicicletas_Marcas FOREIGN KEY (MarcasId) REFERENCES marcas (id) ON DELETE CASCADE,
    CONSTRAINT Bicicletas_Quadros FOREIGN KEY (QuadrosId) REFERENCES quadros (id),
    CONSTRAINT Bicicletas_Suspensoes FOREIGN KEY (SuspensoesId) REFERENCES suspensoes (id),
    CONSTRAINT Bicicletas_Tipos FOREIGN KEY (TiposId) REFERENCES tipos (id) ON DELETE CASCADE
);

CREATE TABLE imagens (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Imagem longtext,
    BicicletasId int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id),
    KEY BicicletasId (BicicletasId),
    CONSTRAINT Imagens_Bicicletas FOREIGN KEY (BicicletasId) REFERENCES bicicletas (id) ON DELETE CASCADE
);

CREATE TABLE numerosseries (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Numero varchar(50) NOT NULL,
    BicicletasId int(11) NOT NULL,
    Tipo int(11) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id),
    KEY BicicletasId (BicicletasId),
    CONSTRAINT NumerosSeries_Bicicletas FOREIGN KEY (BicicletasId) REFERENCES bicicletas (id) ON DELETE CASCADE
);

CREATE TABLE informacoesroubos (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Cidade varchar(50) NOT NULL,
    Estado int(11) NOT NULL,
    Relato longtext NOT NULL,
    LocalAdicional varchar(150) DEFAULT NULL,
    DataRoubo datetime NOT NULL,
    BicicletasId int(11) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id),
    KEY BicicletasId (BicicletasId),
    CONSTRAINT InformacoesRoubos_Bicicletas FOREIGN KEY (BicicletasId) REFERENCES bicicletas (id) ON DELETE CASCADE
);

CREATE TABLE relatosroubos (
    Id int(11) NOT NULL AUTO_INCREMENT,
    Cidade varchar(50) NOT NULL,
    Estado int(11) NOT NULL,
    Relato longtext NOT NULL,
    LocalAdicional varchar(150) DEFAULT NULL,
    DataRelato datetime NOT NULL,
    PessoasId int(11) NOT NULL,
    InformacoesRoubosId int(11) NOT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id),
    KEY InformacoesRoubosId (InformacoesRoubosId),
    KEY PessoasId (PessoasId),
    CONSTRAINT RelatosRoubos_InformacoesRoubos FOREIGN KEY (InformacoesRoubosId) REFERENCES informacoesroubos (id) ON DELETE CASCADE,
    CONSTRAINT RelatosRoubos_Pessoas FOREIGN KEY (PessoasId) REFERENCES pessoas (id) ON DELETE CASCADE
);

CREATE TABLE historicos (
    Id int(11) NOT NULL AUTO_INCREMENT,
    TipoTransferencia int(11) DEFAULT NULL,
    DataAquisicao datetime DEFAULT NULL,
    DataTransferencia datetime DEFAULT NULL,
    BicicletasId int(11) NOT NULL,
    VendedorId int(11) DEFAULT NULL,
    CompradorId int(11) DEFAULT NULL,
    Ativo int(11) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY Id (Id),
    KEY BicicletasId (BicicletasId),
    KEY CompradorId (CompradorId),
    KEY VendedorId (VendedorId),
    CONSTRAINT Historicos_Bicicletas FOREIGN KEY (BicicletasId) REFERENCES bicicletas (id) ON DELETE CASCADE,
    CONSTRAINT Historicos_Comprador FOREIGN KEY (CompradorId) REFERENCES pessoas (id) ON DELETE CASCADE,
    CONSTRAINT Historicos_Vendedor FOREIGN KEY (VendedorId) REFERENCES pessoas (id) ON DELETE CASCADE
);