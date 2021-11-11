using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragTrigger : MonoBehaviour, IEndDragHandler
{

    public void OnEndDrag(PointerEventData eventData)
    {
        ExecuteEvents.Execute<IEndDragHandler>(GameObject.FindObjectOfType<SelectionManger>().gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.endDragHandler);
        Debug.Log("drag ended");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
