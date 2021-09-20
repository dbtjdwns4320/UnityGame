using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rolette : MonoBehaviour
{
    float speed = 0;
    float temp;
    public int routePosition;
    public bool flag;
    public int point;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            temp = Random.RandomRange((float)0.95, (float)0.99);
            print(temp);
            this.speed = 10;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CameraManager camera_data = GameObject.Find("CameraManager").GetComponent<CameraManager>();
            MainCamera Main_audio = GameObject.Find("MainCamera").GetComponent<MainCamera>();
            SubCamera_1 Sub_audio_1 = GameObject.Find("SubCamera_1").GetComponent<SubCamera_1>();
            SubCamera_2 Sub_audio_2 = GameObject.Find("SubCamera_2").GetComponent<SubCamera_2>();
            Stone stone_data = GameObject.Find("Stone").GetComponent<Stone>();
            Stone_2 stone_data_2 = GameObject.Find("Stone_2").GetComponent<Stone_2>();
            camera_data.maincamera.enabled = true;
            camera_data.subcamera_1.enabled = false;
            camera_data.subcamera_2.enabled = false;

            if(stone_data.audio_flag == 1)
            {
                Sub_audio_1.audioSource.Stop();
                Sub_audio_2.audioSource.Stop();
                Main_audio.audioSource.Play();           
            }
            else
            {
                Sub_audio_1.audioSource.Stop();
                Sub_audio_2.audioSource.Stop();
                Main_audio.audioSource.Play();          
            }

            stone_data.cur_moving = true;
            stone_data_2.cur_moving = true;
        }
        transform.Rotate(0, 0, this.speed);

        this.speed *= temp;
    }
}
