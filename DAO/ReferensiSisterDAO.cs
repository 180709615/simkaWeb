using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIConsume.DAO
{
	public class ReferensiSisterDAO
	{

		public DBOutput GetAllRefKategoriKegiatan()
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"SELECT * FROM REF_KATEGORI_KEGIATAN ";


					output.data = conn.Query<RefKategoriKegiatanSister>(query).ToList();
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


		public DBOutput AddRefKategoriKegiatan(int id1, int? parent_id1, string nama1)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"INSERT INTO [dbo].[REF_KATEGORI_KEGIATAN]
								   ([id]
								   ,[parent_id]
								   ,[nama])
									VALUES
									(@id, @parent_id,@nama)";
					var param = new { id = id1, parent_id = parent_id1, nama = nama1 };

					conn.Execute(query, param);

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


		public DBOutput UpdateRefKategoriKegiatan(int id1, int? parent_id1, string nama1)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"UPDATE[dbo].[REF_KATEGORI_KEGIATAN]
											SET [parent_id] = @parent_id
										  ,[nama] = @nama
									 WHERE id = @id";
					var param = new { id = id1, parent_id = parent_id1, nama = nama1 };

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

		public DBOutput DeleteAllRefKategoriKegiatan()
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"DELETE FROM [dbo].[REF_KATEGORI_KEGIATAN]";


					output.data = conn.Execute(query);

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
		public DBOutput DeleteRefKategoriKegiatan(int id)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"DELETE FROM [dbo].[REF_KATEGORI_KEGIATAN] WHERE id = @id";

					var param = new { id = id };
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