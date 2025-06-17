using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("�g�[�^���R�X�g�e�L�X�g")]
    [SerializeField] TextMeshProUGUI totalCostText;

    [Header("���݂̃g�[�^���R�X�g")]
    [SerializeField] int totalCost;

    [Header("�R�X�g���")]
    [SerializeField] int costUpperLimit;
    [SerializeField] bool isUpperLimit;
    [SerializeField] TextMeshProUGUI upperLimitText;

    [Space(20)]
    public GameObject parent;
    public GameObject deck;

    void Start()
    {
        totalCostText.enabled = true;
        upperLimitText.enabled = false;

        for(int i = 0; i < installationNum; i++)
        {
            //Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);

            GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);

            var decks = obj.GetComponent<DeckStatus>();
            if(decks != null)
            {
                //���������f�b�L�ɃX�e�[�^�X�����蓖��
                int random = Random.Range(0, characterData.Length);
                decks.characterName = characterData[random].characterName;
                decks.hp = characterData[random].hp;
                decks.cost = characterData[random].cost;
                decks.iD = characterData[random].id;
            }
        }
    }

    public void TotalCostAdd(int cost) //�g�[�^���R�X�g�𑝉�
    {
        totalCost += cost;
        totalCostText.text = "TotalCost" + " "+ ":" + " " + totalCost.ToString();

        upperLimitText.enabled = false;
        JudgmentTotalCost(); //�R�X�g����
    }

    public void TotalCostSubtraction(int cost) //�g�[�^���R�X�g�����Z
    {
        totalCost -= cost;
        totalCostText.text = "TotalCost" + " " + ":" + " " + totalCost.ToString();

        upperLimitText.enabled = false;
        JudgmentTotalCost();
    }

    void JudgmentTotalCost() //�R�X�g����
    {
        if(totalCost >= costUpperLimit)
        {
            totalCostText.color = Color.red;
            isUpperLimit = true;
        }
        else
        {
            totalCostText.color = Color.white;
            isUpperLimit = false;
        }
    }

    public void DecisionButton() //����
    {
        JudgmentTotalCost();
        if (isUpperLimit)
        {
            upperLimitText.text = "Upper Limit";
            upperLimitText.enabled = true;
        }
        else
        {
            upperLimitText.enabled = false;
        }
    }
}
