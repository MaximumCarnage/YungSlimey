using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public int m_health = 100;
	public Animator m_anim;
	// Use this for initialization
	void Start () {
		m_anim=gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(m_health);
	}
	public void takeDamage(int damage){
		m_health -= damage;
	}

}
