using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{
    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }

    public List<ProjectComment> ProjectComments { get; set; }

    public DevFreelaDbContext()
    {
        Projects = new List<Project>
        {
            new Project("Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 1000),
            new Project("Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 2000),
            new Project("Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 3000),
        };

        Users = new List<User>
        {
            new User("Rafael Veronez", "rafael@gmail.com", new DateTime(1997, 1, 1)),
            new User("Rafael Veronez 2", "rafael2@gmail.com", new DateTime(1997, 1, 1)),
            new User("Rafael Veronez 3", "rafael3@gmail.com", new DateTime(1997, 1, 1)),
        };

        Skills = new List<Skill>
        {
            new Skill(".NET Core"),
            new Skill("Asp.Net Core"),
            new Skill("C#"),
            new Skill("SQL")
        };
    }
}