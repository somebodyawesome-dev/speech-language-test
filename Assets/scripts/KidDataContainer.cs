using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KidDataContainer 
{
    public int seq=0;
    public List<int> id = new List<int>();
    public List<string> firstNames=new List<string>();
    public List<string> lastNames =new List<string>();
    public List<string> etablissment= new List<string>();
    public List<int> dragScore= new List<int>();
    public List<int> matchingScore = new List<int>();
    public List<int> descScore = new List<int>();
    public List<int> nameingScore = new List<int>();
    public List<int> ages= new List<int>();
    
}
