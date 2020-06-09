using UnityEngine;
using System.Collections;
using System;
using Parabox.STL;
using System.Windows.Forms;
using UnityEngine.UI;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using NCalc;

public class start : MonoBehaviour {

    public UnityEngine.UI.Button connect;
    public UnityEngine.UI.Button options;
    public UnityEngine.UI.Button generatebutton;
    public UnityEngine.UI.Text arduinocommunication;
    public UnityEngine.UI.InputField sendtoarduino;
    public UnityEngine.UI.Button send;
    public UnityEngine.UI.InputField savefolderinput;
    public UnityEngine.UI.Text savefoldertext;
    public GameObject modifypanel;
    public Vector3 bedsize = new Vector3(25.4f*12*4, 1,25.4f*12f*4f);
	// Use this for initialization
	void Start () {

        //here we build up the machine that will work with the objects then we can start to figure out how to approach the problem already we
        //can import the model so we need all the machine details that are relevent to be here

        //we need to model five walls for the bounding area
        //we need to model the two gimbals (fully operational)
        //we need to model the two connectors
        //we need to model the two long rods holding the gimbals
        //we need to model the two carriages 
        //more to come later 
        //make it all interact
        connect.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        generatebutton.gameObject.SetActive(false);
        modifypanel.gameObject.SetActive(false);
        send.gameObject.SetActive(false);
        sendtoarduino.gameObject.SetActive(false);
        savefolderinput.gameObject.SetActive(false);
        savefoldertext.gameObject.SetActive(false);
    }

    //test cases for debug only
    void Update () {
        if (Input.GetKeyDown("t"))
        {
            Expression e = new Expression("2 + 2*3");
            Debug.Log(e.Evaluate().ToString());
        }
	}
}
