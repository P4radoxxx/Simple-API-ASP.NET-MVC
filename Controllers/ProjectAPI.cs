using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPITest.Modeles;
using WebAPITest.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using WebAPITest.ErrorHandling;
using System.Net;

namespace WebAPITest.Controllers
{
    [ApiController]
    [Route("api/projects")]
    
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }




        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();
            return Ok(projects);
        }




        // Swagger response isn't working as expected.
        [HttpGet("{id}")]
        [SwaggerResponse(204,"No Content",typeof(ErrorResponseModel))]
        public IActionResult ReadProjectByID(int id)
        {
            var project = _projectRepository.ReadProjectID(id);


            if (project == null)
            {
                var errorResponse = new ErrorResponseModel
                {
                    ErrorCode = "204 No Content",
                    ErrorMessage = "Projet non trouvé dans la database !"
                };
            }
            return Ok(project);
        }





        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Données de projet invalides");
            }
            _projectRepository.CreateProject(project);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] Project project)
        {
            if (project == null || id != project.ProjectID)
            {
                return BadRequest("Données de projet invalides");
            }
            var existingProject = _projectRepository.ReadProjectID(id);
            if (existingProject == null)
            {
                return NoContent();
            }
            _projectRepository.UpdateProject(project);
            return Ok();
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _projectRepository.ReadProjectID(id);
            if (project == null)
            {
                return NoContent();
            }
            _projectRepository.DeleteProject(id);
            return Ok();
        }
    }
}
