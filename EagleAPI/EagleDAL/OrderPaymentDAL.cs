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
    public class OrderPaymentDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO OrderPayment(
IDPayMethod,
IDOrder,
Value,
RegDate)
VALUES(
@IDPayMethod,
@IDOrder,
@Value,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE OrderPayment SET 
IDPayMethod = @IDPayMethod,
IDOrder = @IDOrder,
Value = @Value,

WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDPayMethod,
IDOrder,
Value,
RegDate,
FROM OrderPayment
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
IDPayMethod,
IDOrder,
Value,
RegDate,
FROM OrderPayment

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM OrderPayment
WHERE ID = @ID
";

        #endregion

        #endregion
        public OrderPaymentDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertOrderPayment(OrderPayment orderPayment)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDPayMethod", orderPayment.IDPayMethod);
            parameters.Add("@IDOrder", orderPayment.IDOrder);
            parameters.Add("@Value", orderPayment.Value);
            parameters.Add("@RegDate", orderPayment.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateOrderPayment(OrderPayment orderPayment)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", orderPayment.ID);
            parameters.Add("@IDPayMethod", orderPayment.IDPayMethod);
            parameters.Add("@IDOrder", orderPayment.IDOrder);
            parameters.Add("@Value", orderPayment.Value);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public OrderPayment getOrderPaymentByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<OrderPayment>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteOrderPaymentByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<OrderPayment> ListOrderPayments()
        {
            return SqlMapper.Query<OrderPayment>(connection, SQL_GET_USERS).ToList();
        }
    }
}

