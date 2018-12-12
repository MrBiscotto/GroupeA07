using GroupeA07.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.DAO
{
	public class Auctioned_ObjectDAO
	{

		public static readonly string TABLE_NAME = "Auctioned_Object";
		public static readonly string COLUMN_ID_OBJECT = "idObject";
		public static readonly string COLUMN_NAME_OBJECT = "nameObject";
		public static readonly string COLUMN_DESCRIPTION_OBJECT = "descriptionObject";
		public static readonly string COLUMN_PRICE_OBJECT = "priceObject";
		public static readonly string COLUMN_ID_USER = "idUser";
		public static readonly string COLUMN_CAT_OBJECT = "catObject";

		public static readonly string QUERY = "Select * from " + TABLE_NAME;
		public static readonly string GET = QUERY + " where " + COLUMN_ID_OBJECT + " =@idObject";

		public static readonly string INSERT = "Insert into " + TABLE_NAME +
			"(" + COLUMN_NAME_OBJECT +
			", " + COLUMN_DESCRIPTION_OBJECT +
			", " + COLUMN_PRICE_OBJECT +
			", " + COLUMN_ID_USER +
			", " + COLUMN_CAT_OBJECT + ")"
			+ "output inserted.idObject values(@nameObject,@descriptionObject,@priceObject,@idUser,@catObject)";

		public static readonly string UPDATE = "update " + TABLE_NAME + " set " +
			COLUMN_NAME_OBJECT + " =@nameObject"
			+ ", " + COLUMN_DESCRIPTION_OBJECT + " =@descriptionObject"
			+ ", " + COLUMN_PRICE_OBJECT + "=@priceObject"
			+ ", " + COLUMN_ID_USER + "=@idUser"
			+ ", " + COLUMN_CAT_OBJECT + "=@catObject"
			;



		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_ID_OBJECT + " =@idObject";


		//Renvoie liste des Objects
		public static List<Auctioned_object> Query()
		{
			List<Auctioned_object> objects = new List<Auctioned_object>();

			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					objects.Add(new Auctioned_object(reader));
				}
			}
			return objects;
		}

		//Renvoie un membre selon son id
		public static Auctioned_object Get(int id)
		{
			Auctioned_object m = null;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@idObject", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new Auctioned_object(reader);
				}
			}
			return m;
		}

		//Ajout d'un membre
		public static Auctioned_object Insert(Auctioned_object todo)
		{
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@nameObject", todo.nameObject);
				command.Parameters.AddWithValue("@descriptionObject", todo.descriptionObject);
				command.Parameters.AddWithValue("@priceObject", todo.priceObject);
				command.Parameters.AddWithValue("@idUser", todo.idUser);
				command.Parameters.AddWithValue("@catObject", todo.catObject);

                todo.idObject = (int)command.ExecuteScalar();
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

				command.Parameters.AddWithValue("@idObject", id);

				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}

		public static bool Update(Auctioned_object todo)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

				command.Parameters.AddWithValue("@nameObject", todo.nameObject);
				command.Parameters.AddWithValue("@descriptionObject", todo.descriptionObject);
				command.Parameters.AddWithValue("@priceObject", todo.priceObject);
				command.Parameters.AddWithValue("@idUser", todo.idUser);
				command.Parameters.AddWithValue("@catObject", todo.catObject);


				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}
	}
}