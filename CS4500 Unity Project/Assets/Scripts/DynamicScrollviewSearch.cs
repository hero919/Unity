using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of DynamicScrollView controlling the entire Scroll View area of 
 * the Search page/scene. Handles list population and display.
 */
public class DynamicScrollViewSearch : DynamicScrollView
{

	/**
	 * Initializer function. Retrieves the list of available opportunities from
	 * the database and initializes the list.
	 */
	public override void OnEnable ()
	{		
		GlobalInfo.get_all_opportunities ();
		InitializeList ();
	}

	/**
	 * Wrapped initializer function.
	 */
	protected override void InitializeList ()
	{
		// Delete any old elements that are hanging around and get the new
		// search result.
		ClearOldElements();

		ArrayList search_result = SearchInputField.general_search_result;

		// If the search result returned any opportunities, populate the list with them
		if (search_result.Count > 0) {
			int search_position = 0;
			while (search_position < search_result.Count) {
				InitializeNewItem ((string) search_result[search_position]);
				search_position++;
			}

			// Resize.
			SetContentHeight ();
		}
	}

	/**
	 * Modified version of the above method that uses the advanced search instead
	 * of the default search.
	 */
	public void InitializeAdvancedList ()
	{
		// Delete any old elements that are hanging around and get the new
		// search result.
		ClearOldElements ();
		ArrayList search_result = AdvancedSearchInput.advanced_search_result;
		
		// If the search result returned any opportunities, populate the list with them
		if (search_result.Count > 0) {
			int search_position = 0;
			while (search_position < search_result.Count) {
				InitializeNewItem ((string) search_result[search_position]);
				search_position++;
			}
			SetContentHeight ();
		}
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
	
	// Unused abstract implementation.
	public override void AddNewElement ()
	{
	}
}
