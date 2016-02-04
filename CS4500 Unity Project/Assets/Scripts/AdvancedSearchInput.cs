using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Class controlling the input for the Advanced Search function.
 */
public class AdvancedSearchInput : MonoBehaviour {

	// Buffers for each of the input fields
	private static string locationInput = "";
	private static string timeInput = "";
	private static string typeInput = "";
	private static string keywordInput = "";
	// Array containing filters for the search
	private static ArrayList advancedInput = new ArrayList();
	// Collection of all of the returned opportunity IDs
	public static ArrayList advanced_search_result;
	// Dropdown menu for the opportunity types.
	public Dropdown typeDropdown;

	/**
	 * Functions for getting the appropriate text from each of the 
	 * search input fields.
	 */
	public void getKeywordInput(string input) {
		keywordInput = input;
	}
	public void getLocationInput(string input) {
		locationInput = input;
	}
	public void getTimeInput(string input) {
		timeInput = input;
	}

	/**
	 * Function to get opportunity types from the dropdown menu.
	 */
	public void getType(string name) {	
		switch (typeDropdown.value) {
		case 1:
			typeInput = "COURSE";
			break;
		case 2:
			typeInput = "TRAINING";
			break;
		case 3:
			typeInput = "PROGRAM";
			break;
		case 0:
			typeInput = "";
			break;
		}
	}

	/**
	 * Run Advanced search through the list of opportunites ID
	 */
	public void advancedSearch() {

		// Clear the current search filter and repopulate it
		// with converted inputs
		advancedInput.Clear ();
		if (keywordInput.Length > 0) {
			keywordInput = keywordInput.ToLower();
			advancedInput.Add(keywordInput);
		}
		if (locationInput.Length > 0) {
			locationInput = locationInput.ToLower();
			advancedInput.Add(locationInput);
		}
		if (timeInput.Length > 0) {
			timeInput = timeInput.ToLower();
			advancedInput.Add(timeInput);
		}
		if (typeInput.Length > 0) {
			typeInput = typeInput.ToLower();
			advancedInput.Add(typeInput);
		}

		// Reset search lists
		ArrayList search_list = new ArrayList();
		advanced_search_result = new ArrayList();

		if (SearchInputField.general_search_result.Count == 0) {
			search_list = GlobalInfo.cached_opportunities;
		}
		else {
			search_list = SearchInputField.general_search_result;
		}

		foreach(string opid in search_list) {
			string description = Database.advanced_search_string(Database.get_opportunity(opid));
			int search_level = advancedInput.Count;
			foreach(string input in advancedInput) {
				if (description.Contains(input)) {
					search_level = search_level - 1;
				}
			}
			if (search_level == 0) {
				advanced_search_result.Add(opid);
			}
			else {
			}
		}
	}
}
