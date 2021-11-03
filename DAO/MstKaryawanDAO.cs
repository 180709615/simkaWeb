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



	}
}
//
//