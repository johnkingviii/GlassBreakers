using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public Leaderboard leaderboard;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI RestartButtonText;

    public GameObject ListObject;
    public GameObject LeaderBoardObject;

    public GameObject ScoreEntryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        leaderboard.GetData();

        instance = this;
    }


    public void KillPlayer()
    {
        GameOverText.gameObject.SetActive(true);
        LeaderBoardObject.SetActive(true);
        RestartButtonText.transform.parent.gameObject.SetActive(true);
        leaderboard.Save("test", ScoreCounter.instance.CurrentScore);
        leaderboard.OrderScores();
        DisplayScore();
    }

    public void DisplayScore()
    {
        foreach(LeaderboardEntry entry in leaderboard.leaderboard.Scores)
        {
            GameObject entryGO = GameObject.Instantiate(ScoreEntryPrefab);
            entryGO.GetComponentInChildren<Text>().text = entry.Name + "\t" + entry.Score;
            entryGO.transform.SetParent(ListObject.transform);
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
