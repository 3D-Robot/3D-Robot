using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Parabox.STL;

public class overviewscripting : MonoBehaviour
{

    public static robotobject[] allrobotobjects = new robotobject[1];
    public static GameObject[] allobjects = new GameObject[1];
    public static string[] options = new string[1];
    public static string[] materials = new string[1];
    public static Vector3[] positions = new Vector3[1];
    public static Vector3[] rotations = new Vector3[1];


    //here we do only the basic file type which includes reading the full file from script and loading it all with the options based off of the options
    //all of the scripting elements will be done on the file type by a different scripting system hence we write a file type like that which 
    //the computer would fully export if the user wants to put in something like a for or other then we will need to use a different system and just copy past the
    //lines of the file itself (all is underlined by the file and the text not the actual objects)
    //however we fully integrate the options here

    //we need to parse sections then lines to build up the overview which is just made up of primitives and imports (just as with box)
    //then we will move foward just as in box


    //these are the sections
    //state (we don't need to worry about this it is what brought us here in the first place), then options, 
    //then each block (which contains either a object or a script of objects)

    //these are the lines 
    //for, if, translate, rotate, position, rotation, material, object type (cube, cylinder, sphere), the object number is kept by us (of course)

    //take in the lines and then the options

    private int FindAllIndexof(string[] s, string target)
    {


        int[] v = s.Select((b, i) => b == target ? i : -1).Where(i => i != -1).ToArray();
        return v[0];
    }

    public int readposition = 0;
    public string[] readoverview(string file)
    {
        string fullfile = "";
        fullfile = file;
        string[] stringseparators = new string[] { Environment.NewLine };
        string[] cutstring = fullfile.Split(stringseparators, StringSplitOptions.None);
        for (int i = 0; i < cutstring.Length; i++)
        {
            if (cutstring[i].Contains("//"))
            {
                cutstring[i] = "";
            }
        }

        return cutstring;
    }

    public string[,] readoptions(string file)
    {
        string[] fullfile = readoverview(file);
        string[] readoptions;
        string[] optionsname;

        string target = "options:";
        int optionsbeginnning = FindAllIndexof(fullfile, target);
        int amountofoptions = 0;
        int i = optionsbeginnning;
        while (!(fullfile[i] == "}"))
        {
            i++;
        }
        amountofoptions = i - 2;
        readoptions = new string[amountofoptions];
        optionsname = new string[amountofoptions];
        i = optionsbeginnning;
        while (!(fullfile[i] == "}"))
        {
            if (!(fullfile[i + 1] == null))
            {
                if (fullfile[i + 1].Contains("catergory"))
                {

                }
                else
                {
                    readoptions[i - optionsbeginnning] = fullfile[i + 1];
                }
            }
            i++;
        }

        for (int j = 0; j < readoptions.Length; j++)
        {
            if (!(readoptions[j] == null))
            {
                if (readoptions[j].Contains("="))
                {
                    optionsname[j] = readoptions[j].Substring(0, readoptions[j].IndexOf('=') - 1);
                    readoptions[j] = readoptions[j].Substring((readoptions[j].IndexOf('=') + 1), readoptions[j].Length - (readoptions[j].IndexOf('=') + 1));
                }
            }
        }

        readposition = readoptions.Length + optionsbeginnning;
        string[,] returnoptions = new string[readoptions.Length, optionsname.Length];
        for (int k = 0; k < optionsname.Length; k++)
        {
            returnoptions[k, 0] = optionsname[k];
            returnoptions[k, 1] = readoptions[k];
        }
        return returnoptions;
    }

    public string editfile(string file, string[,] options)
    {
        // in here we implement the options by replacing the variables with the numbers
        // and we also implement the if statement skiping all that is false and including all that is true

        string returnfile = file;

        for (int i = 0; i < options.GetLength(0); i++)
        {
            if (!(options[i, 0] == null) && !(options[i, 1] == null))
            {
                returnfile = returnfile.Replace(options[i, 0], options[i, 1]);
            }
        }

        return returnfile;
    }

    public void ReadUnions()
    {
        //we need the spans of integers that will contain the unions (ignore the rest) then later put it in when it is needed 
        //the way that it is needed

    }

    public string[] readblock(string file)
    {

        //we read each block and return it to allow execution
        string[] fullfile = readoverview(file);
        string[] stringSeparators = new string[] { "object" };
        int numofblocks = file.Split(stringSeparators, StringSplitOptions.None).Length;
        string[] readblocks = new string[numofblocks];
        readblocks = file.Split(stringSeparators, StringSplitOptions.None);
        string[] returnblocks = new string[0];
        if (!(numofblocks == 0))
        {
            returnblocks = new string[numofblocks - 1];


            for (int i = 1; i < numofblocks; i++)
            {
                returnblocks[i - 1] = readblocks[i];
            }
        }

        return returnblocks;
    }

    public robotobject[] executeblock(string[] block)
    {
        //here we read the block executing any if, for, translate, rotate or other function and finally create a primitive per instructions
        robotobject[] blocksobjects = new robotobject[block.Length];

        for (int i = 0; i < block.Length; i++)
        {
            if (block[i] == "union" || block[i] == "union start" || block[i] == "union end")
            {
            }
        }

        //if a object is in the union list then we combine all of the objects together i.e. they are no longer seperate objects 
        //but in the front end they are still individual in the back end they are all part of a union
        //when looping through just a simple if statement should get them out 
        //it's not the best way but for now what else should we do for later we should get better
        for (int i = 0; i < blocksobjects.Length; i++)
        {
            blocksobjects[i] = new robotobject();
        }

        for (int i = 0; i < blocksobjects.Length; i++)
        {
            string[] stringSeparators = new string[] { Environment.NewLine };
            string[] blocklines = block[i].Split(stringSeparators, StringSplitOptions.None);

            //get object type and display it on the screen
            switch (blocklines[4].Substring(0, 4))
            {
                case "cube":
                    blocksobjects[i].body = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    blocksobjects[i].type = "cube";
                    break;
                case "cyli":
                    blocksobjects[i].body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    blocksobjects[i].type = "cylinder";
                    break;
                case "sphe":
                    blocksobjects[i].body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    blocksobjects[i].type = "sphere";
                    break;
                case "thre":
                    blocksobjects[i].body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    blocksobjects[i].type = "thread";
                    break;
                case "impo":
                    //we should allow the import of stl, obj, and fbx
                    Mesh[] m = new Mesh[1];
                    blocksobjects[i].body = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                    m = pb_Stl_Importer.ImportAscii(load.loadfile(Path.GetDirectoryName(load.path) + @"\import\" + 
                        blocklines[6].Substring(7, blocklines[6].Length - 7) + ".stl"));

                    //invert the normals
                    Vector3[] normals = m[0].normals;
                    for (int j = 0; j < normals.Length; j++)
                    {
                        normals[j] = -normals[j];
                    }

                    m[0].normals = normals;

                    for (int l = 0; l < m[0].subMeshCount; l++)
                    {
                        int[] triangles = m[0].GetTriangles(l);
                        for (int j = 0; j < triangles.Length; j += 3)
                        {
                            int temp = triangles[j + 0];
                            triangles[j + 0] = triangles[j + 1];
                            triangles[j + 1] = temp;
                        }
                        m[0].SetTriangles(triangles, l);
                    }
                    blocksobjects[i].body.GetComponent<MeshFilter>().mesh = m[0];
                    blocksobjects[i].body.transform.localScale = new Vector3(1,1,1);
                    blocksobjects[i].type = "imported";
                    break;
                case "subs":
                    //if it is a imported subsystem then we follow the required rules
                    blocksobjects[i].type = "subsystem";
                    break;
                default:
                    break;
            }

            Vector3 objectsscale = new Vector3();
            //we should be able to parse simple math operations
            objectsscale = load.convertstringvector(blocklines[4].Substring(blocklines[4].IndexOf("("), blocklines[4].Length - blocklines[4].IndexOf("(")));
            blocksobjects[i].material = blocklines[1];
            blocksobjects[i].numberobject = i;
            blocksobjects[i].position = load.convertstringvector(blocklines[2].Substring(8, blocklines[2].Length - 8));
            blocksobjects[i].rotation = load.convertstringvector(blocklines[3].Substring(8, blocklines[3].Length - 8));
            if (blocklines[5].Contains("="))
            {
                blocksobjects[i].priority = float.Parse(blocklines[5].Substring((blocklines[5].IndexOf('=') + 1), blocklines[5].Length - (blocklines[5].IndexOf('=') + 1)));
            }

            //get the name first to be used below
            if (!(blocklines[6] == null) && !(blocklines[6] == ""))
            {
                blocksobjects[i].body.name = blocklines[6].Substring(7, blocklines[6].Length - 7);
            }
            else
            {
                blocksobjects[i].body.name = blocksobjects[i].type;
            }
            //assign the primitives their proper values
            blocksobjects[i].body.transform.position = blocksobjects[i].position;
            blocksobjects[i].body.transform.rotation = Quaternion.Euler(new Vector3(blocksobjects[i].rotation.x, blocksobjects[i].rotation.y, blocksobjects[i].rotation.z));
            blocksobjects[i].body.transform.localScale = objectsscale;

        }

        return blocksobjects;
    }

    public void assignallobjects(string file)
    {
        options = new string[readoptions(file).GetLength(0)];
        for (int i = 0; i < readoptions(file).GetLength(0); i++)
        {
            if (!(readoptions(file)[i, 1] == null))
            {
                options[i] = readoptions(file)[i, 1];
            }
            else
            {
                options[i] = " ";
            }
        }
        string readfile = editfile(file, readoptions(file));
        string[] readblocks = readblock(readfile);
        allrobotobjects = executeblock(readblocks);
    }


}
