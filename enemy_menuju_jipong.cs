using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_menuju_jipong : GoapAction {
	
	public bool menang = false;
	//private tujuan_sembunyi tagetObject;
	//public menuju_tempat_sembunyi instence;
	private NavMeshAgent navComponent; 
	public Transform desitination;
	misc mis;

	// Use this for initialization
	public enemy_menuju_jipong(){
		//addPrecondition ("is_player_jauh", true);
		//addPrecondition ("is_observasi", true);
		addPrecondition ("is_lari", true);
		addEffect ("is_jipong", true);
	}

	public override void reset(){
		menang = false;
		target = null;
	}

	public override bool isDone(){
		return menang;
	}

	public override bool requiresInRange(){
		return false;
	}

	public override bool checkProceduralPrecondition(GameObject enemy){ 
		navComponent = GetComponent<NavMeshAgent>();
		mis = GameObject.Find ("enemy").GetComponent<misc> ();
		target = mis.tempat_jipong.transform;
		desitination = target;

		return true;
	}

	public override bool perform(GameObject enemy){
	navComponent.SetDestination (desitination.position);
		if (Vector3.Distance (transform.position, target.position) <= 1) {
			menang = true;

		}
		//Debug.Log ("meangn"+ menang);
		return true;
	}
}
