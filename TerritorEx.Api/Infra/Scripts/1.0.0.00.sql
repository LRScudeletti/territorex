----------------------------
-- Criando tabela NivelTerritorio
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando tabela: NivelTerritorio'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('NivelTerritorio'))
BEGIN
   CREATE TABLE NivelTerritorio (
       NivelTerritorioId  INT          IDENTITY (1, 1) NOT NULL,
       Sigla              CHAR (8)     NULL,
       Descricao          VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_NivelTerritorio PRIMARY KEY CLUSTERED (NivelTerritorioId ASC)
   );
END
GO

----------------------------
-- Criando tabela Territorio
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando tabela: Territorio'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('Territorio'))
BEGIN
   CREATE TABLE Territorio (
       TerritorioId         INT              NOT NULL,
       TerritorioNome       VARCHAR (50)     NOT NULL,
       TerritorioSuperiorId INT              NOT NULL,
       NivelTerritorioId    INT              NOT NULL,
       Latitude             NUMERIC (38, 18) NOT NULL,
       Longitude            NUMERIC (38, 18) NOT NULL,
       Shape                VARBINARY (MAX)  NOT NULL,
       UsuarioAtualizacao   VARCHAR (50)     NOT NULL,
       DataAtualizacao      DATETIME         NOT NULL,
       CONSTRAINT PK_Territorio PRIMARY KEY CLUSTERED (TerritorioId ASC),
       CONSTRAINT FK_Territorio_NivelTerritorioId FOREIGN KEY (NivelTerritorioId) REFERENCES dbo.NivelTerritorio (NivelTerritorioId)
   );
END
GO

----------------------------
-- Criando índice IDX_Territorio_NivelId
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando índice: IDX_Territorio_NivelId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('Territorio') AND NAME = 'IDX_Territorio_NivelId')
BEGIN
   CREATE NONCLUSTERED INDEX IDX_Territorio_NivelId ON Territorio(NivelTerritorioId ASC);
END
GO

----------------------------
-- Criando índice IDX_Territorio_TerritorioSuperiorId
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando índice: IDX_Territorio_TerritorioSuperiorId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('Territorio') AND NAME = 'IDX_Territorio_TerritorioSuperiorId')
BEGIN
   CREATE NONCLUSTERED INDEX IDX_Territorio_TerritorioSuperiorId ON Territorio(TerritorioSuperiorId ASC);
END
GO

----------------------------
-- Criando tabela SituacaoImovel
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando tabela: SituacaoImovel'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('SituacaoImovel'))
BEGIN
   CREATE TABLE SituacaoImovel (
       SituacaoImovelId   INT          IDENTITY (1, 1) NOT NULL,
       Sigla              CHAR (8)     NULL,
       Descricao          VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_SituacaoImovel PRIMARY KEY CLUSTERED (SituacaoImovelId ASC),
       CONSTRAINT FK_SituacaoImovel_SituacaoImovelId FOREIGN KEY (SituacaoImovelId) REFERENCES dbo.SituacaoImovel (SituacaoImovelId)
   );
END
GO

----------------------------
-- Criando tabela TipoImovel
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando tabela: TipoImovel'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('TipoImovel'))
BEGIN
   CREATE TABLE TipoImovel (
       TipoImovelId       INT          IDENTITY (1, 1) NOT NULL,
       Sigla              CHAR (8)     NULL,
       Descricao          VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_TipoImovel PRIMARY KEY CLUSTERED (TipoImovelId ASC)
   );
END
GO

----------------------------
-- Criando tabela TipoImovel
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando tabela: TipoImovel'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('TipoImovel'))
BEGIN
   CREATE TABLE TipoImovel (
       TipoImovelId       INT          IDENTITY (1, 1) NOT NULL,
       Sigla              CHAR (8)     NULL,
       Descricao          VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_TipoImovel PRIMARY KEY CLUSTERED (TipoImovelId ASC)
   );
END
GO

----------------------------
-- Criando tabela AreaAltitudeSuperior1800
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando tabela: AreaAltitudeSuperior1800'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaAltitudeSuperior1800'))
BEGIN
   CREATE TABLE AreaAltitudeSuperior1800 (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NOT NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaAltitudeSuperior1800 PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaAltitudeSuperior1800_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES dbo.Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Criando índice IDX_AreaAltitudeSuperior1800_TerritorioId
-- Luiz Rogério Scudeletti - 15/11/2022
-- Nº Card: Sem card
----------------------------

PRINT 'Criando índice: IDX_AreaAltitudeSuperior1800_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaAltitudeSuperior1800') AND NAME = 'IDX_AreaAltitudeSuperior1800_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IDX_AreaAltitudeSuperior1800_TerritorioId ON AreaAltitudeSuperior1800(TerritorioId ASC);
END
GO