namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public int IdFreelancer { get; private set; }
    public decimal? TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public IEnumerable<ProjectComment> Comments { get; private set; }
}