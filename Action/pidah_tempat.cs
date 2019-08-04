using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class pidah_tempat : GoapAction {
	public bool pindah_temapat_sembunyi = false;
	private NavMeshAgent navComponent;
//	WorldCondition wc;
	private float startTime = 0;
	public float workDuration = 1;
	public int tamp;
	Labourer lbr;
	menuju_tempat_sembunyi mts;
	misc mis;
	public pidah_tempat(){
		addPrecondition ("is_lari", true);
		addPrecondition ("is_aman", false);
		//addEffect ("is_aman", false);
		addEffect ("is_aman", true);
		addEffect("is_sembunyi", true);
		//addEffect ("is_observasi", true);

	}
	public override void reset(){
		pindah_temapat_sembunyi = false;
		//lbr.sembunyi = false;
		startTime = 0;
		target = null;
	}

	public override bool isDone(){
		return pindah_temapat_sembunyi;
	}

	public override bool requiresInRange(){
		return false;
	}

	public override bool checkProceduralPrecondition (GameObject agent)
	{
		lbr = GetComponent<Labourer> ();
		mts = GetComponent<menuju_tempat_sembunyi> ();
		navComponent = GetComponent<NavMeshAgent> (); 
		mis = GameObject.Find ("enemy").GetComponent<misc> ();
		//masalahnya disini lho
		// bagaimana cara memilih target yang tidak di tutup oleh player
		// kalau player ada didepan enemy maka target yang dipilih harus menjauh dari player
		tamp = Random.Range (0, mis.tempat_sembunyi.Length-1);
		if (tamp >= lbr.tampung) {
			tamp += 1;		
		}

		target = mis.tempat_sembunyi [tamp].transform;		
		return target!=null;
	}

	public void JalanPSekarang(int index){
		//print ("indexnya " + index.ToString());
		if (index != 0) {
			index -= 1;
		}
		target = mis.tempat_sembunyi [index].transform;
		navComponent.SetDestination (target.position);
	}

	public override bool perform (GameObject agent)
	{
		//tamp = lbr.tampung;
		navComponent.SetDestination (target.position);

		if (Vector3.Distance (transform.position, target.position) <= 1) {
			//wc.dlek = true;
			if (startTime == 0) {
				startTime = Time.time;
			}

			if (Time.time - startTime > workDuration) {
				pindah_temapat_sembunyi = true;
			}
		}

		if (pindah_temapat_sembunyi == true) {
			if (startTime == 0) {
				startTime = Time.time;
			}

			if (Time.time - startTime > workDuration) {
				pindah_temapat_sembunyi = true;
			}
		}
		//Debug.Log ("sembunyi"+ sembunyi);
		mts.sembunyi = true;
		lbr.aman = true;
		return true;
	}
//	private NavMeshAgent navmesh;
//	public pathfinding Instence;
	// Use this for initialization
//	void Start () {
//		navmesh = GetComponent<NavMeshAgent>();
//		int i;
//		if (Instence.coba == true) {
//			Debug.Log ("aaaa");
//			for (i = 0; i < Instence.target.Length; i++) {
//				if (Instence.target[i] != Instence.target[Instence.z] ) {
//					Debug.Log ("benar");
//					navmesh.SetDestination (Instence.target[i].position);
//				}
//			}
//		}
//	}
	
	// Update is called once per frame
//	void Update () {
//		if (Vector3.Distance (transform.position, Instence.desitination.position) <= 1) {
//			Instence.desitination =
//			Transform temp = Instence.target[Random.Range(0, Instence.target.Length)];
//			while (Instence.desitination.Equals (temp)) {
//				temp = Instence.target[Random.Range(0, Instence.target.Length)];
//			}
//			Instence.desitination = temp;
//			navmesh.SetDestination (Instence.desitination.position);
//		}
//	}
}
