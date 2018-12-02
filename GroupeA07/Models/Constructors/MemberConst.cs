using GroupeA07.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.Models
{
	public partial class Member
	{
		public Member() { }

		public Member(SqlDataReader reader)
		{
			idUser = Int32.Parse(reader[MemberDAO.COLUMN_ID_USER].ToString());
			emailUser = reader[MemberDAO.COLUMN_EMAIL_USER].ToString();
			username = reader[MemberDAO.COLUMN_USER_NAME].ToString();
			userPwd = reader[MemberDAO.COLUMN_USER_PWD].ToString();

			userAdmin = Byte.Parse(reader[MemberDAO.COLUMN_USER_ADMIN].ToString());
		}
	}
}