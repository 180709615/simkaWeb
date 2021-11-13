using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class AnggotaSisterDAO
	{
		public DBOutput GetAnggotaById_penelitian_pengabdian(string id1)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"SELECT *
									FROM     PENELITIAN INNER JOIN ANGGOTA ON PENELITIAN.id_penelitian_pengabdian = ANGGOTA.id_penelitian_pengabdian
									WHERE(ANGGOTA.id_penelitian_pengabdian = @id)            ";

					var param = new { id = id1 };
					output.data = conn.Query<TblAnggota_DATA_SISTER>(query, param).ToList();

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
		public async Task<DBOutput> AddAnggotaSister(TblAnggota_DATA_SISTER anggota)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"INSERT INTO[dbo].[ANGGOTA]
									([no]
									,[jenis]
									,[nama]
									,[nipd]
									,[peran]
									,[id_sdm]
									,[id_orang]
									,[id_pd]
									,[stat_aktif]
									,[id_penelitian_pengabdian])

								VALUES
									(@no,@jenis,@nama,@nipd,@peran,@id_orang,@id_pd,@stat_aktif,@id_penelitian_pengabdian)";

					var param = new
					{
						no = anggota.no,
						jenis = anggota.jenis,
						nama = anggota.nama,
						nipd = anggota.nipd,
						peran = anggota.peran,
						id_sdm = anggota.id_sdm,
						id_orang = anggota.id_orang,
						id_pd = anggota.id_pd,
						stat_aktif = anggota.stat_aktif,
						id_penelitian_pengabdian = anggota.id_penelitian_pengabdian
					};
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

		public async Task<DBOutput> UpdateAnggotaSister(TblAnggota_DATA_SISTER anggota)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"UPDATE[dbo].[ANGGOTA]
									SET
									
									[jenis] =@jenis									
									,[nipd] =@nipd
									,[peran] =@peran									
									,[id_orang] =@id_orang
									,[id_pd] =@id_pd
									,[stat_aktif] = @stat_aktif
									
									WHERE [id_penelitian_pengabdian] = @id_penelitian_pengabdian AND [id_sdm] = @id_sdm OR [nama] =@nama ";

					var param = new
					{

						jenis = anggota.jenis,
						nama = anggota.nama,
						nipd = anggota.nipd,
						peran = anggota.peran,
						id_sdm = anggota.id_sdm,
						id_orang = anggota.id_orang,
						id_pd = anggota.id_pd,
						stat_aktif = anggota.stat_aktif,
						id_penelitian_pengabdian = anggota.id_penelitian_pengabdian
					};
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
		public async Task<DBOutput> DeleteAnggotaSister(TblAnggota_DATA_SISTER anggota)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"DELETE FROM [dbo].[ANGGOTA]
									
									
									WHERE [id_penelitian_pengabdian] = @id_penelitian_pengabdian AND [id_sdm] = @id_sdm OR [nama] =@nama ";

					var param = new
					{
						nama = anggota.nama,
						id_sdm = anggota.id_sdm,
						id_penelitian_pengabdian = anggota.id_penelitian_pengabdian
					};
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
