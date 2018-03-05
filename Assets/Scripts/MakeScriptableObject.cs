using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeScriptableObject 
{

	[MenuItem("Asset/Create/Database")]
	public static void CreateDatabaseAsset()
	{

		DataBase database = ScriptableObject.CreateInstance<DataBase> ();
		AssetDatabase.CreateAsset (database, "Assets/Scripts/Database.asset");
		AssetDatabase.SaveAssets ();

	}
}
