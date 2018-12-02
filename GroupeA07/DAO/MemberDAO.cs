using GroupeA07.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.DAO
{
	public class MemberDAO
	{

		public static readonly string TABLE_NAME = "Member";
		public static readonly string COLUMN_ID_USER = "IdUser";
		public static readonly string COLUMN_EMAIL_USER = "EmailUser";
		public static readonly string COLUMN_USER_NAME = "UserName";
		public static readonly string COLUMN_USER_PWD = "UserPwd";
		public static readonly string COLUMN_USER_ADMIN = "UserAdmin";

		public static readonly string QUERY = "Select * from " + TABLE_NAME;
		public static readonly string GET = QUERY + " where " + COLUMN_ID_USER + " =@id";

		public static readonly string INSERT = "Insert into" + TABLE_NAME +
			"(" + COLUMN_EMAIL_USER +
			", " + COLUMN_EMAIL_USER +
			", " + COLUMN_USER_NAME +
			", " + COLUMN_USER_PWD +
			", " + COLUMN_USER_ADMIN + ")"
			+ "output inserted.id values(@EmailUser,0)";

		public static readonly string UPDATE = "update" + TABLE_NAME + " set " +
			COLUMN_EMAIL_USER + " =@emailUser"
			+ ", " + COLUMN_USER_NAME + " =@username"
			+ ", " + COLUMN_USER_PWD + "=@userPwd"
			+ ", " + COLUMN_USER_ADMIN + "=@userAdmin";



		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_USER_ADMIN + " =@idUser";


		//Renvoie liste des membres
		public static List<member> Query()
		{
			List<member> todos = new List<member>();

			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					todos.Add(new member(reader));
				}
			}
			return todos;
		}

		//Renvoie un membre selon son id
		public static member get(int id)
		{
			member m = null;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@idUser", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new member(reader);
				}
			}
			return m;
		}

		//Ajout d'un membre
		public static member Insert(member m)
		{
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@emailUser", m.emailUser);

				int id = Int32.Parse(command.ExecuteScalar().ToString());
				m.idUser = id;
			}
			return m;
		}

		//Suppresion d'un membre
		public static bool Delete(int id)
		{

			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@idUser", id);

				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}

		//Update d'un membre
		public static bool Update(member m)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

				command.Parameters.AddWithValue("@idUser", m.idUser);
				command.Parameters.AddWithValue("@emailUser", m.emailUser);
				command.Parameters.AddWithValue("@username", m.username);
				command.Parameters.AddWithValue("@userPwd", m.userPwd);
				command.Parameters.AddWithValue("@userAdmin", m.userAdmin);


				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}
	}
}
