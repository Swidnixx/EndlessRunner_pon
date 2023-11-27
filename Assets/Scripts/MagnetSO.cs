using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MagnetSO : ScriptableObject
{
    public bool magnetActive;
    public float magnetRange = 2.5f;
    public float magnetDuration = 5;
}
