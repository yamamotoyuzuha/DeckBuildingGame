using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("トータルコストテキスト")]
    [SerializeField] TextMeshProUGUI totalCostText;

    [Header("現在のトータルコスト")]
    [SerializeField] int totalCost;

    [Header("コスト上限")]
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
                //生成したデッキにステータスを割り当て
                int random = Random.Range(0, characterData.Length);
                decks.characterName = characterData[random].characterName;
                decks.hp = characterData[random].hp;
                decks.cost = characterData[random].cost;
                decks.iD = characterData[random].id;
            }
        }
    }

    public void TotalCostAdd(int cost) //トータルコストを増加
    {
        totalCost += cost;
        totalCostText.text = "TotalCost" + " "+ ":" + " " + totalCost.ToString();

        upperLimitText.enabled = false;
        JudgmentTotalCost(); //コスト判定
    }

    public void TotalCostSubtraction(int cost) //トータルコストを減算
    {
        totalCost -= cost;
        totalCostText.text = "TotalCost" + " " + ":" + " " + totalCost.ToString();

        upperLimitText.enabled = false;
        JudgmentTotalCost();
    }

    void JudgmentTotalCost() //コスト判定
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

    public void DecisionButton() //決定
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
