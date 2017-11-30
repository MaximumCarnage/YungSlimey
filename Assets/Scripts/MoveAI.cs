using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour {
	public Transform goal;
	private NavMeshAgent agent;
	private Animator m_anim;
	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		m_anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		agent.updateRotation = true;
		if(goal){
			agent.SetDestination(goal.position);
			
		}
		
	}
}
