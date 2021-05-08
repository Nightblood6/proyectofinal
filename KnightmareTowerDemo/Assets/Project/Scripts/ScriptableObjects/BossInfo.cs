using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "Boss")]
public class BossInfo : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;

    
}
