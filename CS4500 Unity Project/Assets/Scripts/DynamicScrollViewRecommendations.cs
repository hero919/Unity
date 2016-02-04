using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of DynamicScrollView controlling the entire Scroll View area of 
 * the Recommendations page/scene. Handles list population and display.
 */
public class DynamicScrollViewRecommendations : DynamicScrollView
{
	// How far through the found recommendations we've displayed.
	private int recommendations_position = 0;

	/**
	 * Initializer function. Retrieves the currently logged in user's recommendations
	 * from the database and adds them to the list.
	 */
	public override void OnEnable ()
	{
		GlobalInfo.get_recommendations ();
		InitializeList ();
	}

	/**
	 * Wrapped initializer function.
	 */
	protected override void InitializeList ()
	{
		// Delete any old elements that are hanging around
		ClearOldElements();

		// Add our initial elements, as long as there are still recommendations to add
		while (recommendations_position < noOfItems && recommendations_position < 
		     	GlobalInfo.cached_recommended_IDs.Count) {
			InitializeNewItem ((string) GlobalInfo.cached_recommended_IDs[recommendations_position]);
			recommendations_position++;
		}

		// Resize.
		SetContentHeight ();
	}

	/**
	 * Initializes a new entry for the scroll view, using information connected to the
	 * given opportunity ID. If the ID is invalid, nothing happens; otherwise, the name
	 * and text for a new instance of the object are changed to the values of the
	 * opportunity retrieved from the database.
	 */
	protected override void InitializeNewItem (string op_id)
	{
		// Get our Opportunity or return
		Opportunity op = Database.get_opportunity(op_id);
		if (op == null) return;

		// Create our object
		GameObject newItem = Instantiate (item) as GameObject;

		// Allocate the name/text field
		newItem.name = "";
		newItem.name += op.opportunity_name + '\n';
		newItem.name += op.location + '\n';
		newItem.name += op.begin_date.ToString() + " to " + op.end_date.ToString() + '\n';

		// Add tags
		for (int i = 0; i < op.tags.Count; i++) {
			Tag tag = Database.get_tag((string) op.tags[i]);
			if (tag == null) continue;
			newItem.name += tag.tag_name + ", ";
		}

		// Set script and callback values for the new item
		newItem.GetComponent<ScrollItemOpportunity>().linkID = op.opportunityID;
		newItem.GetComponent<Button>().onClick.AddListener(newItem.GetComponent<ScrollItemOpportunity>().OnClick);

		// Place and activate the item
		newItem.transform.parent = gridLayout.transform;
		newItem.transform.localScale = Vector3.one;
		newItem.SetActive (true);
	}

	/**
	 * Attempts to add a new element to the current layout. Does nothing if there
	 * are not more opportunities to add (with a maximum of 500).
	 */
	public override void AddNewElement ()
	{
		// Only add new elements if we haven't hit the max
		if (recommendations_position <  GlobalInfo.cached_recommended_IDs.Count) {

			// Add our item and resize
		    InitializeNewItem ((string) GlobalInfo.cached_recommended_IDs[recommendations_position]);
			recommendations_position++;
			SetContentHeight ();
			StartCoroutine (MoveTowardsTarget (0.2f, scrollRect.verticalNormalizedPosition, 0));
		}
	}
}
