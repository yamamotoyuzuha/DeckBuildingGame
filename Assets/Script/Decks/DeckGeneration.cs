using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGeneration : MonoBehaviour
{
    public CharacterData[] characterData;

    [Header("生成したデッキの親オブジェクト")]
    [SerializeField] GameObject decksPerant;

    [Header("デッキのPrefab")]
    [SerializeField] GameObject deckPrefab;

    [Header("生成個数")]
    [SerializeField] int installationNum;

    void Start()
    {
        for(int i = 0; i < installationNum; i++)
        {
            Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
        }
    }
}
