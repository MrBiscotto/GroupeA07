using GroupeA07.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.DAO
{
	public class Sold_objectDAO
	{
		public static readonly string TABLE_NAME = "Sold_object";
		public static readonly string COLUMN_ID_OBJECT = "idObject";
		public static readonly string COLUMN_FINAL_PRICE = "finalPrice";
		public static readonly string COLUMN_NAME_OBJECT = "nameObject";
		public static readonly string COLUMN_CAT_OBJECT = "catObject";

		public static readonly string QUERY = "Select * from " + TABLE_NAME;
		public static readonly string GET = QUERY + " where " + COLUMN_ID_OBJECT + " =@idSeller";

		public static readonly string INSERT = "Insert into " + TABLE_NAME +
			"(" + COLUMN_FINAL_PRICE +
			", " + COLUMN_NAME_OBJECT +
			", " + COLUMN_CAT_OBJECT + ")"
			+ "output inserted.idObject values(@finalPrice,@nameObject,@catObject)";

		public static readonly string UPDATE = "update " + TABLE_NAME + " set "
			+ COLUMN_FINAL_PRICE + " =@finalPrice"
			+ ", " + COLUMN_NAME_OBJECT + "=@nameObject"
			+ ", " + COLUMN_CAT_OBJECT + " =@catObject";



		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_ID_OBJECT + " =@idObject";


		//get object list
		public static List<Sold_object> Query()
		{
			List<Sold_object> objects = new List<Sold_object>();

			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					objects.Add(new Sold_object(reader));
				}
			}
			return objects;
		}

		//Get with id
		public static Sold_object Get(int id)
		{
			Sold_object m = null;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@idObject", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new Sold_object(reader);
				}
			}
			return m;
		}

		//Add sold_object
		public static Sold_object Insert(Sold_object todo)
		{
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@finalPrice", todo.finalPrice);
				command.Parameters.AddWithValue("@nameObject", todo.nameObject);
				command.Parameters.AddWithValue("@catObject", todo.catObject);

				int id = Int32.Parse(command.ExecuteScalar().ToString());
				todo.idObject = id;
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

		public static bool Update(Sold_object todo)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

				command.Parameters.AddWithValue("@finalPrice", todo.finalPrice);
				command.Parameters.AddWithValue("@nameObject", todo.nameObject);
				command.Parameters.AddWithValue("@catObject", todo.catObject);


				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}
	}
}
