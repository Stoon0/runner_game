using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSneakPlayer : MonoBehaviour, IPointerDownHandler
{

    private GameObject player;
    public void OnPointerDown(PointerEventData eventData)
    {
        player = GameObject.Find("Player_Man");
        Debug.Log(player);
    }
}
