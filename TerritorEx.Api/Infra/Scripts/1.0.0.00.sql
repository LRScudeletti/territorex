----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela NivelTerritorio
----------------------------

PRINT 'Criando tabela NivelTerritorio'

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
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela Territorio
----------------------------

PRINT 'Criando tabela Territorio'

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
       CONSTRAINT FK_Territorio_NivelTerritorioId FOREIGN KEY (NivelTerritorioId) REFERENCES NivelTerritorio (NivelTerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_Territorio_NivelId
----------------------------

PRINT 'Criando índiceIX_Territorio_NivelId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('Territorio') AND NAME = 'IX_Territorio_NivelId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_Territorio_NivelId ON Territorio(NivelTerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_Territorio_TerritorioSuperiorId
----------------------------

PRINT 'Criando índiceIX_Territorio_TerritorioSuperiorId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('Territorio') AND NAME = 'IX_Territorio_TerritorioSuperiorId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_Territorio_TerritorioSuperiorId ON Territorio(TerritorioSuperiorId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaAltitudeSuperior1800
----------------------------

PRINT 'Criando tabela AreaAltitudeSuperior1800'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaAltitudeSuperior1800'))
BEGIN
   CREATE TABLE AreaAltitudeSuperior1800 (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaAltitudeSuperior1800 PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaAltitudeSuperior1800_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaAltitudeSuperior1800_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaAltitudeSuperior1800_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaAltitudeSuperior1800') AND NAME = 'IX_AreaAltitudeSuperior1800_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaAltitudeSuperior1800_TerritorioId ON AreaAltitudeSuperior1800(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaBanhado
----------------------------

PRINT 'Criando tabela AreaBanhado'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaBanhado'))
BEGIN
   CREATE TABLE AreaBanhado (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaBanhado PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaBanhado_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaBanhado_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaBanhado_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaBanhado') AND NAME = 'IX_AreaBanhado_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaBanhado_TerritorioId ON AreaBanhado(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaBordaChapada
----------------------------

PRINT 'Criando tabela AreaBordaChapada'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaBordaChapada'))
BEGIN
   CREATE TABLE AreaBordaChapada (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaBordaChapada PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaBordaChapada_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaBordaChapada_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaBordaChapada_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaBordaChapada') AND NAME = 'IX_AreaBordaChapada_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaBordaChapada_TerritorioId ON AreaBordaChapada(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaConsolidada
----------------------------

PRINT 'Criando tabela AreaConsolidada'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaConsolidada'))
BEGIN
   CREATE TABLE AreaConsolidada (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaConsolidada PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaConsolidada_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaConsolidada_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaConsolidada_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaConsolidada') AND NAME = 'IX_AreaConsolidada_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaConsolidada_TerritorioId ON AreaConsolidada(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaDeclividadeMaior45
----------------------------

PRINT 'Criando tabela AreaDeclividadeMaior45'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaDeclividadeMaior45'))
BEGIN
   CREATE TABLE AreaDeclividadeMaior45 (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaDeclividadeMaior45 PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaDeclividadeMaior45_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaDeclividadeMaior45_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaDeclividadeMaior45_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaDeclividadeMaior45') AND NAME = 'IX_AreaDeclividadeMaior45_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaDeclividadeMaior45_TerritorioId ON AreaDeclividadeMaior45(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaHidrografia
----------------------------

PRINT 'Criando tabela AreaHidrografia'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaHidrografia'))
BEGIN
   CREATE TABLE AreaHidrografia (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaHidrografia PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaHidrografia_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaHidrografia_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaHidrografia_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaHidrografia') AND NAME = 'IX_AreaHidrografia_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaHidrografia_TerritorioId ON AreaHidrografia(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela SituacaoImovel
----------------------------

PRINT 'Criando tabela SituacaoImovel'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('SituacaoImovel'))
BEGIN
   CREATE TABLE SituacaoImovel (
       SituacaoImovelId   INT          IDENTITY (1, 1) NOT NULL,
       Sigla              CHAR (8)     NULL,
       Descricao          VARCHAR (50) NOT NULL,
       UsuarioAtualizacao VARCHAR (50) NOT NULL,
       DataAtualizacao    DATETIME     NOT NULL,
       CONSTRAINT PK_SituacaoImovel PRIMARY KEY CLUSTERED (SituacaoImovelId ASC),
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela TipoImovel
----------------------------

PRINT 'Criando tabela TipoImovel'

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
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaImovel
----------------------------

PRINT 'Criando tabela AreaImovel'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaImovel'))
BEGIN
   CREATE TABLE AreaImovel (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       ImovelId           VARCHAR (60)    NOT NULL,
       TipoImovelId       INT             NULL,
       SituacaoImovelId   INT             NULL,
       Condicao           VARCHAR (300)   NULL,
       AreaHectare        FLOAT (53)      NULL,
       AreaHectareFiscal  FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaImovel PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaImovel_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId),
       CONSTRAINT FK_AreaImovel_TipoImovelId FOREIGN KEY (TipoImovelId) REFERENCES TipoImovel (TipoImovelId),
       CONSTRAINT FK_AreaImovel_SituacaoImovelId FOREIGN KEY (SituacaoImovelId) REFERENCES SituacaoImovel (SituacaoImovelId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaImovel_ImovelId
----------------------------

PRINT 'Criando índiceIX_AreaImovel_ImovelId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaImovel') AND NAME = 'IX_AreaImovel_ImovelId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaImovel_ImovelId ON AreaImovel(ImovelId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaImovel_SituacaoImovelId
----------------------------

PRINT 'Criando índiceIX_AreaImovel_SituacaoImovelId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaImovel') AND NAME = 'IX_AreaImovel_SituacaoImovelId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaImovel_SituacaoImovelId ON AreaImovel(SituacaoImovelId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaImovel_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaImovel_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaImovel') AND NAME = 'IX_AreaImovel_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaImovel_TerritorioId ON AreaImovel(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaManguezal
----------------------------

PRINT 'Criando tabela AreaManguezal'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaManguezal'))
BEGIN
   CREATE TABLE AreaManguezal (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaManguezal PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaManguezal_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaManguezal_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaManguezal_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaManguezal') AND NAME = 'IX_AreaManguezal_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaManguezal_TerritorioId ON AreaManguezal(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaNascenteOlhoDAgua
----------------------------

PRINT 'Criando tabela AreaNascenteOlhoDAgua'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaNascenteOlhoDAgua'))
BEGIN
   CREATE TABLE AreaNascenteOlhoDAgua (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaNascenteOlhoDAgual PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaNascenteOlhoDAgua_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaNascenteOlhoDAgua_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaNascenteOlhoDAgua_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaNascenteOlhoDAgua') AND NAME = 'IX_AreaNascenteOlhoDAgua_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaNascenteOlhoDAgua_TerritorioId ON AreaNascenteOlhoDAgua(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaPousio
----------------------------

PRINT 'Criando tabela AreaPousio'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaPousio'))
BEGIN
   CREATE TABLE AreaPousio (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaPousio PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaPousio_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaPousio_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaPousio_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaPousio') AND NAME = 'IX_AreaPousio_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaPousio_TerritorioId ON AreaPousio(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaPreservacaoPermanente
----------------------------

PRINT 'Criando tabela AreaPreservacaoPermanente'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaPreservacaoPermanente'))
BEGIN
   CREATE TABLE AreaPreservacaoPermanente (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaPreservacaoPermanente PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaPreservacaoPermanente_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaPreservacaoPermanente_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaPreservacaoPermanente_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaPreservacaoPermanente') AND NAME = 'IX_AreaPreservacaoPermanente_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaPreservacaoPermanente_TerritorioId ON AreaPreservacaoPermanente(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaReservaLegal
----------------------------

PRINT 'Criando tabela AreaReservaLegal'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaReservaLegal'))
BEGIN
   CREATE TABLE AreaReservaLegal (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaReservaLegal PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaReservaLegal_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaReservaLegal_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaReservaLegal_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaReservaLegal') AND NAME = 'IX_AreaReservaLegal_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaReservaLegal_TerritorioId ON AreaReservaLegal(TerritorioId ASC);
END

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaRestinga
----------------------------

PRINT 'Criando tabela AreaRestinga'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaRestinga'))
BEGIN
   CREATE TABLE AreaRestinga (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaRestinga PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaRestinga_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaRestinga_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaRestinga_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaRestinga') AND NAME = 'IX_AreaRestinga_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaRestinga_TerritorioId ON AreaRestinga(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaServidaoAdministrativa
----------------------------

PRINT 'Criando tabela AreaServidaoAdministrativa'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaServidaoAdministrativa'))
BEGIN
   CREATE TABLE AreaServidaoAdministrativa (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaServidaoAdministrativa PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaServidaoAdministrativa_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaServidaoAdministrativa_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaServidaoAdministrativa_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaServidaoAdministrativa') AND NAME = 'IX_AreaServidaoAdministrativa_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaServidaoAdministrativa_TerritorioId ON AreaServidaoAdministrativa(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaTopoMorro
----------------------------

PRINT 'Criando tabela AreaTopoMorro'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaTopoMorro'))
BEGIN
   CREATE TABLE AreaTopoMorro (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaTopoMorro PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaTopoMorro_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaTopoMorro_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaTopoMorro_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaTopoMorro') AND NAME = 'IX_AreaTopoMorro_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaTopoMorro_TerritorioId ON AreaTopoMorro(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaUsoRestrito
----------------------------

PRINT 'Criando tabela AreaUsoRestrito'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaUsoRestrito'))
BEGIN
   CREATE TABLE AreaUsoRestrito (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaUsoRestrito PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaUsoRestrito_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaUsoRestrito_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaUsoRestrito_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaUsoRestrito') AND NAME = 'IX_AreaUsoRestrito_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaUsoRestrito_TerritorioId ON AreaUsoRestrito(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaVegetacaoNativa
----------------------------

PRINT 'Criando tabela AreaVegetacaoNativa'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaVegetacaoNativa'))
BEGIN
   CREATE TABLE AreaVegetacaoNativa (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaVegetacaoNativa PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaVegetacaoNativa_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaVegetacaoNativa_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaVegetacaoNativa_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaVegetacaoNativa') AND NAME = 'IX_AreaVegetacaoNativa_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaVegetacaoNativa_TerritorioId ON AreaVegetacaoNativa(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando tabela AreaVereda
----------------------------

PRINT 'Criando tabela AreaVereda'

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('AreaVereda'))
BEGIN
   CREATE TABLE AreaVereda (
       AreaId             INT             IDENTITY (1, 1) NOT NULL,
       TerritorioId       INT             NOT NULL,
       SicarId            INT             NOT NULL,
       Descricao          VARCHAR (500)   NOT NULL,
       AreaHectare        FLOAT (53)      NULL,
       Shape              VARBINARY (MAX) NULL,
       UsuarioAtualizacao VARCHAR (50)    NOT NULL,
       DataAtualizacao    DATETIME        NOT NULL,
       CONSTRAINT PK_AreaVereda PRIMARY KEY CLUSTERED (AreaId ASC),
       CONSTRAINT FK_AreaVereda_TerritorioId FOREIGN KEY (TerritorioId) REFERENCES Territorio (TerritorioId)
   );
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando índiceIX_AreaVereda_TerritorioId
----------------------------

PRINT 'Criando índiceIX_AreaVereda_TerritorioId'

IF NOT EXISTS (SELECT 1 FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID('AreaVereda') AND NAME = 'IX_AreaVereda_TerritorioId')
BEGIN
   CREATE NONCLUSTERED INDEX IX_AreaVereda_TerritorioId ON AreaVereda(TerritorioId ASC);
END
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando view ViewTerritorioHierarquia
----------------------------

PRINT 'Criando view ViewTerritorioHierarquia'

IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'ViewTerritorioHierarquia') AND TYPE IN (N'V'))
BEGIN
   DROP VIEW ViewTerritorioHierarquia
END
GO

CREATE VIEW dbo.ViewTerritorioHierarquia AS
   SELECT TER.TerritorioId AS TerritorioId, TER.TerritorioNome AS TerritorioNome,
          MIC.TerritorioId AS MicroregiaoId, MIC.TerritorioNome AS MicroregiaoNome,
          MES.TerritorioId AS MesoregiaoId, MES.TerritorioNome AS MesoregiaoNome,
          FEU.TerritorioId AS UnidadeFederativaId, FEU.TerritorioNome AS UnidadeFederativaNome,
          REG.TerritorioId AS RegiaoId, REG.TerritorioNome AS RegiaoNome,
          FED.TerritorioId AS FederacaoId, FED.TerritorioNome AS FederacaoNome
     FROM Territorio TER 
    INNER JOIN Territorio MIC ON MIC.TerritorioId = TER.TerritorioSuperiorId 
    INNER JOIN Territorio MES ON MES.TerritorioId = MIC.TerritorioSuperiorId 
    INNER JOIN Territorio FEU ON FEU.TerritorioId = MES.TerritorioSuperiorId 
    INNER JOIN Territorio REG ON REG.TerritorioId = FEU.TerritorioSuperiorId
    INNER JOIN Territorio FED ON FED.TerritorioId = REG.TerritorioSuperiorId
    WHERE TER.NivelTerritorioId = 6;
GO