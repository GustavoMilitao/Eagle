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
    public class CreditCardDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO CreditCard(
IDPaymentMethod,
NameInCard,
CardNumber,
ValidTru,
CVV,
RegDate)
OUTPUT INSERTED.ID
VALUES(
@IDPaymentMethod,
@NameInCard,
@CardNumber,
@ValidTru,
@CVV,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE CreditCard SET 
IDPaymentMethod = @IDPaymentMethod,
NameInCard = @NameInCard,
CardNumber = @CardNumber,
ValidTru = @ValidTru,
CVV = @CVV,

WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDPaymentMethod,
NameInCard,
CardNumber,
ValidTru,
CVV,
RegDate
FROM CreditCard
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
IDPaymentMethod,
NameInCard,
CardNumber,
ValidTru,
CVV,
RegDate
FROM CreditCard

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM CreditCard
WHERE ID = @ID
";

        #endregion

        #endregion
        public CreditCardDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertCreditCard(CreditCard creditCard)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDPaymentMethod", creditCard.IDPaymentMethod);
            parameters.Add("@NameInCard", creditCard.NameInCard);
            parameters.Add("@CardNumber", creditCard.CardNumber);
            parameters.Add("@ValidTru", creditCard.ValidTru);
            parameters.Add("@CVV", creditCard.CVV);
            parameters.Add("@RegDate", creditCard.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateCreditCard(CreditCard creditCard)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", creditCard.ID);
            parameters.Add("@IDPaymentMethod", creditCard.IDPaymentMethod);
            parameters.Add("@NameInCard", creditCard.NameInCard);
            parameters.Add("@CardNumber", creditCard.CardNumber);
            parameters.Add("@ValidTru", creditCard.ValidTru);
            parameters.Add("@CVV", creditCard.CVV);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public CreditCard getCreditCardByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<CreditCard>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteCreditCardByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<CreditCard> ListCreditCards()
        {
            return SqlMapper.Query<CreditCard>(connection, SQL_GET_USERS).ToList();
        }
    }
}

