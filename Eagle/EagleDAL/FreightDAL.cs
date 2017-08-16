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
    public class FreightDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO Freight(
IDUserDriver,
IDCar,
IDCarCustoma,
IDDriverGain,
TotalFreightCostPerKm,
TotalFreight,
RegDate)
OUTPUT INSERTED.ID
VALUES(
@IDUserDriver,
@IDCar,
@IDCarCustoma,
@IDDriverGain,
@TotalFreightCostPerKm,
@TotalFreight,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE Freight SET 
IDUserDriver = @IDUserDriver,
IDCar = @IDCar,
IDCarCustoma = @IDCarCustoma,
IDDriverGain = @IDDriverGain,
TotalFreightCostPerKm = @TotalFreightCostPerKm,
TotalFreight = @TotalFreight,

WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDUserDriver,
IDCar,
IDCarCustoma,
IDDriverGain,
TotalFreightCostPerKm,
TotalFreight,
RegDate
FROM Freight
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
IDUserDriver,
IDCar,
IDCarCustoma,
IDDriverGain,
TotalFreightCostPerKm,
TotalFreight,
RegDate
FROM Freight

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM Freight
WHERE ID = @ID
";

        #endregion

        #endregion
        public FreightDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertFreight(Freight freight)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDUserDriver", freight.IDUserDriver);
            parameters.Add("@IDCar", freight.IDCar);
            parameters.Add("@IDCarCustoma", freight.IDCarCustoma);
            parameters.Add("@IDDriverGain", freight.IDDriverGain);
            parameters.Add("@TotalFreightCostPerKm", freight.TotalFreightCostPerKm);
            parameters.Add("@TotalFreight", freight.TotalFreight);
            parameters.Add("@RegDate", freight.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateFreight(Freight freight)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", freight.ID);
            parameters.Add("@IDUserDriver", freight.IDUserDriver);
            parameters.Add("@IDCar", freight.IDCar);
            parameters.Add("@IDCarCustoma", freight.IDCarCustoma);
            parameters.Add("@IDDriverGain", freight.IDDriverGain);
            parameters.Add("@TotalFreightCostPerKm", freight.TotalFreightCostPerKm);
            parameters.Add("@TotalFreight", freight.TotalFreight);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public Freight getFreightByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<Freight>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteFreightByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<Freight> ListFreights()
        {
            return SqlMapper.Query<Freight>(connection, SQL_GET_USERS).ToList();
        }
    }
}

