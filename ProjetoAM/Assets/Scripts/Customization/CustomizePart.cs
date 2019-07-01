using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomizePart : MonoBehaviour
{

    public string MaterialName;
 
    public GameObject ChoicePrefab;

    public List<Color> Options;

    public Color? ChosenColour;

    GameObject ChoiceHolder;

    

    private void Start()
    {
        ChosenColour = null;
        ChoiceHolder = GameObject.FindGameObjectWithTag("ChoiceHolder");
    }

    public void ShowChoices()
    {
        foreach(Transform child in ChoiceHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < Options.Count; i++)
        {
            Color color = Options[i];
            GameObject choice = Instantiate<GameObject>(ChoicePrefab);
            choice.GetComponent<Image>().color = color;
            Button btn = choice.AddComponent<Button>();
            btn.onClick.AddListener(delegate
            {
                ChooseColor(color);
            });

            choice.transform.SetParent(ChoiceHolder.transform);
        }
    }

    public void ChooseColor(Color choice)
    {
        Debug.Log(choice);
        ChosenColour = choice;
        DisplayChanges.instance.DisplayVisualChanges();
    }
}
