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
    public class CarCustomaDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO CarCustoma(
IDCar,
IDUser,
TotalCustomaValuePerKm)
OUTPUT INSERTED.ID
VALUES(
@IDCar,
@IDUser,
@TotalCustomaValuePerKm)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE CarCustoma SET 
IDCar = @IDCar,
IDUser = @IDUser,
TotalCustomaValuePerKm = @TotalCustomaValuePerKm
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDCar,
IDUser,
TotalCustomaValuePerKm
FROM CarCustoma
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
IDCar,
IDUser,
TotalCustomaValuePerKm
FROM CarCustoma

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM CarCustoma
WHERE ID = @ID
";

        #endregion

        #endregion
        public CarCustomaDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertCarCustoma(CarCustoma carCustoma)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDCar", carCustoma.IDCar);
            parameters.Add("@IDUser", carCustoma.IDUser);
            parameters.Add("@CarPiecesCustoma", carCustoma.CarPiecesCustoma);
            parameters.Add("@TotalCustomaValuePerKm", carCustoma.TotalCustomaValuePerKm);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateCarCustoma(CarCustoma carCustoma)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", carCustoma.ID);
            parameters.Add("@IDCar", carCustoma.IDCar);
            parameters.Add("@IDUser", carCustoma.IDUser);
            parameters.Add("@CarPiecesCustoma", carCustoma.CarPiecesCustoma);
            parameters.Add("@TotalCustomaValuePerKm", carCustoma.TotalCustomaValuePerKm);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public CarCustoma getCarCustomaByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<CarCustoma>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteCarCustomaByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<CarCustoma> ListCarCustomas()
        {
            return SqlMapper.Query<CarCustoma>(connection, SQL_GET_USERS).ToList();
        }
    }
}

