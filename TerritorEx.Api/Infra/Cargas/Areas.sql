----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 20/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela AreaPreservacaoPermanente
----------------------------

PRINT 'Inserindo dados na tabela AreaPreservacaoPermanente'

INSERT INTO AreaPreservacaoPermanente (
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
  FROM TerritorExTeste.dbo.APP A
 WHERE NOT EXISTS (SELECT 1 
                     FROM AreaPreservacaoPermanente B
                    WHERE B.TerritorioId = A.TERRITORIOID 
                      AND B.SicarId = A.IDF
                      AND B.Descricao = A.NOM_TEMA
                      AND B.SHAPE = A.GEO.STAsBinary());

