using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox next = null;
    [SerializeField]
    private bool debug;


    void AddNext(InteractiveBox box)
    {
        next = box;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (debug && next != null)
        {
            if (Physics.Linecast(transform.position, next.transform.position, out RaycastHit hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 0.3f);

            }
        }
    }
}
