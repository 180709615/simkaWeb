using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIConsume.DAO
{
    public class TblStudiLanjutDAO
    {
        DBOutput output = new DBOutput();
        public DBOutput GetAllDataStudiLanjut()
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
            {
                try
                {
                    
                    string query = @"SELECT simka.TBL_STUDI_LANJUT.ID_STUDI_LANJUT, simka.TBL_STUDI_LANJUT.NPP, simka.TBL_STUDI_LANJUT.ID_REF_JENJANG, simka.TBL_STUDI_LANJUT.NAMA_SEKOLAH, simka.TBL_STUDI_LANJUT.KOTA_SEKOLAH, 
                  simka.TBL_STUDI_LANJUT.NEGARA_SEKOLAH, simka.TBL_STUDI_LANJUT.TGL_MULAI, simka.TBL_STUDI_LANJUT.TGL_LULUS, simka.TBL_STUDI_LANJUT.SK, simka.TBL_STUDI_LANJUT.TGL_PENEMPATAN_KMBLI, 
                  simka.TBL_STUDI_LANJUT.SK_PENEMPATAN_KMBL, simka.TBL_STUDI_LANJUT.FAKULTAS, simka.TBL_STUDI_LANJUT.PRODI, simka.TBL_STUDI_LANJUT.TARGET_LULUS, simka.TBL_STUDI_LANJUT.ID_REF_SS, 
                  simka.REF_JENJANG.DESKRIPSI AS Jenjang, simka.TBL_STUDI_LANJUT.DLM_NEGRI_LUAR_NEGRI AS DalamAtauLuarNegeri, simka.TBL_STUDI_LANJUT.NO_SK_TUGAS_BLJR, 
                   simka.MST_KARYAWAN.NAMA, REF_JENJANG_1.DESKRIPSI AS JENJANG, 
                  simka.REF_STATUS_STUDI.DESKRIPSI AS STATUS_STUDI
FROM     simka.TBL_STUDI_LANJUT INNER JOIN
                  simka.REF_JENJANG ON simka.TBL_STUDI_LANJUT.ID_REF_JENJANG = simka.REF_JENJANG.ID_REF_JENJANG INNER JOIN
                  simka.MST_KARYAWAN ON simka.TBL_STUDI_LANJUT.NPP = simka.MST_KARYAWAN.NPP INNER JOIN
                  simka.REF_JENJANG AS REF_JENJANG_1 ON simka.TBL_STUDI_LANJUT.ID_REF_JENJANG = REF_JENJANG_1.ID_REF_JENJANG INNER JOIN
                  simka.REF_STATUS_STUDI ON simka.TBL_STUDI_LANJUT.ID_REF_SS = simka.REF_STATUS_STUDI.ID_REF_SS";

                    //CASE WHEN simka.TBL_STUDI_LANJUT.DLM_NEGRI_LUAR_NEGRI LIKE 'L' THEN 'Luar Negeri' ELSE 'Dalam Negeri' END AS TEXT_DALAM_LUAR_NEGERI,

                    output.status = true;
                    output.data = conn.Query<object>(query).ToList();

                    return output;
                }
                catch (Exception ex)
                {
                    output.status = false;
                    output.pesan = ex.Message;
                    output.data = new List<string>();
                    return output;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
    }
}
//
//