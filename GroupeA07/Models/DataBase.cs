using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.Models
{
	public class DataBase
	{
		private static readonly string CONNECTION_STRING =
			"Server=tcp:groupea07.database.windows.net,1433;Initial Catalog=groupea07;Persist Security Info=False;User ID=helha;Password=Groupea07;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(DataBase.CONNECTION_STRING);
		}

	}
}