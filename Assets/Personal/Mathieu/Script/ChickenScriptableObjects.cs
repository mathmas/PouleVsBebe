using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChickenObject")]
public class ChickenScriptableObjects : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite spritePreview;
    public int cost;


    public GameObject chickenBody;
}
