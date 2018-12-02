using GroupeA07.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.Models
{
	public partial class Moderator
	{
		public Moderator() { }

		public Moderator(SqlDataReader reader)
		{
			idModerator = Int32.Parse(reader[ModeratorDAO.COLUMN_ID_MODERATOR].ToString());
		}
	}
}