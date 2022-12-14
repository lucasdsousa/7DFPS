using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingSystem : MonoBehaviour
{
    public Camera PlayerCamera;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            PlayerCamera.fieldOfView = 40;
        }
        else
        {
            PlayerCamera.fieldOfView = 60;
        }
    }
}
