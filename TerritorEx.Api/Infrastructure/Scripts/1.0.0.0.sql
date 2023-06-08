----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela Usuario
----------------------------

PRINT 'Criando tabela Usuario'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('Usuario'))
BEGIN
   CREATE TABLE Usuario(
       UsuarioId          INT IDENTITY (1,1) NOT NULL, 
       Email              VARCHAR (80) NOT NULL,
       Nome               VARCHAR (50) NOT NULL,
       Sobrenome          VARCHAR (50) NOT NULL,
       Senha              VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED (UsuarioId ASC),
       CONSTRAINT AK_Email UNIQUE(Email)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índice IX_Usuario_Email
----------------------------

PRINT 'Criando índice IX_Usuario_Email'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('Usuario') AND NAME = 'IX_Usuario_Email')
BEGIN
   CREATE NONCLUSTERED INDEX IX_Usuario_Email ON Usuario(Email ASC);
END
GO