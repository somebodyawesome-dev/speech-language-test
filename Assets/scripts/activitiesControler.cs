using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activitiesControler : MonoBehaviour
{
    [SerializeField] private int currentActivityIndex;
    [SerializeField] private List<GameObject> activities;
    [SerializeField] private int layer;
    [SerializeField] private Button nextButt;
    [SerializeField] private Button prevButt;
    // Start is called before the first frame update
    public void nextActivity()
    {


        currentActivityIndex++;
        
        activities[currentActivityIndex - 1].SetActive(false);
        activities[currentActivityIndex].SetActive(true);
        updateButtonState();
        
        
    }
    public void prevActivity()
    {
        
        activities[--currentActivityIndex].SetActive(true);
        activities[currentActivityIndex + 1].SetActive(false);
        updateButtonState();
    }
    void Start()
    {
        currentActivityIndex = 0;
        MenuItem[] children = GetComponentsInChildren<MenuItem>(true);
        activities = new List<GameObject>();
        for(int i = 0 ; i < children.Length; i++)
        {
            if(children[i].layer == layer)  activities.Add(children[i].gameObject);
        }
        if(activities.Count >= 1)
        {
            activities[0].SetActive(true);
            nextButt.gameObject.SetActive(true);
            
        }
        prevButt.gameObject.SetActive(false);

    }
    private void updateButtonState()
    {
        if (currentActivityIndex == activities.Count - 1)
        {
            nextButt.gameObject.SetActive(false);
        }
        else
        {
            if (currentActivityIndex == 0)
            {
                prevButt.gameObject.SetActive(false);
            }
            else
            {
                nextButt.gameObject.SetActive(true);
                prevButt.gameObject.SetActive(true);

            }
        }
    }
    

}
