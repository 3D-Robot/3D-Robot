using UnityEngine;
using System.Collections;
using Parabox.STL;
using System;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using NCalc;


public class load : MonoBehaviour {

    public UnityEngine.UI.Button optionsbutton;

    public static GameObject[] allobjects = new GameObject[1];
    public static float[] options = new float[18];
    public static string[] materials = new string[1];
    public static Vector3[] positions = new Vector3[1];
    public static Vector3[] rotations = new Vector3[1];

    public static string loadfile(string path)
    {
        string fullfile = "";
        using (System.IO.StreamReader file =
new System.IO.StreamReader(path))
        {
            fullfile = file.ReadToEnd();
        }
        return fullfile;
    }

    //we load .3dr so first we read the state which it's in the beginning
    public int filestate(string file)
    {
        if(file.Substring(7,5) == "final")
        {
            return 0;
        }
        else if(file.Substring(7,8) == "overview")
        {
            return 1;
        }
        else if(file.Substring(7, 6) == "script")
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

    public string[] extractstl(string file, int objectnumber)
    {
        //we have all of the info in the returned array
        //0 is the material, 1 is the name, 2 is the position, 3 is the rotation, 4 is the actual stl mesh
        string[] fullinfo = new string[5];
        string returnstring = "";
        //return substring and delete first 4 lines
        if (file.IndexOf("object " + (objectnumber + 1).ToString()) > -1)
        {
            returnstring = file.Substring(file.IndexOf("object " + objectnumber.ToString()), file.IndexOf("object " + (objectnumber + 1).ToString()) - file.IndexOf("object " + objectnumber.ToString()));
        }
        else
        {
            returnstring = file.Substring(file.IndexOf("object " + objectnumber.ToString()), file.Length - file.IndexOf("object " + objectnumber.ToString()));
        }
        string[] stringseparators = new string[] { Environment.NewLine };
        string[] cutstring = returnstring.Split(stringseparators, StringSplitOptions.None);
        returnstring = "";
        fullinfo[0] = cutstring[1].Substring(9, cutstring[1].Length - 9);
        fullinfo[1] = cutstring[2].Substring(5, cutstring[2].Length - 5);
        fullinfo[2] = cutstring[3].Substring(9, cutstring[3].Length - 9);
        fullinfo[3] = cutstring[4].Substring(9, cutstring[4].Length - 9);
        for(int i = 5; i < cutstring.Length - 2; i++)
        {
            returnstring = returnstring + cutstring[i] + Environment.NewLine;
        }
        fullinfo[4] = returnstring;
        

        return fullinfo;
    }

    //now that we have the file and the state we can load it into the front view and see what to do with it later (in terms of slicing modifing calculating ect.)
    //we now read the file and load the front end so that we can process it into instructions 
    //careful with the order otherwise missed steps can lead to longer times not shorter ones in the long run

    public GameObject[] loadfrontend(string file, int state)
    {
        //for each object we read its position vector and its rotation and finally its stl into a mesh 
        //finally we create all of the gameobjects with the proper position and rotation and mesh
        //we also load a bottom plane and add appropaite physics modifiers now

        start s = new start();

        if (state == 0)
        {
            string[] stringSeparators = new string[] { "object" };
            int numofobjects = file.Split(stringSeparators, StringSplitOptions.None).Length - 1;
            GameObject[] allobjects = new GameObject[numofobjects];
            GameObject[] returnobjects = new GameObject[numofobjects];
            materials = new string[numofobjects];

            Mesh[] m = new Mesh[0];
            for (int i = 0; i < numofobjects; i++)
            {
                //import the stl
                //for now changing to obj
                string[] newstl = new string[5];
                newstl = extractstl(file, i);
                // Mesh m = FastObjImporter.Instance.ImportFile(newstl[4]);

                materials[i] = newstl[0];
                m = pb_Stl_Importer.ImportAscii(newstl[4]);

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
                

                //back to importing
                allobjects[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                allobjects[i].GetComponent<MeshFilter>().mesh = m[0];
                allobjects[i].name = newstl[1] + " " +  i.ToString();
                //place objects properly
                allobjects[i].transform.position = positions[i];
                //always center the object at the bottom center of the bed upon import
                allobjects[i].transform.position = allobjects[i].transform.position + new Vector3(-s.bedsize.x / 2, 45 + 600 / 2 + 10, -s.bedsize.z / 2);
                //rotations generally come at the end
                allobjects[i].transform.rotation = Quaternion.Euler(rotations[i]);
            }

            //just for now correct later
            //figure out why this is neccessary and then omit it
            for(int i = 0; i < 8; i++)
            {
                allobjects[i].transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
            }

            return allobjects;
        }
        else if(state == 1)
        {
            //in here we need to process the script into the primitives overview type that we did in the program box 
            //think it through and make it right
            //it is all done below 

            return null;
        }
        else
        {
            return null;
        }
    }

    public Vector3 getposition(string file, int objectnumber)
    {
        return convertstringvector(extractstl(file,objectnumber)[2]);
    }

    public Vector3 getrotation(string file, int objectnumber)
    {
        return convertstringvector(extractstl(file ,objectnumber)[3]);
    }

    public int getnumofobjects(string file)
    {
        string[] stringSeparators = new string[] { "object" };
        int numofobjects = file.Split(stringSeparators, StringSplitOptions.None).Length - 1;
        return numofobjects;
    }

    static public Vector3 convertstringvector(string vectorstring)
    {
        //convert (-246.6, -246.6, -246.6)  into new vector3(-246.6, -246.6, -246.6)
        Expression returnvectorx = new Expression(vectorstring.Substring(1, vectorstring.Length - 2).Split(',')[0].ToString());
        Expression returnvectory = new Expression(vectorstring.Substring(1, vectorstring.Length - 2).Split(',')[1].ToString());
        Expression returnvectorz = new Expression(vectorstring.Substring(1, vectorstring.Length - 2).Split(',')[2].ToString());
        Vector3 returnvector = new Vector3(float.Parse(returnvectorx.Evaluate().ToString()),
            float.Parse(returnvectory.Evaluate().ToString()), 
            float.Parse(returnvectorz.Evaluate().ToString()));
        return returnvector;
    }

    public float[] readoptions(string file)
    {
        string full = file;
        full = full.Substring(full.IndexOf("options:"), full.IndexOf("object") - full.IndexOf("options:"));
        string[] stringSeparators = new string[] {Environment.NewLine};
        string[] lines = full.Split(stringSeparators, StringSplitOptions.None);
        for(int i = 1; i < lines.Length; i++)
        {
            lines[i-1] = lines[i];
        }
        float[] returnfloat = new float[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IndexOf('=') > 0)
            {
                lines[i] = lines[i].Substring(lines[i].IndexOf('=') + 2, lines[i].Length - (lines[i].IndexOf('=') + 2));
                returnfloat[i] = float.Parse(lines[i]);
            }
            else
            {
                returnfloat[i] = 0.0f;
            }
        }
        return returnfloat;
    }
    public static string path = "";
    public void executeload()
    {
        OpenFileDialog o = new OpenFileDialog();
        o.ShowDialog();
        path = o.FileName;
        if (path == null || path == "")
        {
            GameObject happy = new GameObject();
            allobjects = new GameObject[10];
            for(int i = 0; i < 10; i++)
            {
                allobjects[i].transform.SetParent(happy.transform);
                allobjects[i] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            }
        }
        else
        {
            start s = new start();
            string file = loadfile(path);
            if (filestate(file) == 0)
            {
                int numofobjects = getnumofobjects(file);
                positions = new Vector3[numofobjects];
                rotations = new Vector3[numofobjects];
                for (int i = 0; i < numofobjects; i++)
                {
                    positions[i] = getposition(loadfile(path), i);
                    rotations[i] = getrotation(loadfile(path), i);
                }
                options = readoptions(file);
                allobjects = loadfrontend(file, filestate(file));
            }
            else if(filestate(file) == 1)
            {
                overviewscripting os = new overviewscripting();
                os.assignallobjects(file);
                optionsbutton.gameObject.SetActive(true);
            }
            else
            {

            }
        }
    }

}
