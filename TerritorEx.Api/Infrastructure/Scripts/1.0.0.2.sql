----------------------------]
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela NivelTerritorio
----------------------------

PRINT 'Inserindo dados na tabela NivelTerritorio'

SET IDENTITY_INSERT NivelTerritorio ON;

INSERT NivelTerritorio (NivelTerritorioId,Sigla,Descricao,UsuarioAtualizacao,DataAtualizacao)
SELECT 1,'FE','Federação','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM NivelTerritorio WHERE NivelTerritorioId = 1) UNION ALL
SELECT 2,'RE','Região','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM NivelTerritorio WHERE NivelTerritorioId = 2) UNION ALL
SELECT 3,'UF','Unidade Federativa','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM NivelTerritorio WHERE NivelTerritorioId = 3) UNION ALL
SELECT 4,'ME','Mesorregião','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM NivelTerritorio WHERE NivelTerritorioId = 4) UNION ALL
SELECT 5,'MI','Microrregião','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM NivelTerritorio WHERE NivelTerritorioId = 5) UNION ALL
SELECT 6,'MU','Município','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM NivelTerritorio WHERE NivelTerritorioId = 6);

SET IDENTITY_INSERT NivelTerritorio OFF;

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela SituacaoImovel
----------------------------

PRINT 'Inserindo dados na tabela SituacaoImovel'

SET IDENTITY_INSERT SituacaoImovel ON;

INSERT SituacaoImovel (SituacaoImovelId,Sigla,Descricao,UsuarioAtualizacao,DataAtualizacao)
SELECT 1,'AT','Ativo','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM SituacaoImovel WHERE SituacaoImovelId = 1) UNION ALL
SELECT 2,'PE','Pendente','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM SituacaoImovel WHERE SituacaoImovelId = 2) UNION ALL
SELECT 3,'CA','Cancelado','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM SituacaoImovel WHERE SituacaoImovelId = 3) UNION ALL
SELECT 4,'SU','Em Análise','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM SituacaoImovel WHERE SituacaoImovelId = 4);

SET IDENTITY_INSERT SituacaoImovel OFF;

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela TipoImovel
----------------------------

PRINT 'Inserindo dados na tabela TipoImovel'

SET IDENTITY_INSERT TipoImovel ON;

INSERT TipoImovel (TipoImovelId,Sigla,Descricao,UsuarioAtualizacao,DataAtualizacao)
SELECT 1,'IRU','Imóvel Rural','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM TipoImovel WHERE TipoImovelId = 1) UNION ALL
SELECT 2,'AST','Assentamento','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM TipoImovel WHERE TipoImovelId = 2) UNION ALL
SELECT 3,'PCT','Povos de Comunidades Tradicionais','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM TipoImovel WHERE TipoImovelId = 3) UNION ALL
SELECT 4,'CNFP','Cadastro Nacional de Florestas Públicas','SCUDX',GETDATE() WHERE NOT EXISTS (SELECT 1 FROM TipoImovel WHERE TipoImovelId = 4);

SET IDENTITY_INSERT TipoImovel OFF;