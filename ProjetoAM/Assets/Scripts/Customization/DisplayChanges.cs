using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayChanges : MonoBehaviour
{

    public GameObject PlayerObject;
    public static DisplayChanges instance;

    SkinnedMeshRenderer BodyRenderer;
    SkinnedMeshRenderer ConeRenderer;

    public CharacterAppearance CharacterAppearance;
    public CharacterAppearance DefaultApperance;

    public List<CustomizePart> CustomizationChoices;
    // Start is called before the first frame update
    void Start()
    {
        SkinnedMeshRenderer[] renderers =  PlayerObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        BodyRenderer = renderers[0];
        ConeRenderer = renderers[1];
        instance = this;
    }

    public void DisplayVisualChanges()
    {
        foreach(CustomizePart part in CustomizationChoices)
        {
            Debug.Log(part);
            for (int i = 0; i < BodyRenderer.materials.Length; i++)
            {
                Material mat = BodyRenderer.materials[i];
                
                if (mat.name == part.MaterialName + " (Instance)")
                {
                    Debug.Log(mat.name);
                    if (part.ChosenColour.HasValue)
                        mat.color = part.ChosenColour.Value;
                    
                }
            }
            for (int i = 0; i < ConeRenderer.materials.Length; i++)
            {
                Material mat = ConeRenderer.materials[i];
                
                if (mat.name == part.MaterialName + " (Instance)")
                {
                    Debug.Log(mat.name);
                    if(part.ChosenColour.HasValue)
                        mat.color = part.ChosenColour.Value;
                   
                }
            }
        }
    }

    public void SaveChanges()
    {
        for (int i = 0; i < BodyRenderer.materials.Length; i++)
        {
            Material mat = BodyRenderer.materials[i];
            CharacterAppearance.bodyColours[i] = mat.color;
        }

        for (int i = 0; i < ConeRenderer.materials.Length; i++)
        {
            Material mat = ConeRenderer.materials[i];
            CharacterAppearance.coneColours[i] = mat.color;
        }
    }

    public void SetDefault()
    {
        for (int i = 0; i < BodyRenderer.materials.Length; i++)
        {
            Material mat = BodyRenderer.materials[i];
            mat.color = DefaultApperance.bodyColours[i];
        }
        for (int i = 0; i < ConeRenderer.materials.Length; i++)
        {
            Material mat = ConeRenderer.materials[i];
            mat.color = DefaultApperance.coneColours[i];
        }
        SaveChanges();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
