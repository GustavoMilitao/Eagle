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
    public class PaymentMethodDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO PaymentMethod(
ID_User,
ID_Pay_Type,
Active,
Reg_Date)
VALUES(
@ID_User,
@ID_Pay_Type,
@Active,
@Reg_Date)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE PaymentMethod SET 
ID_User = @ID_User,
ID_Pay_Type = @ID_Pay_Type,
Active = @Active,
Reg_Date = @Reg_Date
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
ID_User,
ID_Pay_Type,
Active,
Reg_Date,
FROM PaymentMethod
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
ID_User,
ID_Pay_Type,
Active,
Reg_Date,
FROM PaymentMethod

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM PaymentMethod
WHERE ID = @ID
";

        #endregion

        #endregion
        public PaymentMethodDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertPaymentMethod(PaymentMethod paymentMethod)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDUser", paymentMethod.IDUser);
            parameters.Add("@IDPayType", paymentMethod.IDPayType);
            parameters.Add("@Active", paymentMethod.Active);
            parameters.Add("@RegDate", paymentMethod.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", paymentMethod.ID);
            parameters.Add("@IDUser", paymentMethod.IDUser);
            parameters.Add("@IDPayType", paymentMethod.IDPayType);
            parameters.Add("@Active", paymentMethod.Active);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public PaymentMethod getPaymentMethodByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<PaymentMethod>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeletePaymentMethodByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<PaymentMethod> ListPaymentMethods()
        {
            return SqlMapper.Query<PaymentMethod>(connection, SQL_GET_USERS).ToList();
        }
    }
}

