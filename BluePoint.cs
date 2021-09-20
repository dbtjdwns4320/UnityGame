using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BluePoint : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    public int resource;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
        resourceText.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        Stone_2 stone = GameObject.Find("Stone_2").GetComponent<Stone_2>();
        resource = stone.point_2;
        if (resource == -1)
        {
            resourceText.text = "Blue Point: 0";
        }
        else
            resourceText.text = "Blue Point: " + resource.ToString();
    }
}
