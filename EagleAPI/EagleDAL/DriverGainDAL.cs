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
    public class DriverGainDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO DriverGain(
IDUserDriver,
IDCar,
NetGainPerKm,
RegDate)
VALUES(
@IDUserDriver,
@IDCar,
@NetGainPerKm,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE DriverGain SET 
IDUserDriver = @IDUserDriver,
IDCar = @IDCar,
NetGainPerKm = @NetGainPerKm,
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDUserDriver,
IDCar,
NetGainPerKm,
RegDate,
FROM DriverGain
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
IDUserDriver,
IDCar,
NetGainPerKm,
RegDate,
FROM DriverGain

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM DriverGain
WHERE ID = @ID
";

        #endregion

        #endregion
        public DriverGainDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertDriverGain(DriverGain driverGain)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDUserDriver", driverGain.IDUserDriver);
            parameters.Add("@IDCar", driverGain.IDCar);
            parameters.Add("@NetGainPerKm", driverGain.NetGainPerKm);
            parameters.Add("@RegDate", driverGain.RegDate);

            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateDriverGain(DriverGain driverGain)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", driverGain.ID);
            parameters.Add("@IDUserDriver", driverGain.IDUserDriver);
            parameters.Add("@IDCar", driverGain.IDCar);
            parameters.Add("@NetGainPerKm", driverGain.NetGainPerKm);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public DriverGain getDriverGainByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<DriverGain>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteDriverGainByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<DriverGain> ListDriverGains()
        {
            return SqlMapper.Query<DriverGain>(connection, SQL_GET_USERS).ToList();
        }
    }
}

