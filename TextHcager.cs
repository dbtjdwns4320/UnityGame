using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextHcager : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    public int resource;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Stone stone = GameObject.Find("Stone").GetComponent<Stone>();
        resource = stone.steps;

      
        if (!stone.flag)
        {
            if (resource == 0)
            {
                resourceText.text = ' '.ToString();
            }
            else
                resourceText.text = "DICE : " + resource.ToString();
        }
       
    }
}
