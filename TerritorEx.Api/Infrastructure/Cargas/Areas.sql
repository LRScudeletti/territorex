----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaAltitudeSuperior1800
----------------------------

PRINT 'Inserindo dados na tabela AreaAltitudeSuperior1800'

INSERT INTO AreaAltitudeSuperior1800(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.AREA_ALTITUDE_SUPERIOR_1800 A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaAltitudeSuperior1800 B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela Areabanhado
----------------------------

PRINT 'Inserindo dados na tabela Areabanhado'

INSERT INTO Areabanhado(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.BANHADO A
 WHERE NOT EXISTS (SELECT 1 
                     FROM Areabanhado B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaBordaChapada
----------------------------

PRINT 'Inserindo dados na tabela AreaBordaChapada'

INSERT INTO AreaBordaChapada(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.BORDA_CHAPADA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaBordaChapada B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaConsolidada
----------------------------

PRINT 'Inserindo dados na tabela AreaConsolidada'

INSERT INTO AreaConsolidada(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.AREA_CONSOLIDADA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaConsolidada B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaDeclividadeMaior45
----------------------------

PRINT 'Inserindo dados na tabela AreaDeclividadeMaior45'

INSERT INTO AreaDeclividadeMaior45(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.AREA_DECLIVIDADE_MAIOR_45 A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaDeclividadeMaior45 B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaHidrografia
----------------------------

PRINT 'Inserindo dados na tabela AreaHidrografia'

INSERT INTO AreaHidrografia(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.HIDROGRAFIA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaHidrografia B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaImovel
----------------------------

PRINT 'Inserindo dados na tabela AreaImovel'

INSERT INTO AreaImovel(
       TerritorioId,
       ImovelId,
       TipoImovelId,
       SituacaoImovelId,
       Condicao,
       AreaHectare,
       AreaHectareFiscal,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao) 
SELECT TERRITORIOID,
       COD_IMOVEL,
       CASE 
	     WHEN TIPO_IMOVE = 'IRU' THEN 1
		 WHEN TIPO_IMOVE = 'AST' THEN 2
		 WHEN TIPO_IMOVE = 'PCT' THEN 3
		 WHEN TIPO_IMOVE = 'CNFP' THEN 4
	   END AS TIPO_IMOVE,
       CASE 
	     WHEN SITUACAO = 'AT' THEN 1
		 WHEN SITUACAO = 'PE' THEN 2
		 WHEN SITUACAO = 'CA' THEN 3
		 WHEN SITUACAO = 'SU' THEN 4
	   END AS SITUACAO,
       CONDICAO_I,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       try_convert(float(53),REPLACE(NUM_MODULO,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.AREA_IMOVEL A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaImovel B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.ImovelId = A.COD_IMOVEL
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaManguezal
----------------------------

PRINT 'Inserindo dados na tabela AreaManguezal'

INSERT INTO AreaManguezal(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.MANGUEZAL A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaManguezal B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaNascenteOlhoDAgua
----------------------------

PRINT 'Inserindo dados na tabela AreaNascenteOlhoDAgua'

INSERT INTO AreaNascenteOlhoDAgua(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       TEMA,
       0,
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.NASCENTE_OLHO_DAGUA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaNascenteOlhoDAgua B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaPousio
----------------------------

PRINT 'Inserindo dados na tabela AreaPousio'

INSERT INTO AreaPousio(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.AREA_POUSIO A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaPousio B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaPreservacaoPermanente
----------------------------

PRINT 'Inserindo dados na tabela AreaPreservacaoPermanente'

INSERT INTO AreaPreservacaoPermanente(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.APP A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaPreservacaoPermanente B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaReservaLegal
----------------------------

PRINT 'Inserindo dados na tabela AreaReservaLegal'

INSERT INTO AreaReservaLegal(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.RESERVA_LEGAL A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaReservaLegal B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaRestinga
----------------------------

PRINT 'Inserindo dados na tabela AreaRestinga'

INSERT INTO AreaRestinga(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.RESTINGA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaRestinga B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaServidaoAdministrativa
----------------------------

PRINT 'Inserindo dados na tabela AreaServidaoAdministrativa'

INSERT INTO AreaServidaoAdministrativa(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.SERVIDAO_ADMINISTRATIVA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaServidaoAdministrativa B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaTopoMorro
----------------------------

PRINT 'Inserindo dados na tabela AreaTopoMorro'

INSERT INTO AreaTopoMorro(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.AREA_TOPO_MORRO A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaTopoMorro B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaUsoRestrito
----------------------------

PRINT 'Inserindo dados na tabela AreaUsoRestrito'

INSERT INTO AreaUsoRestrito(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.USO_RESTRITO A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaUsoRestrito B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaVegetacaoNativa
----------------------------

PRINT 'Inserindo dados na tabela AreaVegetacaoNativa'

INSERT INTO AreaVegetacaoNativa(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.VEGETACAO_NATIVA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaVegetacaoNativa B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaVereda
----------------------------

PRINT 'Inserindo dados na tabela AreaVereda'

INSERT INTO AreaVereda(
       TerritorioId,
       SicarId,
       Descricao,
       AreaHectare,
       Shape,
       UsuarioAtualizacao,
       DataAtualizacao)
SELECT TERRITORIOID,
       IDF,
       NOM_TEMA,
       try_convert(float(53),REPLACE(NUM_AREA,',','.')),
       GEO.STAsBinary(),
       'SCUDX',
       GETDATE()
  FROM TerritorExCarga.dbo.VEREDA A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaVereda B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());
GO