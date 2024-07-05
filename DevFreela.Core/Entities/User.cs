namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; set; }
    public IEnumerable<UserSkill> Skills { get; private set; }
    public IEnumerable<Project> OwnedProjects { get; private set; }
    public IEnumerable<Project> FreelanceProject { get; set; }

    public User(string fullName, string email, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Active = true;
        Skills = Enumerable.Empty<UserSkill>();
        OwnedProjects = Enumerable.Empty<Project>();
        FreelanceProject = Enumerable.Empty<Project>();
    }
}