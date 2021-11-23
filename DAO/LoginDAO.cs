using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class LoginDAO
	{
		public List<RefRole> GetUserRole(string npp)
		{
			

			using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
			{
				try
				{
					string query = @"SELECT DISTINCT 
				  siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI, siatmax.TBL_USER_ROLE.ID_ROLE, siatmax.TBL_USER_ROLE.NPP, siatmax.TBL_USER_ROLE.TGL_AWAL_AKTIF, siatmax.TBL_USER_ROLE.TGL_AKHIR_AKTIF, 
				  siatmax.TBL_USER_ROLE.ID_FAKULTAS, siatmax.REF_ROLE.DESKRIPSI AS Deskripsi
					FROM     siatmax.TBL_USER_ROLE INNER JOIN
									  siatmax.REF_ROLE ON siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE
					WHERE  (siatmax.TBL_USER_ROLE.NPP LIKE @npp) AND (siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI = 1)";

					var param = new { npp = npp };
					var data = conn.Query<RefRole>(query, param).ToList();

					

					return data;
				}
				catch (Exception ex)
				{
					throw;
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