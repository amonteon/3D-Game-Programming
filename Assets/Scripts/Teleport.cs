﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public Transform Destination;       // Gameobject where they will be teleported to
	public string TagList = "|PlayerCharacter|"; // List of all tags that can teleport

	// Use this for initialization
	void Start () {
		// As needed
	}

	// Update is called once per frame
	void Update () {
		// As needed
	}

	public void OnTriggerEnter(Collider other)
	{
		// If the tag of the colliding object is allowed to teleport
		if (TagList.Contains(string.Format("|{0}|",other.tag))) {
			// Update other objects position and rotation
			other.transform.position = Destination.transform.position;
			other.transform.rotation = Destination.transform.rotation;
		}
	}
}
