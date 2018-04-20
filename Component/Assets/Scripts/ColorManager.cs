using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ColorManager : MonoBehaviour {

    public string receiveInfo = "<Test id='Cube1' operation='颜色' value='(0,0,0)'></Test>";

    private GameObject obj;
    private Renderer render;
    private Texture texture;

    private string execId;//与输入信息匹配的正则表达式确定id值
    private string execOp;//确定操作
    private string execValue;//确定操作的值
    private string execBrackets;//匹配括号
    private string Id;//匹配后的id值
    private string Op;//匹配后的操作
    private string Value;//匹配后的值
    private string[] rgb;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("Sphere");
        //获取该游戏对象的渲染器  
        render = obj.GetComponent<Renderer>();
        render.material.mainTexture = texture;
        Analyze();
    }
    void Update()
    {
        ChangeColor(rgb);
    }
    public void Analyze()
    {
        execId = @"<.*\sid='(.*)'\soperation.*>.*<.*>";
        execOp = @"<.*\soperation='(.*)'\svalue.*>.*<.*>";
        execValue = @"<.*\svalue='(.*)'>.*<.*>";
        execBrackets = @"\((.*)\)";
        Id = Regex.Match(receiveInfo, execId).Groups[1].Value;
        Op = Regex.Match(receiveInfo, execOp).Groups[1].Value;
        Value = Regex.Match(receiveInfo, execValue).Groups[1].Value;
        Value = Regex.Match(Value, execBrackets).Groups[1].Value;
        rgb = Regex.Split(Value, ",");
    }
    public void ChangeColor(string[] RGB)
    {
        render.material.color = new Color(int.Parse(RGB.GetValue(0).ToString()), int.Parse(RGB.GetValue(1).ToString()), int.Parse(RGB.GetValue(2).ToString()));

    }

}
