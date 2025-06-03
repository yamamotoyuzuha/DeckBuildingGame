using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGeneration : MonoBehaviour
{
    public CharacterData[] characterData;

    [Header("���������f�b�L�̐e�I�u�W�F�N�g")]
    [SerializeField] GameObject decksPerant;

    [Header("�f�b�L��Prefab")]
    [SerializeField] GameObject deckPrefab;

    [Header("������")]
    [SerializeField] int installationNum;

    void Start()
    {
        for(int i = 0; i < installationNum; i++)
        {
            Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
        }
    }
}
