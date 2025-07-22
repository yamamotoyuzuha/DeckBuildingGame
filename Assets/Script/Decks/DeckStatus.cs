using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckStatus : MonoBehaviour
{
    public string characterName;
    public int hp;
    public int cost;
    public int iD;
    public Sprite image;
    public int generation;

    void Start()
    {
        GetComponent<Image>().sprite = image;
    }
}
