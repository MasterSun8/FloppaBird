using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floppaMovement : MonoBehaviour{
    int scr;
    public Text Points;
    public GameObject Issue;
    public GameObject RunningAway;
    public GameObject Ground;
    public float jump = 0.1f;
    public float acc = 0.005f;
    Vector2 position;
    float zRotation = 0f;
    float vel;
    float vertical;
    bool dead = false;
    bool onTheGround = false;
    GameObject[] Walls;
    void Start(){
        vel = jump;
        Application.targetFrameRate = 60;
        Issue.SetActive(dead);
        RunningAway.SetActive(false);
        position = transform.position;
        position.y = 0f;
        transform.position = position;
    }
    void Update(){
        if(dead){
            foreach (GameObject wall in Walls){
                wall.SendMessage("Stop");
            }
            RunningAway.SetActive(false);
            Issue.SetActive(dead);
            if(onTheGround){
                this.enabled = false;
            }
            transform.Rotate(0, 0, 5.0f);
            position = transform.position;
            position.x -= 0.1f;
            vel -= acc;
            position.y = position.y + vel;
            transform.position = position;
        }else{
        position = transform.position;
        vel -= acc;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){
                vel = jump;
        }
        if((position.y + vel) < 4.5f){
            position.y = position.y + vel;
        }
        if (vel * 200f >= -70){
            zRotation = vel * 100f;
        }
        else{
            zRotation = -70;
        }
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
        transform.position = position;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        Walls = GameObject.FindGameObjectsWithTag("Wall");
        if(other.name == Ground.name){
            onTheGround = true;
            dead = true;
        }else if(other.name == RunningAway.name){
            position.y = other.transform.position[1];
            RunningAway.SetActive(true);
            Invoke("hideSky", 1);
        }else if(other.name == "Score"){
            scr++;
            Points.text = Convert.ToString(scr, 10);
        }else{
            dead = true;
        }
    }
    void hideSky(){
        RunningAway.SetActive(false);
    }
}
