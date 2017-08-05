using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayStructure : MonoBehaviour
{
    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManagerBehavior gameManager;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManagerBehavior>();
	}

    void Update()
    {
        if ( gameManager.isRecording )
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }
    private void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame " + frame);

        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("Current frame: " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}


/// <summary>
/// Structure for storing time, position and rotation!
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;
    
    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation )
    {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}