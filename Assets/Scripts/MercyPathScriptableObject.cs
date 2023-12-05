using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MercyPath", menuName = "MercyPath")]
public class MercyPathScriptableObject : ScriptableObject
{
    public List<Transform> points = new List<Transform>();
}
