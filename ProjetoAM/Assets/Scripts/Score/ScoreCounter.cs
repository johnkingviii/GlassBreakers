using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    public int ScorePerMinute;
    public int ScorePerKill;

    public int CurrentScore;

    bool busy;
    //UI
    public TextMeshProUGUI Counter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateText();
    }

    void UpdateText()
    {
        Counter.text = CurrentScore.ToString();
    }

    public void AwardKill()
    {
        CurrentScore += ScorePerKill;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!busy)
        {
            StartCoroutine("UpdateScore");
        }
    }

    IEnumerator UpdateScore()
    {
        busy = true;
        CurrentScore += (int)(ScorePerMinute/60f);
        UpdateText();
        yield return new WaitForSeconds(1f);
        busy = false;
    }
}
