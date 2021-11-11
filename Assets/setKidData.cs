using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class setKidData : MonoBehaviour
{
    
    public historyDataContainer historyData;
    public GameObject content;
    public void savekidData()
    {
        historyData.setKidData();
        historyData.kidData.updateKid();
        foreach(Transform tran in content.transform)
        {
            Destroy(tran.gameObject);
        }
        content.GetComponent<InitItems>().init();

    }
    public void deleteKidDate()
    {
        historyData.setKidData();
        historyData.kidData.deleteKid();
        foreach (Transform tran in content.transform)
        {
            Destroy(tran.gameObject);
        }
        content.GetComponent<InitItems>().init();
    }
}
