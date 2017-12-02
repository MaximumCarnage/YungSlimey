using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public int m_health = 100;
	public bool isSleeping;
	public Animator m_anim;
	// Use this for initialization
	void Start () {
		m_anim=gameObject.GetComponent<Animator>();
	}
		void FixedUpdate()
	{
		m_anim.SetBool("Damaged",false);
	}
	
	// Update is called once per frame
	void Update () {
		if(m_health == 0){
			FallAsleep();
		}
		
	}
	public void takeDamage(int damage){
		
		if(m_health >= 0){
			//gameObject.GetComponent<AnimalController>().FallAsleep();
			Debug.Log(gameObject.name+m_health);
			m_health -= damage;
			m_anim.SetBool("Damaged",true);
			Debug.Log(m_health);
		}
	}
	public void FallAsleep(){
		isSleeping = true;
		m_anim.SetBool("Asleep",true);
	}
	public void WakeUp(){
		isSleeping = false;
		m_anim.SetBool("Asleep",false);
	}

}
