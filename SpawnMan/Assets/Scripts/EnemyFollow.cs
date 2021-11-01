using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    private float ofsetX = 0.4f;
   
    private void Start()
    {
        target_Offset = transform.position - target.position;
        
    }
    void Update()
    {
        if (target)
        {
            if(target_Offset.z <= 1.5f)
            {
                target_Offset.z += 0.0121f;

            }
            if(target_Offset.x <= ofsetX)
            {
                target_Offset.x += 0.02f;
            }

            transform.position = Vector3.Lerp(transform.position, target.position + target_Offset, 0.1f);
        }
    }
}
