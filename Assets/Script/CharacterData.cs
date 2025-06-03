using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int hp;
    public int cost;
    public int id;

    public string Name { get => characterName; }
    public int HP { get => hp; }
    public int Cost { get => cost; }
    public int ID { get => id; }
}
