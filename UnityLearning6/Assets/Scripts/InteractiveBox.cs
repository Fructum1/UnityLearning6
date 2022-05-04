using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    public InteractiveBox next = null;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    private void FixedUpdate()
    {
        if (next != null)
        {
            if (Physics.Linecast(transform.position, next.transform.position, out RaycastHit hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 0.3f);

                if(hit.collider.TryGetComponent(out ObstacleItem item))
                {
                    item.GetDamage(Time.deltaTime);
                }
            }
        }
    }
}
