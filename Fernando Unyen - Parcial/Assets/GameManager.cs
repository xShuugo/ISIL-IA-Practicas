using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject agentA;
	public GameObject agentB;
	public Vector3 spawner;
	public static List<GameObject> agentsListA = new List<GameObject>();
	public static List<GameObject> agentsListB = new List<GameObject>();
	float n;

	void Awake(){
		agentA = Resources.Load<GameObject>("AgentA");
		agentB = Resources.Load<GameObject>("AgentB");
		spawner  = GameObject.Find("0").transform.position;
	}
	void Start(){			
			StartCoroutine("SpawnA");
			StartCoroutine("SpawnB");
	
	}

	IEnumerator SpawnA() {  
		GameObject instance = Instantiate(agentA); 
		instance.GetComponent<Agent>().currentTarget = GameObject.Find("1").transform; 
		agentsListA.Add(instance);
        yield return new WaitForSeconds(2f);
		StartCoroutine("SpawnA");
	}	

	IEnumerator SpawnB() {  
		GameObject instance = Instantiate(agentB); 
		instance.GetComponent<Agent>().currentTarget = GameObject.Find("1").transform;  
		agentsListB.Add(instance);     
        yield return new WaitForSeconds(4f);
		StartCoroutine("SpawnB");
	}		
}

