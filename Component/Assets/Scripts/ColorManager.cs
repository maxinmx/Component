using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ColorManager : MonoBehaviour {
    /*
    public string receiveInfo = "<Test id='Cube1' operation='颜色' value='(0,0,0)'></Test>";
    */
    private GameObject obj;
    private Renderer render;
    private Texture texture;
    private int ColorR;
    private int ColorG;
    private int ColorB;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.FindWithTag("NotAnimate");
        //获取该游戏对象的渲染器  
        render = obj.GetComponent<Renderer>();
        render.material.mainTexture = texture;
    //    Analyze();
    }
    void Update()
    {
 //       ChangeColor(rgb);
    }
    /*
     将上面的RGB付给下面的值
         */
    //返回RGB数值
    public int getColorR(string[] RGB)
    {
        return int.Parse(RGB.GetValue(0).ToString());
    }
    public int getColorG(string[] RGB)
    {
        return int.Parse(RGB.GetValue(1).ToString());
    }
    public int getColorB(string[] RGB)
    {
        return int.Parse(RGB.GetValue(2).ToString());
    }

    //给球体赋值
    public void ChangeColor(int R,int G,int B)
    {
        render.material.color = new Color(R,G,B);
    }

    //设置R,G,B的值，并调用函数改变其颜色
    public void setColor(string[] rgb)
    {
        ColorR = getColorR(rgb);
        ColorG = getColorG(rgb);
        ColorB = getColorB(rgb);
        ChangeColor(ColorR, ColorG, ColorB);
    }

    /*
    public void ChangeColor(string[] RGB)
    {
        render.material.color = new Color(int.Parse(RGB.GetValue(0).ToString()), int.Parse(RGB.GetValue(1).ToString()), int.Parse(RGB.GetValue(2).ToString()));
    }*/
    /*
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
    }*/


}
