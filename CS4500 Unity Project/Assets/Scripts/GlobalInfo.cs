using UnityEngine;
using System.Collections;

/**
 * Globally accessible class of non-Database fields. Mostly used for carrying 
 * information between scenes.
 */
public class GlobalInfo : MonoBehaviour {

	// The currently logged in user and password combo.
	static public string storedUserName;
	static public string storedPassword;

    /** 
     * variables to load into when moving from screen to screen. A lot of these
	 * aren't used right now, but could be used in the future for better
	 * optimization.
	 */
	// Stored user profile.
    static public Student cached_profile;
	// Stored list of friend IDs.
	static public ArrayList cached_friend_IDs = new ArrayList();
	// Stored list of recently added opportunity IDs.
	static public ArrayList cached_recent_IDs = new ArrayList();
	// Stored list of recommended opportunity IDs.
	static public ArrayList cached_recommended_IDs = new ArrayList();
	// Stored list of search results (opportunity IDs).
	static public ArrayList cached_search_IDs = new ArrayList();
	// Stored large list of non-sorted opportunities.
	static public ArrayList cached_opportunities = new ArrayList();
	// Stored opportunity.
	static public Opportunity cached_opportunity;
	// The last date the cached opportunity was updated.
	static public Date cached_opportunity_last_updated;

	// Getter.
	static public string getUserName() {
		return storedUserName;
	}

	/**
	 * Login function. Goes straight to the checkInfo function in Database.
	 * 
	 * @return True if the login was succesful, false if else.
	 */
	static public bool login(string userName, string password) {
		return Database.checkInfo(userName, password);
	}

	/**
	 * Retrieves the recommendations for the currently logged in user.
	 */
	static public bool get_recommendations() {
		// don't bother regenning opportunities if our data hasn't changed
		/*if (cached_opportunity_last_updated < Database.opportunityHashLastUpdated || 
		    cached_opportunity_last_updated < Database.studentHashLastUpdated) {
			return false;
		}*/

		// clear the cache, load up our user
		cached_recommended_IDs.Clear();
		cached_recommended_IDs = Database.get_recommended_opportunities(storedUserName, storedPassword);
		return true;
	}

	/**
	 * Retrieves all opportunity IDs from the Database. This should not be used 
	 * with large databases - if possible, replace this with a function to 
	 * retrieve the opportunities in large chunks as needed.
	 */
	static public bool get_all_opportunities() {
		cached_opportunities.Clear();
		cached_opportunities = Database.get_all_opportunities(storedUserName, storedPassword);
		return true;
	}
}
