using APIConsume.DAO;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
    public class PerbandinganPengajaranDAO
    {
        public List<object> GetSemester()
        {
            using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
            {
                try
                {
                    string query = @"SELECT DISTINCT semester,id_semester FROM PENGAJARAN";
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

        public List<dynamic>GetPerbandinganPengajaran(int id_smt,string npp)
        {
            using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
            {
                try
                {
                    string query = @"SELECT   top 10  id_pengajaran, mata_kuliah, sks, id_semester,
                                    NPP, NAMA_MK_SPKP, SKS_SPKP
                                    FROM            perbandingan_pengajaran_spkp
                                    WHERE        (id_semester = @id_semester) ";

                    var param = new { id_semester = id_smt };
                    var data = conn.Query<dynamic>(query, param).ToList();

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
