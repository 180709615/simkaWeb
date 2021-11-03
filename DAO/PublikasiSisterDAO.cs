using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIConsume.DAO
{
    public class PublikasiSisterDAO
    {
        public List<PublikasiExcelModel> GetPublikasiSister(string idDosen)
        {
            using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
            {
                try
                {
                    //string query = @"SELECT *
                    //                FROM     PUBLIKASI INNER JOIN PENULIS ON PUBLIKASI.id_riwayat_publikasi_paten = PENULIS.id_riwayat_publikasi_paten
                    //                WHERE(PENULIS.id_sdm = @id_dosen)            ";
                    string query = @"SELECT PUBLIKASI.judul as judul, PUBLIKASI.judul_artikel as judul_artikel, PUBLIKASI.kategori_kegiatan as kategori_kegiatan ,CONVERT(VARCHAR,PUBLIKASI.tanggal,105) as tanggal,
                                    PENULIS.peran as peran, PENULIS.urutan as urutan
                                    FROM   PUBLIKASI INNER JOIN PENULIS ON PUBLIKASI.id_riwayat_publikasi_paten = PENULIS.id_riwayat_publikasi_paten
                                    WHERE(PENULIS.id_sdm = @id_dosen)            ";
                    var param = new { id_dosen = idDosen };
                    var data = conn.Query<PublikasiExcelModel>(query,param).ToList();

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
//
//