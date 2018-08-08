using UnityEngine;
using System;
using System.Data;
using System.Collections.Generic;
using Mono.Data.Sqlite;

public class Utility : MonoBehaviour
{
	public enum ActionType {Insert, Update, Delete, Query};
	const string dbname = "GameDB.db";

	public static void Connect(ActionType action, string query)
	{
		IDbConnection conn = (IDbConnection) new SqliteConnection("URI=file:" + Application.dataPath + "/" + dbname);
		conn.Open();
		IDbCommand command = conn.CreateCommand();
		command.CommandText = query;
		IDataReader reader = command.ExecuteReader();

//		while(reader.Read())
//		{
//			int id = reader.GetInt32(0);
//			string name = reader.GetString(1);
//			print("Player " + id + " " + name);
//		}

		reader.Close();
		reader = null;
		command.Dispose();
		command = null;
		conn.Close();
		conn = null;
	}

	public static Dictionary<int, string> GetQuestList()
	{
		IDbConnection conn = (IDbConnection) new SqliteConnection("URI=file:" + Application.dataPath + "/" + dbname);
		conn.Open();
		IDbCommand command = conn.CreateCommand();
		command.CommandText = "select * from quest";
		IDataReader reader = command.ExecuteReader();
		Dictionary<int, string> list = new Dictionary<int, string>();
		while(reader.Read())
		{
			int id = reader.GetInt32(0);
			string title = reader.GetString(1);
			list.Add(id, title);
		}
		reader.Close();
		reader = null;
		command.Dispose();
		command = null;
		conn.Close();
		conn = null;
		return list;
	}
}
