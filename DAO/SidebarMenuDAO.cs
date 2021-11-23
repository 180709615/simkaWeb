using APIConsume.DAO;
using APIConsume.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.DAO
{
	public class SidebarMenuDAO
	{
		public DBOutput getSidebarMenu(string npp)
		{
			DBOutput output = new DBOutput();

			using (SqlConnection conn = new SqlConnection(Connection.ConnectionStringg))
			{
				try
				{
					string query = @"select ROW_NUMBER() over (order by parentid,NO_URUT) urut,*
									from ( SELECT DISTINCT TBL_SI_MENU.ID_SI_MENU menuid, NO_URUT, TBL_SI_MENU.DESKRIPSI menuname
									,TBL_SI_MENU.LINK menulocation, 0 parentid FROM siatmax.TBL_ROLE_SUBMENU INNER JOIN
									siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE INNER JOIN
									siatmax.REF_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.REF_ROLE.ID_ROLE AND siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE INNER JOIN
									siatmax.TBL_SI_SUBMENU ON siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU INNER JOIN
									siatmax.TBL_SI_MENU ON siatmax.TBL_SI_SUBMENU.ID_SI_MENU = siatmax.TBL_SI_MENU.ID_SI_MENU
									AND siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI = siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI
									WHERE siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI =1 and TBL_SI_SUBMENU.IsActive=1  and TBL_SI_MENU.ISACTIVE = 1
									union all
									SELECT distinct TBL_SI_SUBMENU.ID_SI_SUBMENU, NO_URUT, TBL_SI_SUBMENU.DESKRIPSI ,TBL_SI_SUBMENU.LINK
									,TBL_SI_SUBMENU.ID_SI_MENU FROM siatmax.TBL_SI_MENU INNER JOIN
									siatmax.TBL_SI_SUBMENU ON siatmax.TBL_SI_MENU.ID_SI_MENU = siatmax.TBL_SI_SUBMENU.ID_SI_MENU INNER JOIN
									siatmax.TBL_ROLE_SUBMENU ON siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU INNER JOIN
									siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE AND
									siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI = siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI
									WHERE siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI =1 and TBL_SI_SUBMENU.IsActive=1  ) menu";

					var param = new { };
					output.data = conn.Query<SidebarMenu>(query, param).ToList();

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
