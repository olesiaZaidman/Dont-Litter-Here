using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	float speed = 2f;
	void Update()
	{
		transform.Rotate(new Vector3(0, 90, 0) * speed * Time.deltaTime);
	}
}
