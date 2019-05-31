using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[System.Serializable]
public class Leaderboard
{

    public LeaderboardModel leaderboard;

    private string path = Application.streamingAssetsPath + "/Leaderboard.json";

    public void GetData()
    {
        leaderboard.Scores = new List<LeaderboardEntry>();
        
        string file = File.ReadAllText(path);
        if (file != null)
        {
            leaderboard = JsonUtility.FromJson<LeaderboardModel>(file);
           
            if(leaderboard != null)
            {
                OrderScores();
            }
            else
            {
                leaderboard = new LeaderboardModel
                {
                    Scores = new List<LeaderboardEntry>()
                };
            }
        }
    }
    public void OrderScores()
    {
       leaderboard.Scores = leaderboard.Scores.OrderByDescending(e => e.Score).ToList();
    }


    public void Save(string name,int score)
    {
        leaderboard.Scores.Add(new LeaderboardEntry(name, score));
        Debug.Log(JsonUtility.ToJson(leaderboard));
        File.WriteAllText(path, JsonUtility.ToJson(leaderboard));
    }

    [System.Serializable]
    public class LeaderboardModel
    {
        [SerializeField]
        public List<LeaderboardEntry> Scores;
    }
}

[System.Serializable]
public class LeaderboardEntry
{
    [SerializeField]
    public string Name;

    [SerializeField]
    public int Score;

    public LeaderboardEntry(string Name, int Score)
    {
        this.Name = Name;
        this.Score = Score;
    }
}
