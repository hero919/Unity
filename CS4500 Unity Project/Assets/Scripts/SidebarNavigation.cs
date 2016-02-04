using UnityEngine;
using System.Collections;

/**
 * Navigation handler for the sidebar. These can probably just be replaced
 * with calls to a NavigationHandler script object, since this just wraps
 * those functions.
 */
public class SidebarNavigation : MonoBehaviour {

	// Loads the main page.
	public void onClickMainPage(){
		new NavigationHandler().LoadMainPage();		
	}

	// Does nothing, for now
	public void OnClickName() {

	}

	// Loads the user profile
	public void OnClickProfile() {
		new NavigationHandler().LoadProfile(GlobalInfo.storedUserName);
	}

	// Loads the rankings page
	public void OnClickRanking() {
		new NavigationHandler().LoadRankings();
	}

	// Loads the search page
	public void OnClickSearch() {
		new NavigationHandler().LoadSearch();
	}

	// Loads the recommendations page
	public void OnClickRecommended() {
		new NavigationHandler().LoadRecommendations();
	}

	// Loads the friends page
	public void OnClickFriends() {
		new NavigationHandler().LoadFriends();
	}

	// Loads the settings page
	public void OnClickSettings() {
		new NavigationHandler().LoadSettings();
	}
}
