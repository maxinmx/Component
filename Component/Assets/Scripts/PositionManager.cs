using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class PositionManager : MonoBehaviour {

    public float speed = 5;

    private Transform objTransform;
    private int PositionX;
    private int PositionY;
    private int PositionZ;

    // Use this for initialization
    void Start () {
        objTransform = GameObject.FindWithTag("NotAnimate").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangePosition(int x,int y,int z)
    {
        objTransform.position = new Vector3(x, y, z);
        Debug.Log(objTransform.position);
        transform.position = Vector3.MoveTowards(transform.position, objTransform.position, speed * Time.deltaTime);
    }
    //返回(x,y,z)数值
    public int getCoordinateX(string[] coordinate)
    {
        return int.Parse(coordinate.GetValue(0).ToString());
    }
    public int getCoordinateY(string[] coordinate)
    {
        return int.Parse(coordinate.GetValue(1).ToString());
    }
    public int getCoordinateZ(string[] coordinate)
    {
        return int.Parse(coordinate.GetValue(2).ToString());
    }

    //设置x,y,z的值，并调用函数改变其位置
    public void setCoordinate(string[] coordinate)
    {
        PositionX = getCoordinateX(coordinate);
        PositionY = getCoordinateY(coordinate);
        PositionZ = getCoordinateZ(coordinate);
        ChangePosition(PositionX, PositionY, PositionZ);
    }
}
