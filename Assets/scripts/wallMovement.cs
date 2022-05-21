using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMovement : MonoBehaviour
{
    Vector2 position;
    public float speed = 0.07f;
    public bool isPoint = false;
    void Start()
    {
        gameObject.tag = "Wall";
        position = transform.position;
        if(!isPoint){
            if(position.y < 0){
                position.y = Random.Range(-3.5f, -6.0f);
            }else{
                position.y = Random.Range(3.5f, 6.0f);
            }
        transform.position = position;
        }
    }

    void Update(){
        speed *= 1.001f;
        if(position.x < -10.5f){
            position.x = 10.5f;
            if(!isPoint){
            if(position.y < 0){
                position.y = Random.Range(-3.5f, -6.0f);
            }else{
                position.y = Random.Range(3.5f, 6.0f);
            }
            }
        }
        position.x -= speed;
        transform.position = position;
    }

    void Stop(){
        this.enabled = false;
    }
}
