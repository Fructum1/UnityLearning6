using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulticallSampleScripts : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> scripts = new List<SampleScript> ();

    [ContextMenu("Use")]
    public void ActivateMulticall()
    {
        foreach (SampleScript script in scripts) {
            script.Use();
        }
    }
}
