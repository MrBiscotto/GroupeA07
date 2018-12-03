using GroupeA07.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.Models
{
	public partial class Sold_object
	{

		public Sold_object() { }

		public Sold_object(SqlDataReader reader)
		{
			idObject = Int32.Parse(reader[Sold_objectDAO.COLUMN_ID_OBJECT].ToString());
			finalPrice = Int32.Parse(reader[Sold_objectDAO.COLUMN_FINAL_PRICE].ToString());
			nameObject = reader[Sold_objectDAO.COLUMN_NAME_OBJECT].ToString();
			catObject = reader[Sold_objectDAO.COLUMN_CAT_OBJECT].ToString();

		}
	}
}