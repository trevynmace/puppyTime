using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PuppyActionRandomizer : MonoBehaviour
{
    private Animator animator;
    private DateTime _lastUpdateTime;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    var random = new Random();
	    var randomInt = random.Next(1, 7);
        
	    var currentTime = DateTime.Now;
	    var timeSinceLastAnimationWasSet = (currentTime - _lastUpdateTime).TotalSeconds;
	    if (timeSinceLastAnimationWasSet > 1)
	    {
	        switch (randomInt)
	        {
	            case 1:
	                SetAnimationBooleans("isPlaying");
	                break;
	            case 2:
	                SetAnimationBooleans("isCrying");
	                break;
	            case 3:
	                SetAnimationBooleans("isSleeping");
	                break;
	            case 4:
	                SetAnimationBooleans("isJumping");
	                break;
	            case 5:
	                SetAnimationBooleans("isSittingHigh");
	                break;
	            case 6:
	                SetAnimationBooleans("isPawing");
	                break;
	            default: break;
	        }
	    }
	}

    //TODO: how to get each dog to do one of the 6 animations independently?
    private void SetAnimationBooleans(string boolToSetTrue)
    {
        _lastUpdateTime = DateTime.Now;

        animator.SetBool("isPlaying", false);
        animator.SetBool("isCrying", false);
        animator.SetBool("isSleeping", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isSittingHigh", false);
        animator.SetBool("isPawing", false);

        animator.SetBool(boolToSetTrue, true);
    }
}
