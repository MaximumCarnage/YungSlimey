using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WanderAI : MonoBehaviour {
	public float wanderRadius;
    public float wanderTimer;
    private Animator m_anim;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private float dist;
    private bool m_aggro;
    
  void Start () {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
		agent.updateUpAxis = false;
        m_anim = GetComponent<Animator>();
        dist=agent.remainingDistance;
    }
 
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
    if(dist!=Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete&&agent.remainingDistance == 0){
        
         m_anim.SetBool("isWalking",false);
    }
        if (timer >= wanderTimer) {
            m_anim.SetBool("isWalking",true);
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
           
            
           
            timer = 0;
			
        }
            
        if(agent.remainingDistance <=2f && m_aggro == true){
            agent.isStopped=true;
        }
        else{
            agent.isStopped=false;
        }
		
    }
 
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
		
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
	void OnTriggerStay(Collider other){
		
		if(other.gameObject.tag == "PlayerBody"){
            m_aggro=true;
			agent.SetDestination(other.gameObject.transform.position);
            m_anim.SetBool("Aggro",true);
		}
        
	}
	void OnTriggerExit(Collider other){
      if(other.gameObject.tag == "PlayerBody"){
		Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            m_anim.SetBool("Aggro",false);
            m_aggro = false;
      }
	}
}