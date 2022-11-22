----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando banco de dados: TerritorEX 
----------------------------

PRINT 'Criando banco de dados TerritorEX'

IF NOT EXISTS (SELECT 1 FROM SYS.DATABASES WHERE NAME = 'TerritorEX')
BEGIN
   CREATE DATABASE TerritorEX;
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando banco de dados: TerritorEXCarga 
----------------------------

PRINT 'Criando banco de dados TerritorEXCarga'

IF NOT EXISTS (SELECT 1 FROM SYS.DATABASES WHERE NAME = 'TerritorEXCarga')
BEGIN
   CREATE DATABASE TerritorEXCarga;
END
GO