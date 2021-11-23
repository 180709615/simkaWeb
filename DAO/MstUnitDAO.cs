using APIConsume.DAO;
using APIConsume.Models;
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

        public List<MstUnit> GetListUnitEntrypass()
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
            {
                try
                {
                    string query = @"SELECT DISTINCT siatmax.MST_UNIT.MST_ID_UNIT, MST_UNIT_1.NAMA_UNIT
FROM siatmax.MST_UNIT INNER JOIN siatmax.MST_UNIT AS MST_UNIT_1 ON siatmax.MST_UNIT.MST_ID_UNIT = MST_UNIT_1.ID_UNIT AND siatmax.MST_UNIT.MST_ID_UNIT = MST_UNIT_1.ID_UNIT AND siatmax.MST_UNIT.MST_ID_UNIT = MST_UNIT_1.ID_UNIT AND siatmax.MST_UNIT.MST_ID_UNIT = MST_UNIT_1.ID_UNIT
ORDER BY MST_UNIT_1.NAMA_UNIT";
                    var data = conn.Query<MstUnit>(query).ToList();

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
