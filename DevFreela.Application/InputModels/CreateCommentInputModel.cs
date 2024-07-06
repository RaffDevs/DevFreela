namespace DevFreela.Application.InputModels;

public record CreateCommentInputModel(string Content, int IdUser, int IdProject);