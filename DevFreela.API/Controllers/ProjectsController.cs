using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectModel project)
    {
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] UpdateProjectModel project)
    {
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}