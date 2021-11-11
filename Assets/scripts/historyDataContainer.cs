using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class historyDataContainer : MonoBehaviour
{
    public int id;
    public string firstName;
    public string lastName;
    public string etablisment;
    public int age;

    public int dragScore;
    public int matchingScore;
    public int descScore;
    public int nameingScore;
    public GameObject panel;
    public KidData kidData;
    
    public void setPanel()
    {
        panel.SetActive(true);
        panel.transform.Find("container").GetComponent<setKidData>().historyData = this;
        panel.transform.Find("container").Find("id").Find("InputField (TMP)").GetComponent<TMP_InputField>().text = id.ToString();
        panel.transform.Find("container").Find("name").Find("InputField (TMP)").GetComponent<TMP_InputField>().text = firstName;
        panel.transform.Find("container").Find("prenom").Find("InputField (TMP)").GetComponent<TMP_InputField>().text =  lastName;
        panel.transform.Find("container").Find("etab").Find("InputField (TMP)").GetComponent<TMP_InputField>().text =  etablisment;
        panel.transform.Find("container").Find("age").Find("InputField (TMP)").GetComponent<TMP_InputField>().text = age.ToString();
        panel.transform.Find("container").Find("Catégorisation").Find("InputField (TMP)").GetComponent<TMP_InputField>().text =  dragScore+" / 49";
        panel.transform.Find("container").Find("Désignation").Find("InputField (TMP)").GetComponent<TMP_InputField>().text = matchingScore + " / 43";
        panel.transform.Find("container").Find("Description").Find("InputField (TMP)").GetComponent<TMP_InputField>().text = descScore + " / 16";
        panel.transform.Find("container").Find("Dénomination").Find("InputField (TMP)").GetComponent<TMP_InputField>().text = nameingScore + " / 46";
    }

    public void setKidData()
    {
        kidData.id = id;
        kidData.firstName= panel.transform.Find("container").Find("name").Find("InputField (TMP)").GetComponent<TMP_InputField>().text ;
        kidData.lastName= panel.transform.Find("container").Find("prenom").Find("InputField (TMP)").GetComponent<TMP_InputField>().text;
        kidData.etablisment= panel.transform.Find("container").Find("etab").Find("InputField (TMP)").GetComponent<TMP_InputField>().text ;
        kidData.age=Int32.Parse(panel.transform.Find("container").Find("age").Find("InputField (TMP)").GetComponent<TMP_InputField>().text) ;
        kidData.dragScore = dragScore;
        kidData.descScore = descScore;
        kidData.nameingScore = nameingScore;
        kidData.matchingScore = matchingScore;
    }
}
