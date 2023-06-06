using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons :MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    // Start is called before the first frame update
   
    public bool isOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
        isOver = false;
    }
}
