using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public KidData kidData;
    public GameObject buttonHolder;
    public GameObject forum;
    public TMP_InputField[] forumInput;
    public void setAgeAndGoToForum(int age)
    {
        kidData.init();
        kidData.age = age;
        buttonHolder.SetActive(false);
        forum.SetActive(true);
    }
    public void unSetAgeAndGoBack()
    {
        kidData.age = 0;
        buttonHolder.SetActive(true);
        kidData.init();
        foreach (var input in forumInput)
        {
            input.text = "";
        }

        forum.SetActive(false);
    }

    public void setFirstName(string str)
    {
        kidData.firstName = str;
    }
    public void setLastName(string str)
    {
        kidData.lastName = str;
    }
    public void setEtablissment(string str)
    {
        kidData.etablisment = str;
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
