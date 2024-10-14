/*
* John Nguyen
* GemBehaviour.cs
* Assignment 5A
* This was imported as part of the PennyPixel_2DTilemapProject.zip file from blackboard.
* Only one change was added: Reference to scoreManager + incrementing score when the player collects a gem
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;
	private ScoreManager scoreManager; // ADDED: Reference to ScoreManager


	void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
		scoreManager = FindObjectOfType<ScoreManager>(); // ADDED: Find the ScoreManager in the scene
	}

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		scoreManager.IncrementScore(); // ADDED: Call to increment score in ScoreManager
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
