using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services;

public class SkillService : ISkillService
{
    private readonly DatabaseContext _databaseContext;

    public SkillService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _databaseContext.Skills
            .Select(sk => new SkillViewModel(sk.Id, sk.Description))
            .ToList();
        return skills;
    }
}