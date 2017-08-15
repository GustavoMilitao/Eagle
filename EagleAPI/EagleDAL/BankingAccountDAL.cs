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
    public class BankingAccountDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO BankingAccount(
IDUser,
Bankcode,
Bankname,
Agency,
CurrentAccount,
Digit,
RegDate)
VALUES(
@IDUser,
@Bankcode,
@Bankname,
@Agency,
@CurrentAccount,
@Digit,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE BankingAccount SET 
IDUser = @IDUser,
Bankcode = @Bankcode,
Bankname = @Bankname,
Agency = @Agency,
CurrentAccount = @CurrentAccount,
Digit = @Digit,
RegDate = @RegDate
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"







SELECT ID,IDUser,Bankcode,Bankname,Agency,CurrentAccount,Digit,RegDate
FROM BankingAccount
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
SELECT ID,IDUser,Bankcode,Bankname,Agency,CurrentAccount,Digit,RegDate
FROM BankingAccount

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM BankingAccount
WHERE ID = @ID
";

        #endregion

        #endregion
        public BankingAccountDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertBankingAccount(BankingAccount bankingAccount)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDUser", bankingAccount.IDUser);
            parameters.Add("@Bankcode", bankingAccount.Bankcode);
            parameters.Add("@Bankname", bankingAccount.Bankname);
            parameters.Add("@Agency", bankingAccount.Agency);
            parameters.Add("@CurrentAccount", bankingAccount.CurrentAccount);
            parameters.Add("@Digit", bankingAccount.Digit);
            parameters.Add("@RegDate", bankingAccount.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateBankingAccount(BankingAccount bankingAccount)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", bankingAccount.ID);
            parameters.Add("@IDUser", bankingAccount.IDUser);
            parameters.Add("@Bankcode", bankingAccount.Bankcode);
            parameters.Add("@Bankname", bankingAccount.Bankname);
            parameters.Add("@Agency", bankingAccount.Agency);
            parameters.Add("@CurrentAccount", bankingAccount.CurrentAccount);
            parameters.Add("@Digit", bankingAccount.Digit);
            parameters.Add("@RegDate", bankingAccount.RegDate);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public BankingAccount getBankingAccountByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<BankingAccount>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteBankingAccountByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<BankingAccount> ListBankingAccounts()
        {
            return SqlMapper.Query<BankingAccount>(connection, SQL_GET_USERS).ToList();
        }
    }
}

