using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int hp;
    public int cost;
    public int id;
    public Image image;

    public string Name { get => characterName; }
    public int HP { get => hp; }
    public int Cost { get => cost; }
    public int ID { get => id; }

    public Image Image { get => image; }
}
