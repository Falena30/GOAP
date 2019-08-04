using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
public class menuju_tempat_sembunyi : GoapAction {
	[SerializeField]
	public bool sembunyi = false;
	private tujuan_sembunyi tagetObject;
	//sembunyi = false;
	private int z;
	private NavMeshAgent navComponent; 
	public Transform desitination;
	private WorldCondition wC;
	Labourer lbr;
	private FirstPersonController fs;
	misc mis;
	float timerM;
	menuju_tempat_sembunyi mts;
	menuju_tempat_sembunyi mts2;
	menuju_tempat_sembunyi mts3;
	menuju_tempat_sembunyi mts4;
	public int tamp;

	public menuju_tempat_sembunyi(){
		addEffect ("is_sembunyi", true);
        addPrecondition("is_lari", true);
	}

	public override void reset(){
		//sembunyi = false;
		target = null;
	}

	public override bool isDone(){
		return sembunyi;
	}

	public override bool requiresInRange(){
		return false;
	}
		
	public override bool checkProceduralPrecondition(GameObject enemy){
		lbr = GetComponent<Labourer> ();
		navComponent = GetComponent<NavMeshAgent> ();
		wC = GetComponent<WorldCondition> ();
		mis = GameObject.Find ("enemy").GetComponent<misc> ();
		fs = GameObject.Find ("player").GetComponent<FirstPersonController> ();

		timerM = 10f;


		target = mis.tempat_sembunyi [lbr.tampung].transform;
			wC.simpan = target;
			return target!=null;
	}

	public override bool perform (GameObject enemy)
	{
		navComponent.SetDestination (target.position);
        if (Physics.Raycast(lbr.mata.position, transform.forward, lbr.jarakPandang, lbr.layerId2))
        {
            navComponent.speed = 7;
            tamp = Random.Range(0, mis.enemy.Length);
            target = mis.tempat_sembunyi[tamp].transform;
            navComponent.SetDestination(target.position);
            return false;
        }
        else
        {
            if (Mathf.Ceil(Vector3.Distance(transform.position, target.position)) == 5f)
            {
                print("cek");
                Vector3 pusat = transform.position;
                Collider[] hitColliders = Physics.OverlapSphere(pusat, 10f);
                int i = 0;
                int hitung = 0;
                while (i < hitColliders.Length)
                {
                    menuju_tempat_sembunyi satu = hitColliders[i].GetComponent<menuju_tempat_sembunyi>();
                    if (satu)
                    {
                        if (satu.sembunyi)
                        {
                            hitung++;
                        }
                    }
                    menuju_tempat_sembunyi dua = hitColliders[i].GetComponent<menuju_tempat_sembunyi>();
                    if (dua)
                    {
                        if (dua.sembunyi)
                        {
                            hitung++;
                        }
                    }
                    i++;
                }

                if (hitung >= 2)
                {
                    print("Ngumpet liane!");
                    tamp = Random.Range(0, mis.enemy.Length);
                    target = mis.tempat_sembunyi[tamp].transform;
                    navComponent.SetDestination(target.position);
                }
            }

            if (Vector3.Distance (transform.position, target.position) <= 3) {
				if (fs.enabled == true) {
					if(timerM<0){
						sembunyi = true;
						wC.dlek = true;
						//eksekusi
					} else {
						//--
						//if<0
						timerM = timerM - 1f * Time.deltaTime;
						//reset 10
					}
				} 
			}

            Debug.Log("sukss");
            return true;
		}
        
		//return true;
		}
		
	}
			

