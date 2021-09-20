using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Camera maincamera;
    public Camera subcamera_1;
    public Camera subcamera_2;
    // Start is called before the first frame update
    void Start()
    {
        maincamera.enabled = true;
        subcamera_1.enabled = false;
        subcamera_2.enabled = false;
    }
}
