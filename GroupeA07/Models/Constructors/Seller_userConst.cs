using GroupeA07.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.Models
{
	public partial class Seller_user
	{
		public Seller_user() { }

		public Seller_user(SqlDataReader reader)
		{
			idSeller = Int32.Parse(reader[Seller_userDAO.COLUMN_ID_SELLER].ToString());
			username = reader[Seller_userDAO.COLUMN_USERNAME].ToString();

			nbSales = Int32.Parse(reader[Seller_userDAO.COLUMN_NB_SALES].ToString()); idSeller = Int32.Parse(reader[Seller_userDAO.COLUMN_ID_SELLER].ToString());
			positiveVote = Int32.Parse(reader[Seller_userDAO.COLUMN_POSITIVE_VOTE].ToString());
			negativeVote = Int32.Parse(reader[Seller_userDAO.COLUMN_NEGATIVE_VOTE].ToString());
		}
	}
}