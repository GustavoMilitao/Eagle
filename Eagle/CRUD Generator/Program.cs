using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    class Program
    {
        static string Select = @"
DECLARE @@@TABLENAME VARCHAR(100) = @tabela
DECLARE @@@FIELDNAME VARCHAR(100)
DECLARE @@@SQL NVARCHAR(300)

DECLARE CUR1 CURSOR FOR
SELECT COLUMN_NAME
FROM Eagle.INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @@@TABLENAME
Set @@@SQL = 'SELECT ' 

OPEN CUR1

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME

WHILE @@FETCH_STATUS = 0
BEGIN
  
Set @@@SQL = CHAR(13)+CHAR(10) + @@@SQL + @@@FIELDNAME + ',' 

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME
END

Set @@@SQL = LEFT(@@@SQL, NULLIF(LEN(@@@SQL)-1,-1)) + CHAR(13)+CHAR(10) + 'FROM '+ @@@TABLENAME + CHAR(13)+CHAR(10)
+'WHERE ID = @ID '

CLOSE CUR1
DEALLOCATE CUR1 

SELECT @@@SQL

";
        static string Insert = @"DECLARE @@@TABLENAME VARCHAR(100) = @tabela
DECLARE @@@FIELDNAME VARCHAR(100)
DECLARE @@@SQLINSERT NVARCHAR(300)
DECLARE @@@SQLINSERTVALUES NVARCHAR(300)

DECLARE CUR1 CURSOR FOR
SELECT COLUMN_NAME
FROM Eagle.INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @@@TABLENAME
set @@@SQLINSERT = 'INSERT INTO '+@@@TABLENAME +'('
set @@@SQLINSERTVALUES = 'VALUES('

OPEN CUR1

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME

WHILE @@FETCH_STATUS = 0
BEGIN

Set @@@SQLINSERT =
CASE WHEN @@@FIELDNAME <> 'ID' THEN
@@@SQLINSERT + CHAR(13)+CHAR(10) + @@@FIELDNAME+',' 
ELSE @@@SQLINSERT
END

set @@@SQLINSERTVALUES =
CASE WHEN @@@FIELDNAME <> 'ID' THEN
@@@SQLINSERTVALUES+ CHAR(13)+CHAR(10)+ '@'+ @@@FIELDNAME+',' 
ELSE @@@SQLINSERTVALUES
END


FETCH NEXT FROM CUR1 INTO @@@FIELDNAME
END

set @@@SQLINSERTVALUES = LEFT(@@@SQLINSERTVALUES, NULLIF(LEN(@@@SQLINSERTVALUES)-1,-1))
Set @@@SQLINSERT = LEFT(@@@SQLINSERT, NULLIF(LEN(@@@SQLINSERT)-1,-1)) + ')'+ CHAR(13)+CHAR(10)

set @@@SQLINSERTVALUES = @@@SQLINSERTVALUES+')'
CLOSE CUR1
DEALLOCATE CUR1 

SELECT @@@SQLINSERT + @@@SQLINSERTVALUES
";
        static string Update = @"DECLARE @@@TABLENAME VARCHAR(100) = @tabela
DECLARE @@@FIELDNAME VARCHAR(100)
DECLARE @@@SQLUPDATE NVARCHAR(300)


DECLARE CUR1 CURSOR FOR
SELECT COLUMN_NAME
FROM Eagle.INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @@@TABLENAME
set @@@SQLUPDATE = 'UPDATE '+@@@TABLENAME+' SET '

OPEN CUR1

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME

WHILE @@FETCH_STATUS = 0
BEGIN
  
set @@@SQLUPDATE = 
CASE WHEN @@@FIELDNAME <> 'ID' THEN
@@@SQLUPDATE +CHAR(13)+CHAR(10)+ @@@FIELDNAME + ' = @'+@@@FIELDNAME+','
ELSE @@@SQLUPDATE 
END

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME
END

set @@@SQLUPDATE = LEFT(@@@SQLUPDATE, NULLIF(LEN(@@@SQLUPDATE)-1,-1)) +CHAR(13)+CHAR(10)+'WHERE ID = @ID'

CLOSE CUR1
DEALLOCATE CUR1 

SELECT @@@SQLUPDATE
";
        static string Delete = @"DECLARE @@@TABLENAME VARCHAR(100) = @tabela
DECLARE @@@SQLDELETE NVARCHAR(300)

set @@@SQLDELETE = 'DELETE FROM '+@@@TABLENAME+CHAR(13)+CHAR(10)+ 'WHERE ID = @ID'

SELECT @@@SQLDELETE";

        static string SelectAll = @"
DECLARE @@@TABLENAME VARCHAR(100) = @tabela
DECLARE @@@FIELDNAME VARCHAR(100)
DECLARE @@@SQL NVARCHAR(300)

DECLARE CUR1 CURSOR FOR
SELECT COLUMN_NAME
FROM Eagle.INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @@@TABLENAME
Set @@@SQL = 'SELECT '

OPEN CUR1

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME

WHILE @@FETCH_STATUS = 0
BEGIN
  
Set @@@SQL =  CHAR(13)+CHAR(10)+ @@@SQL + @@@FIELDNAME + ','

FETCH NEXT FROM CUR1 INTO @@@FIELDNAME
END

Set @@@SQL = LEFT(@@@SQL, NULLIF(LEN(@@@SQL)-1,-1)) + CHAR(13)+CHAR(10) + 'FROM '+ @@@TABLENAME + CHAR(13)+CHAR(10)

CLOSE CUR1
DEALLOCATE CUR1 

SELECT @@@SQL


";

        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionStringSilver"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            if (!Directory.Exists("BLL"))
                Directory.CreateDirectory("BLL");
            if (!Directory.Exists("DAL"))
                Directory.CreateDirectory("DAL");
            if (!Directory.Exists("Controllers"))
                Directory.CreateDirectory("Controllers");

            DirectoryInfo pathwithentities = new DirectoryInfo(@"C:\Users\Kaioso\Source\Repos\EagleAPI\EagleAPI\EagleEntities");
            foreach (FileInfo f in pathwithentities.EnumerateFiles().Where(a => a.Extension == ".cs").ToList())
            {
                string filename = f.Name.Replace(".cs", "");
                string uncapitalizename = Char.ToLowerInvariant(filename[0]) + filename.Substring(1);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@@tabela", filename, DbType.AnsiString);

                string select = SqlMapper.Query<string>(connection, Select, parameters).FirstOrDefault();
                string insert = SqlMapper.Query<string>(connection, Insert, parameters).FirstOrDefault();
                string update = SqlMapper.Query<string>(connection, Update, parameters).FirstOrDefault();
                string delete = SqlMapper.Query<string>(connection, Delete, parameters).FirstOrDefault();
                string selectall = SqlMapper.Query<string>(connection, SelectAll, parameters).FirstOrDefault();

                string DAL = File.ReadAllText(@"C:\Users\Kaioso\Source\Repos\EagleAPI\EagleAPI\ModeloDAL.txt");
                string BLL = File.ReadAllText(@"C:\Users\Kaioso\Source\Repos\EagleAPI\EagleAPI\ModeloBLL.txt");
                string Controller = File.ReadAllText(@"C:\Users\Kaioso\Source\Repos\EagleAPI\EagleAPI\ModeloController.txt");

                string param = @"parameters.Add({metadata}, {data});";

                StringBuilder sb = new StringBuilder();
                Car a = new Car();
                Type t = Type.GetType("EagleEntities." + filename);

                var l = t.GetProperties();
                foreach (var c in l)
                {
                    sb.AppendLine(param.Replace("{metadata}", '"' + "@" + c.Name + '"').Replace("{data}", uncapitalizename + "." + c.Name));
                }



                StreamWriter sw = new StreamWriter(@"DAL\" + filename + "DAL.cs");
                DAL = DAL.Replace("{0}", insert);
                DAL = DAL.Replace("{1}", update);
                DAL = DAL.Replace("{2}", select);
                DAL = DAL.Replace("{3}", selectall);
                DAL = DAL.Replace("{4}", delete);
                DAL = DAL.Replace("{5}", filename);
                DAL = DAL.Replace("{6}", uncapitalizename);
                DAL = DAL.Replace("{7}", sb.ToString());
                sw.WriteLine(DAL);
                //var teste = String.Format(DAL, insert, update, select, selectall, delete, filename, uncapitalizename);
                sw.Close();
                sw = new StreamWriter(@"BLL\" + filename + "BLL.cs");
                BLL = BLL.Replace("{0}", filename);
                BLL = BLL.Replace("{1}", uncapitalizename);
                sw.WriteLine(BLL);
                sw.Close();
                sw = new StreamWriter(@"Controllers\" + filename + "Controller.cs");
                Controller = Controller.Replace("{0}", filename);
                Controller = Controller.Replace("{1}", uncapitalizename);
                sw.WriteLine(Controller);
                sw.Close();
            }


        }
    }
}
