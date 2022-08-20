using AutoMapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Territory;

namespace TerritorEx.Api.Services;

public interface ITerritoryService
{
    void Create(TerritoryCreateModel territoryCreateModel);
    IEnumerable<TerritoryEntity> ReadAll();
    TerritoryEntity ReadByTerritoryId(int territoryId);
    IEnumerable<TerritoryEntity> ReadByContainsName(string territoryName);
    IEnumerable<TerritoryEntity> ReadByParentId(int territoryParentId);
    IEnumerable<TerritoryEntity> ReadByLevelId(int levelId);
    void Update(TerritoryUpdateModel territoryUpdateModel);
    void Delete(int territoryId);
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

    public void Create(TerritoryCreateModel territoryCreateModel)
    {
        if (_context.Territories.Any(x => x.TerritoryId == territoryCreateModel.TerritoryId))
            throw new AppException(string.Format(
                Properties.Resources.ThereIsAlreadyTerritoryRegisteredWithId, territoryCreateModel.TerritoryId));

        var territory = _mapper.Map<TerritoryEntity>(territoryCreateModel);

        _context.Territories.Add(territory);
        _context.SaveChanges();
    }

    public IEnumerable<TerritoryEntity> ReadAll()
    {
        return _context.Territories;
    }

    public TerritoryEntity ReadByTerritoryId(int territoryId)
    {
        return GetTerritory(territoryId);
    }

    public IEnumerable<TerritoryEntity> ReadByContainsName(string territoryName)
    {
        var territory = _context.Territories.Where(
            x => x.TerritoryName.Contains(territoryName));

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

    public void Update(TerritoryUpdateModel territoryUpdateModel)
    {
        var territory = GetTerritory(territoryUpdateModel.TerritoryId);

        if (territory == null)
            throw new KeyNotFoundException(string.Format(
                Properties.Resources.NoTerritoryFoundById, territoryUpdateModel.TerritoryId));

        _mapper.Map(territoryUpdateModel, territory);

        _context.Territories.Update(territory);
        _context.SaveChanges();
    }

    public void Delete(int territoryId)
    {
        var territory = GetTerritory(territoryId);
        _context.Territories.Remove(territory);
        _context.SaveChanges();
    }

    // Helper method
    private TerritoryEntity GetTerritory(int territoryId)
    {
        var territory = _context.Territories.FirstOrDefault(x => x.TerritoryId == territoryId);

        if (territory == null)
            throw new KeyNotFoundException(string.Format(
                Properties.Resources.NoTerritoryFoundById, territoryId));

        return territory;
    }
}