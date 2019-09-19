using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonColor : MonoBehaviour
{

	public Color colorA;
	public Color colorB;
	//public float speed;
    public float speed = 1.0F;
	public Material colorMaterial;

    //void Start()
    //{
	
    //}

    // Update is called once per frame
    void Update()
    {

		Color color = Color.Lerp(colorA, colorB, Mathf.PingPong(Time.time * speed, 1));
		colorMaterial.SetColor("_Color", color);

    }
}

