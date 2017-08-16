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
    public class PaymentTypeDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO PaymentType(
Description)
OUTPUT INSERTED.ID
VALUES(
@Description)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE PaymentType SET 
Description = @Description
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
Description
FROM PaymentType
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
Description
FROM PaymentType

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM PaymentType
WHERE ID = @ID
";

        #endregion

        #endregion
        public PaymentTypeDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertPaymentType(PaymentType paymentType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Description", paymentType.Description);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdatePaymentType(PaymentType paymentType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", paymentType.ID);
            parameters.Add("@Description", paymentType.Description);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public PaymentType getPaymentTypeByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<PaymentType>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeletePaymentTypeByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<PaymentType> ListPaymentTypes()
        {
            return SqlMapper.Query<PaymentType>(connection, SQL_GET_USERS).ToList();
        }
    }
}

