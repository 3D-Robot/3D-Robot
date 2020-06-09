using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class importmeshfix : MonoBehaviour {

    //recursively rotate a object tree individualy
    public static void RotateObject(Transform obj)
    {
        Vector3 objRotation = obj.eulerAngles;
        objRotation.x += 90f;
        obj.eulerAngles = objRotation;

        //if a meshFilter is attached, we rotate the vertex mesh data
        MeshFilter meshFilter = obj.GetComponent(typeof(MeshFilter)) as MeshFilter;
        if (meshFilter)
        {
            RotateMesh(meshFilter.sharedMesh);
        }

        //do this too for all our children
        //Casting is done to get rid of implicit downcast errors
        foreach (Transform child in obj)
        {
            RotateObject(child);
        }
    }

    //"rotate" the mesh data
    public static void RotateMesh(Mesh mesh)
    {
        int index = 0;

        //switch all vertex z values with y values
        Vector3[] vertices = mesh.vertices;
        for (index = 0; index < vertices.Length; index++)
        {
            vertices[index] = new Vector3(vertices[index].x, vertices[index].z, vertices[index].y);
        }
        mesh.vertices = vertices;

        //for each submesh, we invert the order of vertices for all triangles
        //for some reason changing the vertex positions flips all the normals???
        for (int submesh = 0; submesh < mesh.subMeshCount; submesh++)
        {
            int[] triangles = mesh.GetTriangles(submesh);
            for (index = 0; index < triangles.Length; index += 3)
            {
                int intermediate = triangles[index];
                triangles[index] = triangles[index + 2];
                triangles[index + 2] = intermediate;
            }
            mesh.SetTriangles(triangles, submesh);
        }

        //recalculate other relevant mesh data
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
