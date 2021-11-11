using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector2 originalSize;
    public float slotedScale;
    public Vector2 originalPostion;
    public int slotPlacedIn;
    public GameObject slotContainer;
    public Vector3 originalRotation;
    public GameObject correctSlotContainer;
    public int score=1;
   
    [SerializeField] private CanvasGroup[] canvasGroups;
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalSize = rectTransform.sizeDelta;
        originalPostion = rectTransform.anchoredPosition;
        slotPlacedIn = -1;
        slotContainer = null;
        canvasGroups = transform.parent.GetComponentsInChildren<CanvasGroup>();
        slotedScale = (rectTransform.sizeDelta.x > rectTransform.sizeDelta.y) ? 80/rectTransform.sizeDelta.x  : 80/rectTransform.sizeDelta.y ;
        originalRotation = rectTransform.eulerAngles;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        rectTransform.sizeDelta = originalSize;
        rectTransform.eulerAngles = originalRotation;
        foreach(CanvasGroup can in canvasGroups)
        {
            can.blocksRaycasts = false;
            
        }

        if (slotContainer)
        {
            slotContainer.GetComponent<SlotsContainer>().deleteSlot(slotPlacedIn);
            slotPlacedIn = -1;
            slotContainer = null;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (CanvasGroup can in canvasGroups)
        {
            can.blocksRaycasts = true;
            
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public int getScore()
    {

        if (!correctSlotContainer && !slotContainer) return score;
        if (correctSlotContainer && slotContainer && slotContainer.GetInstanceID() == slotContainer.GetInstanceID()) return score;
        
        return 0;
    }
}
