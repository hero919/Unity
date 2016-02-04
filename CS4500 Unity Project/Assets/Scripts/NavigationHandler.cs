using UnityEngine;
using System.Collections;

/**
 * Collection of methods used to transition from page to page.
 */
public class NavigationHandler : MonoBehaviour {

	// Application.LoadLevel wrapper
	public static void LoadScene(string name){
		Application.LoadLevel (name);
	}

	// Loads the login page.
	public void LoadLogin(){
		LoadScene("1 Title+Login Screen");
	}

	// Loads the self-assessment quiz.
	public  void LoadSelfAssessment(){
		LoadScene("2 Self-Assesment");
	}

	// Loads the main page.
	public  void LoadMainPage(){
		LoadScene("3 Main page");
	}

	// Loads the settings.
	public  void LoadSettings(){
		LoadScene("4 Settings");
	}


	// Loads the activity page, and stores the provided opportunity for use
	// in the next page.

	public  void LoadChangeProfile(){
		LoadScene("12 ChangeInfo");
	}


	public  void LoadActivity(string opportunity_id){
		Opportunity opportunity_to_load = Database.get_opportunity(opportunity_id);
		if (opportunity_to_load != null) {
			GlobalInfo.cached_opportunity = opportunity_to_load;
		}
		LoadScene("5 Activity");
	}

	// Loads the Score Descriptions page.
	public  void LoadScoreDescriptions(){
		LoadScene("6 Score Descriptions");
	}

	// Loads the Rankings page.
	public  void LoadRankings(){
		LoadScene("7 Rankings");
	}

	// Loads the Friends page.
	public  void LoadFriends(){
		LoadScene("8 Friends");
	}

	// Loads the Recommendations page.
	public  void LoadRecommendations(){
		LoadScene("9 Recommendations");
	}

	// Loads the Search page.
	public  void LoadSearch(){
		LoadScene("10 Search");
	}

	// Loads the Profile page, and stores the provided student for use
	// in the next page.
	public void LoadProfile(string profile_id){
		Student student_to_load = Database.get_student(profile_id);
		if (student_to_load != null) {
			GlobalInfo.cached_profile = student_to_load;
		}
		LoadScene("11 Profile");
	}


	public void LoadMyProfile(){

		Student student_to_load = Database.get_student(GlobalInfo.storedUserName);
		if (student_to_load != null) {
			GlobalInfo.cached_profile = student_to_load;
		}
		LoadScene("11 Profile");


	}
}
