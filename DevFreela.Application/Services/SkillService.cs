using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public SkillService(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _devFreelaDbContext.Skills
            .Select(sk => new SkillViewModel(sk.Id, sk.Description))
            .ToList();
        return skills;
    }
}