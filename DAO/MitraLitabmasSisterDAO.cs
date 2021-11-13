using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class MitraLitabmasSisterDAO
	{
		public DBOutput GetMitraById_penelitian_pengabdian(string id1)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"SELECT *
									FROM     PENELITIAN INNER JOIN MITRA_LITABMAS ON PENELITIAN.id_penelitian_pengabdian = MITRA_LITABMAS.id_penelitian_pengabdian
									WHERE(MITRA_LITABMAS.id_penelitian_pengabdian = @id)            ";

					var param = new { id = id1 };
					output.data = conn.Query<TblMitra_Litabmas_DATA_SISTER>(query, param).ToList();

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

		public async Task<DBOutput> AddMitraSister(TblMitra_Litabmas_DATA_SISTER mitra)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"INSERT INTO[dbo].[MITRA_LITABMAS]
									([no]
									,[id_penelitian_pengabdian]
									,[id]
									,[nama])

									VALUES
										(@no,@id_penelitian_pengabdian,@id,@nama)";

					var param = new { no = mitra.no, id_penelitian = mitra.id_penelitian_pengabdian, id = mitra.id, nama = mitra.nama };
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
		public async Task<DBOutput> UpdateMitraSister(TblMitra_Litabmas_DATA_SISTER mitra)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"UPDATE [dbo].[MITRA_LITABMAS]
									SET									
									[nama] = @nama

									WHERE [id_penelitian_pengabdian]=@id_penelitian_pengabdian AND [id] = @id";

					var param = new { no = mitra.no, id_penelitian = mitra.id_penelitian_pengabdian, id = mitra.id, nama = mitra.nama };
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

		public async Task<DBOutput> DeleteMitraSister(TblMitra_Litabmas_DATA_SISTER mitra)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{
					string query = @"DELETE FROM [dbo].[MITRA_LITABMAS] WHERE [id_penelitian_pengabdian] = @id_penelitian_pengabdian AND [id] = @id";

					var param = new { id_penelitian = mitra.id_penelitian_pengabdian, id = mitra.id };
					output.data = conn.Query<TblMitra_Litabmas_DATA_SISTER>(query, param).ToList();

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

