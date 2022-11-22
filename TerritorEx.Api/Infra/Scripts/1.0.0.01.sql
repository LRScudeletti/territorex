----------------------------]
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela NivelTerritorio
----------------------------

PRINT 'Inserindo dados na tabela NivelTerritorio'

SET IDENTITY_INSERT NivelTerritorio ON;

INSERT NivelTerritorio (NivelTerritorioId,Sigla,Descricao,UsuarioAtualizacao,DataAtualizacao)
SELECT 1,'FE','Federação','SCUDX',GETDATE() UNION ALL
SELECT 2,'RE','Região','SCUDX',GETDATE() UNION ALL
SELECT 3,'UF','Unidade Federativa','SCUDX',GETDATE() UNION ALL
SELECT 4,'ME','Mesorregião','SCUDX',GETDATE() UNION ALL
SELECT 5,'MI','Microrregião','SCUDX',GETDATE() UNION ALL
SELECT 6,'MU','Município','SCUDX',GETDATE();

SET IDENTITY_INSERT NivelTerritorio OFF;

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela SituacaoImovel
----------------------------

PRINT 'Inserindo dados na tabela SituacaoImovel'

SET IDENTITY_INSERT SituacaoImovel ON;

INSERT SituacaoImovel (SituacaoImovelId,Sigla,Descricao,UsuarioAtualizacao,DataAtualizacao)
SELECT 1,'AT','Ativo','SCUDX',GETDATE() UNION ALL
SELECT 2,'PE','Pendente','SCUDX',GETDATE() UNION ALL
SELECT 3,'CA','Cancelado','SCUDX',GETDATE() UNION ALL
SELECT 4,'SU','Em Análise','SCUDX',GETDATE();

SET IDENTITY_INSERT SituacaoImovel OFF;

----------------------------
-- Data alteração | Usuário | Nº Card | Descrição
-- 19/11/2022 | Luiz Rogério Scudeletti | Sem card | Inserindo dados na tabela TipoImovel
----------------------------

PRINT 'Inserindo dados na tabela TipoImovel'

SET IDENTITY_INSERT TipoImovel ON;

INSERT TipoImovel (TipoImovelId,Sigla,Descricao,UsuarioAtualizacao,DataAtualizacao)
SELECT 1,'IRU','Imóvel Rural','SCUDX',GETDATE() UNION ALL
SELECT 2,'AST','Assentamento','SCUDX',GETDATE() UNION ALL
SELECT 3,'PCT','Povos de Comunidades Tradicionais','SCUDX',GETDATE() UNION ALL
SELECT 4,'CNFP','Cadastro Nacional de Florestas Públicas','SCUDX',GETDATE();

SET IDENTITY_INSERT TipoImovel OFF;