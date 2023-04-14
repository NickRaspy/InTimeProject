using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerControl pc;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left") pc.direct = -1f;
        if (gameObject.name == "Right") pc.direct = 1f;
        if (gameObject.name == "Jump") pc.Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pc.direct = 0f;
    }
}
