/*
	Todos os dados deste banco de dados são apenas para fins didáticos, gerados aleatoriamente,
	qualquer semelhança com informaçãoes e dados reais, são mera coincidência.
*/
USE bikesegura;

INSERT INTO aros (Medida, Ativo) VALUES 
('Aro 12', 0), ('Aro 14', 0), ('Aro 16', 0), ('Aro 20', 0), ('Aro 24', 0), ('Aro 26', 0), 
('Aro 27,5', 0), ('Aro 28', 0), ('Aro 29', 0), ('Aro 700', 0), ('OUTRO', 0);

INSERT INTO cambiosdianteiros (Velocidade, Ativo) VALUES 
('1 Velocidade', 0), ('2 Velocidades', 0), ('3 Velocidades', 0), ('OUTRA', 0);

INSERT INTO cambiostraseiros (Velocidade, Ativo) VALUES 
('1 Velocidade', 0), ('2 Velocidades', 0), ('3 Velocidades', 0), ('4 Velocidades', 0), ('5 Velocidades', 0), ('6 Velocidades', 0), 
('7 Velocidades', 0), ('8 Velocidades', 0), ('9 Velocidades', 0), ('10 Velocidades', 0), ('11 Velocidades', 0), ('OUTRA', 0);

INSERT INTO freios (Nome, Ativo) VALUES 
('Cantilever', 0), ('V-Break', 0), ('Freio à disco mecânico', 0), ('Freio à disco hidráulico', 0), 
('Tipo Ferradura / Caliper', 0), ('Hidráulico', 0),  ('OUTRO', 0);

INSERT INTO quadros (Material, Ativo) VALUES 
('Aço', 0), ('Alumínio', 0), ('Fibra de Carbono', 0), ('OUTRO', 0);

INSERT INTO suspensoes (Nome, Ativo) VALUES 
('Rígida', 0), ('Eslastômeros', 0), ('Molas', 0), ('Hidráulica (Ar/Óleo)', 0), ('Full Suspension', 0), ('OUTRO', 0);

INSERT INTO tipos (Nome, Ativo) VALUES 
('BMX / Cross', 0), ('Dobrável', 0), ('Downhill', 0), ('Estrada / Speed / Road / Corrida', 0), ('Handbike', 0), ('Híbrida', 0), ('Infantil', 0), 
('Mountain Bike', 0), ('Triatlo', 0), ('Urbana', 0), ('Infantil', 0), ('Elétrica', 0), ('Fixa / Fixed Gear Bike / Bike Fixa', 0), ('OUTRO', 0);

INSERT INTO marcas (Nome, Ativo) VALUES
('24SEVEN', 0), ('4EVER', 0), ('88', 0), ('ABICI', 0), ('ABSOLUTE', 0), ('ACADEMY', 0), ('ADVENTURE', 0), ('AEGIS', 0), 
('AEROTECH', 0), ('AIRBORNE', 0), ('AIRWALK', 0), ('AKRON', 0), ('ALEOCA', 0), ('ALFAMEQ', 0), ('ALL-CITY', 0), 
('AMF GLORIA MILANO', 0), ('APEX', 0), ('APOLLO', 0), ('ARAYA', 0), ('ARGON 18', 0), ('AROPEC', 0), ('ASPRILLE', 0), 
('ASTRO', 0), ('ATALA', 0), ('ATHOR', 0), ('AUDAX', 0), ('AUTHOR', 0), ('AVALON', 0), ('AVANTI', 0), ('AVENTON', 0), 
('AVENUE', 0), ('AXXIS', 0), ('AZONIC', 0), ('BACINI', 0), ('BALANCE BUDDY', 0), ('BALLISTIC', 0), ('BAMBU BIKE BRASIL', 0), 
('BAMF', 0), ('BANSHEE', 0), ('BASSO', 0), ('BEONE', 0), ('BERG', 0), ('BERGAMONT', 0), ('BERNARDI', 0), ('BERRIA ', 0), 
('BFOLD', 0), ('BH', 0), ('BIANCHI', 0), ('BIANINI', 0), ('BICIMOTO', 0), ('BIKE HAUS', 0), ('BIKE MANUFAKTUR', 0), 
('BIKELAND', 0), ('BIOBIKE', 0), ('BIOMEGA ', 0), ('BKL', 0), ('BLACK FIGHTER', 0), ('BLACK FLEA', 0), ('BLANK', 0), 
('BLB', 0), ('BLITZ', 0), ('BLUE', 0), ('BMC', 0), ('BMW', 0), ('BOARDMAN', 0), ('BOHEMIAN', 0), ('BOMA', 0), ('BONETTI', 0), 
('BOOMERANG', 0), ('BORNIA & COX', 0), ('BÖTTCHER', 0), ('BOTTECCHIA', 0), ('BRACICLO', 0), ('BRAND X', 0), ('BRAUNN', 0), 
('BRAZIL ELECTRIC', 0), ('BREEZER', 0), ('BREMEM', 0), ('BRIDGESTON', 0), ('BRODIE', 0), ('BROMPTON', 0), ('BRUNETT', 0), 
('BSA BICYCLES', 0), ('BT', 0), ('BTWIN', 0), ('BULLS', 0), ('BURNETT', 0), ('BXT', 0), ('CA NORCO', 0), ('CA ROCKY MOUNTAIN', 0), 
('CADEX', 0), ('CAIÇARA', 0), ('CAIRU', 0), ('CAIXA', 0), ('CALFEE', 0), ('CALOI', 0), ('CALYPSO', 0), ('CANADIAN', 0), 
('CANFIELD', 0), ('CANNON', 0), ('CANNONDALE', 0), ('CANYON', 0), ('CARDOSO', 0), ('CARRERA', 0), ('CARRY FREEDOM', 0), 
('CEEPO', 0), ('CELL', 0), ('CERNUNNOS', 0), ('CERVÉLO', 0), ('CHARGE', 0), ('CHASE', 0), ('CHILLIBEANS', 0), ('CHRONOS', 0),
('CHUMBA RACING', 0), ('CIA BRASIL', 0), ('CICLARE', 0), ('CICLÉG', 0), ('CILT', 0), ('CINELLI', 0), ('CIPOLLINI', 0), 
('CITIZEN', 0), ('CITY KOM', 0), ('CLAUD BUTLER', 0), ('CLY', 0), ('COLLI', 0), ('COLNAGO', 0), ('COLNER', 0), ('COLONY', 0), 
('COLOR BIKE', 0), ('COLOSSI', 0), ('COLUER', 0), ('COMMENCAL', 0), ('CONDOR', 0), ('CONOR', 0), ('CORIMA', 0), ('CORRATEC', 0), 
('CORTINA', 0), ('COSTELO', 0), ('COZAC', 0), ('CREATE', 0), ('CREME', 0), ('CRONUS', 0), ('CRUZBIKE', 0), ('CUBE', 0), 
('CULT', 0), ('CURRIE TECH', 0), ('CYCLETECH', 0), ('DA BOMB', 0), ('DACCORDI', 0), ('DAFRA', 0), ('DAHON', 0), ('DALANNIO', 0), 
('DAMATTA', 0), ('DAWA', 0), ('DAWES', 0), ('DE ROSA', 0), ('DEAN', 0), ('DECATHLON', 0), ('DEDACCIAI', 0), ('DEKERF', 0), 
('DEPAULA', 0), ('DEPEDAL', 0), ('DEVINCI', 0), ('DIAMONDBACK', 0), ('DINAMICA', 0), ('DINÂMICA', 0), ('DITEC', 0), 
('DK', 0), ('DMS', 0), ('DNZ', 0), ('DOLAN', 0), ('DOSNOVENTA', 0), ('DOWNHILL', 0), ('DREAMBIKE', 0), ('DRÖSSIGER', 0), 
('DTFLY', 0), ('DURBAN', 0), ('DYNAMICS', 0), ('E-CLUB', 0), ('E-LEEZE', 0), ('EAGLEBIKES', 0), ('EASTERN', 0), 
('ECHO VINTAGE', 0), ('ECHOWELL', 0), ('ECOBIKE', 0), ('ECOS', 0), ('ECOSTART', 0), ('EDDY MERCKX', 0), ('EIGHTBIKE', 0), 
('EIGHTBIKES', 0), ('EIGHTHINCH', 0), ('ELECTRA', 0), ('ELEEZE', 0), ('ELLEVEN', 0), ('ELLSWORTH', 0), ('ENDORPHINE', 0), 
('ENDURO', 0), ('ENTERPRISE', 0), ('ESSENCIAL', 0), ('EUROBIKE', 0), ('EVO', 0), ('EVOKE', 0), ('F. MOSER', 0), ('FAILURE', 0), 
('FALCON', 0), ('FELT', 0), ('FENIX', 0), ('FES', 0), ('FIB', 0), ('FICTION', 0), ('FIRETECK', 0), ('FIRMSTRONG', 0), ('FIRST', 0), 
('FISCHER', 0), ('FIV5R', 0), ('FLEE', 0), ('FLYXII', 0), ('FOCUS', 0), ('FOES', 0), ('FOFFA', 0), ('FONDRIEST', 0), ('FORMAT', 0), 
('FORME', 0), ('FORSS', 0), ('FOXXER', 0), ('FRAIDA', 0), ('FREEAGENT', 0), ('FSC', 0), ('FUGN', 0), ('FUJI', 0), 
('FUN MOTORS', 0), ('FUNRIDE', 0), ('GALILEUS', 0), ('GALLO', 0), ('GAMA', 0), ('GARRA', 0), ('GARY FISHER', 0), 
('GAZELLE', 0), ('GENERAL WINGS', 0), ('GENESIS', 0), ('GHAO', 0), ('GHOST', 0), ('GIANT', 0), ('GIC', 0), ('GILMEX', 0), 
('GIORDANO ', 0), ('GIOS', 0), ('GITANE', 0), ('GMC', 0), ('GO EASY', 0), ('GO SPORT', 0), ('GONEW', 0), ('GOOD NINE', 0), 
('GÖRICK', 0), ('GRAZIELLA', 0), ('GRECG', 0), ('GRECO', 0), ('GREEN', 0), ('GROOVE', 0), ('GT', 0), ('GT MAX', 0), 
('GT SUPER', 0), ('GTA', 0), ('GTI', 0), ('GTK', 0), ('GTS', 0), ('GTSM1', 0), ('GTW', 0), ('GTX', 0), ('GTZ', 0), 
('GUNNAR', 0), ('GURU', 0), ('GW', 0), ('HAIBIKE', 0), ('HARO', 0), ('HARPY', 0), ('HASA', 0), ('HEBEI TONGYI', 0), 
('HEILAND', 0), ('HERCULES', 0), ('HIATE', 0), ('HÍBRIDA', 0), ('HIGH ONE', 0), ('HOFFMAN', 0), ('HONGFU', 0), ('HÓRIZOM', 0), 
('HOUSTON', 0), ('HOWMER', 0), ('HUBU', 0), ('HUFFY', 0), ('HUMMER', 0), ('HUPI', 0), ('HYPER', 0), ('IBIS', 0), 
('IDENTITI', 0), ('INTENSE', 0), ('IRONHORSE', 0), ('J.SNOW', 0), ('JAMIS', 0), ('JAVA', 0), ('JBC PRO', 0), 
('JBTECH', 0), ('JEEP', 0), ('JINDAL FINE INDUSTRIES', 0), ('JLS', 0), ('JNA', 0), ('JOHNNY LOCO', 0), ('K2', 0), 
('KABUTO TAKARA', 0), ('KALF', 0), ('KAPA', 0), ('KARAKORAM', 0), ('KASINSKY', 0), ('KAWASAKI', 0), ('KEBI', 0), ('KEEN', 0), 
('KENSTONE', 0), ('KENT', 0), ('KESTREL', 0), ('KHS', 0), ('KHT', 0), ('KIDDIMOTO', 0), ('KINESIS', 0), ('KINK', 0), 
('KLEIN', 0), ('KMT', 0), ('KODE', 0), ('KOGA', 0), ('KOMBAT', 0), ('KONA', 0), ('KONNOR', 0), ('KRONUS', 0), ('KROSS', 0), 
('KRS', 0), ('KSW', 0), ('KTM', 0), ('KULANA', 0), ('KUOTA', 0), ('KURUMA', 0), ('KUSTOMBIKE', 0), ('KYLIN', 0), 
('LA BICI ', 0), ('LA DRACO', 0), ('LAHSEN', 0), ('LAND ROVER', 0), ('LANGTU', 0), ('LAPIERRE', 0), ('LEE COUGAN', 0), 
('LEMOND', 0), ('LEV', 0), ('LIKE', 0), ('LINUS', 0), ('LITESPEED', 0), ('LKSG', 0), ('LOOK', 0), ('LOTUS', 0), 
('LTX', 0), ('LXR', 0), ('LYNSKEY', 0), ('M ROSSI', 0), ('M7', 0), ('MAGIAS', 0), ('MAGNA', 0), ('MANHATTAN', 0), 
('MARIN BIKES', 0), ('MARSSTAR', 0), ('MARTIN', 0), ('MASCOT', 0), ('MASI', 0), ('MASTER BIKE', 0), ('MAZZA', 0), 
('MBK', 0), ('MBL', 0), ('MDI', 0), ('MEGA', 0), ('MERAUD', 0), ('MERCIER', 0), ('MERIDA', 0), ('MERLIN', 0), ('MEYBO', 0), 
('MIFA', 0), ('MITICAL', 0), ('MITSU', 0), ('MIYAMURA', 0), ('MIYATA', 0), ('MMR', 0), ('MOB', 0), ('MOBELE', 0), ('MODE', 0), 
('MOMENTUM', 0), ('MONACO', 0), ('MONARK', 0), ('MONDAINE', 0), ('MONDRAKER', 0), ('MONGOOSE', 0), ('MONTAGNA', 0), 
('MONTAGUE', 0), ('MONTY', 0), ('MOOD', 0), ('MOOTS', 0), ('MOPAR', 0), ('MORMAII', 0), ('MOSER', 0), ('MOSSO', 0), 
('MOTACHIE', 0), ('MOTOBECANE', 0), ('MOULTON', 0), ('MOUNTAIN CYCLE', 0), ('MOVE YOUR LIFE', 0), ('MR. GUD', 0), 
('MSC', 0), ('MUDDYFOX', 0), ('MULTILASER', 0), ('MURRAY', 0), ('MUSEEUW', 0), ('MUZZICYCLES', 0), ('MYMAX', 0), 
('NATHOR', 0), ('NEASTY', 0), ('NEILPRYDE', 0), ('NESS', 0), ('NEW BIKE', 0), ('NEW RUN RIDE', 0), ('NEXT', 0), ('NIKONNA', 0), 
('NINER', 0), ('NIRVE', 0), ('NISHIKI', 0), ('NORCO', 0), ('NOSTER', 0), ('NOVARA', 0), ('NOVELLO', 0), ('NS BIKES', 0), 
('NUKEPOCTANE ONEROOF', 0), ('NUKEPROOF', 0), ('NUVEM', 0), ('OCEANO', 0), ('OCP', 0), ('OEM', 0), ('OGGI', 0), 
('OLYMPIA', 0), ('ON ONE', 0), ('ONE', 0), ('OPEN', 0), ('OPTIMA', 0), ('ORBEA', 0), ('ORIGIN8', 0), ('ORTLER', 0), 
('OX', 0), ('OX PRO', 0), ('OXER', 0), ('OZARK TRAIL', 0), ('PAGOTTI', 0), ('PALAZZO', 0), ('PASHLEY', 0), ('PEDALLA', 0), 
('PEGASUS', 0), ('PEONY', 0), ('PERIFA', 0), ('PEUGEOT', 0), ('PHILLIPS', 0), ('PHOENIX', 0), ('PIERROT', 0), 
('PINARELLO', 0), ('PINNACLE', 0), ('PIVOT', 0), ('PLANET X', 0), ('PLIAGE', 0), ('POLIMET', 0), ('PORTAL WHEELING', 0), 
('PORTO SEGURO', 0), ('PREMIUM', 0), ('PREY', 0), ('PRINCE', 0), ('PRIORITY', 0), ('PRIVITERA', 0), ('PRO LITE', 0), 
('PRO-X', 0), ('PROFESSIONAL', 0), ('PROFLEX', 0), ('PROMOUNTAIN', 0), ('PROSHOCK', 0), ('PUBLIC', 0), ('PUMMA', 0), 
('PURE', 0), ('PYTHON', 0), ('PZZ RACING', 0), ('QUINTANA ROO', 0), ('R-WOOD', 0), ('RAASCH BIKE', 0), ('RACCER', 0), 
('RADON ', 0), ('RAF', 0), ('RAINBOW', 0), ('RAIO', 0), ('RALEIGH', 0), ('RALLY', 0), ('RAPTOR', 0), ('RAVA', 0), 
('RC BIKES', 0), ('REDFOOT', 0), ('REDLAND', 0), ('REDLINE', 0), ('REDSTONE', 0), ('REEBOK', 0), ('REID', 0), ('RENAULT', 0), 
('REPÚBLICA DA BICICLETA', 0), ('RETROSPEC', 0), ('REX', 0), ('RHARU', 0), ('RIDGEBACK', 0), ('RIDLEY', 0), 
('RIESE & MÜLLER', 0), ('RINO', 0), ('RIOSOUTH', 0), ('RITCHEY', 0), ('RIVER', 0), ('ROCK GARDEN', 0), ('ROCKRIDER', 0), 
('ROCKWAY', 0), ('ROCKY MOUNTAIN', 0), ('ROCOMO', 0), ('RONGHUI', 0), ('ROOSTER', 0), ('ROSA', 0), ('ROSSETTI', 0), 
('ROTA HORIZONTE', 0), ('ROYALBABY', 0), ('ROYCE UNION', 0), ('RSC', 0), ('RUPTION', 0), ('RUSH', 0), ('S-WORKS', 0), 
('SAIDX', 0), ('SALSA', 0), ('SAMCHULY BICYCLE', 0), ('SAMPSON', 0), ('SAMY', 0), ('SANMARCO', 0), ('SANTA CRUZ', 0), 
('SANTA MONICA', 0), ('SANTINNI', 0), ('SANTOS', 0), ('SAVA', 0), ('SAVOY', 0), ('SCATTANTE', 0), ('SCHWINN', 0), 
('SCIROCCO', 0), ('SCOOTER BRASIL', 0), ('SCOTT', 0), ('SCREPPER', 0), ('SCUD', 0), ('SENSE', 0), ('SERFAS', 0), ('SEROTTA', 0), 
('SETTE', 0), ('SEVEN CYCLES', 0), ('SHIMANO', 0), ('SHINERAY', 0), ('SHOCKBLAZE', 0), ('SINTESI', 0), ('SIXXIS', 0), 
('SKAPE', 0), ('SKODA', 0), ('SKY', 0), ('SKY LINE', 0), ('SLINGSHOT', 0), ('SLP', 0), ('SMART', 0), ('SMX', 0), 
('SNOW', 0), ('SOBATO', 0), ('SOFTRIDE', 0), ('SOLYOM', 0), ('SOMA', 0), ('SOMAKRE', 0), ('SOUL', 0), ('SOUTH', 0), 
('SOUTH BIKE', 0), ('SPACE', 0), ('SPECIAL LIFE', 0), ('SPECIALIZED', 0), ('SPEEDO', 0), ('SPIN', 0), ('SPINO', 0), 
('SPORTIX', 0), ('SPRICK CYCLE', 0), ('STAMINA 29', 0), ('STARK', 0), ('STATE', 0), ('STATUS', 0), ('STEREO BIKES', 0), 
('STEVENS', 0), ('STINGRAY', 0), ('STL', 0), ('STOLEN', 0), ('STONE', 0), ('STORCK', 0), ('STRADALLI', 0), ('STRADERA', 0), 
('STRIDA', 0), ('SUMMER', 0), ('SUNBURST', 0), ('SUNDOWN', 0), ('SUNN', 0), ('SUNSET', 0), ('SUNTOUR', 0), ('SUPERO', 0), 
('SUPERPEDESTRIAN', 0), ('SURGE', 0), ('SURLY', 0), ('SWIFT', 0), ('T-REX', 0), ('TAEQ', 0), ('TARGET', 0), ('TAURUS', 0), 
('TAYTO', 0), ('TECBIKE', 0), ('TERN', 0), ('TEXAS RANGERS', 0), ('THUNDER', 0), ('TI CYCLES', 0), ('TIDEACE', 0), ('TIME', 0), 
('TIRION', 0), ('TITO', 0), ('TITUS', 0), ('TOKEN', 0), ('TOMAC', 0), ('TOMMASO', 0), ('TOPBIKE', 0), ('TORELLI', 0), 
('TORONTO', 0), ('TOSEEK', 0), ('TOTEM', 0), ('TOUR DE FRANCE', 0), ('TRACK & BIKES', 0), ('TRACTOR', 0), ('TRANSITION', 0), 
('TRE3E', 0), ('TREK', 0), ('TRIAX', 0), ('TRIGON', 0), ('TRINX', 0), ('TRIUMPH', 0), ('TROPIX', 0), ('TROTZ', 0), 
('TRUST', 0), ('TRYTO', 0), ('TSW', 0), ('TURNER', 0), ('TWIN SIX', 0), ('TWITTER', 0), ('TWO DOGS', 0), ('TWO HARD', 0), 
('ULTIMATE', 0), ('UMF', 0), ('UNITED PELOTON', 0), ('UNIVEGA', 0), ('UPLAND', 0), ('URBANA', 0), ('VAN DESSEL', 0), 
('VAXES', 0), ('VAZZO', 0), ('VECTOR', 0), ('VEHEN', 0), ('VELA', 0), ('VELLE', 0), ('VELOBUILD', 0), ('VELOFORCE', 0), 
('VEMEX', 0), ('VENZO', 0), ('VERCELLI', 0), ('VERDEN', 0), ('VERSA', 0), ('VERTICAL', 0), ('VFS CUSTOMS', 0), 
('VICINI', 0), ('VICINITECH', 0), ('VIKINGX', 0), ('VINER', 0), ('VIRTUE', 0), ('VISION', 0), ('VITUS', 0), ('VIVATEC', 0), 
('VO2', 0), ('VO2BIKE', 0), ('VOLARE', 0), ('VOLTEC', 0), ('VOLUME', 0), ('VOOX', 0), ('VOYCE', 0), ('VZAN', 0), 
('WATERFORD', 0), ('WATTS MOTORS', 0), ('WBT', 0), ('WENDY', 0), ('WENDYBIKE', 0), ('WETHEPEOPLE', 0), ('WHEELER', 0), 
('WHYTE', 0), ('WILIER', 0), ('WINDSOR', 0), ('WINNING ', 0), ('WNY', 0), ('WOIE', 0), ('WRP', 0), ('WS CRUISER', 0), 
('X RACING', 0), ('X TERRA', 0), ('X-PLORE', 0), ('X-TREME', 0), ('XKS', 0), ('XTB', 0), ('XTGS', 0), ('YEDOO', 0), 
('YETI', 0), ('YOELEO', 0), ('YOSEMITE', 0), ('YT INDUSTRIES', 0), ('YUNBIKE', 0), ('ZENITH', 0), ('ZEPPELIN', 0), 
('ZIPP', 0), ('ZOHRER', 0), ('ZUMMI', 0), ('ZYMMER', 0), ('OUTRA', 0);

INSERT INTO pessoas (Nome, Email, ConfirmaEmail, Senha, ConfirmaSenha, Endereco, Numero, Complemento, 
Cep, Bairro, Cidade, Estado, TelefoneUm, TelefoneDois, Cpf, DataNascimento, Genero, Imagem, 
NomeContato, TelefoneContatoUm, TelefoneContatoDois, TipoUsuario, Ativo, DataCadastro) VALUES 
('Administrador', 'adm@email.com', 'adm@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
null, null, null, null, null, null, null, '(11) 1111-1111', null, '111.111.111-11', 
null, null, 'user01.jpg', null, null, null, 1, 1, null), 
('Usuário', 'usuario@email.com', 'usu@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
null, null, null, null, null, null, null, '(01) 0101-0101', null, '000.000.000-00', 
null, null, 'user02.jpg', null, null, null, 0, 1, null), 
('Gustavo Teixeira', 'gustavoteixeira@email.com', 'gustavoteixeira@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Gustavo Teixeira', '101', 'Casa', '10101-010', 'Centro', 'João Pessoa', 14, 
'(10) 1010-1010', '(10) 1010-1010', '101.010.101-01', '1996-06-10', 0, 'perfil01.jpg', 
'Raul Castro', '(83) 2575-0110', '(83) 98571-4116', 0, 1, '2018-01-10'), 
('Benício Caldeira', 'benocaldeira@email.com', 'benocaldeira@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Benício Caldeira', '202', 'Bloco 1, Ap 3', '20202-020', 'Centro', 'Caraguatatuba', 24, 
'(20) 2020-2020', '(20) 92020-2020', '202.020.202-02', '1987-07-20', 0, 'perfil02.jpg', 
'Giovanna Nicole', null, '(20) 92121-2121', 0, 1, '2018-03-05'),
('Mariah Moraes', 'marimoraes@email.com', 'marimoraes@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Mariah Moraes', '303', 'Casa', '30303-030', 'Centro', 'Dourados', 12, 
'(30) 3030-3030', '(30) 93030-3030', '303.030.303-30', '1992-09-16', 1, 'perfil03.jpg', 
'Olivia Liz', '(30) 3131-3131', null, 0, 1, '2018-04-18'),
('Manuel Vicente', 'vicentemanuel@email.com', 'vicentemanuel@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Manuel Vicente', '404', 'Ap 8', '40404-404', 'Centro', 'São Gonçalo', 18, 
'(40) 4040-4040', '(40) 94040-4040', '404.040.404-04', '1975-07-07', 0, 'perfil04.jpg', 
'Stella Santos', '(40) 4141-4141', null, 0, 1, '2018-06-08'),
('Rosa Carvalho', 'rosacarvalho@email.com', 'rosacarvalho@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Avenida Rosa Carvalho', '505', null, '50505-050', 'Centro', 'Londrina', 15, 
'(50) 5050-5050', '(50) 95050-5050', '505.050.505-05', '2000-12-04', 1, 'perfil05.jpg', 
null, null, null, 0, 1, '2018-06-14'),
('Rafaela Luana Lopes', 'rafalopes@email.com', 'rafalopes@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Rafaela Luana Lopes', '606', 'Bloco C, Apartamento 5', '60606-060', 'Centro', 'Blumenau', 23, 
'(60) 6060-6060', '(60) 96060-6060', '606.060.606-06', '1975-07-07', 1, 'perfil06.jpg', 
'Davi Mota', '(60) 6161-6161', '(47) 96161-6161', 0, 1, '2018-08-28'),
('Francisco Rodrigues', 'chicorois@email.com', 'chicorois@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Francisco Rodrigues', '12', 'Casa', '70707-070', 'Centro', 'Serra', 7, 
'(70) 7070-7070', '(70) 97070-7070', '707.070.707-07', '1994-08-14', 0, 'perfil07.jpg', 
'Mariane', '(70) 7070-7070', null, 0, 1, '2018-09-07'),
('José Leandro Sales', 'zesales@email.com', 'zesales@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua José Leandro Sales', '85', 'Casa', '80808-080', 'Centro', 'São Paulo', 24, 
'(80) 8080-8080', '(80) 98080-8080', '808.080.808-08', '1987-01-26', 0, 'perfil08.jpg', 
null, null, null, 0, 1, '2018-10-11'),
('Danilo Baptista', 'danilobaptista@email.com', 'danilobaptista@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Rua Danilo Baptista', '25', null, '90909-090', 'Centro', 'Bauru', 24, 
'(90) 9090-9090', '(90) 99090-9090', '909.090.909-09', '1983-09-23', 0, 'perfil09.jpg', 
'Otávio Baptista', null, '(90) 99191-9191', 0, 1, '2018-10-19'),
('Natália Barros', 'nataliabarros@email.com', 'nataliabarros@email.com', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', '122705f49b13a7d2f378eedf8581f02222b6753a6cb6417d77cfbc4884df74ea6ae7699951470f06c34f5c782b7210c34e867f1d0e5d8fcc4e94adb5ab8e8e79', 
'Travessa Natália Barros', '2', 'Casa', '10010-010', 'Cajá', 'Vitória de Santo Antão', 16, 
'(99) 1001-0010', '(99) 91001-0010', '100.100.100-99', '1979-04-20', 1, 'perfil10.jpg', 
'Leonardo Barros', '(81) 3917-9425', null, 0, 1, '2018-11-10');

INSERT INTO bicicletas (MarcasId, Modelo, TiposId, Cor, Tamanho, CambiosDianteirosId, CambiosTraseirosId, 
FreiosId, SuspensoesId, ArosId, QuadrosId, Informacoes, AlertaRoubo, Vendendo, Ativo) VALUES 
(638, 'TB NINER', 10, 'Branca', '21"', 3, 7, 3, 3, 9, 1, null, 0, 0, 0),
(96, 'Twister', 10, 'Amerela', '18"', 3, 7, 2, 1, 6, 1, null, 1, 0, 0),
(96, 'Andes', 10, 'Vermelha', '18"', 3, 7, 2, 2, 6, 1, 'Aro Aero', 0, 0, 0),
(266, 'GTS M1 Advanced New', 8, 'Preta', '29"', 3, 8, 4, null, 9, 2, 'Freio à disco Shimano hidráulico e câmbio Shimano 24 marchas.', 0, 1, 0),
(96, '100 Sport', 10, 'Preta/Amarela', '18"', 3, 7, 2, 2, 6, 2, null, 1, 0, 0),
(101, 'CAAD OPTIMO SORA', 4, 'Branca', '56', 2, 9, 5, 1, 10, 3, null, 1, 0, 0),
(96, 'TRS', 8, 'Azul', '18"', 3, 7, 2, 2, 6, 2, null, 0, 1, 0),
(259, 'SLAP70', 8, 'Azul', 'M', 1, 11, 4, 5, 9, 2, 'Alavanca de Freio Shimano BL-MT400 Hidráulico. Freio Shimano Disco BR-MT400 Hidráulico. Cubos "Hub" Shimano SLX M7010/M7010 Dianteiro eixo 15mm Traseiro 12mm/142mm.', 0, 0, 0),
(96, 'T-Type', 8, 'Preta Fosco', '18"', 3, 7, 1, 3, 6, 2, 'Trocador Shimano Easy Fire, Câmbio traseiro Shimano', 1, 0, 0),
(26, 'Ventus 3000', 4, 'Vermelha', null, 2, 11, 5, 1, 10, 3, null, 0, 0, 0),
(96, '10', 4, 'Preta/Dourada', 'M', 2, 7, 5, 1, 1, 2, 'Câmbio traseiro Shimano, câmbio dianteiro Shimano, pedivela Shimano', 0, 0, 0);

INSERT INTO imagens (Imagem, BicicletasId) VALUES 
('tb_niner.png', 1), ('caloi-twister.jpg', 2), ('caloi-andes.jpg', 3), ('gts-m1-advanced-new.jpg', 4),
('caloi-100.jpg', 5), ('cannondale-cadd-optimo-sora.png', 6), ('caloi-trs.jpg', 7), ('groove-slap70.png', 8),
('caloi-ttype.jpg', 9), ('audax-ventus01.png', 10), ('audax-ventus02.png', 10), ('audax-ventus03.png', 10), 
('caloi-10.jpg', 11);

INSERT INTO numerosseries (Numero, BicicletasId, Tipo, Ativo) VALUES 
('ABC123', 1, 0, 0), ('7582135BR', 2, 0, 0), ('TR1234', 3, 0, 0), ('78797RGT2312412412', 4, 0, 0), ('987123', 5, 0, 0), 
('QJENGLOPRK10', 6, 0, 0), ('GJU7UDJ', 7, 0, 0), ('GHDBRYQIA10', 8, 0, 0), ('456ADC789', 9, 0, 0), 
('VENT728325', 10, 0, 0), ('VENT859481', 10, 0, 0), ('VENT193748', 10, 0, 0), ('15258514DAG', 11, 0, 0);

INSERT INTO informacoesroubos (Cidade, Estado, Relato, LocalAdicional, DataRoubo, BicicletasId, Ativo) VALUES 
('Caraguatatuba', 24, 'A bicicleta foi roubada no estacionamento do supermercado, no período da noite. Ela estava trancada no bicicletário, junto com outras bicicletas.', 
'Centro', '2017-12-20', 2, 0),
('Londrina', 15, 'A bicicleta estava trancada em um poste em frente a lotérica, entre às 10h00 e 10h30.', 
'Centro', '2018-01-10', 5, 0),
('Blumenau', 23, 'A bicicleta foi roubada na praça, a bicicleta estava junto com outras, não estava trancada.', 
'Centro', '2018-04-10', 6, 0),
('Bauru', 24, 'Foi roubada na praça do centro.', 
'Centro', '2018-10-20', 9, 0);

INSERT INTO relatosroubos (Cidade, Estado, Relato, LocalAdicional, DataRelato, PessoasId, InformacoesRoubosId, Ativo) VALUES 
('Caraguatatuba', 24, 'A bicicleta esta à venda no site de classificados, neste link: https://exemplosite.com.br/ciclismo/caloi-twister-123456', 
'Site da Internet', '2018-02-25', 11, 1, 0),
('Londrina', 15, 'Vi o anúncio de venda da bicicleta no classificados do jornal, liguei e combinei de ver a bicileta com o vendedor. Após verificar o número de série, vi que não era de quem estava vendendo. Quem estava vendendo se chama Fulano, celular (99)99999-9999', 
'Centro', '2018-06-29', 10, 2, 0);

INSERT INTO historicos (TipoTransferencia, DataAquisicao, DataTransferencia, BicicletasId, VendedorId, CompradorId, Ativo) VALUES 
(1, '2018-01-15', '2018-06-23', 1, 3, 4, 0),
(0, '2018-06-23', null, 1, null, 4, 0),
(0, '2018-05-05', null, 2, null, 5, 0),
(0, '2018-06-08', null, 3, null, 6, 0),
(0, '2018-07-15', null, 4, null, 7, 0),
(0, '2018-09-07', null, 5, null, 8, 0),
(0, '2018-03-05', null, 6, null, 3, 0),
(0, '2018-09-07', null, 7, null, 9, 0),
(0, '2018-10-12', null, 8, null, 10, 0),
(0, '2018-10-25', null, 9, null, 11, 0),
(0, '2018-11-10', null, 10, null, 12, 0),
(0, '2018-11-11', null, 11, null, 12, 0);