using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAppearance", menuName = "Character/Appearance")]
public class CharacterAppearance : ScriptableObject
{
    public List<Color> bodyColours;

    public List<Color> coneColours;
}
