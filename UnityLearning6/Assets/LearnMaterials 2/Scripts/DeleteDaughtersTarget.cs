using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDaughtersTarget : SampleScript
{
    [SerializeField]
    private Transform target;

    public override void Use()
    {
        Compress();
        foreach (Transform child in target)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    private void Compress()
    {
        float minimum = 0.001F;
        float maximum = 0.0001F;

        foreach (Transform child in target)
        {
            while (child.localScale.x >= 0)
            {
                child.localScale -= new Vector3(Mathf.Lerp(minimum, maximum, Time.time), Mathf.Lerp(minimum, maximum, Time.time), Mathf.Lerp(minimum, maximum, Time.time));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
