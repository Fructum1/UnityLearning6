using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    [SerializeField]
    private GameObject interactiveBoxCube;
    private GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag.Equals("InteractivePlane"))
                {
                    Vector3 newPosition = hitInfo.point;
                    newPosition += hitInfo.normal;
                    Instantiate(interactiveBoxCube, newPosition, Quaternion.identity);
                }

                if (hitInfo.collider.TryGetComponent(out InteractiveBox interactiveBox))
                {
                    if (interactiveBox.next == null)
                    {
                        prefab = interactiveBox.gameObject;
                    }
                    else if(prefab != interactiveBox)
                    {
                        interactiveBox.AddNext(hitInfo.collider.GetComponent<InteractiveBox>());
                        prefab = null;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out InteractiveBox interactiveBox))
                {
                    Destroy(interactiveBox.gameObject);
                }
            }
        }
    }
}
