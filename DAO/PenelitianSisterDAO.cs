using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIConsume.DAO
{
    public class PenelitianSisterDAO
    {
        public List<PenelitianExcelModel> GetPenelitianSister(string idDosen)
        {
            using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
            {
                try
                {
                    //string query = @"SELECT *
                    //                FROM     PUBLIKASI INNER JOIN PENULIS ON PUBLIKASI.id_riwayat_publikasi_paten = PENULIS.id_riwayat_publikasi_paten
                    //                WHERE(PENULIS.id_sdm = @id_dosen)            ";
                    
                    string query = @"SELECT TOP(200) PENELITIAN.judul_penelitian_pengabdian as judul_penelitian_pengabdian , PENELITIAN.jenis_skim as jenis_skim, 
                                    PENELITIAN.tahun_kegiatan as tahun_kegiatan,PENELITIAN.durasi_kegiatan as durasi_kegiatan  , 
                                    ANGGOTA.peran AS peran, 
                                                      ANGGOTA.id_sdm
                                    FROM     PENELITIAN INNER JOIN
                                                     ANGGOTA ON PENELITIAN.id_penelitian_pengabdian = ANGGOTA.id_penelitian_pengabdian
                                    WHERE(ANGGOTA.id_sdm = @id_dosen)";
                    var param = new { id_dosen = idDosen };
                    var data = conn.Query<PenelitianExcelModel>(query, param).ToList();

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