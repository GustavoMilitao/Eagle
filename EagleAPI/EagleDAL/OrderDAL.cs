using Dapper;
using EagleEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleDAL
{
    public class OrderDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO Orders(
IDUser,
IDDistributor,
IDDriver,
TotalPrice,
RegDate)
OUTPUT INSERTED.ID
VALUES(
@IDUser,
@IDDistributor,
@IDDriver,
@TotalPrice,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE Orders SET 
IDUser = @IDUser,
IDDistributor = @IDDistributor,
IDDriver = @IDDriver,
TotalPrice = @TotalPrice,

WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDUser,
IDDistributor,
IDDriver,
TotalPrice,
RegDate
FROM Orders
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"SELECT 
ID,
IDUser,
IDDistributor,
IDDriver,
TotalPrice,
RegDate
FROM Orders
";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM Orders
WHERE ID = @ID
";

        #endregion

        #endregion
        public OrderDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertOrder(Order order)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDUser", order.IDUser);
            parameters.Add("@IDDistributor", order.IDDistributor);
            parameters.Add("@IDDriver", order.IDDriver);
            parameters.Add("@TotalPrice", order.TotalPrice);
            parameters.Add("@RegDate", order.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateOrder(Order order)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", order.ID);
            parameters.Add("@IDUser", order.IDUser);
            parameters.Add("@IDDistributor", order.IDDistributor);
            parameters.Add("@IDDriver", order.IDDriver);
            parameters.Add("@TotalPrice", order.TotalPrice);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public Order getOrderByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<Order>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteOrderByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<Order> ListOrders()
        {
            return SqlMapper.Query<Order>(connection, SQL_GET_USERS).ToList();
        }
    }
}

