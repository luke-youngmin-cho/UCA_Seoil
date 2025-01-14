using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEventTest : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"[{nameof(PointerEventTest)}] entered pointer.");
    }
}
