using WebAPITest.Modeles;
using WebAPITest.Repositories;
using Dapper;
using WebAPITest.Helpers;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace WebAPITest.DAL
{

    // Basic CRUD + 1 method to get user by email who will be used with the login controller.
    public class UserDAL : IUserRepository
    {
      
        
       private readonly string connectionString = ConfigurationHelper.GetConnectionString("CString");




        public Users CreateUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password); SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = connection.Query<int>(sql, user).Single();
                user.UserID = id;
                return user;
            }
        }




        public void DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Users WHERE UserID = @UserID";
                connection.Execute(sql, new { UserID = id });
            }
        }




        public List<Users> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users";
                var users = connection.Query<Users>(sql).ToList();
                return users;
            }
        }




        public Users GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users WHERE Email = @Email";
                var user = connection.Query<Users>(sql, new { Email = email }).FirstOrDefault();
                return user;
            }
        }




        public Users ReadUserID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users WHERE UserID = @UserID";
                var user = connection.Query<Users>(sql, new { UserID = id }).FirstOrDefault();
                return user;
            }
        }
        


        public void UpdateUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password WHERE UserID = @UserID";
                connection.Execute(sql, user);
            }
        }



    }
}
