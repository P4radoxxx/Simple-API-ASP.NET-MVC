using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using WebAPITest.Helpers;
using WebAPITest.Modeles;
using WebAPITest.Repositories;

namespace WebAPITest.DAL
{
    public class ProjectDAL : IProjectRepository
    {
        
        
        private readonly string connectionString = ConfigurationHelper.GetConnectionString("CString");




        public List<Project> GetAllProjects()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Project";
                var projects = connection.Query<Project>(sql).AsList();
                return projects;
            }
        }




        public Project ReadProjectID(int projectId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Project WHERE ProjectID = @ProjectID";
                var project = connection.QueryFirstOrDefault<Project>(sql, new { ProjectID = projectId });
                return project;
            }
        }




        public void CreateProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Project (Name, Amount, Created, DateAvailable, EndingDate, UserID) " +
                             "VALUES (@Name, @Amount, @Created, @DateAvailable, @EndingDate, @UserID)";
                connection.Execute(sql, project);
            }
        }




        public void UpdateProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Project SET Name = @Name, Amount = @Amount, Created = @Created, " +
                             "DateAvailable = @DateAvailable, EndingDate = @EndingDate WHERE ProjectID = @ProjectID";
                connection.Execute(sql, project);
            }
        }




        public void DeleteProject(int projectId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Project WHERE ProjectID = @ProjectID";
                connection.Execute(sql, new { ProjectID = projectId });
            }
        }

        
    }
}
