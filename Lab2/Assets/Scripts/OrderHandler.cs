using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrderHandler : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private Transform _sticker;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _sticker.SetAsLastSibling();
    }
}
