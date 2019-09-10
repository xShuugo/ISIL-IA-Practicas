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

    [SerializeField]
    float maxSpeed = 1;
    [SerializeField]
    float maxSteer = 1;
    
    // ...
    Transform target;
    Transform area;

    void Update()
    {
        target = GameObject.Find("Target").transform;
        area = GameObject.Find("Area").transform;

        // desired
        desired = (target.position - transform.position).normalized * maxSpeed;
        desired *= -1;
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);   

        velocity += steer * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;  

        if(transform.position.x <= -8 || transform.position.x >= 8 || transform.position.y >= 5.28 || transform.position.y <= -5.38){
            Debug.Log("Has perdido");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
        } 

        float dist = Vector2.Distance(transform.position, area.position);

        if(dist<=1){
            Debug.Log("Has Ganado");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
                
    }
}
