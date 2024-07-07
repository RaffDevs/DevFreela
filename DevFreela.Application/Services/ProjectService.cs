using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public ProjectService(DevFreelaDbContext context)
    {
        _devFreelaDbContext = context;
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _devFreelaDbContext.Projects;

        var projectViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectViewModel;
    }

    public ProjectDetailsViewModel GetById(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        return new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.StartedAt, 
            project.FinishedAt,
            project.TotalCost
            );
    }

    public int Create(CreateProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient,
            inputModel.IdFreelancer, inputModel.IdFreelancer);
        _devFreelaDbContext.Projects.Add(project);

        return project.Id;
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
        project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
    }

    public void Delete(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project?.Cancel();
    }

    public void Start(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project?.Start();
    }

    public void Finish(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project?.Finish();
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.IdUser, inputModel.IdProject);
        _devFreelaDbContext.ProjectComments.Add(comment);
    }
}