using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class PenulisSisterDAO
	{
		public async Task<DBOutput> UpdatePenulisSister(TblPenulis_DATA_SISTER penulis)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"UPDATE [dbo].[PENULIS]
								   SET 
									  
									  [urutan] = @urutan
									  ,[afiliasi] = @afiliasi
									  ,[peran] = @peran
									  ,[jenis] = @jenis
									  ,[apakah_corresponding_author] = @apakah_corresponding_author									  
									  ,[id_peserta_didik] = @id_peserta_didik
									  ,[id_orang] = @id_orang
									  ,[nomor_induk_peserta_didik] = @nomor_induk_peserta_didik
								 WHERE [id_sdm] = @id_sdm OR [nama] = @nama AND [id_riwayat_publikasi_paten] = @id_riwayat_publikasi_paten";

					var param = new { 
						nama = penulis.nama,
						urutan = penulis.urutan,
						afiliasi = penulis.afiliasi,
						peran = penulis.peran,
						jenis = penulis.jenis,
						apakah_corresponding_author = penulis.corresponding_author,
						id_peserta_didik = penulis.id_peserta_didik,
						id_orang = penulis.id_orang,
						nomor_induk_peserta_didik = penulis.nomor_induk_peserta_didik,
						id_sdm = penulis.id_sdm,
						id_riwayat_publikasi_paten = penulis.id_riwayat_publikasi_paten

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

		public async Task<DBOutput> AddPenulisSister(TblPenulis_DATA_SISTER penulis)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"INSERT INTO [dbo].[PENULIS]
									([no]
									,[id_riwayat_publikasi_paten]
									,[nama]
									,[urutan]
									,[afiliasi]
									,[peran]
									,[jenis]
									,[apakah_corresponding_author]
									,[id_sdm]
									,[id_peserta_didik]
									,[id_orang]
									,[nomor_induk_peserta_didik])

								VALUES
									(@no,
									@id_riwayat_publikasi_paten,
									@nama,
									@urutan,
									@afiliasi,
									@peran,
									@jenis,
									@apakah_corresponding_author,
									@id_sdm,
									@id_peserta_didik,
									@id_orang,
									@nomor_induk_peserta_didik)";
					

					var param = new
					{
						nama = penulis.nama,
						id_riwayat_publikasi_paten = penulis.id_riwayat_publikasi_paten,
						urutan = penulis.urutan,
						afiliasi = penulis.afiliasi,
						peran = penulis.peran,
						jenis = penulis.jenis,
						apakah_corresponding_author = penulis.corresponding_author,
						id_peserta_didik = penulis.id_peserta_didik,
						id_orang = penulis.id_orang,
						nomor_induk_peserta_didik = penulis.nomor_induk_peserta_didik,
						id_sdm = penulis.id_sdm,
						no = penulis.no,


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
		public async Task<DBOutput> DeletePenulisSister(TblPenulis_DATA_SISTER penulis)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
			{
				try
				{

					string query = @"DELETE FROM[dbo].[PENULIS]
									WHERE [id_riwayat_publikasi_paten] = @id_riwayat_publikasi_paten AND [id_sdm]=@id_sdm";

					var param = new
					{					
						id_riwayat_publikasi_paten = penulis.id_riwayat_publikasi_paten,						
						id_sdm = penulis.id_sdm,						
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

