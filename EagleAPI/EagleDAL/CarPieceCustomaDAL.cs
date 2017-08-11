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
    public class CarPieceCustomaDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO CarPieceCustoma(
Name,
KmToChange,
ValueToChange,
IDCustoma)
VALUES(
@Name,
@KmToChange,
@ValueToChange,
@IDCustoma)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE CarPieceCustoma SET 
Name = @Name,
KmToChange = @KmToChange,
ValueToChange = @ValueToChange,
IDCustoma = @IDCustoma
WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
Name,
KmToChange,
ValueToChange,
IDCustoma,
FROM CarPieceCustoma
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
Name,
KmToChange,
ValueToChange,
IDCustoma,
FROM CarPieceCustoma

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM CarPieceCustoma
WHERE ID = @ID
";

        #endregion

        #endregion
        public CarPieceCustomaDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertCarPieceCustoma(CarPieceCustoma carPieceCustoma)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", carPieceCustoma.Name);
            parameters.Add("@KmToChange", carPieceCustoma.KmToChange);
            parameters.Add("@ValueToChange", carPieceCustoma.ValueToChange);
            parameters.Add("@IDCustoma", carPieceCustoma.IDCustoma);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateCarPieceCustoma(CarPieceCustoma carPieceCustoma)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", carPieceCustoma.ID);
            parameters.Add("@Name", carPieceCustoma.Name);
            parameters.Add("@KmToChange", carPieceCustoma.KmToChange);
            parameters.Add("@ValueToChange", carPieceCustoma.ValueToChange);
            parameters.Add("@IDCustoma", carPieceCustoma.IDCustoma);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public CarPieceCustoma getCarPieceCustomaByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<CarPieceCustoma>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteCarPieceCustomaByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<CarPieceCustoma> ListCarPieceCustomas()
        {
            return SqlMapper.Query<CarPieceCustoma>(connection, SQL_GET_USERS).ToList();
        }
    }
}

