using UnityEngine;
using System.Collections;

public class modify : MonoBehaviour {

    public GameObject modifypanel;

    public void executemodify()
    {
        modifypanel.gameObject.SetActive(true);
    }

   
        public GameObject createcube()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            return cube;
        }

        public GameObject createcylinder()
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            return cylinder;
        }

        public GameObject createsphere()
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            return sphere;
        }
    
        public GameObject import()
       {
        //import is a primitive type 
        //a imported full file (e.g. from autodesk) will be converted into our overview .3dr consisting of mostly imports
        //since this import will be working through openscad we only support .stl and all else will need to be converted

        return null;
        }
}
