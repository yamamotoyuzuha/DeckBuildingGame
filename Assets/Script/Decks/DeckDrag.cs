using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckDrag : MonoBehaviour, IDragHandler, IDropHandler
{
    private DeckGeneration deckGeneration;
    
    void Start()
    {
        deckGeneration = FindObjectOfType<DeckGeneration>();
    }
    
    public void OnDrag(PointerEventData pointerEventData)
    {
        transform.position = pointerEventData.position;

        //�h���b�O���Ă���f�b�L���f�b�L���X�g����폜
        deckGeneration.allDecks.Remove(this.GetComponent<DeckStatus>());
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        //�L�����o�X�ɂ��Ȃ��ƃf�b�L���ړ�������ۂɁA�f�b�L���X�g���l�߂��ĕ��΂Ȃ��Ȃ邽��
        gameObject.transform.SetParent(deckGeneration.parent.transform); //�e�I�u�W�F�N�g��canvas�ɕύX

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        foreach(var hit in results)
        {
            if (hit.gameObject.CompareTag("SetDeck"))
            {
                transform.position = hit.gameObject.transform.position;
                Debug.Log("�f�b�L���Z�b�g���ꂽ��");

                //�R�X�g�𑝉�������
                int dropDeckCost = this.gameObject.GetComponent<DeckStatus>().cost;
                deckGeneration.TotalCostAdd(dropDeckCost);
            }
            else if (hit.gameObject.CompareTag("RemoveDeck"))
            {
                gameObject.transform.SetParent(deckGeneration.decksPerant.transform); //���̐e�I�u�W�F�N�g�ɕύX���AGridLayoutGroup�Ő���
                Debug.Log("�f�b�L��߂�����");

                //�h���b�O���Ă����f�b�L���f�b�L���X�g�ɒǉ�
                deckGeneration.allDecks.Add(this.GetComponent<DeckStatus>());

                if (deckGeneration.totalCost < 0) return; //�f�b�L���Z�b�g���Ă��Ȃ��ꍇ
                //�R�X�g�����Z
                int dropDeckCost = this.gameObject.GetComponent<DeckStatus>().cost;
                deckGeneration.TotalCostSubtraction(dropDeckCost);
            }
            else if(hit.gameObject.CompareTag("CanNotPut")) //�f�b�L���u���Ȃ��ꏊ
            {
                gameObject.transform.SetParent(deckGeneration.decksPerant.transform);
                Debug.Log("�����ɒu�����Ƃ͂ł��Ȃ�");

                deckGeneration.allDecks.Add(this.GetComponent<DeckStatus>());
            }
        }
    }
}
