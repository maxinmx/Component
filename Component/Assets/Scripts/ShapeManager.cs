using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ShapeManager : MonoBehaviour {

    public float speed = 5;

    private Transform objTransform;
    private int ScaleX;
    private int ScaleY;
    private int ScaleZ;

    // Use this for initialization
    void Start () {
        objTransform = GameObject.FindWithTag("NotAnimate").transform;
     /*   obj = GameObject.Find("Sphere");
        objTransform = obj.transform;
        Analyze();*/
    }

    public void ChangeShape(int x,int y,int z)
    {
        objTransform.localScale = new Vector3(x, y, z);
        Debug.Log(objTransform.localScale);
        transform.localScale = Vector3.MoveTowards(transform.localScale, objTransform.localScale, speed * Time.deltaTime);
    }

    //返回扩大倍数x，y，z数值
    public int getScaleX(string[] scale)
    {
        return int.Parse(scale.GetValue(0).ToString());
    }
    public int getScaleY(string[] scale)
    {
        return int.Parse(scale.GetValue(1).ToString());
    }
    public int getScaleZ(string[] scale)
    {
        return int.Parse(scale.GetValue(2).ToString());
    }

    //设置x,y,z的值，并调用函数改变其大小
    public void setScale(string[] shape)
    {
        ScaleX = getScaleX(shape);
        ScaleY = getScaleY(shape);
        ScaleZ = getScaleZ(shape);
        ChangeShape(ScaleX, ScaleY, ScaleZ);
    }


    //    public string receiveInfo = "<Test id='NotAnimate' operation='Shape' value='(2,3,4)'></Test>";
    /*
    public string receiveInfo = "<Test id='Cube1' operation='大小' value='(2,3,4)'></Test>";
    public string receiveInfo1 = "<Test id='Cube1' operation='位置' value='(2,3,4)'></Test>";
    private string execId;//与输入信息匹配的正则表达式确定id值
    private string execOp;//确定操作
    private string execValue;//确定操作的值
    private string execBrackets;//匹配括号
    private string Id;//匹配后的id值
    private string Op;//匹配后的操作
    private string Value;//匹配后的值
    private string[] param;*/
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
        param = Regex.Split(Value, ",");
    }
    */
    // Update is called once per frame
    void Update()
    {
        /*   if (Input.GetMouseButtonDown(0))
           {
               changeShape(param);
           }*/
    }
}
