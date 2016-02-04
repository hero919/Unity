using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of DynamicScrollView controlling the entire Scroll View area of 
 * the Friends page/scene. Handles list population and display.
 */
public class DynamicScrollViewFriends : DynamicScrollView
{

	// Text of the friends search bar.
	public Text Input;

	/**
	 * Initializer function. Retrieves the currently logged in user's friends
	 * from the database and adds them to the list. 
	 */
	public override void OnEnable ()
	{
		if (GlobalInfo.storedUserName != null) {
			GlobalInfo.cached_friend_IDs = Database.get_student (GlobalInfo.storedUserName).friend_IDs;
			if (GlobalInfo.cached_friend_IDs != null) {
				InitializeList ();
			}
		}
	}

	/**
	 * Wrapped initializer function.
	 */
	protected override void InitializeList ()
	{
		foreach (string item in GlobalInfo.cached_friend_IDs) {
			InitializeNewItem (item);
			SetContentHeight ();
			StartCoroutine (MoveTowardsTarget (0.2f, scrollRect.verticalNormalizedPosition, 0));
		}
	}

	/**
	 * Initializes a new entry for the scroll view, using information connected to the
	 * given student ID. If the ID is invalid, nothing happens; otherwise, the name
	 * and text for a new instance of the object are changed to the values of the
	 * student retrieved from the database.
	 */
	protected override void InitializeNewItem (string ID)
	{

		// Set up the new list item
		Student student = Database.get_student (ID);
		if (student == null) {
			return; // TODO add error handling
		}
		GameObject newItem = Instantiate (item) as GameObject;

		// Set the item name to whatever text we need to display
		newItem.name = "";
		for (int i = 0; i < name.Length; i++) {
			//newItem.name += name [i] + '\n';
		}
		
		// Allocate the name/text field
		newItem.name = "";
		newItem.name += "Friend Name:" + student.student_name + '\n';
		newItem.name += student.email + '\n';
		
		// Set script and callback values for the new item
		newItem.GetComponent<ScrollItemStudent> ().linkID = ID;
		newItem.GetComponent<Button> ().onClick.AddListener (newItem.GetComponent<ScrollItemStudent> ().OnClick);

		// Place the item in our list
		newItem.transform.parent = gridLayout.transform;
		newItem.transform.localScale = Vector3.one;
		newItem.SetActive (true);
	}
		
	/**
	 * Adds a new friend to the list, based on the text in the input field. If there's no friend with the
	 * given name, then this function does nothing.
	 */
	public override void AddNewElement ()
	{
		// Get the desired student info
		string ID = Input.text;
		Student student = Database.get_student (ID);
		Debug.Log (ID);
		
		if (student != null) {

			// Attempt to add the students as friends, if they aren't already
			if (!Database.get_student (GlobalInfo.storedUserName).friend_IDs.Contains (ID)) {
				Database.add_friend (GlobalInfo.storedUserName, ID);

				// Add the new friend to the list and resize
				InitializeNewItem (ID);
				SetContentHeight ();
				StartCoroutine (MoveTowardsTarget (0.2f, scrollRect.verticalNormalizedPosition, 0));
			} else {
				Debug.Log ("This friend already exists");
			}
		} else {
			Debug.Log ("no NUID exists");
		}
	}
		
}
