using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    public bool move = false;
        
    void Update(){
        if(Input.GetKeyDown(GameManager.Rkey)){

        if(!move) move = true;
        else move = false;

    
    }
    if(move) {
     distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);   
    }
    
}
    
}
