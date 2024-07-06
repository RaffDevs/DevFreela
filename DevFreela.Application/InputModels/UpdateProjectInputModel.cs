namespace DevFreela.Application.InputModels;

public record UpdateProjectInputModel(
    int Id,
    string Title,
    string Description,
    decimal TotalCost
);