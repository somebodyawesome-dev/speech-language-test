using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControler : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float interval;
    [SerializeField] private float timer;
    [SerializeField] private float intensity;
    [SerializeField] private int randomColorIndex;
    [SerializeField] Color[] toColor;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        randomColorIndex = Random.Range(0, toColor.Length);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (timer >= interval)
        {
            // material.SetColor("_Color", Color.Lerp(material.GetColor("_Color"), toColor[Random.Range(0,toColor.Length)]*intensity, timer/interval));
            randomColorIndex = Random.Range(0, toColor.Length);
            timer = 0;
        }
        else
        {
            timer += Time.fixedDeltaTime;
            material.SetColor("_Color", Color.Lerp(material.GetColor("_Color"), toColor[randomColorIndex] * intensity, timer / interval));
        }
    }
}
