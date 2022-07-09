using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WarriorData : ScriptableObject
{
    public Sprite sprite;

    public WarriorType warriorType;
    public string warriorName;
    public float damage;
    public float maxHealth;
}