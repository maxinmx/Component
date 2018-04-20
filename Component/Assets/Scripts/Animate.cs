using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Animate : MonoBehaviour {
    public Animation mAnimation;
    public string receiveInfo = "<Test id='Cube1' operation='动画' value='play'></Test>";

    private string execId;//与输入信息匹配的正则表达式确定id值
    private string execOp;//确定操作
    private string execValue;//确定操作的值
    private string Id;//匹配后的id值
    private string Op;//匹配后的操作
    private string Value;//匹配后的值
    private AnimationClip aniClip;

    // Use this for initialization  
    void Start()
    {
        GameObject a = GameObject.Find("Cube");
        mAnimation = a.GetComponent<Animation>();
        Analyze();
    }


    // Update is called once per frame  */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Result(Id, Value);
        }
    }

    //得出id号和操作的名称及操作值
    public void Analyze()
    {
        execId = @"<.*\sid='(.*)'\soperation.*>.*<.*>";
        execOp = @"<.*\soperation='(.*)'\svalue.*>.*<.*>";
        execValue = @"<.*\svalue='(.*)'>.*<.*>";
        Id = Regex.Match(receiveInfo, execId).Groups[1].Value;
        Op = Regex.Match(receiveInfo, execOp).Groups[1].Value;
        Value = Regex.Match(receiveInfo, execValue).Groups[1].Value;
    }

    //判断操作名称以及将会执行的操作
    public void Result(string id,string value)
    {
        if (value == "play")
        {
            setAnimationClipName(id);
            mAnimation.Play();
        }
        else
        {
            setAnimationClipName(id);
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
}
