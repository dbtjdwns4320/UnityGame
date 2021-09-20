using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedPoint : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    public int resource;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
        resourceText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Stone stone = GameObject.Find("Stone").GetComponent<Stone>();
        resource = stone.point;
        if(resource == -1)
        {
            resourceText.text = "Red Point: 0";
        }
        else
        resourceText.text = "Red Point: " + resource.ToString();
    }
}
