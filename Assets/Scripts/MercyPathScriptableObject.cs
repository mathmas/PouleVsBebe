using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MercyPath", menuName = "MercyPath")]
public class MercyPathScriptableObject : ScriptableObject
{
    public List<Vector3> points = new List<Vector3>();
}
