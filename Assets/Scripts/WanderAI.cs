using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WanderAI : MonoBehaviour {
	public float wanderRadius;
    public float wanderTimer;
 
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
  void Start () {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
		agent.updateUpAxis = false;
    }
 
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);

            timer = 0;
			
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
		Debug.Log("Aggro");
		if(other.gameObject.tag == "PlayerBody"){
			agent.SetDestination(other.gameObject.transform.position);
		}
	}
	void OnTriggerExit(Collider other){
		Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);

	}
}