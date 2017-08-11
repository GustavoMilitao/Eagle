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
    public class ProductDAL
    {
        static string connectionString;
        static SqlConnection connection;


        #region SQL

        #region SQL_INSERIR

        static string SQL_INSERIR = @"INSERT INTO Product(
IDUserDistributor,
Description,
Name,
Returnable,
SinglePrice,
Available,
RegDate)
VALUES(
@IDUserDistributor,
@Description,
@Name,
@Returnable,
@SinglePrice,
@Available,
@RegDate)
";

        #endregion

        #region SQL UPDATE

        static string SQL_UPDATE = @"UPDATE Product SET 
IDUserDistributor = @IDUserDistributor,
Description = @Description,
Name = @Name,
Returnable = @Returnable,
SinglePrice = @SinglePrice,
Available = @Available,

WHERE ID = @ID
";


        #endregion

        #region SQL GET USER BY ID

        static string SQL_GET_USER_BY_ID = @"SELECT 
ID,
IDUserDistributor,
Description,
Name,
Returnable,
SinglePrice,
Available,
RegDate,
FROM Product
WHERE ID = @ID 
        ";

        #endregion

        #region GET USERS

        static string SQL_GET_USERS = @"
            SELECT 
ID,
IDUserDistributor,
Description,
Name,
Returnable,
SinglePrice,
Available,
RegDate,
FROM Product

";

        #endregion

        #region DELETE USER BY ID

        static string DELETE_USER_BY_ID = @"DELETE FROM Product
WHERE ID = @ID
";

        #endregion

        #endregion
        public ProductDAL()
        {
            connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public int InsertProduct(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", product.ID);
            parameters.Add("@IDUserDistributor", product.IDUserDistributor);
            parameters.Add("@Description", product.Description);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Returnable", product.Returnable);
            parameters.Add("@SinglePrice", product.SinglePrice);
            parameters.Add("@Available", product.Available);
            parameters.Add("@RegDate", product.RegDate);


            return (int)SqlMapper.ExecuteScalar(connection, SQL_INSERIR, parameters);
        }

        public bool UpdateProduct(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", product.ID);
            parameters.Add("@IDUserDistributor", product.IDUserDistributor);
            parameters.Add("@Description", product.Description);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Returnable", product.Returnable);
            parameters.Add("@SinglePrice", product.SinglePrice);
            parameters.Add("@Available", product.Available);


            return SqlMapper.Execute(connection, SQL_UPDATE, parameters) > 0;
        }

        public Product getProductByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Query<Product>(connection, SQL_GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public bool DeleteProductByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            return SqlMapper.Execute(connection, DELETE_USER_BY_ID, parameters) > 0;
        }

        public List<Product> ListProducts()
        {
            return SqlMapper.Query<Product>(connection, SQL_GET_USERS).ToList();
        }
    }
}

