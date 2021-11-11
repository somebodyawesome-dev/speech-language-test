using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class ScoreBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GetTotalScore getTotalScore;
    [SerializeField]private int maxScore;
    [SerializeField]private int targetScore;
    [SerializeField]private float fellingSpeed;
    [SerializeField] Sprite years3Image;
    [SerializeField] Sprite years4Image;
    [SerializeField] Sprite years5Image;
    [SerializeField] int age;
    [SerializeField] KidData kidData;
    [SerializeField] Image fillImage;
    [SerializeField] float target;
    // Start is called before the first frame update
    void Start()
    {
        age = kidData.age;
        targetScore = getTotalScore.getTotalScore();
       
        setTargetValue(age);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (slider.value < target)
        {
            slider.value += fellingSpeed * Time.fixedDeltaTime;
            
        }
    }

    public float calculateTargetValue(ScoreBar.LEVEL level,float start,float end,float value)
    {
        float slope=0, cte=0,ystart=0,yend=0;
        
        if(level == LEVEL.BAD)
        {
            ystart = 0;
            yend = 50;
        }
        if(level == LEVEL.MEDIUM)
        {
            ystart = 50;
            yend = 100;
        }
        if(level == LEVEL.GOOD)
        {
            ystart = 100;
            yend = 150;
        }
        

        slope = (yend - ystart) / (end - start);
        cte = yend - slope * end;

        return slope*value+cte;
    }
    public enum LEVEL { BAD,MEDIUM,GOOD};
    void setTargetValue(int age)
    {
        float start = 0, end = 0;
        LEVEL level = LEVEL.BAD;
        if(age == 3)
        {
            if (targetScore < 58)
            {
                start = 0;
                end = 58;
                level = LEVEL.BAD;
                
            }
            else
            {
                if (targetScore < 117)
                {
                    start = 58;
                    end = 117;
                    level = LEVEL.MEDIUM;
                }
                else
                {
                    start = 117;
                    end = 154;
                    level = LEVEL.GOOD;
                }
            }
            
        }
        if (age == 4)
        {
            if (targetScore < 69)
            {
                start = 0;
                end = 69;
                level = LEVEL.BAD;
            }
            else
            {
                if (targetScore < 129)
                {
                    start = 69;
                    end = 129;
                    level = LEVEL.MEDIUM;
                }
                else
                {
                    start = 129;
                    end = 154;
                    level = LEVEL.GOOD;
                }
            }
            
        }
        if (age == 5)
        {
            if (targetScore < 110)
            {
                start = 0;
                end = 110;
                level = LEVEL.BAD;
            }
            else
            {
                if (targetScore < 139)
                {
                    start = 110;
                    end = 139;
                    level = LEVEL.MEDIUM;
                }
                else
                {
                    start = 139;
                    end = 154;
                    level = LEVEL.GOOD;
                }
            }
           
        }
        target = calculateTargetValue(level, start, end, targetScore);
    }
    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
    }

    void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");
        targetScore = getTotalScore.getTotalScore();
       
        slider.value = 0f;
        setTargetValue(age);
    }

    void incremeantBar(int newProgress)
    {
        
    }


}
