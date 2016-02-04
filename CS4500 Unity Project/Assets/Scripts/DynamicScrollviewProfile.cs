using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of DynamicScrollView controlling the entire Scroll View area of 
 * the Profile page/scene. Handles list population and display.
 */
public class DynamicScrollViewProfile : DynamicScrollView
{

	/**
	 * Initializer function. Retrieves the currently logged in user's recent
	 * opportunities from the database and adds them to the list.
	 */
	public override void OnEnable ()
	{
		InitializeList ();
	}

	/**
	 * Wrapped Initializer function.
	 */
	protected override void InitializeList ()
	{
		ClearOldElements ();
		Student s = GlobalInfo.cached_profile;
		if (s == null) {
			return;
		}
		GlobalInfo.cached_recent_IDs.Clear ();
		for (int i = 0; i < s.opportunity_history.Count && i < 5; i++) {
			GlobalInfo.cached_recent_IDs.Add (s.opportunity_history [s.opportunity_history.Count - i - 1]);
		}
		for (int i = 0; i < GlobalInfo.cached_recent_IDs.Count; i++) {
			if (GlobalInfo.cached_recent_IDs[i] is string) {
				InitializeNewItem ((string) GlobalInfo.cached_recent_IDs[i]);
			}
		}
		SetContentHeight ();
		StartCoroutine (MoveTowardsTarget (0.2f, scrollRect.verticalNormalizedPosition, 0));
	}

	/**
	 * Initializes a new entry for the scroll view, using information connected to the
	 * given opportunity ID. If the ID is invalid, nothing happens; otherwise, the name
	 * and text for a new instance of the object are changed to the values of the
	 * opportunity retrieved from the database.
	 */
	protected override void InitializeNewItem (string id)
	{
		// Get our Opportunity or return
		Opportunity op = Database.get_opportunity(id);
		if (op == null) return;
		
		// Create our object
		GameObject newItem = Instantiate (item) as GameObject;
		
		// Allocate the name/text field
		newItem.name = "";
		newItem.name += op.opportunity_name + '\n';
		newItem.name += op.location + '\n';
		newItem.name += op.begin_date.ToString() + " to " + op.end_date.ToString() + '\n';
		
		// Set script and callback values for the new item
		newItem.GetComponent<ScrollItemOpportunity>().linkID = op.opportunityID;
		newItem.GetComponent<Button>().onClick.AddListener(newItem.GetComponent<ScrollItemOpportunity>().OnClick);
		
		// Place and activate the item
		newItem.transform.parent = gridLayout.transform;
		newItem.transform.localScale = Vector3.one;
		newItem.SetActive (true);
	}

	public override void AddNewElement ()
	{
	}

}
