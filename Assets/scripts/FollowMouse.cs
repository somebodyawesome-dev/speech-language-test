using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer ;
    // Start is called before the first frame update
    private void Awake()
    {

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.Find("CheckBox").position);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer.enabled )
        {
            lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Console.Write(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
