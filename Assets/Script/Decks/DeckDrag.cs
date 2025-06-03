using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckDrag : MonoBehaviour, IDragHandler, IDropHandler
{
    public void OnDrag(PointerEventData pointerEventData)
    {
        transform.position = pointerEventData.position;
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        foreach(var hit in results)
        {
            if (hit.gameObject.CompareTag("SetDeck"))
            {
                transform.position = hit.gameObject.transform.position;
                Debug.Log("デッキがセットされたよ");
            }
        }
    }
}
