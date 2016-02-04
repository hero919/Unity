using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Helper class for everything needed for an activity page.
 */
public class ActivityPage : MonoBehaviour
{
	
	// Opportunity to load into.
	Opportunity opp = new Opportunity ();
	
	// Fields for each aspect of the opportunity to display.
	public Text activityDescription;
	public Text IAScore;
	public Text GAScore;
	public Text PPEScore;
	public Text SCICScore;
	public Text WBScore;
	
	// References for the Button users click to mark an event
	// as having been attended.
	public Button Attend;
	
	public Text ButtonText;
	
	
	/**
	 * Initialization function.
	 */
	void Start ()
	{
		activityDescription.fontSize = 18;
		testChangeData ();
		changeData ();
	}
	
	/**
	 * Sets the displayed page info, based on the information contained in
	 * the cached Opportunity.
	 */
	private void changeData ()
	{
		opp = GlobalInfo.cached_opportunity;
		if (opp == null) {
			return;
		}
		string text = "";
		
		// Set text based on Opportunity fields
		text += "Description: " + opp.get_description() + '\n' + '\n';
		text += "Location: " + opp.get_location() + '\n' + '\n';
		text += "Minimum GPA Required:" + opp.get_minimum_gpa() + '\n' + '\n';
		text += "Begin Date: " + opp.get_begin_date() + '\n' + '\n';
		text += "End Date: " + opp.get_end_date() + '\n' + '\n';
		text += "Contacts Name: " + opp.get_contact_name() + '\n' + '\n';
		text += "Contacts Email: " + opp.get_contact_email() + '\n' + '\n';
		text += "Contacts Phone: " + opp.get_contact_phone() + '\n' + '\n';
		
		// Assign text to on-screen text box
		activityDescription.text = text;
		Score new_score = opp.get_base_score();
		int score_multiplier = (int)opp.engagement * (int)opp.length;
		new_score *= score_multiplier;
		// Get and display player scores in each of the five dimensions
		IAScore.text = new_score.IA.ToString() + '\n' + "IA";
		TestHarness.check_test ("check the whether the screen can show IA Score: ", !(new_score.IA==null));

		GAScore.text = new_score.GA.ToString()+ '\n' + "GA";
		TestHarness.check_test ("check the whether the screen can show GA Score: ", !(new_score.GA==null));

		PPEScore.text = new_score.PPE.ToString() + '\n' + "PPE";
		TestHarness.check_test ("check the whether the screen can show PPE Score: ", !(new_score.PPE==null));

		SCICScore.text = new_score.SCIC.ToString() + '\n' + "SCIC";
		TestHarness.check_test ("check the whether the screen can show SCIC Score: ", !(new_score.SCIC==null));

		WBScore.text = new_score.WB.ToString() + '\n' + "WB";
		TestHarness.check_test ("check the whether the screen can show WB Score: ", !(new_score.WB==null));

		
		
		if (((Student)Database.studentHash [GlobalInfo.storedUserName]).get_opportunity_history ().Contains (GlobalInfo.cached_opportunity.opportunityID)) {
			ButtonText.text = "Cancel Register";
		} else {
			ButtonText.text = "Need Register";
		}
		

	}
	

	
	//After clicking the register button. The opportunity will be registered. After clicking the cacel button. It will 
	//be removed from the list.
	public void addOpp ()
	{
		//Check whether we attended the event.
		if (((Student)Database.studentHash[GlobalInfo.storedUserName]).get_opportunity_history().Contains(GlobalInfo.cached_opportunity.opportunityID)) {
			ButtonText.text = "Need Register";
			Opportunity removeOpp = GlobalInfo.cached_opportunity;
			foreach (DictionaryEntry pair in Database.studentHash) {
				Debug.Log (((Student)(pair.Value)).huskyID.Equals (GlobalInfo.storedUserName));
				Score initialScore = ((Student)(pair.Value)).score;
				Hashtable initialStudentSkills = ((Student)(pair.Value)).skills;
				if (((Student)(pair.Value)).huskyID.Equals (GlobalInfo.storedUserName)) {
					Database.delete_opportunity (GlobalInfo.cached_opportunity.opportunityID, ((Student)(pair.Value)).huskyID);
					TestHarness.check_test ("check the whether the activity history deleted the new activity: ",((Student)(pair.Value)).get_opportunity_history().Contains(GlobalInfo.cached_opportunity.opportunityID)==false);
					TestHarness.check_test ("check the whether the five dimensions scores changes after deleting the opportunity: ",((Student)(pair.Value)).score.Equals(initialScore)==false);
					//TestHarness.check_test ("check the whether the skills score changes after deleting the opportunity: ",((Hashtable)(((Student)(pair.Value)).skills)).Cast<DictionaryEntry>().Union(initialStudentSkills.Cast<DictionaryEntry>()).Count() == ((Hashtable)(((Student)(pair.Value)).skills)).Count);
				}
			}
		} 
		else {
			ButtonText.text = "Cancel Register";
			Opportunity newOpp = GlobalInfo.cached_opportunity;
			foreach (DictionaryEntry pair in Database.studentHash) {
				Score initialScore = ((Student)(pair.Value)).score;
				if (((Student)(pair.Value)).huskyID.Equals (GlobalInfo.storedUserName)) {
					Database.complete_opportunity (GlobalInfo.cached_opportunity.opportunityID, ((Student)(pair.Value)).huskyID);
					TestHarness.check_test ("check the whether the activity history added the new activity: ",((Student)(pair.Value)).get_opportunity_history().Contains(GlobalInfo.cached_opportunity.opportunityID)==true);
					TestHarness.check_test ("check the whether the five dimensions scores changes after adding the opportunity: ",((Student)(pair.Value)).score.Equals(initialScore)==false);

				}
			}
		}
		
	}




	//The corresponding Tests;

	public void testChangeData(){


		//Tests whether we can get the opportunity information.
		TestHarness.check_test ("check the whether the screen can show the descriptions: ", !(GlobalInfo.cached_opportunity.description==null));
		TestHarness.check_test ("check the whether the screen can show the Location: ", !(GlobalInfo.cached_opportunity.location==null));
		TestHarness.check_test ("check the whether the screen can show the Minimum GPA Required: ", !(GlobalInfo.cached_opportunity.minimum_gpa==null));
		TestHarness.check_test ("check the whether the screen can show the Begin Date: ", !(GlobalInfo.cached_opportunity.begin_date==null));
		TestHarness.check_test ("check the whether the screen can show the End Date: ", !(GlobalInfo.cached_opportunity.end_date==null));
		TestHarness.check_test ("check the whether the screen can show the Contacts Name: ", !(GlobalInfo.cached_opportunity.contact_name==null));
		TestHarness.check_test ("check the whether the screen can show the Contacts Email: ", !(GlobalInfo.cached_opportunity.contact_email==null));
		TestHarness.check_test ("check the whether the screen can show the Contacts Phone: ", !(GlobalInfo.cached_opportunity.contact_phone==null));


	}






















	

}