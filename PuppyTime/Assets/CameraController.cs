using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int _timeDelayUntilCameraMove = 30;

    private DateTime _startTime;
    private bool _missionAccomplished;
    private GameObject _trex;

    // Use this for initialization
    void Start ()
    {
        _trex = GameObject.Find("t-rex");
        _trex.SetActive(false);
        _startTime = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    var currentTime = DateTime.Now;
	    var elapsedTime = (currentTime - _startTime).TotalSeconds;
        
	    if (elapsedTime > _timeDelayUntilCameraMove && !_missionAccomplished)
	    {
	        _missionAccomplished = true;

	        //make the trex appear  
	        _trex.SetActive(true);

	        var trexAnimator = _trex.GetComponent<Animator>();
            trexAnimator.SetTrigger("go");
        }

    }
}
