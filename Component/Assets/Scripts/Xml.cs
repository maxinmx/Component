using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Text.RegularExpressions;

public class Xml : MonoBehaviour {
    public string receiveInfo = "<Test id='1'>播放</Test>";

    private string execId;//与输入信息匹配的正则表达式确定id值
    private string execInfo;//确定信息值
    private string Id;//匹配后的id值
    private string Info;//匹配后的信息值

    private Animation mAnimation;
    // Use this for initialization
    void Start () {
        mAnimation = GameObject.Find("Cube").GetComponent<Animator>().GetComponent<Animation>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Analyze()
    {
        execId = @"<.*\sid='(.*)'>.*<.*>";
        execInfo =@">(.*)</";
        Id = Regex.Match(receiveInfo, execId).Groups[1].Value;
        Info = Regex.Match(receiveInfo, execInfo).Groups[1].Value;





    }
}
