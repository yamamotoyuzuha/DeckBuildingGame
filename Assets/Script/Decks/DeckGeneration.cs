using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckGeneration : MonoBehaviour
{
    public CharacterData[] characterData;

    [Header("生成したデッキの親オブジェクト")]
    public GameObject decksPerant;

    [Header("デッキのPrefab")]
    [SerializeField] GameObject deckPrefab;

    [Header("生成個数")]
    [SerializeField] int installationNum;

    [Header("トータルコストテキスト")]
    [SerializeField] TextMeshProUGUI totalCostText;

    [Header("現在のトータルコスト")]
    public int totalCost;

    [Header("コスト上限")]
    [SerializeField] int costUpperLimit;
    [SerializeField] bool isUpperLimit;
    [SerializeField] TextMeshProUGUI upperLimitText;

    [Header("デッキ移動する際の親オブジェクト（キャンバス）")]
    public GameObject parent;

    [Header("生成したデッキのリスト")]
    public List<DeckStatus> allDecks;

    [Header("ソートスクリプト")]
    public DeckSort deckSort;


    void Start()
    {
        totalCostText.enabled = true;
        upperLimitText.enabled = false;

        for(int i = 0; i < installationNum; i++)
        {
            GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);

            var decks = obj.GetComponent<DeckStatus>();
            if(decks != null)
            {
                //生成したデッキにステータスを割り当て
                int random = Random.Range(0, characterData.Length);
                decks.characterName = characterData[random].Name;
                decks.hp = characterData[random].HP;
                decks.cost = characterData[random].Cost;
                decks.iD = characterData[random].ID;
                decks.generation = characterData[random].Acquisition;

                decks.image = characterData[random].Image;

                allDecks.Add(decks); //生成したデッキをリストに追加
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

    public void SortDeckGeneration(List<(int, string)> sortDeck) //ソートしたデッキを生成
    {
        if (deckSort.isGeneration)
        {
            CharacterData match = null; //データとマッチしたものを入れる
            
            allDecks.Clear(); //生成したデッキを削除

            //生成したカードオブジェクトを削除
            foreach (Transform child in decksPerant.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var generation in sortDeck) //入手順
            {
                foreach (var deta in characterData) //カードデータ
                {
                    if (deta.Acquisition == generation.Item1 && deta.Name == generation.Item2) //カードデータのカード入手順とソートしたデッキのカード入手順が一致したら
                    {
                        match = deta;
                        break;
                    }
                }
                
                GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
                var decks = obj.GetComponent<DeckStatus>();

                //生成したデッキ（カード）にカードの情報を代入
                decks.characterName = match.Name;
                decks.hp = match.HP;
                decks.cost = match.Cost;
                decks.iD = match.ID;
                decks.generation = match.Acquisition;

                decks.image = match.Image;

                allDecks.Add(decks); //生成したデッキをリストに追加

                deckSort.isGeneration = false;
            }
        }
        else if (deckSort.isCost)
        {
            CharacterData match = null; //データとマッチしたものを入れる
            
            allDecks.Clear(); //生成したデッキを削除

            //生成したカードオブジェクトを削除
            foreach (Transform child in decksPerant.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var cost in sortDeck) //コスト
            {
                foreach (var deta in characterData) //カードデータ
                {
                    if (deta.Cost == cost.Item1 && deta.Name == cost.Item2) //カードデータのカードコストとソートしたデッキのカードコストが一致したら
                    {
                        match = deta;
                        break;
                    }
                }

                GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
                var decks = obj.GetComponent<DeckStatus>();

                //生成したデッキ（カード）にカードの情報を代入
                decks.characterName = match.Name;
                decks.hp = match.HP;
                decks.cost = match.Cost;
                decks.iD = match.ID;
                decks.generation = match.Acquisition;

                decks.image = match.Image;

                allDecks.Add(decks); //生成したデッキをリストに追加

                deckSort.isCost = false;
            }
        }
        else if (deckSort.isHp)
        {
            CharacterData match = null; //データとマッチしたものを入れる
            
            allDecks.Clear(); //生成したデッキを削除

            //生成したカードオブジェクトを削除
            foreach (Transform child in decksPerant.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var hp in sortDeck) //HP
            {
                foreach (var deta in characterData) //カードデータ
                {
                    if (deta.HP == hp.Item1 && deta.Name == hp.Item2) //カードデータのカードHPとソートしたデッキのカードHPが一致したら
                    {
                        match = deta;
                        break;
                    }
                }

                GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
                var decks = obj.GetComponent<DeckStatus>();

                //生成したデッキ（カード）にカードの情報を代入
                decks.characterName = match.Name;
                decks.hp = match.HP;
                decks.cost = match.Cost;
                decks.iD = match.ID;
                decks.generation = match.Acquisition;

                decks.image = match.Image;

                allDecks.Add(decks); //生成したデッキをリストに追加

                deckSort.isHp = false;
            }
        }
    }
}
