using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[CreateAssetMenu(fileName ="kidData",menuName ="scriptableObject/kidData")]
public class KidData : ScriptableObject
{
    public int id;
    public string firstName;
    public string lastName;
    public string etablisment;
    public int age;
   
    public int dragScore ;
    public int matchingScore;
    public int descScore ;
    public int nameingScore;

    public void init()
    {
        KidDataContainer dataContainer = loadKidData();
        id = dataContainer.seq;
        age = 0;
        firstName = "";
        lastName = "";
        etablisment = "";
        dragScore = 0;
        matchingScore = 0;
        descScore = 0;
        nameingScore = 0;
    }



    public void initSeqId()
    {
        KidDataContainer dataContainer = loadKidData();
        id = dataContainer.seq;
    }
    public void addKid()
    {
        KidDataContainer data;
       
        data = loadKidData();


        data.seq++;
        
        data.id.Add(id);
        data.firstNames.Add(firstName);
        data.lastNames.Add(lastName);
        data.ages.Add(age);
        
        data.etablissment.Add(etablisment);
        data.dragScore.Add(dragScore);
        data.matchingScore.Add(matchingScore);
        data.descScore.Add(descScore);
        data.nameingScore.Add(nameingScore);


        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "KidsData.wiow", FileMode.Create);
        binaryFormatter.Serialize(stream, data);
        stream.Close();
        init();


    }

    public KidDataContainer loadKidData()
    {
        
        if (!File.Exists(Application.persistentDataPath + "KidsData.wiow"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "KidsData.wiow", FileMode.Create);
            KidDataContainer data = new KidDataContainer();
            binaryFormatter.Serialize(stream, data);
            stream.Close();
            return data;
        }
        

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "KidsData.wiow", FileMode.Open);
        KidDataContainer dataContainer = new KidDataContainer();
        dataContainer = (KidDataContainer)bf.Deserialize(file);
        if (dataContainer.id==null)
        {
            dataContainer.id = new List<int>();
            for(int i = 0; i < dataContainer.firstNames.Count; i++)
            {
                dataContainer.id.Add(i);
            }
        }
        file.Close();

        return dataContainer;

    }
    public void setFirstName(string str)
    {
        firstName = str;
    }
    public void setLastName(string str)
    {
        lastName = str;
    }
    public void setEtablissment(string str)
    {
        etablisment = str;
    }
    public void initBD()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "KidsData.wiow", FileMode.Create);
        KidDataContainer data = new KidDataContainer();
        binaryFormatter.Serialize(stream, data);
        stream.Close();
        
    }
    public void affiche()
    {
        KidDataContainer aux = loadKidData();
        for(int i = 0; i < aux.firstNames.Count; i++)
        {
            Debug.Log(aux.firstNames[i]);
        }
    }
    public void deleteKid()
    {
        KidDataContainer aux = loadKidData();
        for(int i = 0; i < aux.id.Count; i++)
        {
            if(aux.id[i] == id)
            {
                aux.id.RemoveAt(i);
                aux.firstNames.RemoveAt(i);
                aux.lastNames.RemoveAt(i);
                aux.ages.RemoveAt(i);
                aux.etablissment.RemoveAt(i);
                aux.descScore.RemoveAt(i);
                aux.dragScore.RemoveAt(i);
                aux.nameingScore.RemoveAt(i);
                aux.matchingScore.RemoveAt(i);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(Application.persistentDataPath + "KidsData.wiow", FileMode.Create);
                binaryFormatter.Serialize(stream, aux);
                stream.Close();
                init();
                break;
            }
        }
    }
    public void updateKid()
    {
        KidDataContainer aux = loadKidData();
        for (int i = 0; i < aux.id.Count; i++)
        {
            if (aux.id[i] == id)
            {
                aux.id[i]=id;
                aux.firstNames[i]=firstName;
                aux.lastNames[i]= lastName;
                aux.ages[i]=age;
                aux.etablissment[i]=etablisment;
                aux.descScore[i]=descScore;
                aux.dragScore[i]=dragScore;
                aux.nameingScore[i]=nameingScore;
                aux.matchingScore[i]=matchingScore;
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(Application.persistentDataPath + "KidsData.wiow", FileMode.Create);
                binaryFormatter.Serialize(stream, aux);
                stream.Close();
                init();
                break;
            }
        }
    }
}
