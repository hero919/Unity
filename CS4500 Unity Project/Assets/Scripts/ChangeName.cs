using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour {
	
	public Text Name;
	
	// Use this for initialization
	void Start () {
		Name.text = "    "+ ((Student)Database.studentHash [GlobalInfo.storedUserName]).student_name;
	}
	
	
}


