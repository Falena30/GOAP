using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy_agent : Labourer {
	public override HashSet<KeyValuePair<string,object>> createGoalState () {
        // membuat goal
		HashSet<KeyValuePair<string,object>> goal = 
            new HashSet<KeyValuePair<string,object>> ();
		getWorldState ();
		// main goal
		if (myTabrak[0] == true || sembu == true &&
            bergerak == true && playerjauhjipong == true ) {
			goal.Add(new KeyValuePair<string, object>("is_jipong",true));}
		// gaol awal
		if(sembu == false){
			goal.Add(new KeyValuePair<string, object>("is_observasi",true));	
			sembu = true;}
		// sub goal
		if (aman == false) {
			goal.Add(new KeyValuePair<string, object>("is_aman",true));	
		}return goal;}
}
