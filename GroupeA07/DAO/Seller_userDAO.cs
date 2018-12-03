using GroupeA07.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupeA07.DAO
{
	public class Seller_userDAO
	{
		public static readonly string TABLE_NAME = "Seller_user";
		public static readonly string COLUMN_ID_SELLER = "idSeller";
		public static readonly string COLUMN_USERNAME = "username";
		public static readonly string COLUMN_NB_SALES = "nbSales";
		public static readonly string COLUMN_POSITIVE_VOTE = "positiveVote";
		public static readonly string COLUMN_NEGATIVE_VOTE = "negativeVote";

		public static readonly string QUERY = "Select * from " + TABLE_NAME;
		public static readonly string GET = QUERY + " where " + COLUMN_ID_SELLER + " =@idSeller";

		public static readonly string INSERT = "Insert into" + TABLE_NAME +
			"(" + COLUMN_USERNAME +
			", " + COLUMN_NB_SALES +
			", " + COLUMN_POSITIVE_VOTE +
			", " + COLUMN_NEGATIVE_VOTE + ")"
			+ "output inserted.id values(@nameObject,0)";

		public static readonly string UPDATE = "update" + TABLE_NAME + " set "
			+ COLUMN_USERNAME + " =@username"
			+ ", " + COLUMN_NB_SALES + "=@nbSales"
			+ ", " + COLUMN_POSITIVE_VOTE + "=@username"
			+ ", " + COLUMN_NEGATIVE_VOTE + " =@negativeVote";



		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_ID_SELLER + " =@idSeller";


		//Renvoie liste des Objects
		public static List<Seller_user> Query()
		{
			List<Seller_user> objects = new List<Seller_user>();

			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					objects.Add(new Seller_user(reader));
				}
			}
			return objects;
		}

		//Renvoie un membre selon son id
		public static Seller_user Get(int id)
		{
			Seller_user m = null;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@idSeller", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new Seller_user(reader);
				}
			}
			return m;
		}

		//Ajout d'un membre
		public static Seller_user Insert(Seller_user todo)
		{
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@username", todo.username);

				int id = Int32.Parse(command.ExecuteScalar().ToString());
				todo.idSeller = id;
			}
			return todo;
		}

		public static bool Delete(int id)
		{

			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

				command.Parameters.AddWithValue("@idSeller", id);

				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}

		public static bool Update(Seller_user todo)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

				command.Parameters.AddWithValue("@idSeller", todo.idSeller);
				command.Parameters.AddWithValue("@username", todo.username);
				command.Parameters.AddWithValue("@nbSales", todo.nbSales);
				command.Parameters.AddWithValue("@positiveVote", todo.positiveVote);
				command.Parameters.AddWithValue("@negativeVote", todo.negativeVote);


				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}
	}
}