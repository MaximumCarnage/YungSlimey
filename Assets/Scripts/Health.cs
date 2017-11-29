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
		if(m_health == 0){
			
		}
	}
	public void takeDamage(int damage){
		m_health -= damage;
		m_anim.SetBool("Damaged",true);
		
	}

}
