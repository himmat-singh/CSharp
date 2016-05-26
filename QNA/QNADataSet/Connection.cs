using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QNA.DataSet
{
    /// <summary>
    /// Holds the connection information
    /// </summary>
    interface IConnection
    {
        IDbConnection SetConnection(string connectionString);
        IDbConnection SetConnection(string server, string database, string user, string password);
    }

    public class QnaSQLConnection : IConnection
    {
        public string ConnectionString { get; set; }
        
        public IDbConnection SetConnection(string connectionString)
        {
            try
            {
                ConnectionString = connectionString;     
                return new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {
                
                return null;
            }
        }

        public IDbConnection SetConnection(string server, string database, string user, string password)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection();
                sqlConn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", server,database,user,password);
                ConnectionString = sqlConn.ConnectionString;
                return sqlConn;
            }
            catch (SqlException ex)
            {

                return null;
            }
        }
    }
}
