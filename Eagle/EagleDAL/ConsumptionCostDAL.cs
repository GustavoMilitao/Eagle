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
    public class ConsumptionCostDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO ConsumptionCost(
IDCar,
GasKmPerLiter,
GasPrice,
GasPricePerKm,
RegDate)
VALUES(
@IDCar,
@GasKmPerLiter,
@GasPrice,
@GasPricePerKm,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE ConsumptionCost SET 
IDCar = @IDCar,
GasKmPerLiter = @GasKmPerLiter,
GasPrice = @GasPrice,
GasPricePerKm = @GasPricePerKm,
RegDate = @RegDate
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"





SELECT ID,IDCar,GasKmPerLiter,GasPrice,GasPricePerKm,RegDate
FROM ConsumptionCost
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            





SELECT ID,IDCar,GasKmPerLiter,GasPrice,GasPricePerKm,RegDate
FROM ConsumptionCost

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM ConsumptionCost
WHERE ID = @ID
";

        #endregion

        #endregion
        public ConsumptionCostDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertConsumptionCost(ConsumptionCost consumptionCost)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDCar", consumptionCost.IDCar);
            parameters.Add("@GasKmPerLiter", consumptionCost.GasKmPerLiter);
            parameters.Add("@GasPrice", consumptionCost.GasPrice);
            parameters.Add("@GasPricePerKm", consumptionCost.GasPricePerKm);
            parameters.Add("@RegDate", consumptionCost.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateConsumptionCost(ConsumptionCost consumptionCost)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", consumptionCost.ID);
            parameters.Add("@IDCar", consumptionCost.IDCar);
            parameters.Add("@GasKmPerLiter", consumptionCost.GasKmPerLiter);
            parameters.Add("@GasPrice", consumptionCost.GasPrice);
            parameters.Add("@GasPricePerKm", consumptionCost.GasPricePerKm);
            parameters.Add("@RegDate", consumptionCost.RegDate);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public ConsumptionCost getConsumptionCostByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<ConsumptionCost>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteConsumptionCostByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<ConsumptionCost> ListConsumptionCosts()
        {
            return SqlMapper.Query<ConsumptionCost>(connection, SQL_GET_USERS).ToList();
        }
    }
}

