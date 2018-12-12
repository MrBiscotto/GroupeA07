using GroupeA07.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.Models
{
	public partial class Auctioned_object
	{

		public Auctioned_object() { }

		public Auctioned_object(SqlDataReader reader)
		{
			idObject = Int32.Parse(reader[Auctioned_ObjectDAO.COLUMN_ID_OBJECT].ToString());
			nameObject = reader[Auctioned_ObjectDAO.COLUMN_NAME_OBJECT].ToString();
			descriptionObject = reader[Auctioned_ObjectDAO.COLUMN_DESCRIPTION_OBJECT].ToString();
			priceObject = Int32.Parse(reader[Auctioned_ObjectDAO.COLUMN_PRICE_OBJECT].ToString());
			idUser = Int32.Parse(reader[Auctioned_ObjectDAO.COLUMN_ID_USER].ToString());
			catObject = (reader[Auctioned_ObjectDAO.COLUMN_CAT_OBJECT].ToString());
		}
	}
}