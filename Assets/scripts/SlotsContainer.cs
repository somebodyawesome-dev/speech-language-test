using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsContainer : MonoBehaviour,IDropHandler
{
    [SerializeField] private RectTransform[] slots;
    [SerializeField] private int counter;
    [SerializeField] private GameObject[] images;
    private void Awake()
    {
        counter = 0;
        images = new GameObject[slots.Length];
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (counter < slots.Length && eventData.pointerDrag)
        {
            
            GameObject targetedImage = eventData.pointerDrag;
            RectTransform rect = targetedImage.GetComponent<RectTransform>();
            float maxWidthHeight = (slots[counter].sizeDelta.x > slots[counter].sizeDelta.y) ? slots[counter].sizeDelta.x : slots[counter].sizeDelta.y;

            float slotedScale = (rect.sizeDelta.x > rect.sizeDelta.y) ? maxWidthHeight / rect.sizeDelta.x : maxWidthHeight / rect.sizeDelta.y;
            rect.anchoredPosition = slots[counter].anchoredPosition + GetComponent<RectTransform>().anchoredPosition;

            images[counter] = targetedImage;
            targetedImage.GetComponent<DragAndDrop>().slotPlacedIn = counter++;
            targetedImage.GetComponent<DragAndDrop>().slotContainer = this.gameObject;
            
            rect.sizeDelta = new Vector2(slotedScale*rect.sizeDelta.x,  slotedScale*rect.sizeDelta.y);
            rect.eulerAngles = GetComponent<RectTransform>().eulerAngles;

        }
        else
        {
            if (eventData.pointerDrag) {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<DragAndDrop>().originalPostion;
            }
        }
    }
    public void deleteSlot(int slotIndex)
    {
        if (slotIndex < slots.Length)
        {
            images[slotIndex] = (slotIndex + 1 == slots.Length) ? null : images[counter-1];
            
            if (images[slotIndex])
            {
                images[slotIndex].GetComponent<RectTransform>().anchoredPosition = slots[slotIndex].anchoredPosition + GetComponent<RectTransform>().anchoredPosition;
                images[slotIndex].GetComponent<DragAndDrop>().slotPlacedIn = slotIndex;
                images[slotIndex].GetComponent<DragAndDrop>().slotContainer = this.gameObject;
            }
            counter--;

        }
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
