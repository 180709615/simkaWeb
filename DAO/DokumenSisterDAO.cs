using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class DokumenSisterDAO
	{
		public DBOutput GetDokumenPenelitianById_penelitian_pengabdian(string id1)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"SELECT *
									FROM     PENELITIAN INNER JOIN DOKUMEN ON PENELITIAN.id_penelitian_pengabdian = DOKUMEN.id_publikasi_atau_penelitian
									WHERE(DOKUMEN.id_penelitian_pengabdian = @id)            ";

					var param = new { id = id1 };
					output.data = conn.Query<TblDokumen_DATA_SISTER>(query, param).ToList();

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
		public async Task<DBOutput> UpdateDokumenSister(TblDokumen_DATA_SISTER dokumen)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"UPDATE [dbo].[DOKUMEN]
								   SET 
									  [nama_dokumen] = @nama_dokumen
									  ,[nama_file] = @nama_file
									  ,[jenis_file] = @jenis_file
									  ,[tanggal_upload] = @tanggal_upload
									  ,[nama_jenis_dokumen] = @nama_jenis_dokumen
									  ,[tautan] = tautan
									  ,[keterangan_dokumen] = @keterangan_dokumen
								 WHERE [id_publikasi_atau_penelitian] = @id_publikasi_atau_penelitian AND  [id_dokumen] = @id_dokumen";

					var param = new
					{
						nama_dokumen = dokumen.nama_dokumen,
						nama_file = dokumen.nama_file,
						jenis_file = dokumen.jenis_file,
						tanggal_upload = dokumen.tanggal_upload,
						nama_jenis_dokumen = dokumen.nama_jenis_dokumen,
						tautan = dokumen.tautan,
						keterangan_dokumen = dokumen.keterangan_dokumen,
						id_publikasi_atau_penelitian = dokumen.id_publikasi_atau_penelitian,
						id_dokumen = dokumen.id_dokumen,
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

		public async Task<DBOutput> AddDokumenSister(TblDokumen_DATA_SISTER dokumen)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"INSERT INTO [dbo].[DOKUMEN]
								   ([no]
								   ,[id_dokumen]
								   ,[id_publikasi_atau_penelitian]
								   ,[nama_dokumen]
								   ,[nama_file]
								   ,[jenis_file]
								   ,[tanggal_upload]
								   ,[nama_jenis_dokumen]
								   ,[tautan]
								   ,[keterangan_dokumen])
							 VALUES
								   (@no
									,@id_dokumen
								    ,@id_publikasi_atau_penelitian
									,@nama_dokumen
									,@nama_file
									,@jenis_file
									,@tanggal_upload
									,@nama_jenis_dokumen
									,@tautan
									,@keterangan_dokumen)";


					var param = new
					{
						no = dokumen.no,
						nama_dokumen = dokumen.nama_dokumen,
						nama_file = dokumen.nama_file,
						jenis_file = dokumen.jenis_file,
						tanggal_upload = dokumen.tanggal_upload,
						nama_jenis_dokumen = dokumen.nama_jenis_dokumen,
						tautan = dokumen.tautan,
						keterangan_dokumen = dokumen.keterangan_dokumen,
						id_publikasi_atau_penelitian = dokumen.id_publikasi_atau_penelitian,
						id_dokumen = dokumen.id_dokumen,

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
		public async Task<DBOutput> DeleteDokumenSister(TblDokumen_DATA_SISTER dokumen)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"DELETE FROM[dbo].[DOKUMEN]
									WHERE [id_publikasi_atau_penelitian] = @id_riwayat_publikasi_paten AND [id_dokumen]=@id_dokumen";

					var param = new
					{
						id_publikasi_atau_penelitian = dokumen.id_publikasi_atau_penelitian,
						id_dokumen = dokumen.id_dokumen,
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