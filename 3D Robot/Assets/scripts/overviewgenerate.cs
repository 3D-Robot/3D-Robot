using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

public class overviewgenerate : MonoBehaviour
{
    //here is where we take our standard generated overview (similiar to box) and generate all of the files needed as well as the .3dr full
    //file for futher processing into .3da which will then be fed directly into the 3D Robot
    //Ultimately we should use collision detectors for selecting unions and differences however for now just simply union everything and difference
    //it from the part in question
    private openscad.scadfunctions.operations os = new openscad.scadfunctions.operations();
    private openscad.scadfunctions.createobject oc = new openscad.scadfunctions.createobject();

    public string[] createallscad(robotobject[] allrobotobjects)
    {
        string[] individualscads = new string[allrobotobjects.Length];
        string[] createscads = new string[allrobotobjects.Length];
        for (int i = 0; i < allrobotobjects.Length; i++)
        {
            if (allrobotobjects[i].material == "nothing" || allrobotobjects[i].material == "air")
            {
                allrobotobjects[i].type = "";
            }
            switch (allrobotobjects[i].type)
            {
                case "cube":
                    individualscads[i] = os.translate(allrobotobjects[i].position) + os.rotate(allrobotobjects[i].rotation) + oc.cube(allrobotobjects[i].body.transform.localScale) + os.ending(2);
                    break;
                case "cylinder":
                    individualscads[i] = os.translate(allrobotobjects[i].position) + os.rotate(allrobotobjects[i].rotation) + oc.cylinder(allrobotobjects[i].body.transform.localScale) + os.ending(2);
                    break;
                case "sphere":
                    individualscads[i] = os.translate(allrobotobjects[i].position) + os.rotate(allrobotobjects[i].rotation) + oc.sphere(allrobotobjects[i].body.transform.localScale) + os.ending(2);
                    break;
                case "imported":
                    //we should allow the import of stl, obj, and fbx
                    string pathname = Path.GetDirectoryName(load.path) + @"\import\" + allrobotobjects[i].body.name + ".stl";
                    individualscads[i] = os.translate(allrobotobjects[i].position) + os.rotate(allrobotobjects[i].rotation) +
                    oc.import(pathname.Replace(@"\", @"/")) + os.ending(2);
                    break;
                case "subsystem":
                    //we use subsystems as per the rules regarding them
                    break;
                case "thread":
                    //thread is a seperate object it is represented as a cylinder but is rendered and generated as a stl thread
                    break;
                default:
                    break;
            }
        }

        for (int i = 0; i < allrobotobjects.Length; i++)
        {
            createscads[i] = individualscads[i];
            string join = "";
            for (int j = 0; j < allrobotobjects.Length; j++)
            {
                if (!(j == i) && allrobotobjects[i].priority < allrobotobjects[j].priority)
                {
                    join = join + individualscads[j];
                }
                else if (!(j == i) && allrobotobjects[i].priority == allrobotobjects[j].priority)
                {
                    //then do one but not the other selected at random if the user wants he can change priority to choose
                    join = join + individualscads[j];
                    allrobotobjects[j].priority = allrobotobjects[j].priority + .0001f;
                }
            }
            string allotherobjects = os.union(join, "");
            string mainobject;
            mainobject = os.union(createscads[i], "");
            //now we subtract a union of the above (if it is a set of objects above) from a union of everything else or a union of all intersecting meshes
            //using mesh collidors
            //We must incorporate priority
            //And when designing remember to use tolerance to create manifold parts
            createscads[i] = os.difference(mainobject, allotherobjects);
        }

        //reposition all created objects to center so that they are easier to work with and we can reload them 
        for (int i = 0; i < allrobotobjects.Length; i++)
        {
            createscads[i] = os.rotate(-allrobotobjects[i].rotation) + os.translate(-allrobotobjects[i].position) + createscads[i] + os.ending(2);
        }

        return createscads;
    }

    public void saveallscads(string[] scadfiles, string[] names, string path)
    {
        if (path == null)
        {

        }
        else if (path == "")
        {
        }
        else if (path == @"\")
        {
        }
        else
        {
            openscad.scadfunctions.export.savefolder = path;
            for (int i = 0; i < scadfiles.Length; i++)
            {
                openscad.scadfunctions.export.savefile(scadfiles[i], names[i]);
            }
            openscad.scadfunctions.export.savestlgenerator();
            openscad.scadfunctions.export.executestlgenerator();
        }
    }

}
