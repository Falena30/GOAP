using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

/**
 * A general labourer class.
 * You should subclass this for specific Labourer classes and implement
 * the createGoalState() method that will populate the goal for the GOAP
 * planner.
 */
public abstract class Labourer : MonoBehaviour, IGoap
{
	public Transform mata;
	public float jarakPandang;
	public string namaLayer;
	public string namaLayer2;
	public int layerId;
	public int layerId2;
	public Transform[] tempat_sembu;
	public float moveSpeed = 1;
	public bool player_dekat = false;
	public bool[] myTabrak;
	public bool[] giliran_maju;

	public float jarak;
	public bool bergerak;
	public bool sembu;
	pidah_tempat pd_tempat;
	public int tampung;
	public int tampung1;
	public float[] jark;
	WorldCondition wc;
    RaycastHit hit;
    enemy_kabur ek;
	menuju_tempat_sembunyi mts;
	menuju_tempat_sembunyi mts2;
	menuju_tempat_sembunyi mts3;
	menuju_tempat_sembunyi mts4;
    menuju_tempat_sembunyi mts5;
    menuju_tempat_sembunyi mts6;
    public bool[] count_enemy;
	public bool aman = true;
	//public bool sembunyi = false;
	public bool i;
    int jmlh_dihitung = 0;
    int jumlah_musuh_dihitung = 0;
	public float workDuration;
	public bool playerjauhjipong;
	public bool obsr;
	player_agent pg;
	public int timer;
	public float timer_nglaju;
	misc mis;
	public int jumlah_enemy;
	void Start ()
	{
		layerId = LayerMask.GetMask (namaLayer);
		layerId2 = LayerMask.GetMask (namaLayer2);

		// menambahkan komponen yang diperlukan
		pd_tempat = GetComponent<pidah_tempat> ();
        // meneukan target setiap enemy agent
		mts = GameObject.Find  ("enemy1").GetComponent<menuju_tempat_sembunyi> ();
		mts2 = GameObject.Find ("enemy2").GetComponent<menuju_tempat_sembunyi> ();
		mts3 = GameObject.Find ("enemy3").GetComponent<menuju_tempat_sembunyi> ();
		mts4 = GameObject.Find ("enemy4").GetComponent<menuju_tempat_sembunyi> ();
      //  mts5 = GameObject.Find ("enemy5").GetComponent<menuju_tempat_sembunyi> ();
       // mts6 = GameObject.Find ("enemy6").GetComponent<menuju_tempat_sembunyi> ();
        
        wc = GetComponent<WorldCondition> ();
		ek = GetComponent<enemy_kabur> ();
        //
		pg = GameObject.Find ("player").GetComponent<player_agent> ();
		mis = GameObject.Find ("enemy").GetComponent<misc> ();
		timer_nglaju = 5f;
		tempat_sembu = new Transform[mis.tempat_sembunyi.Length];
		giliran_maju = new bool[mis.enemy.Length];
        //count_enemy = new bool[mis.enemy.Length];
        //for (int count_enemy_loop = 0; count_enemy_loop < mis.enemy.Length; count_enemy_loop++) {
          //  count_enemy[count_enemy_loop] = true;
        //}
		for (int k = 0; k < mis.tempat_sembunyi.Length; k++) {
			tempat_sembu [k] = mis.tempat_sembunyi [k];
		}
		// menentukan taget awal tempat sembunyi untuk enemy
		tampung = wc.rand (mis);
        // untuk berganti tempat sembunyi jika sudah ditempati min 1 tempat
		//if (mts.target == mts2.target || mts.target == mts3.target || mts.target == mts4.target || mts.target == mts5.target || mts.target == mts6.target || mts2.target == mts3.target || mts2.target == mts4.target || mts2.target == mts5.target || mts2.target == mts6.target ||
			//mts3.target == mts4.target || mts3.target == mts5.target || mts3.target == mts6.target || mts4.target == mts5.target || mts4.target == mts6.target || mts5.target == mts6.target) {
			//tampung = wc.rand (mis);
		//}
		// deklarasi awal boolean
		myTabrak = new bool[mis.enemy.Length];
		for (int z = 0; z < mis.enemy.Length; z++) {
			myTabrak [z] = false;
		}
		sembu = false;
		bergerak = false;
		jumlah_enemy = mis.enemy.Length;
		jark = new float[mis.enemy.Length];
		for (int j = 0; j < mis.enemy.Length; j++) {
			jark [j] = Vector3.Distance (mis.enemy [j].transform.position, mis.player.transform.position);
			if (jark [j] < mis.jarak_player) {
				player_dekat = true;
			} else {
				player_dekat = false;
			}
		}
		workDuration = Random.Range (2, 5);
		if (Vector3.Distance (GameObject.FindWithTag ("Player").transform.position, GameObject.FindWithTag ("goal").transform.position) < 30) {
			playerjauhjipong = false;
		} else {
			playerjauhjipong = true;
		}

		timer = Random.Range (5, 8);


	}


	void Update ()
	{
		//if (mts.target == mts2.target || mts.target == mts3.target || mts.target == mts4.target || mts2.target == mts3.target || mts2.target == mts4.target ||
			//mts3.target == mts4.target) {
			//tampung = wc.rand (mis);
		//}


		if(timer_nglaju<0){
			
			timer_nglaju = Random.Range(6f,8f);
			//eksekusi
		} else {
			//--
			//if<0
			timer_nglaju = timer_nglaju - 1f * Time.deltaTime;
			//reset 10
		}

        //disini untuk membuat musuh bisa di satu tempat maksimal 2 kali
        //if (Physics.Raycast(mata.position, transform.forward, jarakPandang, layerId2))
        //{
            
          //  for (jumlah_musuh_dihitung = 0; jumlah_musuh_dihitung < mis.enemy.Length; jumlah_musuh_dihitung++) {
                
            //    if (hit.collider == mis.enemy[jumlah_musuh_dihitung].gameObject && count_enemy[jumlah_musuh_dihitung] == true)
              //  {
                //    count_enemy[jumlah_musuh_dihitung] = false;
                  //  jmlh_dihitung += 1;
                //}
            //}
            
           // Debug.Log(jmlh_dihitung);
            //navComponent.speed = 7;
            //tamp = Random.Range(0, mis.enemy.Length);
            //target = mis.tempat_sembunyi[tamp].transform;
            //navComponent.SetDestination(target.position);
            //return false;
        //}

        // jarak pandang dari enemy
        if (Physics.Raycast (mata.position, transform.forward, jarakPandang, layerId)) {
			aman = false;
			if (pd_tempat.tamp < tempat_sembu.Length) {
				pd_tempat.tamp += 1;		
			} else {
				pd_tempat.tamp = 0;
			}
			pd_tempat.JalanPSekarang (pd_tempat.tamp);

		} else {
			aman = true;
		}
		//Debug.DrawRay (mata.position, transform.forward*jarakPandang);
		// enemy mengetahui apakah player menemukan enemy atau tidak
		for(int z = 0; z< mis.enemy.Length;z++){
			myTabrak [z] = pg.MyTabrakEnemy [z];
		}
		// enemy mengehtahui player sudah bisa bergerak atau tidak
		bergerak = pg.enabled;

		// enemy mengetahui apakah player jauh dari jipong atau tidak
		if (Vector3.Distance (GameObject.FindWithTag ("Player").transform.position, GameObject.FindWithTag ("goal").transform.position) < 15) {
			playerjauhjipong = false;
		} else {
			playerjauhjipong = true;
		}
		// untuk mengetahui apakah player dekat dengan enemy atau tidak
		jark = new float[mis.enemy.Length];
		for (int j = 0; j < mis.enemy.Length; j++) {
			jark [j] = Vector3.Distance (mis.enemy [j].transform.position, mis.player.transform.position);
			if (jark [j] < mis.jarak_player) {
				player_dekat = true;
			} else {
				player_dekat = false;
			}

		}
		// tidak adak kabur dihilangkan juga tidak apa2 karena gameplay tidak menuntut kabur
		if (ek.enemey_flee == true) {
			jark = new float[mis.enemy.Length];
			for (int j = 0; j < mis.enemy.Length; j++) {
				jark [j] = Vector3.Distance (mis.enemy [j].transform.position, mis.player.transform.position);
				if (jark[j] < mis.jarak_player) {
					GameObject.FindWithTag ("Player").GetComponent<NavMeshObstacle> ().enabled = true;
				} else {
					GameObject.FindWithTag ("Player").GetComponent<NavMeshObstacle> ().enabled = false;
				}
			}

		}


	}

	/**
	 * Key-Value data that will feed the GOAP actions and system while planning.
	 */
	public HashSet<KeyValuePair<string,object>> getWorldState () {
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();

		worldData.Add(new KeyValuePair<string, object>("is_observasi", obsr));
		worldData.Add(new KeyValuePair<string, object>("is_sembunyi", sembu ));
		worldData.Add(new KeyValuePair<string, object>("is_jipong", false));
		worldData.Add(new KeyValuePair<string, object>("is_player_jauh", jarak > 15));
		worldData.Add(new KeyValuePair<string, object>("is_lari", false));
		worldData.Add(new KeyValuePair<string, object>("is_aman", aman));
		return worldData;
	}

	/**
	 * Implement in subclasses
	 */
	public abstract HashSet<KeyValuePair<string,object>> createGoalState ();


	public void planFailed (HashSet<KeyValuePair<string, object>> failedGoal)
	{
		// Not handling this here since we are making sure our goals will always succeed.
		// But normally you want to make sure the world state has changed before running
		// the same goal again, or else it will just fail.
	}

	public void planFound (HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
	{
		// Yay we found a plan for our goal
		Debug.Log ("<color=green>Plan found</color> "+GoapAgent.prettyPrint(actions));
	}

	public void actionsFinished ()
	{
		// Everything is done, we completed our actions for this gool. Hooray!
		Debug.Log ("<color=blue>Actions completed</color>");
	}

	public void planAborted (GoapAction aborter)
	{
		// An action bailed out of the plan. State has been reset to plan again.
		// Take note of what happened and make sure if you run the same goal again
		// that it can succeed.
		Debug.Log ("<color=red>Plan Aborted</color> "+GoapAgent.prettyPrint(aborter));
		createGoalState ();

	}

	public bool moveAgent(GoapAction nextAction) {
		// move towards the NextAction's target
		float step = moveSpeed * Time.deltaTime;
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
		
		if (gameObject.transform.position.Equals(nextAction.target.transform.position) ) {
			// we are at the target location, we are done
			nextAction.setInRange(true);
			return true;
		} else
			return false;
	}
}

