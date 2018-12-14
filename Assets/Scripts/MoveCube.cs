using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class MoveCube : MonoBehaviour {

    GameObject targetCube;
    GameObject left;
    GameObject right;
    GameObject up;
    GameObject down;
    bool move;
    void Start () {
        left = GameObject.FindGameObjectWithTag("TriggerLeft");
        right = GameObject.FindGameObjectWithTag("TriggerRight");
        up = GameObject.FindGameObjectWithTag("TriggerUp");
        down = GameObject.FindGameObjectWithTag("TriggerDown");
        targetCube = left;
        TrackableBehaviour.Status dd = new TrackableBehaviour.Status();
    }
	void FixedUpdate () {
        if (move) { 
        transform.position = Vector3.MoveTowards(transform.position, targetCube.transform.position, Time.deltaTime / 6);
        }
    }
    private void OnTriggerEnter(Collider col) {
        if (col.tag == "TriggerLeft") { targetCube = up; }
        if (col.tag == "TriggerUp") { targetCube = right; }
        if (col.tag == "TriggerRight") { targetCube = down; }
        if (col.tag == "TriggerDown") { targetCube = left; }
    }
    private void OnBecameVisible() {
        move = true;
    }
    private void OnBecameInvisible() {
        move = false;
    }

    void OnTrackingFound()
    {
        Debug.Log("fhfhfhfhf");
    }
}
