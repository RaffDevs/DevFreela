namespace DevFreela.Application.ViewModels;

public record ProjectDetailsViewModel(
    int Id,
    string Title,
    string Description,
    DateTime? StartedAt,
    DateTime? FinishedAt,
    decimal TotalCost);