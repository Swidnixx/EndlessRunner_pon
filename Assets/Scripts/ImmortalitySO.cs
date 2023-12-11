using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ImmortalitySO : ScriptableObject
{
    public bool active;
    public float speedBoost = 2.5f;
    public float duration = 5;

    public int level = 1;
    public int upgradeCost = 100;
    public ImmortalitySO upgraded;
}
