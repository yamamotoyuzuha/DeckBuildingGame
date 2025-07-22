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

        //ドラッグしているデッキをデッキリストから削除
        deckGeneration.allDecks.Remove(this.GetComponent<DeckStatus>());
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        //キャンバスにしないとデッキを移動させる際に、デッキリストが詰められて並ばなくなるため
        gameObject.transform.SetParent(deckGeneration.parent.transform); //親オブジェクトをcanvasに変更

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        foreach(var hit in results)
        {
            if (hit.gameObject.CompareTag("SetDeck"))
            {
                transform.position = hit.gameObject.transform.position;
                Debug.Log("デッキがセットされたよ");

                //コストを増加させる
                int dropDeckCost = this.gameObject.GetComponent<DeckStatus>().cost;
                deckGeneration.TotalCostAdd(dropDeckCost);
            }
            else if (hit.gameObject.CompareTag("RemoveDeck"))
            {
                gameObject.transform.SetParent(deckGeneration.decksPerant.transform); //元の親オブジェクトに変更し、GridLayoutGroupで整頓
                Debug.Log("デッキを戻したよ");

                //ドラッグしていたデッキをデッキリストに追加
                deckGeneration.allDecks.Add(this.GetComponent<DeckStatus>());

                if (deckGeneration.totalCost < 0) return; //デッキをセットしていない場合
                //コストを減算
                int dropDeckCost = this.gameObject.GetComponent<DeckStatus>().cost;
                deckGeneration.TotalCostSubtraction(dropDeckCost);
            }
            else if(hit.gameObject.CompareTag("CanNotPut")) //デッキが置けない場所
            {
                gameObject.transform.SetParent(deckGeneration.decksPerant.transform);
                Debug.Log("ここに置くことはできない");

                deckGeneration.allDecks.Add(this.GetComponent<DeckStatus>());
            }
        }
    }
}
