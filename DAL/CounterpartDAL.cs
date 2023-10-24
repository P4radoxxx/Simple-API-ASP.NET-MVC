using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using WebAPITest.Helpers;
using WebAPITest.Modeles;
using WebAPITest.Repositories;

namespace WebAPITest.DAL
{
    public class CounterpartDAL : ICounterpartRepository
    {


        private readonly string connectionString = ConfigurationHelper.GetConnectionString("CString");

       



        public List<Counterpart> GetAllCounterparts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Counterpart";
                var counterparts = connection.Query<Counterpart>(sql).AsList();
                return counterparts;
            }
        }



        public Counterpart ReadCounterpartID(int counterpartId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Counterpart WHERE CounterpartID = @CounterpartID";
                var counterpart = connection.QueryFirstOrDefault<Counterpart>(sql, new { CounterpartID = counterpartId });
                return counterpart;
            }
        }



        public void CreateCounterpart(Counterpart counterpart)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Counterpart (ProjectID, Amount, Description) " +
                             "VALUES (@ProjectID, @Amount, @Description)";
                connection.Execute(sql, counterpart);
            }
        }



        public void UpdateCounterpart(Counterpart counterpart)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Counterpart SET ProjectID = @ProjectID, Amount = @Amount, " +
                             "Description = @Description WHERE CounterpartID = @CounterpartID";
                connection.Execute(sql, counterpart);
            }
        }



        public void DeleteCounterpart(int counterpartId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Counterpart WHERE CounterpartID = @CounterpartID";
                connection.Execute(sql, new { CounterpartID = counterpartId });
            }
        }


    }
}
