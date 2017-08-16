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
    public class CarModelDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO CarModel(
ModelName,
Brand,
Year,
Potency,
Flex)
VALUES(
@ModelName,
@Brand,
@Year,
@Potency,
Convert(BIT, ISNULL(@Flex, 0)))
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE CarModel SET 
ModelName = @ModelName,
Brand = @Brand,
Year = @Year,
Potency = @Potency,
Flex = Convert(BIT, ISNULL(@Flex, 0))
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"





SELECT ID,ModelName,Brand,Year,Potency,Flex
FROM CarModel
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            





SELECT ID,ModelName,Brand,Year,Potency,Flex
FROM CarModel

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM CarModel
WHERE ID = @ID
";

        #endregion

        #endregion
        public CarModelDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertCarModel(CarModel carModel)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ModelName", carModel.ModelName);
            parameters.Add("@Brand", carModel.Brand);
            parameters.Add("@Year", carModel.Year);
            parameters.Add("@Potency", carModel.Potency);
            parameters.Add("@Flex", carModel.Flex);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateCarModel(CarModel carModel)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", carModel.ID);
            parameters.Add("@ModelName", carModel.ModelName);
            parameters.Add("@Brand", carModel.Brand);
            parameters.Add("@Year", carModel.Year);
            parameters.Add("@Potency", carModel.Potency);
            parameters.Add("@Flex", carModel.Flex);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public CarModel getCarModelByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<CarModel>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteCarModelByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<CarModel> ListCarModels()
        {
            return SqlMapper.Query<CarModel>(connection, SQL_GET_USERS).ToList();
        }
    }
}

