using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;

public class build : MonoBehaviour {
    public Button connect;

    public GameObject gimbal1;
    public GameObject gimbal2;
    
    //use transform.getchild(0) to access the gimbals individual motors

    public GameObject connector1;
    public GameObject connector2;

    //So where do they start and where do they end and how do we put together the box
    //They originate at the 3D Builder of any sort or form they then are qeued into a random place on the build volume and then are assembled as per the list
    //and positions and rotations specified before


    GameObject[] allobjects;
    public static robotobject[] allrobotobjects = new robotobject[1];
    float[] options;
    string[] materials;
    Vector3[] positions;
    Vector3[] rotations;

    public void objectstart()
    {

        //the first thing to do is the change the origin of all gameobjects to the object itself (in a convinient way)
        //and then to place them where they are meant to start in the begining of the game
        allobjects = load.allobjects;
        allrobotobjects = new robotobject[allobjects.Length];
        options = load.options;
        materials = load.materials;
        positions = load.positions;
        rotations = load.rotations;

        Vector3[] startpositions = new Vector3[allobjects.Length];
        Vector3[] startrotation = new Vector3[allobjects.Length];

      /*  for(int i = 0; i < allobjects.Length;i++)
        {
            allrobotobjects[i].body = allobjects[i];
            allrobotobjects[i].material = materials[i];
            allrobotobjects[i].position = positions[i];
            allrobotobjects[i].rotation = rotations[i];
            allrobotobjects[i].numberobject = i;
        } */
        for (int i = 0; i < allobjects.Length;i++)
        {
            //these are the assumtions (will change later) 
            //plastics originate at the 3d printer -- then to be processed from start
            //steel makes up extrusion (only now) and has to be choped (or what ever) and orginates there -- then to be placed at start
            //wood makes up sheets (only now) and has to be cnced from the sheet and is placed at start (the leftover are placed out)
            //aluminum starts from block and has to be cnced and then is placed at start
            switch(materials[i])
            {
                case "pla":
                    startpositions[i] = new Vector3(-316, 140 + 30, 0);     //assuming on the 3d printer calc. where that really wil be
                    break;
                case "abs":
                    startpositions[i] = new Vector3(-316, 140 + 30, 0);
                    break;
                case "steel":
                    startpositions[i] = new Vector3(-609.6f, 50, 50);
                    startrotation[i] = new Vector3(0,0,90);
                    break;
                case "wood":
                    startpositions[i] = new Vector3(-1219 + 300,50+10,-1219 + 300);     //since this is going to be cnced for the biginning it will be cnced by us and put in later it will be cnced
                    //in there as well so just put flat in a corner
                    startrotation[i] = new Vector3(0,0,0);
                    break;
                case "aluminum":
                    startpositions[i] = new Vector3(-1219 + 300, 20, -1219 + 600);      //same as above it will be cnced outside but could be done inside as well
                    startrotation[i] = new Vector3();
                    break;
                default:
                    //
                    break;
            }
        }
        for (int i = 0; i < allobjects.Length; i++)
        {
            allobjects[i].transform.position = startpositions[i];
            allobjects[i].transform.rotation = Quaternion.Euler(startrotation[i]);
        }
        //now they have to be qeued in and placed and then generate list and then assemble (instructions only, we send later)
    }

    public GameObject[] nodepart = new GameObject[4+2+1+1];
    public int[] assemblylist()
    {
        //for now only otherwise is was done already upthere
        allobjects = load.allobjects;   
        int[] order = new int[allobjects.Length];
        for(int i = 0; i < 8;i++)
        {
            nodepart[i] = new GameObject();
            nodepart[i].name = "part" + i.ToString();
        }
        //so instead we start off by breaking up any system (even a prime one) into parts like we would anywhere else
        //finally we look from inside outside to each specific part in instruction and off of this we develop a part list then of course we will need
        //to do many more details as well

        //we go manually then we think
        //node1
        //four of the sides corner bolt extrusion corner
        //this is the first part of node1
        order[0] = 1;
        order[1] = 59;
        order[2] = 17;
        order[3] = 3;
        for(int i = 0; i < 4; i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[0].transform);
        }
        //second part
        order[4] = 0;
        order[5] = 58;
        order[6] = 16;
        order[7] = 2;
        for (int i = 4; i < 8; i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[1].transform);
        }
        //third part
        order[8] = 7;
        order[9] = 61;
        order[10] = 19;
        order[11] = 5;
        for (int i = 8; i < 12; i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[2].transform);
        }
        //fourth part
        order[12] = 6;
        order[13] = 60;
        order[14] = 18;
        order[15] = 4;
        for (int i = 12; i < 16; i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[3].transform);
        }
        //node2
        //node1 part1 and node1 part2 with a bolt extrusion between on both sides
        //first part
        nodepart[0].transform.SetParent(nodepart[4].transform);
        nodepart[1].transform.SetParent(nodepart[4].transform);
        order[16] = 54;
        order[17] = 12;
        order[18] = 56;
        order[19] = 14;
        for(int i = 16;i < 20;i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[4].transform);
        }
        //second part
        nodepart[2].transform.SetParent(nodepart[5].transform);
        nodepart[3].transform.SetParent(nodepart[5].transform);
        order[20] = 55;
        order[21] = 13;
        order[22] = 57;
        order[23] = 15;
        for(int i = 20;i<24;i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[5].transform);
        }
        //node3 
        //node2 part1 with a bolt extrusion and then node2 part2 for top
        //first part
        nodepart[4].transform.SetParent(nodepart[6].transform);
        nodepart[5].transform.SetParent(nodepart[6].transform);
        order[24] = 51;
        order[25] = 9;
        order[26] = 50;
        order[27] = 8;
        for(int i = 24; i < 28;i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[6].transform);
        }
        //second part
        order[28] = 10;
        order[29] = 52;
        order[30] = 11;
        order[31] = 53;
        for(int i = 28; i < 32;i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[6].transform);
        }
        //node4 here we just take node3 and add a sheet then add four nuts onto each order doesn't matter except mind the bottom sheet
        //last part
        nodepart[6].transform.SetParent(nodepart[7].transform);
        //all sheets and nuts after this in proper order
        order[32] = 47;
        for(int i = 0; i < 4;i++)
        {
            order[33 + i] = 40 + i;
        }
        order[37] = 49;
        for(int i = 0; i < 4;i++)
        {
            order[38 + i] = 36 + i;
        }
        order[41] = 46;
        for(int i = 0; i < 4;i++)
        {
            order[42 + i] = 33 + i;
        }
        order[45] = 48;
        for(int i = 0; i < 4;i++)
        {
            order[46 + i] = 30 + i;
        }
        order[49] = 44;
        for(int i = 0; i < 4;i++)
        {
            order[50 + i] = 27+i;
        }
        order[53] = 45;
        for(int i = 0;i < 4;i++)
        {
            order[53 + i] = 24+i;
        }

        for(int i = 32; i < 62; i++)
        {
            allobjects[order[i]].transform.SetParent(nodepart[7].transform);
        }

        //finally make full list including assembled parts
        //using simple distance for ordering


        return order;

    }

    public string generateinstructions()
    {
        //first the instructions are generated based on all of the above (the instructions here includes the qeues ect.)

        //then these are the instructions to be saved as a .3da and then sent directly to the arduino
        instruction newin = new instruction();
        string instructions = "";
        instructions = newin.movegimbal(0, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        return instructions;
    }

    public void SaveAndExecuteSlic3r(string savefolder)
    {
        //create the batch and run it
        savefolder = Path.GetDirectoryName(savefolder) + "/";
        using (System.IO.StreamWriter file =
new System.IO.StreamWriter(savefolder + "generategcode" + ".bat", false))
        {
            string[] files = System.IO.Directory.GetFiles(savefolder, "*.stl");
            string meshconvg = "";
            for (int i = 0; i < files.Length; i++)
            {
                meshconvg = meshconvg + @"Slic3r\slic3r-console.exe " + System.IO.Path.GetFileName(files[i]) + " --layer-height 0.2 " + Environment.NewLine;
            }
            string save = "cd " + savefolder +
                Environment.NewLine + meshconvg;
            file.Write(save);
            //save slic3r program (if on board computer use general directory
          //  System.IO.File.Copy(@"C:\Users\yfukesman\Downloads\projects\3D Robot\basic models (specifics)\1. box\box\box\Assets\Slic3r\", savefolder +
           //   "meshconv.exe", true);
        }
        System.Diagnostics.Process.Start(savefolder + "generategcode" + ".bat");
    }

    public void executebuild()
    {
        if(load.allobjects.Length > 2)
        {
            objectstart();
            assemblylist();
        }
        if (!(load.path == ""))
        {
            SaveAndExecuteSlic3r(load.path);
        }
        else
        {

        }
        connect.gameObject.SetActive(true);

        //finally generate instructions and save it as a .3da and then later allow user to upload to arduino (see later)

    }
}

//this is the robot object which we should be passing around instead of all individual arrays
public class robotobject
{
    public GameObject body = new GameObject();
    public string type = "";
    public string material = "";
    public Vector3 position = new Vector3();
    public Vector3 rotation = new Vector3();
    public int numberobject = 0;
    public float priority = 0.0f;
}
