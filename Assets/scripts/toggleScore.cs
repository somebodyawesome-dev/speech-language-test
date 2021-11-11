using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleScore : MonoBehaviour
{
    public GameObject[] images;
    private Toggle[] toggles;
    public int score = 1;
    public int scoreDesc=4;
    public GameObject[] descriptions;
    // Start is called before the first frame update
    private void Awake()
    {

        
    }
    public int getScoreOfToggles()
    {
        int result = 0;
        foreach(var image in images)
        {
            toggles = image.GetComponentsInChildren<Toggle>();
            foreach (var toggle in toggles)
            {
                if (toggle.isOn) result += score;
            }
        }
        
        return result;
    }
    public int getScoreOfDesc()
    {
        int result = 0;
        foreach(var desc in descriptions)
        {
            toggles = desc.GetComponentsInChildren<Toggle>();
            if (toggles[3].isOn)
            {
                result += scoreDesc;
            }
            else
            {
                if (toggles[2].isOn)
                {
                    result += scoreDesc - 2;
                }
                else
                {
                    if (toggles[1].isOn)
                    {
                        result += scoreDesc - 3;
                    }
                    else
                    {
                        if (toggles[0].isOn)
                        {
                            //result += scoreDesc - 3;
                        }
                    }
                }
            }

        }
        return result;
    }
}
