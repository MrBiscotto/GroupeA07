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
		public static readonly string COLUMN_ID_USER = "idUser";

		public static readonly string QUERY = "Select * from " + TABLE_NAME;
		public static readonly string GET = QUERY + " where " + COLUMN_ID_SELLER + " =@idSeller";

		public static readonly string INSERT = "Insert into " + TABLE_NAME +
			"(" + COLUMN_USERNAME +
			", " + COLUMN_NB_SALES +
			", " + COLUMN_POSITIVE_VOTE +
			", " + COLUMN_NEGATIVE_VOTE +
            ","  + COLUMN_ID_USER + ")"
			+ "output inserted.idSeller values(@username,@nbSales,@positiveVote,@negativeVote,@idUser)";

		public static readonly string UPDATE = "update " + TABLE_NAME + " set "
			+ COLUMN_USERNAME + " =@username"
            + ", " + COLUMN_NB_SALES + "=@nbSales"
			+ ", " + COLUMN_POSITIVE_VOTE + "=@positiveVote"
			+ ", " + COLUMN_NEGATIVE_VOTE + " =@negativeVote"
            + ", " + COLUMN_ID_USER + "=@idUser"
            + " WHERE "  + COLUMN_ID_USER + "= @idUser";


		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_ID_SELLER + " =@idSeller";


		//Return seller list
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

		//Return seller by id
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


		//Add seller
		public static Seller_user Insert(Seller_user todo)
		{
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(INSERT, connection);

                command.Parameters.AddWithValue("@username", todo.username);
                command.Parameters.AddWithValue("@nbSales", todo.nbSales);
                command.Parameters.AddWithValue("@positiveVote", todo.positiveVote);
                command.Parameters.AddWithValue("@negativeVote", todo.negativeVote);
                command.Parameters.AddWithValue("@idUser", todo.idUser);

                todo.idSeller = (int)command.ExecuteScalar();

			}
			return todo;
		}

        //Delete a Seller_user
		public static bool Delete(int id)
		{

			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(DELETE, connection);

				command.Parameters.AddWithValue("@idSeller", id);

				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}

        //Update a seller_user
		public static bool Update(Seller_user todo)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

				command.Parameters.AddWithValue("@username", todo.username);
				command.Parameters.AddWithValue("@nbSales", todo.nbSales);
				command.Parameters.AddWithValue("@positiveVote", todo.positiveVote);
				command.Parameters.AddWithValue("@negativeVote", todo.negativeVote);
				command.Parameters.AddWithValue("@idUser", todo.idUser);
                
				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}
	}
}