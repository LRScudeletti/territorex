using AutoMapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Services
{
    public interface ITerritoryService
    {
    }

    public class TerritoryService : ITerritoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TerritoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TerritoryEntity> ReadAll()
        {
            return _context.Territories;
        }

        public TerritoryEntity ReadByTerritoryId(int territoryId)
        {
            return GetTerritory(territoryId);
        }

        public TerritoryEntity ReadByContainsName(string territoryName)
        {
            var territory = _context.Territories.FirstOrDefault(x => x.TerritoryName == territoryName);

            if (territory == null)
                throw new KeyNotFoundException(string.Format(
                        Properties.Resources.NoTerritoryFoundByName, territoryName));

            return territory;
        }

        public IEnumerable<TerritoryEntity> ReadByParentId(int territoryParentId)
        {
            var territory = _context.Territories.Where(x => x.TerritoryParentId == territoryParentId);

            if (territory == null)
                throw new KeyNotFoundException(string.Format(
                    Properties.Resources.NoTerritoryFoundByParentId, territoryParentId));

            return territory;
        }

        public IEnumerable<TerritoryEntity> ReadByLevelId(int levelId)
        {
            var territory = _context.Territories.Where(x => x.LevelId == levelId);

            if (territory == null)
                throw new KeyNotFoundException(string.Format(
                    Properties.Resources.NoTerritoryFoundByLevelId, levelId));

            return territory;
        }

        // Helper methods
        private TerritoryEntity GetTerritory(int territoryId)
        {
            var territory = _context.Territories.FirstOrDefault(x => x.TerritoryId == territoryId);

            if (territory == null)
                throw new KeyNotFoundException(string.Format(
                    Properties.Resources.NoTerritoryFoundById, territoryId));

            return territory;
        }
    }
}
