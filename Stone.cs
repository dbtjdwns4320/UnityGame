using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stone : MonoBehaviour
{
    public Route currentRoute;
    public int routePosition;  
    public bool flag;
    public int point;
    public int steps;
    public int audio_flag;
    public bool cur_moving;
    int die_flag;
    bool isMoving;
   
  
    void Start()
    {
        flag = true;
        point = -1;
        die_flag = 0;
        cur_moving = true;
    }
    void Update()
    {
        if (flag && cur_moving)
        {        
            if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
            {
                flag = false;
                steps = Random.Range(1, 7);
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

        while (steps > 0)
        {
            if (routePosition == 0)  //round Á¡¼ö ¿Ã¸®±â
            {
                if(die_flag == 1)    // die³ëµå ¹â¾ÒÀ»‹š´Â Á¡¼ö ¾È¿Ã¸²
                {
                    die_flag = 0;
                }
                else
                    point++;
            }
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            //routePosition++;
        }

       

        if (routePosition == 16) // die ¹â¾ÒÀ»‹š
        {
            routePosition = 0;
            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos)) { yield return null; }
            die_flag = 1;
        }

        else if(routePosition == 6 || routePosition == 9 || routePosition == 13 || routePosition == 19) // ·ê·¿
        {

            Stone_2 data_cur = GameObject.Find("Stone_2").GetComponent<Stone_2>();
            data_cur.cur_moving = false;
            CameraManager camera_data = GameObject.Find("CameraManager").GetComponent<CameraManager>();
            MainCamera Main_audio = GameObject.Find("MainCamera").GetComponent<MainCamera>();
            SubCamera_1 Sub_audio_1 = GameObject.Find("SubCamera_1").GetComponent<SubCamera_1>();
            Main_audio.audioSource.Stop();
            Sub_audio_1.audioSource.Play();
            audio_flag = 1;         
            camera_data.maincamera.enabled = false;
            camera_data.subcamera_1.enabled = true;
            camera_data.subcamera_2.enabled = false;
            
        }

        isMoving = false;
        Stone_2 data = GameObject.Find("Stone_2").GetComponent<Stone_2>();
        data.flag_2 = true;
    }
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
