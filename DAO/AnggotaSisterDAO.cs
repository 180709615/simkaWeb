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
	}
}
//
//