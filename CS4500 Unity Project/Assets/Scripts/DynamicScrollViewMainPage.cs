using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of DynamicScrollView controlling the entire Scroll View area of 
 * the Main Page page/scene. Handles list population and display.
 */
public class DynamicScrollViewMainPage : DynamicScrollView
{

	/**
	 * Initializer function. Retrieves the most recently added opportunities
	 * from the database and adds them to the list.
	 */
	public override void OnEnable ()
	{
		// Call the funciton to show all the opportunites in the list.
		InitializeList ();
	}

	/**
	 * Wrapped initializer function.
	 */
	protected override void InitializeList ()
	{
		//Clear the old data
		ClearOldElements();

		// Iterate over all the opportunities in hashtable.
		foreach (DictionaryEntry pair in Database.opportunityHash) {
			InitializeNewItem((string) pair.Key);
		}
		SetContentHeight ();
	}

	/**
	 * Initializes a new entry for the scroll view, using information connected to the
	 * given opportunity ID. If the ID is invalid, nothing happens; otherwise, the name
	 * and text for a new instance of the object are changed to the values of the
	 * opportunity retrieved from the database.
	 */
	protected override void InitializeNewItem(string id) {

		// Get our opportunity from the database
		Opportunity op = (Opportunity) Database.opportunityHash[id];
		string opportunityID = op.opportunityID;
		
		// Initialize our new entry
		GameObject newItem = Instantiate (item) as GameObject;
		
		// Set name, location, and date
		newItem.name = "";
		newItem.name += op.opportunity_name + '\n';
		newItem.name += op.location + '\n';
		newItem.name += op.begin_date.ToString() + " to " + op.end_date.ToString();
		
		// Make the button works and set the dynamic scroll bar.
		newItem.GetComponent<ScrollItemOpportunity> ().linkID = opportunityID;
		newItem.GetComponent<Button> ().onClick.AddListener (newItem.GetComponent<ScrollItemOpportunity> ().OnClick);
		newItem.transform.parent = gridLayout.transform;
		newItem.transform.localScale = Vector3.one;
		newItem.SetActive (true);
	}

	// Unused abstract method.
	public override void AddNewElement() {}
}
