using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShirtColor : MonoBehaviour
{
    [SerializeField] Material tshirtMaterial;

     void Start()
    {
            
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    int i = Random.Range(0, colors.Length);
        //    tshirtMaterial.color = colors[i].color;
        //}
    }

    public void ChangeColor(Color _color)
    {
        tshirtMaterial.color = _color;
    }
}
