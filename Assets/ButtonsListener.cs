using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsListener : MonoBehaviour
{
    public Astronaut astronaut;

    public Button movebtn;

    public void setMoveButtonListener(){
        EventTrigger trigger = movebtn.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);

        //movebtn.onClick.AddListener(astronaut.move);
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        astronaut.move();
    }
}
