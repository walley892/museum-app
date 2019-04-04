using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private static float angle;
    private static float height;
    private static float distance;
    private float radius =-11;

    // Start is called before the first frame update
    void Start()
    {
        angle = Camera.main.transform.eulerAngles.x;
        height = Camera.main.transform.position.y;
        distance = Camera.main.transform.position.z;
    }

    // Update is called once per frame
    void Update()  
    {

        //transform.position = new Vector3(Mathf.Sin(Time.time), -2.455f, Mathf.Cos(Time.time)) * radius; 

        transform.RotateAround(Vector3.zero, Vector3.up, 2 * Time.deltaTime);

        if (Camera.main.transform.eulerAngles.x < angle-.05 || Camera.main.transform.eulerAngles.x > angle+.05){
            transform.Rotate((angle-Camera.main.transform.eulerAngles.x)*Time.deltaTime, 0, 0);
        }

        if (Camera.main.transform.position.y < height-.05 || Camera.main.transform.position.y > height+.05){
            transform.Translate(0, (height-Camera.main.transform.position.y)*Time.deltaTime, 0);
        }

        if ((Camera.main.transform.localPosition.z > ((distance)*Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)+.05)) || (Camera.main.transform.localPosition.x > ((distance)*Math.Sin(Camera.main.transform.eulerAngles.y*Math.PI/180)+.05))){
            transform.Translate(0.0f,0.0f, (float)(-Math.Abs(Camera.main.transform.localPosition.z-(distance*Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)))) * Time.deltaTime, Space.Self);
        }

        if ((Camera.main.transform.localPosition.z < distance*Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)-.05) || (Camera.main.transform.localPosition.x < (distance)*Math.Sin(Camera.main.transform.eulerAngles.y*Math.PI/180)-.05)){
            transform.Translate(0.0f,0.0f, (float)(Math.Abs(Camera.main.transform.localPosition.z-(distance*Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)))) * Time.deltaTime, Space.Self);
        } 

        // if ((Camera.main.transform.position.z < distance*Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)-.05) || (Camera.main.transform.position.z > ((distance)*Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)+.05))){
        //     transform.Translate(0, 0, (distance*(float)Math.Cos(Camera.main.transform.eulerAngles.y*Math.PI/180)-Camera.main.transform.position.z)*Time.deltaTime/2);
        // }

        // if ((Camera.main.transform.position.x < (distance)*Math.Sin(Camera.main.transform.eulerAngles.y*Math.PI/180)-.05) || (Camera.main.transform.position.x > ((distance)*Math.Sin(Camera.main.transform.eulerAngles.y*Math.PI/180)+.05))){
        //     transform.Translate((distance*(float)Math.Sin(Camera.main.transform.eulerAngles.y*Math.PI/180)-Camera.main.transform.position.x)*Time.deltaTime/2,0,0);
        // }
    }

    // Next three functions give different parameters for the camera to rest at, allowing it to smoothly transition between positions
    public void CameraAngle(float ang){
        angle = ang;
    }

    public void CameraHeight(float h){
        height = h;
    }

    public void CameraDistance(float d){
        distance = d;
    }

}
