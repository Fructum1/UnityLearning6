using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    private float currentValue=0;
    private UnityEvent onDestroyObstacle;
    [SerializeField]
    private Material m_material;
    // Start is called before the first frame update
    void Start()
    {
        m_material = GetComponent<Renderer>().material;
    }

    public void GetDamage(float value) 
    {
        currentValue -= value;
        if (currentValue == 1)
        {
            m_material.color = Color.white;
        }
        if (currentValue == 0)
        {
            m_material.color = Color.Lerp(Color.white,Color.red,5);
            onDestroyObstacle?.Invoke();
            Destroy(transform.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (currentValue == 0)
        {
            transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, Time.time / 10);
        }

    }
}