using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int _timeDelayUntilCameraMove = 30;

    private DateTime _startTime;

    // Use this for initialization
    void Start ()
    {
	    _startTime = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    var currentTime = DateTime.Now;
	    var elapsedTime = (currentTime - _startTime).TotalSeconds;
        
	    if (elapsedTime > _timeDelayUntilCameraMove)
	    {
            //rotate player to dinosaur and have it roar
            transform.rotation = Quaternion.Euler(-20, 141, 0);
            var trexAnimator = GameObject.Find("t-rex").GetComponent<Animator>();
            trexAnimator.SetTrigger("go");
        }

    }
}
