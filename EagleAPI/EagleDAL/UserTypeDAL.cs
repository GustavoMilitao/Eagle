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

INSERT INTO UserTypes
           (Name
           ,Address
           ,City
           ,State
           ,Addresscode
           ,Country
           ,DDI
           ,DDD
           ,Phonenumber
           ,Nickname
           ,Password
           ,Email
           ,Reg_Date)
     OUTPUT INSERTED.ID
     VALUES
           (@Name
           ,@Address
           ,@City
           ,@State
           ,@Addresscode
           ,@Country
           ,@DDI
           ,@DDD
           ,@Phonenumber
           ,@Nickname
           ,CONVERT(BINARY, @Password)
           ,@Email
           ,@Reg_Date)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"
            UPDATE UserTypes
            SET  Name = @Name
                ,Address = @Address
                ,City = @City
                ,State = @State
                ,Addresscode = @Addresscode
                ,Country = @Country
                ,DDI = @DDI
                ,DDD = @DDD
                ,Phonenumber = @Phonenumber
                ,Nickname = @Nickname
                ,Password = CONVERT(BINARY,@Password)
                ,Email = @Email
            WHERE ID = @ID

";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"
        SELECT
            ID
           ,Name
           ,Address
           ,City
           ,State
           ,Addresscode
           ,Country
           ,DDI
           ,DDD
           ,Phonenumber
           ,Nickname
           ,ISNULL(CONVERT(VARCHAR,Password),'') Password
           ,Email
           ,Reg_Date
        FROM UserTypes
        WHERE ID = @ID
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT
            ID
           ,Name
           ,Address
           ,City
           ,State
           ,Addresscode
           ,Country
           ,DDI
           ,DDD
           ,Phonenumber
           ,Nickname
           ,ISNULL(CONVERT(VARCHAR,Password),'') Password
           ,Email
           ,Reg_Date
        FROM UserTypes
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
            parameters.Add("@Name", userType.Name, DbType.AnsiString);
            parameters.Add("@Address", userType.Address, DbType.AnsiString);
            parameters.Add("@City", userType.City, DbType.AnsiString);
            parameters.Add("@State", userType.State, DbType.AnsiString);
            parameters.Add("@Addresscode", userType.Addresscode, DbType.AnsiString);
            parameters.Add("@Country", userType.Country, DbType.AnsiString);
            parameters.Add("@DDI", userType.DDI, DbType.AnsiString);
            parameters.Add("@DDD", userType.DDD, DbType.AnsiString);
            parameters.Add("@Phonenumber", userType.Phonenumber, DbType.AnsiString);
            parameters.Add("@Nickname", userType.Nickname, DbType.AnsiString);
            parameters.Add("@Password", userType.Password, DbType.AnsiStringFixedLength);
            parameters.Add("@Email", userType.Email, DbType.AnsiString);
            parameters.Add("@Reg_Date", DateTime.Now, DbType.DateTime);

            return (int) SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateUserType(UserType userType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", userType.Name, DbType.AnsiString);
            parameters.Add("@Address", userType.Address, DbType.AnsiString);
            parameters.Add("@City", userType.City, DbType.AnsiString);
            parameters.Add("@State", userType.State, DbType.AnsiString);
            parameters.Add("@Addresscode", userType.Addresscode, DbType.AnsiString);
            parameters.Add("@Country", userType.Country, DbType.AnsiString);
            parameters.Add("@DDI", userType.DDI, DbType.AnsiString);
            parameters.Add("@DDD", userType.DDD, DbType.AnsiString);
            parameters.Add("@Phonenumber", userType.Phonenumber, DbType.AnsiString);
            parameters.Add("@Nickname", userType.Nickname, DbType.AnsiString);
            parameters.Add("@Password", userType.Password, DbType.AnsiStringFixedLength);
            parameters.Add("@Email", userType.Email, DbType.AnsiString);
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

        public List<UserType> ListUserTypesByPartialName(string partialName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", "%" + partialName + "%", DbType.AnsiString);
            parameters.Add("@Nickname", "%" + partialName + "%", DbType.AnsiString);
            return SqlMapper.Query<UserType>(connection, SQL_GET_USER_BY_PARTIAL_NAME, parameters).ToList();
        }

        public List<UserType> ListUserTypes()
        {
            return SqlMapper.Query<UserType>(connection, SQL_GET_USERS).ToList();
        }
    }
}
