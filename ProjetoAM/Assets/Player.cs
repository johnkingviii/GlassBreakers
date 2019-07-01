using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterAppearance appearance;

    public SkinnedMeshRenderer Body;
    public SkinnedMeshRenderer Cone;
    // Start is called before the first frame update
    void Start()
    {
        Material[] bodyMats = Body.materials;
        for (int i = 0; i < bodyMats.Length; i++)
        {
            Material mat = bodyMats[i];
            mat.color = appearance.bodyColours[i];
        }

        Material[] coneMats = Cone.materials;
        for (int i = 0; i < coneMats.Length; i++)
        {
            Material mat = coneMats[i];
            Debug.Log(mat.name);
            mat.color = appearance.coneColours[i];
        }


        Body.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f)
        {
            GameController.instance.KillPlayer();
            GetComponent<FPSController>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }
}
