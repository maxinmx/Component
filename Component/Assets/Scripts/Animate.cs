using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Animate : MonoBehaviour {

    public Animation mAnimation;
    private AnimationClip aniClip;

    /*
     * 对于每个加进来的动画来讲都需要给这个动画项目加标签Animate
     */
    // Use this for initialization  
    void Start()
    {
        GameObject a = GameObject.FindWithTag("Animate");
        mAnimation = a.GetComponent<Animation>();
    //    Analyze();
    }

    //判断操作名称以及将会执行的操作
    public void ChangeAnimate(string operation, string value)
    {
        if (value == "play")
        {
            setAnimationClipName(operation);
            mAnimation.Play();
        }
        else
        {
            setAnimationClipName(operation);
            mAnimation.Stop();
        }
    }


    //获取当前正在播放的动画片段的名称
    public string GetAnimationClipName()
    {
        foreach (AnimationState a in mAnimation)
        {
            if (mAnimation.IsPlaying(a.name))
            {
                return a.name;
            }
        }
        return null;
    }


    //设置想要播放的动画
    public void setAnimationClipName(string name)
    {
        if (GetAnimationClipName() != name)
        {
            aniClip = mAnimation.GetClip(name);
            Debug.Log(mAnimation.GetClip(name));
            mAnimation.clip = aniClip;
        }

    }
    void Update()
    {
        /* if (Input.GetMouseButtonDown(0))
         {
             changeAnimate(Id, Value);
         }*/
    }
}

//得出id号和操作的名称及操作值
/*  public void Analyze()
  {
      execId = @"<.*\sid='(.*)'\soperation.*>.*<.*>";
      execOp = @"<.*\soperation='(.*)'\svalue.*>.*<.*>";
      execValue = @"<.*\svalue='(.*)'>.*<.*>";
      Id = Regex.Match(receiveInfo, execId).Groups[1].Value;
      Op = Regex.Match(receiveInfo, execOp).Groups[1].Value;
      Value = Regex.Match(receiveInfo, execValue).Groups[1].Value;
  }*/
// Update is called once per frame  */


