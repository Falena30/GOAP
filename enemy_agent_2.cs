using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy_agent_2 : Labourer {
	public GameObject player;
	public float jarak_player = 30; 
	public int rand_tujuan_sembunyi;
	public bool giliran_enemy2 = false;
	public override HashSet<KeyValuePair<string,object>> createGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		getWorldState ();
		//main goal
		if (myTabrak[0] == false && myTabrak[1] == true && myTabrak[2] == false && myTabrak[3] == false || sembu == true && playerjauhjipong == true && bergerak == true) {
			goal.Add(new KeyValuePair<string, object>("is_jipong",true));
		}
		// goal awal
		if(sembu == false){
			goal.Add(new KeyValuePair<string, object>("is_observasi",true));	
			sembu = true;
		}
		// sub goal
		if (aman == false) {
			goal.Add(new KeyValuePair<string, object>("is_aman",true));	
		}
		return goal;
	}
}
