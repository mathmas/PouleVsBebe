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

    [Header("Gameplay")]

    public GameObject chickenBody;
    [Space]
    public bool doubleCouches;
    [Space]
    public float speedMultiplicator;
    [Space]
    public bool invisible;
}
