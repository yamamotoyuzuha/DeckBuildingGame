using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSort : MonoBehaviour
{
    [SerializeField] DeckGeneration deckGeneration;

    [Header("ソートリスト")]
    public List<int> generationList;
    public List<int> costList;
    public List<int> hpList;

    [Header("ソートボタン")]
    public GameObject SortButton;
    public GameObject SortButtons;

    [Header("ソートフラグ")]
    public bool isGeneration;
    public bool isCost;
    public bool isHp;

    private int generation;
    private bool isgenerationChange;

    private int cost;
    private bool isCostChange;

    private int hp;
    private bool isHpChange;

    void Start()
    {
        SortButtons.SetActive(false);
    }

    public void OpenSortButton()
    {
        SortButtons.SetActive(true);
        SortButton.SetActive(false);
    }

    public void CloseSortButton()
    {
        SortButtons.SetActive(false);
        SortButton.SetActive(true);
    }

    public void AcquisitionSourtButton() //入手順
    {
        isGeneration = true; 

        generationList.Clear();

        if (!isgenerationChange)
        {
            foreach (var deck in deckGeneration.allDecks)
            {
                generation = deck.generation;
                generationList.Add(generation);
                generationList.Sort();
            }
            isgenerationChange = true;

            deckGeneration.SortDeckGeneration(generationList);
        }
        else
        {
            foreach (var deck in deckGeneration.allDecks)
            {
                generation = deck.generation;
                generationList.Add(generation);
                generationList.Sort();
                generationList.Reverse();
            }
            isgenerationChange = false;

            deckGeneration.SortDeckGeneration(generationList);
        }
    }

    public void CostSourtButton() //コスト
    {
        isCost = true;

        costList.Clear();

        if (!isCostChange)
        {
            foreach (var deck in deckGeneration.allDecks)
            {
                cost = deck.cost;
                costList.Add(cost);
                costList.Sort();
            }
            isCostChange = true;

            deckGeneration.SortDeckGeneration(costList); //ソートしたデッキを再度生成する
        }
        else
        {
            foreach (var deck in deckGeneration.allDecks)
            {
                cost = deck.cost;
                costList.Add(cost);
                costList.Sort();
                costList.Reverse();
            }
            isCostChange = false;

            deckGeneration.SortDeckGeneration(costList); //ソートしたデッキを再度生成する
        }
    }

    public void HPSortButton() //HP
    {
        isHp = true;

        hpList.Clear();

        if (!isHpChange)
        {
            foreach(var deck in deckGeneration.allDecks)
            {
                hp = deck.hp;
                hpList.Add(hp);
                hpList.Sort();
            }
            isHpChange = true;

            deckGeneration.SortDeckGeneration(hpList);
        }
        else
        {
            foreach(var deck in deckGeneration.allDecks)
            {
                hp = deck.hp;
                hpList.Add(hp);
                hpList.Sort();
                hpList.Reverse();
            }
            isHpChange = false;

            deckGeneration.SortDeckGeneration(hpList);
        }
    }
}
