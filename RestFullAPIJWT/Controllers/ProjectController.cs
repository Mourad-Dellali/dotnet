using RestFullAPIJwt.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RestFullAPIJwt.Controllers;

[ApiController]
[Route("api/projects")]
[Authorize] // Apply Authorize at the controller level to ensure all actions require authentication by default
public class ProjectsController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = Permission.Project.Read)] // Requires 'project:read' permission
    public IActionResult GetProjects()
    {
        return Ok(new
        {
            Message = "Read List of project",
            UserInfo = GetUserInfo(),
            Permission = Permission.Project.Read // Using constant for consistency
        });
    }

    private string GetUserInfo()
    {
        if (User.Identity is {IsAuthenticated: false})
            return "Annonymous";
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var FirstName = User.FindFirst(ClaimTypes.GivenName);
        var LastName = User.FindFirst(ClaimTypes.Surname);

        return $"[{userId}] {FirstName} {LastName}";
    }

    [HttpGet("{id}")]
    [Authorize(Policy = Permission.Project.Read)] // Requires 'project:read' permission
    public IActionResult GetProjectById(string id)
    {
        return Ok(new
        {
            Message = $"Read a single project with id = {id}",
            UserInfo = GetUserInfo(),
            Permission = Permission.Project.Read // Using constant for consistency
        });
    }

    [HttpPost]
    [Authorize(Policy = Permission.Project.Create)] // Requires 'project:create' permission
    public IActionResult CreateProject()
    {
        return CreatedAtAction(
            nameof(GetProjectById),
            new { id = Guid.NewGuid() },
            new
            {
                Message = "Project created successfully",
                UserInfo = GetUserInfo(),
                Permission = Permission.Project.Create // Using constant for consistency
            });
    }

    [HttpPut("{id}")]
    [Authorize(Policy = Permission.Project.Update)] // Requires 'project:update' permission
    public IActionResult UpdateProject(string id)
    {
        return Ok(new
        {
            Message = $"Project with Id = '{id}' was updated successfully",
            UserInfo = GetUserInfo(),
            Permission = Permission.Project.Update // Using constant for consistency
        });
    }


    [HttpDelete("{id}")]
    [Authorize(Policy = Permission.Project.Delete)] // Requires 'project:delete' permission
    public IActionResult DeleteProject(string id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(new
        {
            Message = $"Project with Id = '{id}' was Deleted successfully",
            UserInfo = GetUserInfo(),
            Permission = Permission.Project.Delete // Using constant for consistency
        });
    }

    [HttpPost("{id}/members")]
    [Authorize(Policy = Permission.Project.AssignMember)] // Requires 'project:assign_member' permission
    public IActionResult AssignMember(string id)
    {
        return CreatedAtAction(
            nameof(GetProjectById),
            new { id },
            new
            {
                Message = $"A memeber has been assigned successfully to project '{id}'",
                UserInfo = GetUserInfo(),
                Permission = Permission.Project.AssignMember // Using constant for consistency
            }
        );
    }

    [HttpGet("{id}/budget")]
    [Authorize(Policy = Permission.Project.ManageBudget)] // Requires 'project:manage_budget' permission
    public IActionResult GetProjectBudget(string id)
    {
        return Ok(new
        {
            Message = $"Successfully accessed the budget for project '{id}'",
            UserInfo = GetUserInfo(),
            Permission = Permission.Project.ManageBudget // Using constant for consistency
        });
    }

    [HttpGet("tasks/{taskId}")]
    [Authorize(Policy = Permission.Task.Read)] // Requires 'task:read' permission
    public IActionResult GetTask(string taskId)
    {
        return Ok(new
        {
            Message = $"Task '{taskId}' details retrieved",
            UserInfo = GetUserInfo(),
            Permission = Permission.Task.Read // Using constant for consistency
        });
    }
}