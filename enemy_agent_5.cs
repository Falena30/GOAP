﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_agent_5 : Labourer {

	public GameObject player;
	public float jarak_player = 30; 
	public int rand_tujuan_sembunyi;
	public bool giliran_enemy4 = false;
	public override HashSet<KeyValuePair<string,object>> createGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		getWorldState ();
		// main goal
		if (myTabrak[4] == true|| sembu == true && playerjauhjipong == true && bergerak == true) {
			goal.Add(new KeyValuePair<string, object>("is_jipong",true));
		}
		//goal awal
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
