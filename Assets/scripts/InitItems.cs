using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class InitItems : MonoBehaviour
{
    public KidData kidData;
    public GameObject scrollItem;
    public GameObject InfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    public void init()
    {

        KidDataContainer dataContainer = kidData.loadKidData();
       
        for (int i = 0; i < dataContainer.id.Count; i++)
        {
            GameObject obj = Instantiate(scrollItem);

            obj.transform.SetParent(GetComponent<Transform>(), false);

            historyDataContainer aux = obj.GetComponent<historyDataContainer>();
            aux.id = dataContainer.id[i];
            aux.firstName = dataContainer.firstNames[i];
            aux.lastName = dataContainer.lastNames[i];
            aux.etablisment = dataContainer.etablissment[i];
            aux.age = dataContainer.ages[i];
            aux.dragScore = dataContainer.dragScore[i];
            aux.matchingScore = dataContainer.matchingScore[i];
            aux.descScore = dataContainer.descScore[i];
            aux.nameingScore = dataContainer.nameingScore[i];
            aux.panel = InfoPanel;
            aux.kidData = kidData;


            obj.transform.Find("name").GetComponent<TextMeshProUGUI>().text = aux.firstName;

            obj.transform.Find("prenom").GetComponent<TextMeshProUGUI>().text = aux.lastName;

            obj.transform.Find("etab").GetComponent<TextMeshProUGUI>().text = aux.etablisment;

            obj.transform.Find("age").GetComponent<TextMeshProUGUI>().text = aux.age.ToString();

        }
    }

    
}
