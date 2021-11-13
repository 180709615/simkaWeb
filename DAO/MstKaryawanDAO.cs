using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class MstKaryawanDAO
	{
		public async Task<DBOutput> EncryptPassword(string npp1,string password1)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
			{
				try
				{
					//string query = @"SELECT *
					//                FROM     PUBLIKASI INNER JOIN PENULIS ON PUBLIKASI.id_riwayat_publikasi_paten = PENULIS.id_riwayat_publikasi_paten
					//                WHERE(PENULIS.id_sdm = @id_dosen)            ";
					string query = @"UPDATE[simka].[MST_KARYAWAN]
										SET [PASSWORD_RIPEM] = @password
									 WHERE [NPP] = @npp"; 
					var param = new {npp = npp1, password = password1 };
					output.data = conn.Execute(query, param);

					output.status = true;

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

		public async Task<DBOutput> UbahPassword(string npp1, string password1, string passwordRIPEM)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
			{
				try
				{
					//string query = @"SELECT *
					//                FROM     PUBLIKASI INNER JOIN PENULIS ON PUBLIKASI.id_riwayat_publikasi_paten = PENULIS.id_riwayat_publikasi_paten
					//                WHERE(PENULIS.id_sdm = @id_dosen)            ";
					string query = @"UPDATE[simka].[MST_KARYAWAN]
										SET [PASSWORD_RIPEM] = @passwordRIPEM,
										[PASSWORD] = @password
									 WHERE [NPP] = @npp";
					var param = new { npp = npp1, password = password1,passwordRIPEM = passwordRIPEM };
					output.data = conn.Execute(query, param);

					output.status = true;

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

		public async Task<DBOutput> UbahUUID_Reset_Pswd(string npp1, string uuid)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
			{
				try
				{
			
					string query = @"UPDATE[simka].[MST_KARYAWAN]
										SET [UUID_LUPA_PWD] = @uuid
										
									 WHERE [NPP] = @npp";
					var param = new { npp = npp1, uuid = uuid};
					output.data = conn.Execute(query, param);

					output.status = true;

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

		public async Task<DBOutput> GetDataKaryawanByCriteria(int idJabatanAkademik, int idFungsional, int idUnit, int idSubUnit, int idJenjang, string statusKepegawaian, string npp, string nama)
		{
			DBOutput output = new DBOutput();
			var kondisi = "";
			var joinRiwayatPendidikan = "";
			var selectJenjang = "";

			if (idJabatanAkademik != 0) // Menggunakan exception karena bisa saja parameter tersebut tidak diisi
			{
				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.ID_REF_JBTN_AKADEMIK = @idJabatanAkademik ";
				else
					kondisi = kondisi + " AND mstKaryawan.ID_REF_JBTN_AKADEMIK = @idJabatanAkademik ";

			}
			if (idFungsional != 0)
			{
				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.ID_REF_FUNGSIONAL = @idFungsional ";
				else
					kondisi = kondisi + " AND mstKaryawan.ID_REF_FUNGSIONAL = @idFungsional ";

			}
			if (idUnit != 0)
			{
				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.ID_UNIT = @idUnit ";
				else
					kondisi = kondisi + " AND mstKaryawan.ID_UNIT = @idUnit ";

			}
			if (idSubUnit != 0)
			{
				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.MST_ID_UNIT = @idSubUnit ";
				else
					kondisi = kondisi + " AND mstKaryawan.MST_ID_UNIT = @idSubUnit ";

			}
			if (idJenjang != 0)
			{
				joinRiwayatPendidikan = @" INNER JOIN simka.TR_RIWAYAT_PENDIDIKAN AS riwayat ON mstKaryawan.NPP = riwayat.NPP LEFT OUTER JOIN simka.REF_JENJANG AS jenjang ON riwayat.ID_REF_JENJANG = jenjang.ID_REF_JENJANG ";
				selectJenjang =", jenjang.DESKRIPSI AS JENJANG ";

				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE riwayat.ID_REF_JENJANG = @idJenjang ";
				else
					kondisi = kondisi + " AND riwayat.ID_REF_JENJANG = @idJenjang ";

			}
			if (!String.IsNullOrEmpty(statusKepegawaian))
			{
				statusKepegawaian = "%" + statusKepegawaian + "%";

				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.STATUS_KEPEGAWAIAN LIKE @statusKepegawaian ";
				else
					kondisi = kondisi + "AND mstKaryawan.STATUS_KEPEGAWAIAN LIKE @statusKepegawaian ";

			}
			if (!String.IsNullOrEmpty(npp))
			{
				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.NPP = @npp ";
				else
					kondisi = kondisi + "AND mstKaryawan.NPP = @npp ";

			}
			if (!String.IsNullOrEmpty(nama))
			{
				nama = "%" + nama + "%";
				if (String.IsNullOrEmpty(kondisi))
					kondisi = " WHERE mstKaryawan.NAMA LIKE @nama ";
				else
					kondisi = kondisi + "AND mstKaryawan.NAMA LIKE @nama";

			}


			using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
			{
				try
				{

					string query = @" SELECT mstKaryawan.NAMA, idUnit.NAMA_UNIT, mstIdUnit.NAMA_UNIT AS PENEMPATAN, fungsional.DESKRIPSI AS FUNGSIONAL, idUnitAkademik.NAMA_UNIT_AKADEMIK, mstKaryawan.NPP"+selectJenjang+@" FROM  [simka].[MST_KARYAWAN] AS mstKaryawan INNER JOIN[simka].[REF_FUNGSIONAL] AS fungsional ON mstKaryawan.ID_REF_FUNGSIONAL = fungsional.ID_REF_FUNGSIONAL"+joinRiwayatPendidikan+@" LEFT OUTER JOIN
									[siatma].[MST_UNIT_AKADEMIK] AS idUnitAkademik ON mstKaryawan.ID_UNIT_AKADEMIK = idUnitAkademik.ID_UNIT LEFT OUTER JOIN [siatmax].[MST_UNIT] AS mstIdUnit ON mstKaryawan.MST_ID_UNIT = mstIdUnit.ID_UNIT LEFT OUTER JOIN [siatmax].[MST_UNIT] AS idUnit ON mstKaryawan.ID_UNIT = idUnit.ID_UNIT"+kondisi;
					var param = new { idJabatanAkademik = idJabatanAkademik, idFungsional= idFungsional, idUnit= idUnit, idSubUnit=idSubUnit, idJenjang= idJenjang, statusKepegawaian= statusKepegawaian,   npp = npp, nama = nama };
					output.data = conn.Query<object>(query,param).ToList();

					output.status = true;

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