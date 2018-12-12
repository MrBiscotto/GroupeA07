using GroupeA07.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.DAO
{
	public class ModeratorDAO
	{
		public static readonly string TABLE_NAME = "Moderator";
		public static readonly string COLUMN_ID_MODERATOR = "idModerator";
		public static readonly string COLUMN_ID_USER = "idUser";
		

		public static readonly string QUERY = "Select * from " + TABLE_NAME;
		public static readonly string GET = QUERY + " where " + COLUMN_ID_USER + " =@idModerator";

		public static readonly string INSERT = "Insert into " + TABLE_NAME +
			"(" + COLUMN_ID_USER + ")"
			+ "output inserted.idModerator values(@idUser)";

		public static readonly string UPDATE = "update " + TABLE_NAME + " set " +
			COLUMN_ID_USER + " =@isUser";



		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_ID_MODERATOR + " =@idModerator";


		//Return moderator list
		public static List<Moderator> Query()
		{
			List<Moderator> objects = new List<Moderator>();

			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					objects.Add(new Moderator(reader));
				}
			}
			return objects;
		}

		//Return moderator thanks to id
		public static Moderator Get(int id)
		{
			Moderator m = null;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@idModerator", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new Moderator(reader);
				}
			}
			return m;
		}

		//ADD Moderator
		public static Moderator Insert(Moderator todo)
		{
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@idUser", todo.idUser);

				int id = Int32.Parse(command.ExecuteScalar().ToString());
				todo.idModerator = id;
			}
			return todo;
		}

		public static bool Delete(int id)
		{

			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(DELETE, connection);

				command.Parameters.AddWithValue("@idModerator", id);

				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}

		public static bool Update(Moderator todo)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

				command.Parameters.AddWithValue("@idUser", todo.idUser);
				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}
	}
}