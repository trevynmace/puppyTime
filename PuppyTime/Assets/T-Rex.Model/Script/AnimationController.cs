using UnityEngine;
using System.Collections;
using UnityEditor.Animations;

public class AnimationController : MonoBehaviour 
{
	Animator animator;
    AudioSource audioSource;
    private string lastPlayedRoarName = "";
	
	void Start () 
	{
		animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			go ();
		}
        
		if (Input.GetMouseButtonDown (1)) 
		{
			back ();
		}

        CheckRoar();
	}

    private void CheckRoar()
    {
        var currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        var shout1 = "Center|Shout01";
        var shout2 = "Center|Shout02";
        var isShout1 = currentAnimatorStateInfo.IsName(shout1);
        var isShout2 = currentAnimatorStateInfo.IsName(shout2);
        var currentShoutName = isShout1 ? shout1 : shout2;
        var isShouting = isShout1 || isShout2;

        if (isShouting && !audioSource.isPlaying)
        {
            if (!lastPlayedRoarName.Equals(currentShoutName))
            {
                lastPlayedRoarName = currentShoutName;
                audioSource.Play();
            }
        }
    }

    public void go()
	{
        audioSource.Stop();
        animator.SetTrigger ("go");
    }

	public void back()
	{
        audioSource.Stop();
		animator.SetTrigger ("back");
    }
}