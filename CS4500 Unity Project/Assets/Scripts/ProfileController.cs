using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Class for controlling the Profile page.
 */
public class ProfileController : MonoBehaviour {

	// The DynamicScrollView containing previously attended opportunities
	public DynamicScrollViewProfile scrollView;

	// Text fields to fill
	public Text nameText;
	public Text yearText;
	public Text majorText;
	public Image profileImage;

	// Text fields to fill for dimensions and top scores
	public Text[] dimensionsTexts = new Text[5];
	public Text[] skillsTexts = new Text[5];

	/**
	 * Initializer.
	 */
	void Start () {
		SetupText(GlobalInfo.cached_profile);
	}

	/**
	 * Fills the profile text fields with retrieved Student information
	 */
	private void SetupText(Student s){
		if (s == null) return;

		// Fill basic information
		nameText.text = s.student_name;
		yearText.text = "Year " + s.year;
		majorText.text = s.major + " Major";
		// TODO profile image

		// Fill dimensions button text
		dimensionsTexts[0].text = s.score.IA 	+ "" + '\n' + " IA";
		dimensionsTexts[1].text = s.score.GA 	+ "" + '\n' + " GA";
		dimensionsTexts[2].text = s.score.PPE 	+ "" + '\n' + " PPE";
		dimensionsTexts[3].text = s.score.SCIC 	+ "" + '\n' + " SCIC";
		dimensionsTexts[4].text = s.score.WB 	+ "" + '\n' + " WB";

		// Fill top skll button text
		skillsTexts[0].text = "Empathy";
		skillsTexts[1].text = "Planning";
		skillsTexts[2].text = "Integrity";
		skillsTexts[3].text = "Advocacy";
		skillsTexts[4].text = "Networking";
	}
}
