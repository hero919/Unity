using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(CanvasGroup))]
[RequireComponent (typeof(Text))]
/**
 * Class controlling an entry for a specific student in the Rankings page.
 */
public class StudentRankController : MonoBehaviour
{
	// The id of the student
	private string id;
	// The name of the student represented.
	private Text studentName;
	// The student's score
	public Text score;
	// Allows this entry to be hidden
	private CanvasGroup canvasGroup;

	/**
	 * Initializer.
	 */
	void Awake ()
	{
		studentName = GetComponent<Text> ();
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	/**
	 * Displays the name and score of a given student across a given dimension.
	 */
	public void SetForStudent (Student student, Score.Dimension dimension)
	{
		if (student != null) {
			SetVisibility (true);
			id = student.huskyID;
			studentName.text = student.student_name;
			score.text = student.score.GetScoreForDimension (dimension) + "";
		} else {
			SetVisibility (false);
		}
	}

	/**
	 * Sets this object to be visible or invisible based on the input.
	 */
	public void SetVisibility (bool b)
	{
		canvasGroup.alpha = b ? 1 : 0;
		canvasGroup.interactable = b;
		canvasGroup.blocksRaycasts = b;
	}


	/**
	 * Loads this student's profile page
	 */
	public void InspectProfile(){
		new NavigationHandler().LoadProfile(id);
	}
}
