using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSort : MonoBehaviour
{
    [SerializeField] DeckGeneration deckGeneration;

    [Header("ソートリスト")]
    public List<(int, string)> generationList = new List<(int, string)>();
    public List<(int, string)> costList = new List<(int, string)>();
    public List<(int, string)> hpList = new List<(int, string)>();

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
                generationList.Add((deck.generation, deck.characterName));
            }
            isgenerationChange = true;
            generationList.Sort();

            deckGeneration.SortDeckGeneration(generationList);
        }
        else
        {
            foreach (var deck in deckGeneration.allDecks)
            {
                generationList.Add((deck.generation, deck.characterName));
            }
            isgenerationChange = false;
            generationList.Sort();
            generationList.Reverse();

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
                costList.Add((deck.cost, deck.characterName));
            }
            isCostChange = true;
            costList.Sort();

            deckGeneration.SortDeckGeneration(costList); //ソートしたデッキを再度生成する
        }
        else
        {
            foreach (var deck in deckGeneration.allDecks)
            {
                costList.Add((deck.cost, deck.characterName));
            }
            isCostChange = false;
            costList.Sort();
            costList.Reverse();

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
                hpList.Add((deck.hp, deck.characterName));
            }
            isHpChange = true;
            hpList.Sort();

            deckGeneration.SortDeckGeneration(hpList);
        }
        else
        {
            foreach(var deck in deckGeneration.allDecks)
            {
                hpList.Add((deck.hp, deck.characterName));
            }
            isHpChange = false;
            hpList.Sort();
            hpList.Reverse();

            deckGeneration.SortDeckGeneration(hpList);
        }
    }
}
