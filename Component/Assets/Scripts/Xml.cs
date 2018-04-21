using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Text.RegularExpressions;

public class Xml : MonoBehaviour {

    /*从客户端接收到的信息
     * id 为项目的名称即对那个项目进行操作
     * operation 为这个项目执行什么样的操作
     * value 执行的操作值为多少
     * public string receiveInfo = "<Test id='NotAnimate' operation='Shape' value='(2,3,4)'></Test>";
     * public string receive = "<Test id='Animate' operation='Cube1' value='play'></Test>";
    */

    private string execId;//与输入信息匹配的正则表达式确定id值
    private string execOp;//确定操作
    private string execValue;//确定操作的值
    private string execBrackets;//匹配括号
    private string Id;//匹配后的id值
    private string Op;//匹配后的操作
    private string Value;//匹配后的值
    private string[] param;//匹配括号里的参数

    public void ExecAnalyze(string receiveInfo)
    {
        execId = @"<.*\sid='(.*)'\soperation.*>.*<.*>";
        execOp = @"<.*\soperation='(.*)'\svalue.*>.*<.*>";
        execValue = @"<.*\svalue='(.*)'>.*<.*>";
        execBrackets = @"\((.*)\)";
        Id = Regex.Match(receiveInfo, execId).Groups[1].Value;
        Op = Regex.Match(receiveInfo, execOp).Groups[1].Value;
        Value = Regex.Match(receiveInfo, execValue).Groups[1].Value;
        if(Regex.IsMatch(Value, execBrackets))
        {
            Value = Regex.Match(Value, execBrackets).Groups[1].Value;
            param = Regex.Split(Value, ",");
        }
    }


    /*
     向外传递的值
         */
    public string getId()
    {
        return Id;
    }
    public string getOperation()
    {
        return Op;
    }
    public string getValue()
    {
        return Value;
    }
    public string[] getParameter()
    {
        return param;
    }

}
