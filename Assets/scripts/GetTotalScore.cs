using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTotalScore : MonoBehaviour
{
    public DragAndDrop[] drags;
    public ImagetoConnect[] images;
    public toggleScore[] toggle;
    public KidData kidData;
    // Start is called before the first frame update
    void Start()
    {
        drags = (DragAndDrop[])Resources.FindObjectsOfTypeAll(typeof(DragAndDrop));
        images = (ImagetoConnect[])Resources.FindObjectsOfTypeAll(typeof(ImagetoConnect));
        toggle = (toggleScore[])Resources.FindObjectsOfTypeAll(typeof(toggleScore));
    }

    
    // Update is called once per frame
    public void saveTotalScore()
    {

        
        kidData.dragScore = getDragScore();
        kidData.matchingScore = getMatchingScore();
        kidData.nameingScore = getToggleScore();
        kidData.descScore = getDescriptionScore();
        kidData.addKid();


    }


    public int getTotalScore()
    {
        
        return getDragScore() + getMatchingScore() + getToggleScore() + getDescriptionScore();
    }

    public int getDragScore()
    {
        int result = 0;
        foreach (var drag in drags)
        {
            result += drag.getScore();
        }
        return result;
    }
    public int getMatchingScore()
    {
        int result = 0;
        foreach (var image in images)
        {
            result += image.getScore();
        }
        return result;
    }
    public int getToggleScore()
    {
        int result = 0;
        foreach (var togg in toggle)
        {
            result += togg.getScoreOfToggles();
         //   result += togg.getScoreOfDesc();
        }
        return result;
    }
    public int getDescriptionScore()
    {
        int result = 0;
        foreach (var togg in toggle)
        {
          //  result += togg.getScoreOfToggles();
               result += togg.getScoreOfDesc();
        }
        return result;
    }
}
