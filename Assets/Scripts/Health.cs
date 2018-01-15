using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
		if(m_health == 0 ){
			FallAsleep();
			if(this.gameObject.tag == "Enemy")
			{
				m_anim.SetBool("Aggro",false);
				this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
				this.gameObject.GetComponent<WanderAI>().enabled = false;
				
			}
		}
		
	}
	public void takeDamage(int damage){
		
		if(m_health > 0){
			//gameObject.GetComponent<AnimalController>().FallAsleep();
			
			m_health -= damage;
			m_anim.SetBool("Damaged",true);
			
		}
			if(m_health == 0){
			FallAsleep();
		}

	}
	public void FallAsleep(){
		GetComponent<RPGCharacterController>().enabled = false;
		isSleeping = true;
		m_anim.SetBool("Asleep",true);
	}
	public void WakeUp(){
		isSleeping = false;
		m_anim.SetBool("Asleep",false);
	}

}
