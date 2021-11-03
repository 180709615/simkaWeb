using APIConsume.DAO;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace APIConsume.DAO
{
    public class MstUnitDAO
    {
        public List<object> GetNamaUnit()
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
            {
                try
                {
                    string query = @"SELECT ID_UNIT,NAMA_UNIT,KODE_UNIT FROM siatmax.MST_UNIT";
                    var data = conn.Query<object>(query).ToList();

                    return data;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
    }
}
