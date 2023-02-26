----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando banco de dados: TerritorEX 
----------------------------

PRINT 'Criando banco de dados TerritorEX'

IF NOT EXISTS (SELECT 1 FROM SYS.DATABASES WHERE NAME = 'TerritorEX')
BEGIN
   CREATE DATABASE TerritorEX
   ON   
   ( NAME = TerritorEX,  
       FILENAME = 'D:\Databases\TerritorEX.mdf',  
       SIZE = 10,  
       MAXSIZE = 50,  
       FILEGROWTH = 5)  
   LOG ON  
   ( NAME = TerritorEX_log,  
       FILENAME = 'D:\Databases\TerritorEX.ldf',  
       SIZE = 5MB,  
       MAXSIZE = 25MB,  
       FILEGROWTH = 5MB);  
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando banco de dados: TerritorEXCarga 
----------------------------

PRINT 'Criando banco de dados TerritorEXCarga'

IF NOT EXISTS (SELECT 1 FROM SYS.DATABASES WHERE NAME = 'TerritorEXCarga')
BEGIN
   CREATE DATABASE TerritorEXCarga
   ON   
   ( NAME = TerritorEXCarga,  
       FILENAME = 'D:\Databases\TerritorEXCarga.mdf',  
       SIZE = 10,  
       MAXSIZE = 50,  
       FILEGROWTH = 5)  
   LOG ON  
   ( NAME = TerritorEXCarga_log,  
       FILENAME = 'D:\Databases\TerritorEXCarga.ldf',  
       SIZE = 5MB,  
       MAXSIZE = 25MB,  
       FILEGROWTH = 5MB); 
END
GO