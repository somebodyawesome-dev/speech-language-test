using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    
    [SerializeField] private GetTotalScore getTotalScore;
    [SerializeField] private Text nameingScore;
    [SerializeField] private int nameing;
    [SerializeField] private Text matchingScore;
    [SerializeField] private int matching;
    [SerializeField] private Text dragScore;
    [SerializeField] private int drag;
    [SerializeField] private Text descriptionScore;
    [SerializeField] private int description;
    [SerializeField] private Text scoreText;
    [SerializeField] private int targetScore;
    // Start is called before the first frame update
    private void Awake()
    {
              nameing = getTotalScore.getToggleScore();
        matching = getTotalScore.getMatchingScore();
        drag = getTotalScore.getDragScore();
        description = getTotalScore.getDescriptionScore();
        targetScore = getTotalScore.getTotalScore();

    }
    void Start()
    {
         }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        nameing = getTotalScore.getToggleScore();
        matching = getTotalScore.getMatchingScore();
        drag = getTotalScore.getDragScore();
        description = getTotalScore.getDescriptionScore();
        targetScore = getTotalScore.getTotalScore();
        
        scoreText.text =   targetScore.ToString() + " /154";
        dragScore.text = "Catégorisation: " + drag.ToString() + " /49";
        matchingScore.text = "Désignation: "+ matching.ToString() + " /43";
        descriptionScore.text = "Description: " + description.ToString() + " /16";
        nameingScore.text = "Dénomination: " + nameing.ToString() + " /46";
        
    }

}
