using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Models.Levels;

public class LevelLoadScript : MonoBehaviour
{
	public List<LevelPrefabLetter> Prefabs;

	// Use this for initialization
	void Start () {
		LoadLevel(@"Assets/Levels/level1.txt");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(string fileName)
	{
		var levelReader= File.OpenText(fileName);

		float positionX = 0;
		float positionY = 0;

		while (!levelReader.EndOfStream)
		{
			string rowData = levelReader.ReadLine();

			positionX = 0;

			foreach (char c in rowData)
			{
				var prefab = Prefabs.FirstOrDefault(pf => pf.Letter.Equals(c.ToString()));

				if (prefab != null)
				{
					Instantiate(prefab.Prefab, new Vector3(positionX, positionY), Quaternion.identity);
				}

				positionX += .5f;
			}

			positionY += .5f;
		}
	}
}
