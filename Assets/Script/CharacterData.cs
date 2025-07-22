using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField]string characterName;
    [SerializeField]int hp;
    [SerializeField]int cost;
    [SerializeField]int id;
    [SerializeField]Sprite image;
    [SerializeField]int acquisition;

    public string Name { get => characterName; }
    public int HP { get => hp; }
    public int Cost { get => cost; }
    public int ID { get => id; }
    public Sprite Image { get => image; }
    public int Acquisition { get => acquisition; }
}
