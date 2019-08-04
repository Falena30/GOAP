using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy_kabur : GoapAction {
	public NavMeshAgent navMesh;
	public bool enemey_flee = false;

//	Labourer lbr;
//	enemy_agent eg;
	public enemy_kabur(){
		addPrecondition ("is_player_jauh", false);
		addEffect ("is_player_jauh", true);
		addEffect ("is_kabur", true);
	}
	public override void reset ()
	{
		enemey_flee = false;
		target = null;
	}
	public override bool isDone ()
	{
		return enemey_flee;	
	}
	public override bool requiresInRange ()
	{
		return false;
	}
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		navMesh = GetComponent<NavMeshAgent>();
//		lbr = GetComponent<Labourer> ();
//		eg = GetComponent<enemy_agent> ();
		return true;
	}
	public override bool perform (GameObject agent)
	{
		enemey_flee = true;
		navMesh.speed = 6;
		return true;
	}
	// Use this for initialization

}
