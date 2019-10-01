using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Agent : MonoBehaviour
{
    
    // Agent
    Vector3 velocity = Vector3.zero;
    Vector3 desired = Vector3.zero;
    Vector3 steer = Vector3.zero;
    Vector3 originPos = Vector3.zero;
    public float AreaCircle = 2;    

    [SerializeField]
    float maxSpeed = 1;
    [SerializeField]
    float maxSteer = 1;   
    
    // ...
    Transform target;
    
    void Awake(){
        originPos = transform.position;
    }

    void Update()
    {
        target = GameObject.Find("Target").transform;        

        // desired       
        
        if(Vector3.Distance(originPos, transform.position) >= AreaCircle){
            velocity += Seek(originPos, 100);
            transform.position += velocity * Time.deltaTime;             
        }         
        velocity += Seek(target.position, 100);
        transform.position += velocity * Time.deltaTime;                
    }

    public Vector3 Seek(Vector3 target, float range = 99999){ 
        Vector3 desired = new Vector3(0, 0, 0);
        Vector3 difference = (target - transform.position);                    
        float distance = difference.magnitude;
        desired = difference.normalized * maxSpeed;        
        Vector3 steer;
        if(distance< range){
                steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
        }else{
                steer = Vector3.zero;
        }     
        return steer;        
    }   
}
