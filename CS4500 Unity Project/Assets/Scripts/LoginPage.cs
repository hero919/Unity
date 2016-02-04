using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Class controlling the start/login page. Mostly just handles logins.
 */
public class LoginPage : MonoBehaviour
{

	// Input fields for login information.
	public GameObject usernameInput;
	public GameObject passwordInput;

	// Use this for initialization.
	void Start ()
	{
		if (TestHarness.run_tests) {
			Database.testDatabase02();
			Database.initDatabase();

		}
		Database.initDatabase(); // THIS IS EXTREMELY IMPORTANT
		testLogIn ();
	}

	/**
	 * Attempts to log the user in based on the provided login info. If the info
	 * is valid, the user either proceeds to the main page of the 
	 * self-assessment quiz.
	 */
	public void OnClickLogin ()
	{
		// Try to log in
		if (GlobalInfo.login (usernameInput.GetComponent<UnityEngine.UI.Text> ().text, 
		                      passwordInput.GetComponent<UnityEngine.UI.Text> ().text)) {

			// If the login is successful, stash the login info
			GlobalInfo.storedUserName = usernameInput.GetComponent<UnityEngine.UI.Text> ().text;
			GlobalInfo.storedPassword = passwordInput.GetComponent<UnityEngine.UI.Text> ().text;

			// Proceed to either the main page or the quiz
			if (Database.get_student(GlobalInfo.storedUserName).has_finished_quiz) {
				Application.LoadLevel ("3 Main Page");
			} else {
				Application.LoadLevel ("2 Self-Assesment");
			}
		} else {
			Debug.Log("Login Failed");
		}
	}






	public void testLogIn(){
		TestHarness.check_test ("check if the username and password are both correct: ",GlobalInfo.login ("zhang.ze","admin") == true);

		TestHarness.check_test ("check if the username and password are both correct: ",GlobalInfo.login ("ritter.g","admin") == true);

		TestHarness.check_test ("check if the username and password are both correct: ",GlobalInfo.login ("chaoID","admin") == true);

		TestHarness.check_test ("check if the username and password are both correct: ",GlobalInfo.login ("parker.sar","admin") == true);

		TestHarness.check_test ("check if the username and password are both correct: ",GlobalInfo.login ("dylanID","admin") == true);

		TestHarness.check_test ("check if the username is correct but the password is wrong: ",GlobalInfo.login ("zhang.ze","123") == false);

		TestHarness.check_test ("check if the username is correct but the password is wrong: ",GlobalInfo.login ("dylanID","234") == false);

//		This part doesn't work for some reason.
//		usernameInput.GetComponent<UnityEngine.UI.Text> ().text = "qin.yue";
//		passwordInput.GetComponent<UnityEngine.UI.Text> ().text = "123";
		TestHarness.check_test ("check if we can't find the username: ",GlobalInfo.login ("qin.yue","admin") == false);




	}











}
