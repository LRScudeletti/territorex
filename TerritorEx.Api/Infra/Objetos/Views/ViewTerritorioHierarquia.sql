----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Criando view: ViewTerritorioHierarquia
----------------------------

PRINT 'Criando view: ViewTerritorioHierarquia'

IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'ViewTerritorioHierarquia') AND TYPE IN (N'V'))
BEGIN
   DROP VIEW ViewTerritorioHierarquia
END
GO

CREATE VIEW ViewTerritorioHierarquia AS
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