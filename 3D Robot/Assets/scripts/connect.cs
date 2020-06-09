using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class connect : MonoBehaviour {

    public static SerialPort sp = new SerialPort();
    public Button connectedbutton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ConnectToArduino()
    {
        sp.BaudRate = 14400;
        sp.PortName = @"//./" + "COM5";
        sp.ReadTimeout = 20;

        try
        {
            sp.Open();
        }
        catch (System.Exception)
        {

            throw;
        }

        //ensure good connection
            sp.Write("y");
        try
        {
            if (sp.ReadChar() == 'y')
            {
                GameObject.Find("connectbutton").GetComponentInChildren<Text>().text = "connected!";
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Handshake = Handshake.None;
                sp.ReadTimeout = 2;
                sp.WriteTimeout = 2;

            }
            else
            {
                GameObject.Find("connectbutton").GetComponentInChildren<Text>().text = "error connecting to arduino";
            }
        }

        catch (System.Exception)
        {

            throw;
        }
    }
}
