namespace DevFreela.Application.InputModels;

public record CreateProjectInputModel(
    string Title,
    string Description,
    int IdClient,
    int IdFreelancer,
    decimal TotalCost
);