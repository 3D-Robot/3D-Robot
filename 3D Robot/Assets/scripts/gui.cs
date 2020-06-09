using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Windows.Forms;

public class gui : MonoBehaviour {

    public UnityEngine.UI.Button optionsbutton;
    public UnityEngine.UI.Button generatebutton;
    public UnityEngine.UI.Button send;
    public UnityEngine.UI.InputField sendtoarduino;
    public UnityEngine.UI.InputField savefilepath;
    public UnityEngine.UI.Text savefiletext;
    overviewgenerate og = new overviewgenerate();

    public GameObject gimbal1;
    public GameObject gimbal2;
    public GameObject boundingvolume;

    string arduinocommunicationtext = "";
    bool connected = false;

    // Use this for initialization
    public void Connect()
    {
        connect.ConnectToArduino();
        connected = true;
        arduinocommunicationtext = "connected!";
        send.gameObject.SetActive(true);
        sendtoarduino.gameObject.SetActive(true);
    }

    public void displayoptions()
    {
        overviewscripting o = new overviewscripting();
        string[] options = overviewscripting.options;
        float[] options1 = load.options;
        for (int i = 0; i < (UnityEngine.Screen.width - 250) / 180; i++)
        {
            for (int j = 0; j < options.Length / ((UnityEngine.Screen.width - 250) / 180); j++)
            {
                int fillin = 250;
                GUI.Label(new Rect(180 * i + fillin, j * 30 + 50, 100, 20),options[j * ((UnityEngine.Screen.width - 250) / 180) + i]);
                options[j * ((UnityEngine.Screen.width - 250) / 180) + i] = GUI.TextField(new Rect(180 * i + fillin, j * 30 + 50, 100, 20), options1[j * ((UnityEngine.Screen.width - 250) / 180) + i].ToString());
            }

        }
    }


    public string getpath()
    {
        string path = "";
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (savefilepath.text == null || savefilepath.text == "")
        {
            folderBrowserDialog.ShowDialog();
            path = folderBrowserDialog.SelectedPath + "\\";
        }
        else
        {
            path = savefilepath.text;
        }
        Debug.Log(path);
        return path;
    }

    public void GenerateAndExportFull()
    {

        string[] names = new string[overviewscripting.allrobotobjects.Length];
        //we use the name of the object later add a naming system that is useful to the user
        for (int i = 0; i < overviewscripting.allrobotobjects.Length; i++)
        {
            names[i] = overviewscripting.allrobotobjects[i].body.name + i.ToString();
        }
        og.saveallscads(og.createallscad(overviewscripting.allrobotobjects), names,getpath());
    }

    public void optionsexecute()
    {
        optionsbutton.gameObject.SetActive(false);
        generatebutton.gameObject.SetActive(true);
        savefilepath.gameObject.SetActive(true);
        savefiletext.gameObject.SetActive(true);
        og.createallscad(overviewscripting.allrobotobjects);
        //after generating the display we allow user to modify all options
        displayoptions();


    }

    public void generateexecute()
    {
        //when options is clicked we generate the default on the front end only
        //and display all of the options the user modifies the options as he wants
        //then when generate is clicked we generate the modified version and generate it completely into the .3dr which includes everything
        GenerateAndExportFull();
        generatebutton.gameObject.SetActive(false);
        savefilepath.gameObject.SetActive(false);
        savefiletext.gameObject.SetActive(false);
    }

    public void HideUnhideRobot()
    {
        //when clicked make the robot invisible when clicked again make it visable

        if(gimbal1.active == false)
        {
            gimbal1.SetActive(true);
            gimbal2.SetActive(true);
            boundingvolume.SetActive(true);
        }
        else if(gimbal1.active == true)
        {
            gimbal1.SetActive(false);
            gimbal2.SetActive(false);
            boundingvolume.SetActive(false);
        }
    }

    private void OnGUI()
    {
        if (connected)
        {
            try
            {
                arduinocommunicationtext = connect.sp.ReadLine();
            }
            catch (System.TimeoutException)
            {
            }
            GUI.Label(new Rect(10, 70, 150, 30), arduinocommunicationtext);
        }
    }

    public void SendToArduino()
    {
        connect.sp.WriteLine(sendtoarduino.text);
    }
}
