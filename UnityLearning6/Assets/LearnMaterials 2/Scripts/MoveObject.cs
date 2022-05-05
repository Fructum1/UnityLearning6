using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : SampleScript
{
    [SerializeField]
    [Min(0f)]
    private float speed = 1;
    private bool used = false;

    [SerializeField]
    private Vector3 point;

    [ContextMenu("adsd")]
    public override void Use()
    {
        used = true;
    }

    
    public void Update()
    {
        if (used)
        {
            if (Vector3.Distance(transform.position, point) > (speed*2))
            {
                transform.position += (point - transform.position) * speed * Time.deltaTime;
            }
        }
    }


}
