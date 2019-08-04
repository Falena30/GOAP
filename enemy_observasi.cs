using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy_observasi : GoapAction {

	public Transform[] tamp;
	[SerializeField]
	private NavMeshAgent agent;
	private bool observasi = false;
	private float startTime = 0;
	public float workDuration = 2;
	public Transform[] desitination;
	private int i;
	private int j;
//	private bool done;
	private bool done1 = false;
	WorldCondition wC;
	Labourer lbr;
	misc mis;
    menuju_tempat_sembunyi mts;
	float timerM;
	public enemy_observasi(){
		addPrecondition ("is_sembunyi", true);
		addEffect ("is_observasi", true);
	}

	public override void reset(){
		observasi = false;
		startTime = 0;
		target = null;
		tamp [0] = null;
	}

	public override bool isDone(){
		return observasi;
	}

	public override bool requiresInRange(){
		return false;
	}

	public override bool checkProceduralPrecondition(GameObject enemy){
		wC = GetComponent<WorldCondition>();
		lbr = GetComponent<Labourer> ();
		agent = GetComponent<NavMeshAgent>();
        mts = GetComponent<menuju_tempat_sembunyi>();
		// salah sasaran untuk index
		mis = GameObject.Find ("enemy").GetComponent<misc> ();
		//timerM = lbr.timer;
		return true;
	}

	public override bool perform(GameObject enemy){
        if (mts.sembunyi == true)
        {
            for (i = 0; i < mis.area_obervasi.Length; i++)
            {
                if (Vector3.Distance(transform.position, mis.area_obervasi[i].position) < 6f)
                {
                    //tamp[0] = mis.area_obervasi[i];
                    if (tamp[0] == null)
                    {
                        tamp[0] = mis.area_obervasi[i];

                    }
                    else if (tamp[1] == null)
                    {
                        tamp[1] = mis.area_obervasi[i];
                    }
                    else
                    {
                        tamp[1] = mis.area_obervasi[i];
                    }
                }
            }
            //	for (i = 0; i < 5; i++) {

            // if (tamp[0] != null || tamp[1] != null) {

            if (done1 == false)
            {
                agent.SetDestination(tamp[0].position);
                Debug.Log("masuk g y?");
                if (startTime == 0)
                {
                    startTime = Time.time;
                }
                if (Time.time - startTime > workDuration)
                {
                    observasi = true;
                }
                done1 = true;
            }

            if (Vector3.Distance(transform.position, tamp[0].position) < 2 && done1 == true)
            {
                agent.SetDestination(tamp[1].position);
                if (startTime == 0)
                {
                    startTime = Time.time;
                }
                if (Time.time - startTime > workDuration)
                {
                    observasi = true;
                }
            }

            if (Vector3.Distance(transform.position, tamp[1].position) < 2 && done1 == true)
            {
                agent.SetDestination(tamp[0].position);
                if (startTime == 0)
                {
                    startTime = Time.time;
                }
                if (Time.time - startTime > workDuration)
                {
                    observasi = true;
                }
                //			done = true;
            }
            //}

            if (Vector3.Distance(transform.position, mis.tempat_jipong.transform.position) > 25)
            {
                timerM = Random.Range(4, 6);
                Debug.Log("jarak jauh : " + timerM);
                if (startTime == 0)
                {
                    startTime = Time.time;
                }
                if (Time.time - startTime > timerM)
                {
                    Debug.Log("waktu dekat : " + timerM);
                    //lbr.obsr = true;
                    //lbr.sembu = true;						
                    observasi = true;
                }
            }
            else
            {
                timerM = Random.Range(1, 3);
                Debug.Log("jarak dekat : " + timerM);
                if (startTime == 0)
                {
                    startTime = Time.time;
                }
                if (Time.time - startTime > timerM)
                {
                    Debug.Log("waktu dekat : " + timerM);

                    observasi = true;
                }
            }
            lbr.obsr = true;
            lbr.sembu = true;
            return true;
        }
        else {
            return false;
        }

	}
}
