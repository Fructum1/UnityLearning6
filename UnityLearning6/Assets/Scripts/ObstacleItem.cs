using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    private float currentValue=1;
    [SerializeField]
    private UnityEvent onDestroyObstacle;
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
            m_material.color = Color.Lerp(Color.white, Color.red, value);
        }

        if (currentValue <= 0)
        {
            onDestroyObstacle?.Invoke();
            Destroy(gameObject);
        }
    }
}