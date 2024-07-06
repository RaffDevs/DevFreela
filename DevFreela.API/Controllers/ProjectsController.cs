using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _projectService.GetAll(query);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);
        return Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectInputModel projectModel)
    {
        var projectId = _projectService.Create(projectModel);
        return CreatedAtAction(nameof(GetById), new { id = projectId }, projectModel);
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel project)
    {
        _projectService.Update(project);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _projectService.Delete(id);
        return NoContent();
    }
}