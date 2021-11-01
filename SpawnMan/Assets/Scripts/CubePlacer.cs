using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    private float test = 0;
    float pathZ = 0;
    float pathX = 0;
    float cubeScale = 3;
    public Material cubeMat;

    Rigidbody m_Rigidbody;
    Collider m_ObjectCollider;
    Vector3 yeniVektor;

    private void Awake()
    {
        
        grid = FindObjectOfType<Grid>();
        pathZ = grid.transform.localScale.z;
        pathX = grid.transform.localScale.x;


        for (int x = 0; x < pathX; x+= (int)cubeScale)
        {
            yeniVektor = new Vector3((float)x, grid.transform.localScale.y, 0);
            PlaceCubeNear(yeniVektor);
            for (int z = 0; z < pathZ; z+= (int)cubeScale)
            {
                yeniVektor = new Vector3((float)x, grid.transform.localScale.y, (float)z);
                PlaceCubeNear(yeniVektor);
               
            }

        }
       
    }

    private void Update()
    {
        
    }
 

 

    private void PlaceCubeNear(Vector3 vectorParam)
    {
        var finalPosition = grid.GetNearestPointOnGrid(vectorParam);
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = finalPosition;
        cube.transform.localScale = new Vector3(cubeScale, 1.0f, cubeScale);
        cube.transform.gameObject.tag = "Cubes";
        m_Rigidbody =  cube.AddComponent<Rigidbody>();
        m_Rigidbody = cube.GetComponent<Rigidbody>();
        m_ObjectCollider = cube.GetComponent<Collider>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        m_ObjectCollider.isTrigger = false;
        cube.GetComponent<Renderer>().material = cubeMat;
        m_Rigidbody.mass = 1000f;
    }
}
