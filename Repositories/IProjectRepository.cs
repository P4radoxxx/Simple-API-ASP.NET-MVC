using WebAPITest.Modeles;

namespace WebAPITest.Repositories
{
    public interface IProjectRepository
    {
        public void CreateProject(Project project);
        public Project ReadProjectID(int projectID);
        public void UpdateProject(Project project);
        public void DeleteProject(int id);
        public List<Project> GetAllProjects();

    }
}
