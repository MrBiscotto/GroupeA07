﻿using GroupeA07.Models;
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
		public static readonly string GET = QUERY + " where " + COLUMN_ID_USER + " =@idUser";

        public static readonly string INSERT = "Insert into " + TABLE_NAME +
             "(" + COLUMN_EMAIL_USER +
             ", " + COLUMN_USER_NAME +
             ", " + COLUMN_USER_PWD +
             ", " + COLUMN_USER_ADMIN + ")"
            + " output inserted.idUser values(@emailUser,@username,@userPwd,0)";

        public static readonly string UPDATE = "update" + TABLE_NAME + " set " +
			COLUMN_EMAIL_USER + " =@emailUser"
			+ ", " + COLUMN_USER_NAME + " =@username"
			+ ", " + COLUMN_USER_PWD + "=@userPwd"
			+ ", " + COLUMN_USER_ADMIN + "=@userAdmin";



		public static readonly string DELETE = "delete from " + TABLE_NAME
			+ " where " + COLUMN_ID_USER + " =@idUser";


		//Return member list
		public static List<Member> Query()
		{
			List<Member> todos = new List<Member>();

			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					todos.Add(new Member(reader));
				}
			}
			return todos;
		}

		//Return member thanks to id
		public static Member Get(int id)
		{
			Member m = null;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@idUser", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new Member(reader);
				}
			}
			return m;
		}

        //Add member
        public static Member Insert(Member m)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(INSERT, connection);

                command.Parameters.AddWithValue("@emailUser", m.emailUser);
                command.Parameters.AddWithValue("@username", m.username);
                command.Parameters.AddWithValue("@userPwd", m.userPwd);
                command.Parameters.AddWithValue("@userAdmin", m.userAdmin);

                m.idUser = (int)command.ExecuteScalar();
            }
            return m;
        }

        //DELETE MEMBER
        public static bool Delete(int id)
		{

			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(DELETE, connection);

				command.Parameters.AddWithValue("@idUser", id);

				state = command.ExecuteNonQuery() != 0;
			}
			return state;
		}

		//Update Member
		public static bool Update(Member m)
		{
			bool state = false;
			using (SqlConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(UPDATE, connection);

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
