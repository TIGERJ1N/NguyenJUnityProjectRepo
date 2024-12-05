/*
* John Nguyen
* ObstacleAnimation.cs
* Assignment 9 - Pathfinding and AI with NavMeshAgent
* This code was pre-made and unchanged throughout the follow-along. It's attached to the obstacles used
* in Finished02 to control their movement using a sin function.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour {

	public float speed = .2f;
	public float strength = 9f;

	private float randomOffset;

	// Use this for initialization
	void Start () {
		randomOffset = Random.Range(0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = Mathf.Sin(Time.time * speed + randomOffset) * strength;
		transform.position = pos;
	}
}
