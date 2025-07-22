using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckGeneration : MonoBehaviour
{
    public CharacterData[] characterData;

    [Header("���������f�b�L�̐e�I�u�W�F�N�g")]
    public GameObject decksPerant;

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

    [Header("�f�b�L�ړ�����ۂ̐e�I�u�W�F�N�g�i�L�����o�X�j")]
    public GameObject parent;

    [Header("���������f�b�L�̃��X�g")]
    public List<DeckStatus> allDecks;

    [Header("�\�[�g�X�N���v�g")]
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
                //���������f�b�L�ɃX�e�[�^�X�����蓖��
                int random = Random.Range(0, characterData.Length);
                decks.characterName = characterData[random].characterName;
                decks.hp = characterData[random].hp;
                decks.cost = characterData[random].cost;
                decks.iD = characterData[random].id;
                decks.generation = i;

                allDecks.Add(decks); //���������f�b�L�����X�g�ɒǉ�
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

    public void SortDeckGeneration(List<int> sortDeck) //�\�[�g�����f�b�L�𐶐�
    {
        if (deckSort.isGeneration)
        {
            CharacterData match = null; //�f�[�^�ƃ}�b�`�������̂�����
            int num = 0; //����������

            allDecks.Clear(); //���������f�b�L���폜

            //���������J�[�h�I�u�W�F�N�g���폜
            foreach (Transform child in decksPerant.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var generation in sortDeck) //���菇
            {
                foreach (var deta in characterData) //�J�[�h�f�[�^
                {
                    if (deta.generation == generation) //�J�[�h�f�[�^�̃J�[�h���菇�ƃ\�[�g�����f�b�L�̃J�[�h���菇����v������
                    {
                        match = deta;
                        break;
                    }
                }
                
                GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
                var decks = obj.GetComponent<DeckStatus>();

                //���������f�b�L�i�J�[�h�j�ɃJ�[�h�̏�����
                decks.characterName = match.characterName;
                decks.hp = match.hp;
                decks.cost = match.cost;
                decks.iD = match.id;
                decks.generation = num;

                num++;

                allDecks.Add(decks); //���������f�b�L�����X�g�ɒǉ�

                deckSort.isGeneration = false;
            }

        }
        else if (deckSort.isCost)
        {
            CharacterData match = null; //�f�[�^�ƃ}�b�`�������̂�����
            int num = 0; //����������

            allDecks.Clear(); //���������f�b�L���폜

            //���������J�[�h�I�u�W�F�N�g���폜
            foreach (Transform child in decksPerant.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var cost in sortDeck) //�R�X�g
            {
                foreach (var deta in characterData) //�J�[�h�f�[�^
                {
                    if (deta.cost == cost) //�J�[�h�f�[�^�̃J�[�h�R�X�g�ƃ\�[�g�����f�b�L�̃J�[�h�R�X�g����v������
                    {
                        match = deta;
                        break;
                    }
                }

                GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
                var decks = obj.GetComponent<DeckStatus>();

                //���������f�b�L�i�J�[�h�j�ɃJ�[�h�̏�����
                decks.characterName = match.characterName;
                decks.hp = match.hp;
                decks.cost = match.cost;
                decks.iD = match.id;
                decks.generation = num;

                num++;

                allDecks.Add(decks); //���������f�b�L�����X�g�ɒǉ�

                deckSort.isCost = false;
            }
        }
        else if (deckSort.isHp)
        {
            CharacterData match = null; //�f�[�^�ƃ}�b�`�������̂�����
            int num = 0; //����������

            allDecks.Clear(); //���������f�b�L���폜

            //���������J�[�h�I�u�W�F�N�g���폜
            foreach (Transform child in decksPerant.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var hp in sortDeck) //HP
            {
                foreach (var deta in characterData) //�J�[�h�f�[�^
                {
                    if (deta.hp == hp) //�J�[�h�f�[�^�̃J�[�hHP�ƃ\�[�g�����f�b�L�̃J�[�hHP����v������
                    {
                        match = deta;
                        break;
                    }
                }

                GameObject obj = Instantiate(deckPrefab, transform.position, Quaternion.identity, decksPerant.transform.transform);
                var decks = obj.GetComponent<DeckStatus>();

                //���������f�b�L�i�J�[�h�j�ɃJ�[�h�̏�����
                decks.characterName = match.characterName;
                decks.hp = match.hp;
                decks.cost = match.cost;
                decks.iD = match.id;
                decks.generation = num;

                num++;

                allDecks.Add(decks); //���������f�b�L�����X�g�ɒǉ�

                deckSort.isHp = false;
            }
        }
        
    }
}
