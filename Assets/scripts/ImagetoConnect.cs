using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagetoConnect : MonoBehaviour
{
    public enum LINE {LEFT,RIGHT };
    public enum STATE {NOT_CONNECTED, CONNECTED};
    public  LINE line;
    public STATE state;
    public bool leftToMiddle;
    public int connectedTo;
    public int index;
    [SerializeField] private int correctImageIndex;
    public int score = 1;
    // Start is called before the first frame update
    void Start()
    {
        state = STATE.NOT_CONNECTED;
        connectedTo = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getScore()
    {
        
        return (state == STATE.CONNECTED && correctImageIndex == connectedTo) ? score : 0;
    }
}
