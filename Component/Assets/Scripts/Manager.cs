using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private string id;
    private string operation;
    private string value;
    private string[] param;
    // Use this for initialization
    void Start () {
        id=GetComponent<Xml>().getId();
        operation = GetComponent<Xml>().getOperation();
        value = GetComponent<Xml>().getValue();
        param = GetComponent<Xml>().getParameter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SelectNotAnimateOp(string operate, string[] param)
    {
        switch (operate)
        {
            case "Position":
                GetComponent<PositionManager>().setCoordinate(param);
                break;
            case "Shape":
                GetComponent<ShapeManager>().setScale(param);
                break;
            case "Color":
                GetComponent<ColorManager>().setColor(param);
                break;
            case "Text":
                break;
            default:
                Debug.Log("输入信息有误，请重新输入");
                break;
        }
    }

    public void SelectAnimateOp(string operate,string value)
    {
        GetComponent<Animate>().ChangeAnimate(operate,value);
    }

    //判断要改变的是否是动画，是|非动画分开做改变
    void IsAnimate(string id,string operate,string value,string[] param)
    {
        if(id == "NotAnimate")
        {
            SelectNotAnimateOp(operate, param);
        }
        else
        {
            SelectAnimateOp(operate, value);
        }
    }

    public void Change()
    {
        IsAnimate(id,operation,value,param);
    }


}
