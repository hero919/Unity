using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdatePassword : MonoBehaviour
{

	//The current user password
	public GameObject currentPasswordInput;

	//The new password
	public GameObject newPasswordInput;


	//If you click the button then the current password should become the new password
	public void OnClickUpdatePassword ()
	{
		//testOnClieckUpdatePassword ();
		string password = null;
		foreach (DictionaryEntry pair in Database.studentHash){
			if(GlobalInfo.storedUserName.Equals(pair.Key)){
				//Get the current student password and check whether the password is the same as the student entered
				password = ((Student)(pair.Value)).password;
				if ((currentPasswordInput.GetComponent<UnityEngine.UI.Text> ().text).Equals (password)) {
					Debug.Log("The past password is "+ password);
					if(newPasswordInput.GetComponent<UnityEngine.UI.Text>().text != null){
						((Student)(pair.Value)).password = newPasswordInput.GetComponent<UnityEngine.UI.Text>().text;
						Debug.Log("The new password is "+ ((Student)(pair.Value)).password);

					}else{
						Debug.Log("Please enter a new password");
					}
				}else{
					Debug.Log("The password is not correct.");
				}
			}
		}

	}







	//Tests
	public void testOnClieckUpdatePassword(){
		string password = null;
		foreach (DictionaryEntry pair in Database.studentHash){
			if(GlobalInfo.storedUserName.Equals(pair.Key)){
				//Get the current student password and check whether the password is the same as the student entered
				password = ((Student)(pair.Value)).password;
				TestHarness.check_test ("check if the current password is correct: ", (currentPasswordInput.GetComponent<UnityEngine.UI.Text> ().text).Equals (password));
				if ((currentPasswordInput.GetComponent<UnityEngine.UI.Text> ().text).Equals (password)) {
					Debug.Log("The past password is "+ password);
					if(newPasswordInput.GetComponent<UnityEngine.UI.Text>().text != null){
						((Student)(pair.Value)).password = newPasswordInput.GetComponent<UnityEngine.UI.Text>().text;
						TestHarness.check_test ("check if the password is changed: ", (currentPasswordInput.GetComponent<UnityEngine.UI.Text> ().text).Equals (password));
						//Debug.Log("The new password is "+ ((Student)(pair.Value)).password);
					}
				}
			}
		}



	}















}
