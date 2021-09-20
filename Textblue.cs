using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textblue : MonoBehaviour
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
        Stone_2 stone = GameObject.Find("Stone_2").GetComponent<Stone_2>();
        resource = stone.steps_2;


        if (!stone.flag_2)
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
