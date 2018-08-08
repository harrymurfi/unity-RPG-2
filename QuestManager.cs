using UnityEngine;
using System;
using System.Data;
using System.Collections.Generic;
using Mono.Data.Sqlite;

public class QuestManager : MonoBehaviour
{
	public Dictionary<int, string> questList = new Dictionary<int, string>();
	public Dictionary<int, string> activeQuest = new Dictionary<int, string>();

	const string dbname = "GameDB.db";

	void Start()
	{
		questList = GetQuest("all");
		activeQuest = GetQuest("active");
		print(questList.Count);
	}

	Dictionary<int, string> GetQuest(string action)
	{
		IDbConnection conn = (IDbConnection) new SqliteConnection("URI=file:" + Application.dataPath + "/" + dbname);
		conn.Open();
		IDbCommand command = conn.CreateCommand();
		switch(action)
		{
		case "all": command.CommandText = "select * from quest"; break;
		case "active": command.CommandText = "select * from quest where status=1"; break;
		}
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

	public void ActivateQuest(int questId)
	{
		
	}
}
