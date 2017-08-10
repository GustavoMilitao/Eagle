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
    public class UserTypeDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"

INSERT INTO dbo.UserType
           (Type)
     VALUES
           (@Type)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"
            UPDATE UserTypes
            SET Type = @Type
            WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"
        SELECT ID
               ,Type
        FROM UserType
        WHERE ID = @ID
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT ID
               ,Type
        FROM UserType
";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"

            DELETE FROM UserTypes 
            WHERE ID = @ID
";

        #endregion

        #endregion
        public UserTypeDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertUserType(UserType userType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Type", userType.Type, DbType.AnsiString);
            parameters.Add("@Reg_Date", DateTime.Now, DbType.DateTime);

            return (int) SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateUserType(UserType userType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Type", userType.Type, DbType.AnsiString);
            parameters.Add("@ID", userType.ID, DbType.Int32);

            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public UserType getUserTypeByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<UserType>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteUserTypeByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<UserType> ListUserTypes()
        {
            return SqlMapper.Query<UserType>(connection, SQL_GET_USERS).ToList();
        }
    }
}
