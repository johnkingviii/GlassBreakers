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
    public GameObject mainMenuBtn;

    public GameObject ListObject;
    public GameObject LeaderBoardObject;
    public GameObject CrossHair;

    public GameObject ScoreEntryPrefab;

    public TMP_InputField NameInput;
    public GameObject submitBtn;

    public bool GameOver;


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
        mainMenuBtn.SetActive(true);
        NameInput.gameObject.SetActive(true);
        submitBtn.SetActive(true);
        CrossHair.SetActive(false);
        DisplayScore();
        GameOver = true;
    }

    public void SaveToLeaderBoard()
    {
        string name = NameInput.text;
        if (name.Length <= 0)
            return;

        leaderboard.Save(name, ScoreCounter.instance.CurrentScore);
        leaderboard.OrderScores();
        DisplayScore();
        NameInput.gameObject.SetActive(false);
        submitBtn.SetActive(false);
    }

    public void DisplayScore()
    {
        foreach (Transform child in ListObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (LeaderboardEntry entry in leaderboard.leaderboard.Scores)
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

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
