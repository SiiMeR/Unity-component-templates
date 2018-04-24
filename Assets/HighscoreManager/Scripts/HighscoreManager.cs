using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{

	[SerializeField] private GameObject highScoreHolder;

	private List<GameObject> highScoreLabels;
	
	// Use this for initialization
	void Awake ()
	{
		highScoreLabels = new List<GameObject>();
		foreach (Transform child in highScoreHolder.transform)
		{
			highScoreLabels.Add(child.gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	/// <summary>
	/// Takes a list of sorted highscores and fills the table with them
	/// </summary>
	/// <param name="highScores">List of sorted highscores</param>
	public void FillTable(List<Highscore> highScores)
	{
		for (var i = 0; i < highScoreLabels.Count; i++)
		{

			var textFields = highScoreLabels[i].GetComponentsInChildren<Text>(true);
			
			if (i >= highScores.Count)
			{
				textFields[0].text = (i + 1) + ". -";
				textFields[1].text = " - ";
			}
			else
			{
				textFields[0].text = (i + 1) + ". " + highScores[i].name;
				textFields[1].text = highScores[i].score.ToString();
			}
			
		}
	}

}

[System.Serializable]
public struct Highscore
{

	public string name;
	public int    score;

	public Highscore(string name, int score)
	{
		this.name = name;
		this.score = score;
	}
}
