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
    public class CarDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO Car(
IDCarModel,
IDUser)
VALUES(
@IDCarModel,
@IDUser)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE Car SET 
IDCarModel = @IDCarModel,
IDUser = @IDUser
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"


SELECT ID,
       IDCarModel,
       IDUser
FROM Car
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            


SELECT ID,
       IDCarModel,
       IDUser
FROM Car

";

        #endregion

        #region DELETE CAR BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM Car
WHERE ID = @ID
";

        #endregion

        #endregion
        public CarDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertCar(Car car)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IDCarModel", car.IDCarModel);
            parameters.Add("@IDUser", car.IDUser);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateCar(Car car)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", car.ID);
            parameters.Add("@IDCarModel", car.IDCarModel);
            parameters.Add("@IDUser", car.IDUser);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public Car getCarByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<Car>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteCarByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<Car> ListCars()
        {
            return SqlMapper.Query<Car>(connection, SQL_GET_USERS).ToList();
        }
    }
}

