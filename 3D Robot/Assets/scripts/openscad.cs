using UnityEngine;
using System.Collections;
using Parabox.STL;
using System;

//Important when installing this software don't forget
//to install openscad and set system varaibles 

public class openscad : MonoBehaviour {
    public class scadfunctions
    {
        public class operations
        {
            public string translate(Vector3 moveamount)
            {
                string translate = "translate([" + moveamount.x + "," + moveamount.y + "," + moveamount.z +"]){";
                return translate;
            }

            public string rotate(Vector3 degreesofrotation)
            {
                string rotate = "rotate([" + degreesofrotation.x + "," + degreesofrotation.y + "," + degreesofrotation.z+ "]){";
                return rotate;
            }

            public string scale(Vector3 scaleamount)
            {
                string scale = "scale([" + scaleamount.x + "," + scaleamount.y + "," + scaleamount.z + "]){";
                return scale;
            }

            public string ending(int num)
            {
                string ending = "";
                for (int i = 0; i < num; i++)
                {
                    ending = ending + "}";
                }
                return ending;
            }

            public string difference(string d1, string d2)
            {
                string difference = "";
                difference = "difference(){" + d1 + d2 + "}";
                return difference;
            }

            public string union(string u1, string u2)
            {
                string union = "";
                union = "union(){" + u1 + u2 + "}";
                return union;
            }

            public string intersection(string i1, string i2)
            {
                string interection = "";
                interection = "intersection(){" + i1 + i2 + ")";
                return interection;
            }

        }

        public class createobject
        {
            public int facecount = 100;
            public string sphere(Vector3 size)
            {
                string sphere = "sphere([" + size.x + "," + size.y + "," + size.z + "]);";
                return sphere;
            }

            public string cylinder(Vector3 size)
            {
                string cylinder = "cylinder(r = " + size.x + "," + "h = " + size.z*2 + ",center = true, $fn = " + facecount + ");";
                return cylinder;
            }

            public string cube(Vector3 size)
            {
                string cube = "cube(size = [" + size.x + "," + size.y + "," + size.z + "],center = true);";
                return cube;
            }

            public string import(string file)
            {
                string import = "import(\""+ file + "\");";
                return import;
            }
        }

        public class import
        {

            //we need to import them all as stls into the unity program and position them properly otherwise all is done (they will be 3d printed and 
            //will be aviable for future use as will all else be)

            public static void importobj(GameObject into, string path)
            {
                //play more with stls we are trying objs and see how to get them there
                //Just use stl importer
                Mesh myMesh = FastObjImporter.Instance.ImportFile(path);
                into.GetComponent<MeshFilter>().mesh = myMesh;
            }

            public static void importstl(GameObject[] into, string path)
            {

                Mesh[] myMesh = pb_Stl_Importer.Import(path + ".stl");
                for(int i = 0; i < myMesh.Length; i++)
                {
                    into[i].GetComponent<MeshFilter>().mesh = myMesh[i];
                }

            }

        }

        public class export
        {
            public static string savefolder = "";
            public static void savefile(String save, string name)
            {
                //export (esp. now that we are using middleware and very ineffectively as well)
                using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(savefolder + name + ".scad", false))
                {
                    file.Write(save);
                }
            }

            //assuming we generate the openscad file successfully and saved it properly we now need to make and run the batch file
            //export (esp. now that we are using middleware and very ineffectively as well)
            public static void savestlgenerator()
            {
                using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(savefolder + "generatestl" + ".bat", false))
                {
                    string save = "cd " + savefolder + 
                        Environment.NewLine + "FOR %%f in (*.scad)  DO openscad -o \"%%~nf.stl\" \"%%f\"";
                    file.Write(save);
                }
            }

            public static void executestlgenerator()
            {
                
                System.Diagnostics.Process.Start(savefolder + 
                    "generatestl" + ".bat");
            }

            //then reimport them all in
    }
    }

}
