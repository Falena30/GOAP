using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_lari : GoapAction {
	private NavMeshAgent navComponent;
	public int speed;
	public bool lari = false;
	enemy_agent NPC;

	//private float startTime = 0;
	//public float workDuration = 3;

	// Use this for initialization
	public enemy_lari(){
		//addPrecondition ("is_player_jauh", true);
		//addPrecondition("is_observasi",true);
		addEffect ("is_lari", true);
	}

	public override void reset(){
		navComponent = GetComponent<NavMeshAgent>();
		navComponent.speed = 4;
		lari = false;
		//speed = 4;
		target = null;
	}

	public override bool isDone(){
		
		return lari;
	}

	public override bool requiresInRange(){
		return false;
	}

	public override bool checkProceduralPrecondition(GameObject enemy){
		//NPC = GetComponent<enemy_agent> ();
		navComponent = GetComponent<NavMeshAgent>();
		return true;
	}

	public override bool perform(GameObject enemy){
		navComponent.speed = speed;
			lari = true;
			return true;
	}
}
