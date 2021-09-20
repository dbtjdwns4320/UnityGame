using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_2 : MonoBehaviour
{
    public Route_2 currentRoute_2;
    int routePosition_2;
    public int steps_2;
    public bool flag_2;
    public int point_2;
    public int audio_flag;
    public bool cur_moving;
    int die_flag;
    bool isMoving;

   
    void Start()
    {
        flag_2 = false;
        point_2 = -1;
        die_flag = 0;
        cur_moving = true;
    }
    void Update()
    {
        if (flag_2 && cur_moving)
        { 
            if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
            {
                flag_2 = false;
                steps_2 = Random.Range(1, 7);
                StartCoroutine(Move());  
               
            }
        }
    }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps_2 > 0)
        {
            if (routePosition_2 == 0)
            {
                if(die_flag == 1)
                {
                    die_flag = 0;
                }
                else
                    point_2++;
            }

            routePosition_2++;
            routePosition_2 %= currentRoute_2.childNodeList_2.Count;

            Vector3 nextPos = currentRoute_2.childNodeList_2[routePosition_2].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps_2--;

        }
        
        if (routePosition_2 == 16)  // die ¹â¾ÒÀ»‹š
        {
            routePosition_2 = 0;
            Vector3 nextPos = currentRoute_2.childNodeList_2[routePosition_2].position;
            while (MoveToNextNode(nextPos)) { yield return null; }
            die_flag = 1;
        }

        else if (routePosition_2 == 6 || routePosition_2 == 9 || routePosition_2 == 13 || routePosition_2 == 19) // ·ê·¿
        {
            Stone data_cur = GameObject.Find("Stone").GetComponent<Stone>();
            data_cur.cur_moving = false;
            CameraManager camera_data = GameObject.Find("CameraManager").GetComponent<CameraManager>();
            MainCamera Main_audio = GameObject.Find("MainCamera").GetComponent<MainCamera>();
            SubCamera_2 Sub_audio_2 = GameObject.Find("SubCamera_2").GetComponent<SubCamera_2>();
            Main_audio.audioSource.Stop();
            Sub_audio_2.audioSource.Play();
            audio_flag = 2;        
            camera_data.maincamera.enabled = false;
            camera_data.subcamera_1.enabled = false;
            camera_data.subcamera_2.enabled = true;
        }

        isMoving = false;
        Stone data = GameObject.Find("Stone").GetComponent<Stone>();
        data.flag = true;
    }
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
