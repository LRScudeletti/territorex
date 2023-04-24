----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela Usuario
----------------------------

PRINT 'Criando tabela Usuario'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('Usuario'))
BEGIN
   CREATE TABLE Usuario(
       Email              VARCHAR (50) NOT NULL,
       Nome               VARCHAR (50) NOT NULL,
       Sobrenome          VARCHAR (50) NOT NULL,
       Senha              VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED (Email ASC)
   );
END
GO