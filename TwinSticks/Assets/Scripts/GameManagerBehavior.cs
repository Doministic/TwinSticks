using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManagerBehavior : MonoBehaviour
{

    public bool isRecording;
	
	void Update ()
    {
        if( CrossPlatformInputManager.GetButton("Fire1") )
        { 
            isRecording = false;
        }
        else
        {
            isRecording = true;
        }
    }
}
