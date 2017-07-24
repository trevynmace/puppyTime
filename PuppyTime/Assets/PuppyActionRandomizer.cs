using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PuppyActionRandomizer : MonoBehaviour
{
    private DateTime _lastUpdateTime;
    private GameObject[] _puppies;

    // Use this for initialization
    void Start()
    {
        _puppies = GameObject.FindGameObjectsWithTag("Puppy");
    }

    // Update is called once per frame
    void Update()
    {
        var currentTime = DateTime.Now;
        var timeSinceLastAnimationWasSet = (currentTime - _lastUpdateTime).TotalSeconds;

        if (timeSinceLastAnimationWasSet > 1)
        {
            var random = new Random();

            foreach (var puppy in _puppies)
            {
                var randomInt = random.Next(1, 7);

                switch (randomInt)
                {
                    case 1:
                        SetAnimationBooleans("isPlaying", puppy.GetComponent<Animator>());
                        break;
                    case 2:
                        SetAnimationBooleans("isCrying", puppy.GetComponent<Animator>());
                        break;
                    case 3:
                        SetAnimationBooleans("isSleeping", puppy.GetComponent<Animator>());
                        break;
                    case 4:
                        SetAnimationBooleans("isJumping", puppy.GetComponent<Animator>());
                        break;
                    case 5:
                        SetAnimationBooleans("isSittingHigh", puppy.GetComponent<Animator>());
                        break;
                    case 6:
                        SetAnimationBooleans("isPawing", puppy.GetComponent<Animator>());
                        break;
                    default: break;
                }
            }
        }
    }
    
    private void SetAnimationBooleans(string boolToSetTrue, Animator puppyAnimator)
    {
        _lastUpdateTime = DateTime.Now;

        puppyAnimator.SetBool("isPlaying", false);
        puppyAnimator.SetBool("isCrying", false);
        puppyAnimator.SetBool("isSleeping", false);
        puppyAnimator.SetBool("isJumping", false);
        puppyAnimator.SetBool("isSittingHigh", false);
        puppyAnimator.SetBool("isPawing", false);

        puppyAnimator.SetBool(boolToSetTrue, true);
    }
}
