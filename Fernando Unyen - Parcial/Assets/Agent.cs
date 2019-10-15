using UnityEngine;
using System.Collections;

public class Agent : SBAgent
{	
	public Transform currentTarget;
	public char type;	

	void Start()
	{
		maxSteer = 3f;
		if(type == 'A'){
			maxSpeed = 1f;
				
		} else if(type == 'B'){
			maxSpeed = 3f;			
		}
	}

	void Update()
	{		
		
		velocity += SteeringBehaviours.Seek(this, currentTarget, 200);

		if(type == 'A'){								
			velocity += SteeringBehaviours.Separate(this, GameManager.agentsListB, 1f);
		
		}		
		 if(type == 'B'){
			velocity += SteeringBehaviours.Separate(this, GameManager.agentsListA, 1f);
		}

		transform.position += velocity * Time.deltaTime;
		changeTarget();
	}

	public void changeTarget(){			
		if(Vector3.Distance(this.transform.position, currentTarget.position) <= 0.1f && currentTarget.name != (GameObject.FindGameObjectsWithTag("Points").Length).ToString()){						
			currentTarget = GameObject.Find((int.Parse(currentTarget.name) + 1).ToString()).transform;							
								
		} if(Vector3.Distance(this.transform.position, currentTarget.position) <= 0.1f && currentTarget.name == (GameObject.FindGameObjectsWithTag("Points").Length).ToString()){
			Destroy(gameObject);
			if(type == 'A'){
				GameManager.agentsListA.Remove(this.gameObject);
			}
			if(type == 'B'){
				GameManager.agentsListB.Remove(this.gameObject);
			}

		}				
	}   
}
