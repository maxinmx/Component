using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {
    public Animation mAnimation;

    // Use this for initialization  
    void Start()
    {
        GameObject a = GameObject.Find("Cube");
        mAnimation = a.GetComponent<Animator>().GetComponent<Animation>();
        Debug.Log(mAnimation);
        if (Input.GetMouseButtonDown(0))
        {
            if (mAnimation.isPlaying)
            {
                mAnimation.Stop();
            }
            else
            {
                mAnimation.Play();
            }
        }
    }


    // Update is called once per frame  */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mAnimation.isPlaying)
            {
                mAnimation.Stop();
            }
            else
            {
                mAnimation.Play();
            }
        }
    }

    
}
