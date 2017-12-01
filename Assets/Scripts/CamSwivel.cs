using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwivel : MonoBehaviour {
	public Transform m_target;
	private float m_speed=25;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 transform.LookAt(m_target);
    	transform.Translate(Vector3.right * Time.deltaTime*m_speed);
	}
}
