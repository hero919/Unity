using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SearchInputField : MonoBehaviour {

	private static string userInput;
	public static ArrayList general_search_result;
	private static string locationInput;
	private static string timeInput;
	private static string typeInput;
	private static string keywordInput;

	public void getInput(string input) {
		userInput = input;
		Debug.Log("You entered: " + input);
		InputField keyword = GameObject.Find ("KeywordInput").GetComponent<InputField> ();
		keyword.text = userInput;
	}

	public void setKeywordInput(string input) {
		keywordInput = input;
		Debug.Log("You entered: " + input);
	}

	public void setLocationInput(string input) {
		locationInput = input;
		Debug.Log("You entered: " + input);
	}

	public void setTimeInput(string input) {
		timeInput = input;
	}

	public void setTypeInput(string input) {
		typeInput = input;
	}


 
	// Run on scene load.
	void OnEnable ()
	{
		general_search_result = new ArrayList();
		if (Database.opportunityHash.Count == 0) Database.initDatabase();
		if (GlobalInfo.storedUserName == null) {
			GlobalInfo.storedUserName = "ritter.g"; 
			GlobalInfo.storedPassword = "admin";
		}
		GlobalInfo.get_all_opportunities ();
		//foreach (string opid in GlobalInfo.cached_opportunities) {
		//	string description = Database.general_search_string(Database.get_opportunity(opid));

		//	Debug.Log("Opportunity Description: \n" + description); 
		//}

		//InitializeList ();
	}



	/*
	 * Check whether the user input is contained in opportunity description
	 */
	public void check_description() {
		general_search_result.Clear ();
		userInput = userInput.ToLower ();
		bool result = false;
		foreach (string opid in GlobalInfo.cached_opportunities) {
			string description = Database.general_search_string(Database.get_opportunity(opid));
			if (description.Contains(userInput)) {
				general_search_result.Add(opid);
				Debug.Log("Search Result Length:" + general_search_result.Count + " ---- " + opid);
				Debug.Log("Opportunity Description: \n" + description); 
				result = true;

			}
		}
		Debug.Log ("Check Result is: " + result);
		//return result;

	}
}
