insert into aros (Medida) values 
('Aro 12'), ('Aro 14'), ('Aro 16'), ('Aro 20'), ('Aro 24'), ('Aro 26'), 
('Aro 27,5'), ('Aro 28'), ('Aro 29'), ('Aro 700'), ('OUTRO');

insert into cambiosdianteiros (Velocidade) values 
('1 Velocidade'), ('2 Velocidades'), ('3 Velocidades');

insert into cambiostraseiros (Velocidade) values 
('1 Velocidade'), ('2 Velocidades'), ('3 Velocidades'), ('4 Velocidades'), ('5 Velocidades'), 
('6 Velocidades'), ('7 Velocidades'), ('8 Velocidades'), ('9 Velocidades'), ('10 Velocidades'), ('11 Velocidades');

insert into freios (Nome) values 
('Cantilever'), ('V-Break'), ('Freio à disco mecânico'), ('Freio à disco hidráulico'), 
('Tipo Ferradura / Caliper'), ('Hidráulico'),  ('OUTRO');

insert into quadros (Material) values 
('Aço'), ('Alumínio'), ('Fibra de Carbono'), ('OUTRO');

insert into suspensoes (Nome) values 
('Rígida'), ('Eslastômeros'), ('Molas'), ('Hidráulica (Ar/Óleo)'), ('OUTRO');

insert into tipos (Nome) values 
('BMX / Cross'), ('Dobrável'), ('Downhill'), ('Estrada / Speed / Road / Corrida'), ('Handbike'), ('Híbrida'), ('Infantil'), 
('Mountain Bike'), ('Triatlo'), ('Urbana'), ('Infantil'), ('Elétrica'), ('Fixa / Fixed Gear Bike / Bike Fixa'), ('OUTRO');

insert into marcas (Nome) values
('Marca A'), ('Marca B'), ('Marca C'), ('Marca D'), ('Marca E'), ('Marca F');

insert into bicicletas (MarcasId, Modelo, TiposId, Cor, Tamanho, 
CambiosDianteirosId, CambiosTraseirosId, FreiosId, SuspensoesId, ArosId, 
QuadrosId, Informacoes, AlertaRoubo, Vendendo) values 
(1, 'Modelo A', 10, 'Preta/Branca', '18"', 3, 7, 2, 1, 6, 1, null, 0, 0),
(5, 'Modelo B', 10, 'Amerela', '18"', 3, 7, 2, 1, 6, 1, null, 0, 0),
(6, 'Modelo C', 10, 'Vermelha', '18"', 3, 7, 2, 2, 6, 1, 'Aro Aero', 0, 0),
(3, 'Modelo D', 10, 'Preta/Amarela', '18"', 3, 7, 2, 2, 6, 2, null, 0, 0),
(2, 'Modelo E', 8, 'Azul', '18"', 3, 7, 2, 2, 6, 2, null, 0, 0);

insert into imagens (Imagem, BicicletasId) values 
('caloi-montana.jpg', 1), ('caloi-twister.jpg', 2), ('caloi-andes.jpg', 3), ('caloi-100.jpg', 4),
('caloi-trs.jpg', 5);

insert into numerosseries (Numero, BicicletasId) values 
('ABC1234CBA', 1), ('987ABCBR', 2), ('BR12345', 3), ('222AAA555', 4),
('987654', 5);

insert into pessoas (Nome, Email, ConfirmaEmail, Senha, ConfirmaSenha, 
Endereco, Numero, Complemento, Cep, Bairro, Cidade, Estado, 
Telefone, Celular, Cpf, DataNascimento, Genero, Imagem, 
NomeContato, TelefoneContato, CelularContato, TipoUsuario) values 
('Gustavo Teixeira', 'gustavoteixeira@email.com', 'gustavoteixeira@email.com', '12345678', '12345678', 
'Rua Gustavo Teixeira', '111', 'Casa', '11111-111', 'Centro', 'João Pessoa', 14, 
'(83) 1111-1111', '(83) 11111-1111', '111.111.111-11', '1996-06-10', 0, 'perfil01.jpg', 
'Raul Castro', '(83) 1111-1111', '(83) 11111-1111', 0),
('Benício Caldeira', 'benocaldeira@email.com', 'benocaldeira@email.com', '12345678', '12345678', 
'Rua Benício Caldeira', '111', 'Bloco 1, Ap 3', '11111-111', 'Centro', 'Caraguatatuba', 24, 
'(12) 1111-1111', '(12) 11111-3377', '111.111.111-11', '1987-07-20', 0, 'perfil02.jpg', 
'Giovanna Nicole', null, '(12) 11111-1111', 0),
('Mariah Moraes', 'marimoraes@email.com', 'marimoraes@email.com', '12345678', '12345678', 
'Rua Mariah Moraes', '111', 'Casa', '11111-111', 'Centro', 'Dourados', 12, 
'(67) 1111-1111', '(67) 11111-2030', '111.111.111-11', '1992-09-16', 1, 'perfil03.jpg', 
'Olivia Liz', '(67) 1111-1111', null, 0),
('Manuel Vicente', 'vicentemanuel@email.com', 'vicentemanuel@email.com', '12345678', '12345678', 
'Rua Manuel Vicente', '111', 'Ap 8', '11111-111', 'Itaoca', 'Centro', 18, 
'(21) 1111-1111', '(21) 11111-1111', '111.111.111-11', '1975-07-07', 0, 'perfil04.jpg', 
'Stella Santos', '(21) 1111-1111', null, 0),
('Rosa Carvalho', 'rosacarvalho@email.com', 'rosacarvalho@email.com', '12345678', '12345678', 
'Avenida Rosa Carvalho', '111', null, '11111-111', 'Centro', 'Londrina', 15, 
'(44) 1111-1111', '(44) 11111-1111', '111.111.111-11', '2000-12-04', 1, 'perfil05.jpg', 
null, null, null, 0),
('Rafaela Luana Lopes', 'rafalopes@email.com', 'rafalopes@email.com', '12345678', '12345678', 
'Rua Rafaela Lopes', '111', 'Bloco C, Apartamento 5', '11111-111', 'Centro', 'Blumenau', 23, 
'(47) 1111-1111', '(47) 11111-1111', '111.111.111-11', '1975-07-07', 1, 'perfil06.jpg', 
'Davi Mota', '(47) 1111-1111', '(47) 11111-1111', 0);

insert into informacoesroubos (Relato, Local, Data, BicicletasId) values 
('A bicicleta foi roubada na praça do centro, no período da manhã. 
Ela estava trancada no porta bicicletas, junto com outras bicicletas.', 
'Centro, São Paulo-SP', '2018-03-10', 1),
('A bicicleta estava tancada no bicicletário do shopping, entre às 18h00 e 19h30.', 
'Centro, São Paulo-SP', '2018-05-20', 3);

insert into relatosroubos (Relato, Local, Data, PessoasId, InformacoesRoubosId) values 
('A bicicleta esta à venda no classificados deste site, link:
 http://exemplo.com.br/ciclismo/caloi-montana', 
'Site Exemplo', '2018-05-25', 1, 1),
('Vi o anúncio de venda da bicicleta no jornal da cidade, liguei e combinei com quem estava vendendo de ver a bicicleta. 
Após verificar o número de série, vi que não era de quem estava vendendo.
 Quem estava vendendo se chama João, celular (11)11111-1111', 
'Centro, São Paulo-SP', '2018-08-29', 2, 2);

insert into historicos (SituacaoAtual, DataAquisicao, DataTransferencia, BicicletasId, VendedorId, CompradorId) values 
(0, '2017-01-20', '2018-02-15', 1, 1, 5),
(0, '2016-10-05', '2018-05-10', 4, 2, 3);