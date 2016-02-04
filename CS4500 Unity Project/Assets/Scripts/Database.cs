using UnityEngine;
using System.Collections;

/**
 * A generic Database wrapper class, used to simulate a database that we don't
 * actually have access to. Ideally, all of this (except maybe the skill
 * definitions) should be stripped out and replaced with accessor functions to
 * a real server database.
 */
public class Database : MonoBehaviour
{
	// Hashtables to store the actual database info
	public static Hashtable studentHash = new Hashtable ();
	public static Date studentHashLastUpdated = new Date ();
	public static Hashtable opportunityHash = new Hashtable ();
	public static Date opportunityHashLastUpdated = new Date ();
	public static Hashtable tagHash = new Hashtable ();
	public static Date tagHashLastUpdated = new Date ();

	/****** skills ******/
	public static Skill Adaptable_Flexible = new Skill (true, true, false, true, true);
	public static Skill Advocacy = new Skill (false, false, true, false, false);
	public static Skill CC_Creative_Thinking = new Skill (true, true, true, true, true);
	public static Skill CC_Critical_Thinking = new Skill (true, true, true, true, true);
	public static Skill CC_Decision_Making = new Skill (true, true, true, true, true);
	public static Skill CC_Emotional_Intelligence = new Skill (true, true, true, true, true);
	public static Skill CC_Innovation_Design_Thinking = new Skill (true, true, true, true, true);
	public static Skill CC_Inquiry_and_Analysis = new Skill (true, true, true, true, true);
	public static Skill CC_Integrative_Thinking = new Skill (true, true, true, true, true);
	public static Skill CC_Knowledge_Acquisition = new Skill (true, true, true, true, true);
	public static Skill CC_Problem_Solving = new Skill (true, true, true, true, true);
	public static Skill CC_Quantitative_Reasoning = new Skill (true, true, true, true, true);
	public static Skill CC_Self_Awareness = new Skill (true, true, true, true, true);
	public static Skill CC_Strategic_Thinking = new Skill (true, true, true, true, true);
	public static Skill Civically_Minded = new Skill (false, false, true, false, false);
	public static Skill Collaboration_Teamwork = new Skill (true, true, false, true, false);
	public static Skill Communication = new Skill (true, true, true, true, false);
	public static Skill Conflict_Analysis = new Skill (false, false, true, false, false);
	public static Skill Creative_Expression = new Skill (true, false, false, false, false);
	public static Skill Cultural_and_Aesthetic_Arts = new Skill (true, false, false, true, false);
	public static Skill Curiosity_Inquisitiveness = new Skill (true, true, true, false, false);
	public static Skill Emotionally_Healthy = new Skill (false, false, false, false, true);
	public static Skill Empathy = new Skill (false, true, true, false, false);
	public static Skill Ethical_Reasoning = new Skill (false, true, true, true, true);
	public static Skill Financial_Literacy = new Skill (false, false, false, true, true);
	public static Skill Global_Citizenship = new Skill (false, false, true, false, false);
	public static Skill Global_Mindset = new Skill (false, true, true, false, false);
	public static Skill Independence_Autonomy = new Skill (false, false, false, false, true);
	public static Skill Information_Literacy = new Skill (true, true, false, true, true);
	public static Skill Initiative_Resourcefulness = new Skill (true, false, true, true, true);
	public static Skill Integrity = new Skill (false, true, false, true, false);
	public static Skill Intercultural_Understanding = new Skill (false, true, true, false, false);
	public static Skill Interpersonal_Skills = new Skill (false, true, true, false, false);
	public static Skill Networking = new Skill (false, false, true, true, true);
	public static Skill Observation_Interpretation = new Skill (false, true, true, false, false);
	public static Skill Open_Mindedness = new Skill (false, true, true, false, false);
	public static Skill Organization = new Skill (true, false, true, false, false);
	public static Skill Perseverance = new Skill (true, false, false, true, true);
	public static Skill Physical_Self_Care = new Skill (false, false, false, true, true);
	public static Skill Planning = new Skill (true, false, false, false, false);
	public static Skill Positive_Self_Esteem = new Skill (false, false, false, true, true);
	public static Skill Realistic_Self_Confidence = new Skill (false, false, true, true, false);
	public static Skill Resilience = new Skill (false, false, false, true, true);
	public static Skill Scientific_Imagination = new Skill (true, false, false, true, false);
	public static Skill Scientific_Literacy = new Skill (true, false, false, false, false);
	public static Skill Self_Directed_Learner = new Skill (true, false, false, true, false);
	public static Skill Social_Awareness = new Skill (false, false, true, false, false);
	public static Skill Social_Consciousness = new Skill (false, true, false, false, false);
	public static Skill Socially_Integrated = new Skill (false, false, false, false, true);

	/**
	 * An initializer function that fills the database with test data. Should be
	 * run as soon as the application starts. Really ugly, but kind of necessary.
	 */
	public static void initDatabase ()
	{
		studentHash.Clear ();
		tagHash.Clear ();
		opportunityHash.Clear ();

		// Set students and scores.
		Student s1 = new Student ("ritter.g", "Graham Ritter", "admin", "ritter.g@husky.neu.edu");
		Student s2 = new Student ("zheng.q", "Qiaozhi Zheng", "admin", "zheng.q@husky.neu.edu");
		Student s3 = new Student ("chaoID", "Chao Fang", "admin", "fang.chao1@husky.neu.edu");
		Student s4 = new Student ("parker.sar", "Sarah Parker", "admin", "parker.sar@husky.neu.edu");
		Student s5 = new Student ("zhang.ze", "Zeqing Zhang", "admin", "zhang.ze@husky.neu.edu");
		Student s6 = new Student ("dylanID", "Dylan Mayerchak", "admin", "dylanmayerchak@gmail.com");
		s1.score = new Score (1, 2, 3, 4, 5);
		s2.score = new Score (3, 4, 5, 6, 7);
		s3.score = new Score (1, 3, 2, 10, 2);
		s4.score = new Score (5, 24, 35, 2, 6);
		s5.score = new Score (5, 2, 2, 1, 7);
		s6.score = new Score (7, 4, 2, 8, 10);

		// Set opportunities.
		Opportunity e0 = new Opportunity ();

		Opportunity e1 = new Opportunity ("NUGOAL_1", "Northeastern University Growth Opportunities for Asian American Leaders (NU GOAL)",
		                                  Opportunity.OPPORTUNITY_FORMATS.TRAINING, new ArrayList{"Multicultural", "Leadership", "Community Engagement", "Exploring Identity"}, "Northeastern University Growth and Opportunity for Asian American Leaders is a program specifically designed for first and second year Asian American students who are looking to increase and gain experiences to empower themselves as leaders at Northeastern University and beyond. A cohort of students will be chosen based on their potential as future leaders and need for leadership development. This seven week program will focus on the intersection of leadership and Asian American racial identity through discussions and projects. It will be facilitated by current Asian American student leaders and AAC staff. Apply by December 1, 2015. View web site for more information: Website", 
		                                  new Date (2015, 12, 1), new Date (2015, 3, 0), Opportunity.OPPORTUNITY_LENGTH._3_499_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.ACTIVE, Opportunity.OPPORTUNITY_RECURRENCE.DAILY, "Boston Campus", 
		                                  true, 0f, "either", "Self-identify as Asian-American", "Asian American Center", "Kristine Din", 
		                                  "x5554", "k.din@neu.edu", new ArrayList{"Students will be able to define leadership in relationship to their own racial identity.", 
			"Students will be able to describe their leadership strengths.", "Students will be able to employ their leadership style and strengths in their daily lives.", "Students will be able to analyze leadership in the Asian American community.", "Students will be able to propose a meaningful intervention for building Asian American leadership capacity.", "Students will be able to assess the need for leadership development within the Asian American community at Northeastern."},
											new ArrayList{Communication, Collaboration_Teamwork, Social_Awareness, Networking, Organization, Planning});

		Opportunity e2 = new Opportunity ("PEERMENTORING", "Peer Mentoring Program", Opportunity.OPPORTUNITY_FORMATS.COURSE, new ArrayList{"Multicultural"}, "Asia Peer Mentoring program is a program for first year and transfer Asian-American students to connect with a community. Mentees will be paired with upper class students for support around themes of Asian-American identity and transition to Northeastern.", 
		                                  new Date (2015, 9, 15), new Date (2016, 5, 0), Opportunity.OPPORTUNITY_LENGTH._180_23999_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.GENERATIVE, Opportunity.OPPORTUNITY_RECURRENCE.EACH_FALL, "Boston Campus", 
		true, 0f, "either", "", "", "", "", "", new ArrayList (), new ArrayList {Communication, Collaboration_Teamwork, Intercultural_Understanding, Socially_Integrated});
		;

		Opportunity e3 = new Opportunity ("RA", "Resident Assistant", Opportunity.OPPORTUNITY_FORMATS.PROGRAM, new ArrayList{"Leadership role", "Peer mentor", "Program facilitator", "Officer", "Student clubs/organizations"}, "The Resident Assistant position at Northeastern provides students to take on a leadership position within our campus residence halls.  Resident Assistants are responsible for engaging with residents individually, programming to the needs of their community, assisting with crisis and duty response, and performing administrative tasks.",
		                                  new Date (2015, 8, 0), new Date (2015, 12, 0), Opportunity.OPPORTUNITY_LENGTH._30_5999_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.ACTIVE, Opportunity.OPPORTUNITY_RECURRENCE.EACH_SPRING, "Boston Campus", 
		                                  false, 0f, "On-campus", "", "Residential Life", "David Grimes", "617-373-7590", "d.grimes@neu.edu",
		                                  new ArrayList{"RAs will learn to be a mentor by providing support, resources, and guidance to the students residing in their community.", "RAs will gain empathy and understanding by engaging with residents individually and learn about them on a personal level.",
			"RAs will reflect on their own values and decision-making by responding to crises and incidents within their communities.", "RAs will navigate their leadership styles by working on a staff team for programming, duty response, training, and other administrative tasks."}, new ArrayList{Empathy, Open_Mindedness, Organization, Collaboration_Teamwork});

		Opportunity e4 = new Opportunity ("HALL", "Hall Council", Opportunity.OPPORTUNITY_FORMATS.PROGRAM, new ArrayList{"Campus administrative offices", "Northeastern community", "Leadership", "Community engagement", "Advocacy", "Governance"}, "Hall Councils at Northeastern provide an opportunity for residents to obtainleadership positions within their communities.  These leaders are responsible for advocating for the needs of their residents to the Resident Student Association and assisting in developing a strong and inclusive living community.",
		                                  new Date (2015, 8, 0), new Date (2016, 5, 0), Opportunity.OPPORTUNITY_LENGTH._5_899_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.ACTIVE, Opportunity.OPPORTUNITY_RECURRENCE.EACH_YEAR, "Boston Campus", 
		                                  true, 0f, "On-campus", "Must live in International Village to be on International Village Hall Council (building specific)", 
		                                  "Residential Life", "David Grimes", "617-373-7590", "d.grimes@neu.edu", 
		                                  new ArrayList{"Hall Council members will learn to be a mentor by providing support, resources, and guidance to the students residing in their community.", "Hall Council members will navigate their leadership styles by working on a staff team for programming, duty response, training, and other administrative tasks."}, 
										new ArrayList{Initiative_Resourcefulness, Independence_Autonomy, Socially_Integrated, Adaptable_Flexible, Communication, Integrity, Collaboration_Teamwork, Empathy, Social_Awareness, Open_Mindedness, Planning, Organization});

		// Fill databases.
		addStudent (s1);
		addStudent (s2);
		addStudent (s3);
		addStudent (s4);
		addStudent (s5);
		addStudent (s6);
		
		addOpportunity (e0);
		addOpportunity (e1);
		addOpportunity (e2);
		addOpportunity (e3);
		addOpportunity (e4);
	}

	/**
	 * Adds a new element to each of the hashtables.
	 */
	public static void addTag (Tag t)
	{
		tagHash.Add (t.tag_name, t);
	}

	public static void addStudent (Student s)
	{
		studentHash.Add (s.huskyID, s);
	}

	public static void addOpportunity (Opportunity o)
	{
		opportunityHash.Add (o.opportunityID, o);
	}

	/**
	 * Checks that the given login information is correct. Returns true if a student 
	 * with the given password exists for the given username, and returns false if
	 * either the password is incorrect, or no Student exists in the database with
	 * the given username.
	 * 
	 * @param username The username to check.
	 * @param password The password to check.
	 * @return A bool indicating if the login attempt was successful.
	 */
	public static bool checkInfo (string username, string password)
	{
		Student student_to_check = get_student (username);
		if (student_to_check != null && student_to_check.password == password) {
			Debug.Log (true);
			return true;
		} else {
			return false;
		}
	}

	/**
	 * Connects two students with the provided usernames as friends. If the
	 * database doesn't contain a student for either provided username, the
	 * method does nothing.
	 */
	public static void add_friend (string username1, string username2)
	{
		Student s1 = get_student (username1);
		Student s2 = get_student (username2);
		if (s1 != null && s2 != null) {
			s1.add_friend (username2);
			s2.add_friend (username1);
		}
	}

	/**
	 * Disconnects two students with the provided usernames as friends. If the
	 * database doesn't contain a student for either provided username, the
	 * method does nothing.
	 */
	public static void remove_friend (string username1, string username2)
	{
		Student s1 = get_student (username1);
		Student s2 = get_student (username2);
		if (s1 != null && s2 != null) {
			s1.remove_friend (username2);
			s2.remove_friend (username1);
		}
	}


	/**
	 * Retrives a Student with the given ID from the database. Should be used instead of
	 * directly accessing the database. If the ID doesn't exist, or is mapped to a non-
	 * Student value, then this returns null.
	 * 
	 * @param student_id The ID (key) used to retrieve an object from the database.
	 * @return The student with the given ID, or null if one does not exist.
	 */
	public static Student get_student (string student_id)
	{
		if (studentHash.ContainsKey (student_id)) {
			object hash_value = Database.studentHash [student_id];
			if (hash_value is Student) {
				return (Student)hash_value;
			}
		}
		return null;
	}

	/**
	 * Retrives an Opportunity with the given ID from the database. Should be used 
	 * instead of directly accessing the database. If the ID doesn't exist, or is mapped
	 * to a non-Opportunity value, then this returns null.
	 * 
	 * @param opportunity_id The ID (key) used to retrieve an object from the database.
	 * @return The opportunity with the given ID, or null if one does not exist.
	 */
	public static Opportunity get_opportunity (string opportunity_id)
	{
		if (opportunityHash.ContainsKey (opportunity_id)) {
			object hash_value = Database.opportunityHash [opportunity_id];
			if (hash_value is Opportunity) {
				return (Opportunity)hash_value;
			}
		}
		return null;
	}

	/**
	 * Retrives a Tag with the given ID from the database. Should be used instead 
	 * of directly accessing the database. If the ID doesn't exist, or is mapped
	 * to a non-Tag value, then this returns null.
	 * 
	 * @param tag_id The ID (key) used to retrieve an object from the database.
	 * @return The tag with the given ID, or null if one does not exist.
	 */
	public static Tag get_tag (string tag_id)
	{
		if (tagHash.ContainsKey (tag_id)) {
			object hash_value = Database.tagHash [tag_id];
			if (hash_value is Tag) {
				return (Tag)hash_value;
			}
		}
		return null;
	}

	/**
	 * Registers a given opportunity as completed for a given student. This adds the
	 * opportunity's score to the user's, as well as the associated skills, and
	 * adds the opportunity to the user's history.
	 * 
	 * @param opportunity_id The ID of the opportunity to register.
	 * @param user_id The ID of the user to register with.
	 * @return True if the operation was successful, false if not.
	 */
	public static bool complete_opportunity (string opportunity_id, string user_id)
	{

		// Get student and opportunity.
		Student s = get_student (user_id);
		Opportunity o = get_opportunity (opportunity_id);
		if (s == null || o == null) {
			return false;
		}

		// Do nothing if this user has already completed the opportunity
		if (s.opportunity_history.Contains (opportunity_id)) {
			return false;
		} else {

			// Add the opportunity to the user's history
			s.opportunity_history.Add (opportunity_id);

			// Get the score of this opportunity and apply it
			Score new_score = o.get_base_score ();
			int score_multiplier = (int)o.engagement * (int)o.length;
			new_score *= score_multiplier;
			s.score = Score.addScores (s.score, new_score);

			// Update player skill ratings for each skill in this opportunity
			ArrayList OppSkills = o.get_skills ();
			for (int i = 0; i<OppSkills.Count; i++) {
				if (s.skills.ContainsKey (OppSkills [i])) {
					s.skills [OppSkills [i]] = (int)s.skills [OppSkills [i]] + score_multiplier;
				} else {
					s.skills.Add (OppSkills [i], + score_multiplier);
				}
			}
		}
		Database.studentHashLastUpdated = Date.get_today ();
		return true;
	}

	/**
	 * Unregisters a given opportunity as completed for a given student. This 
	 * removes the opportunity's score from the user's, as well as the associated 
	 * skills, and removes the opportunity from the user's history.
	 * 
	 * @param opportunity_id The ID of the opportunity to unregister.
	 * @param user_id The ID of the user to unregister with.
	 * @return True if the operation was successful, false if not.
	 */
	public static bool delete_opportunity (string opportunity_id, string user_id)
	{
		// Get student and opportunity.
		Student s = get_student (user_id);
		Opportunity o = get_opportunity (opportunity_id);
		if (s == null || o == null) {
			return false;
		}

		// Do nothing if this user has not completed the opportunity
		if (!s.opportunity_history.Contains (opportunity_id)) {
			return false;
		} else {

			// Remove the opportunity from the user's history
			s.opportunity_history.Remove (opportunity_id);

			// Get the score of this opportunity and apply it
			Score new_score = o.get_base_score ();
			int score_multiplier = (int)o.engagement * (int)o.length;
			new_score *= score_multiplier;
			s.score = Score.minusScores (s.score, new_score);

			// Update player skill ratings for each skill in this opportunity
			ArrayList OppSkills = o.get_skills ();
			for (int i = 0; i<OppSkills.Count; i++) {
				if (s.skills.ContainsKey (OppSkills [i])) {
					s.skills [OppSkills [i]] = (int)s.skills [OppSkills [i]] - score_multiplier;
				} else {

				}
			}
		}
		Database.studentHashLastUpdated = Date.get_today ();
		return true;
	}

	/**
	 * Two sorting functions for dictionary comparison.
	 */
	public class DictionarySort : IComparer
	{
		public int Compare (object x, object y)
		{
			return Comparer.Default.Compare (((DictionaryEntry)x).Key, ((DictionaryEntry)y).Key);
		}
		
	}

	public class ReverseDictionarySort : IComparer
	{
		public int Compare (object x, object y)
		{
			return Comparer.Default.Compare (((DictionaryEntry)y).Key, ((DictionaryEntry)x).Key);
		}
		
	}

	/**
	 * Retrieves a list of IDs for recommended opportunities for a given user. Opportunities are
	 * returned, sorted in order from most-impactful to least-impactful on the user's two 
	 * weakest dimensions (so if a user's weakest dimensions are GA and SCIC, the earliest 
	 * results will be the opportunities with the highest reward for those dimensions). Only
	 * searches through the first 500 opportunities or so; this can be adjusted pretty easily.
	 */
	public static ArrayList get_recommended_opportunities (string username, string password)
	{

		const int MAX_RETURNED_OPPORTUNITIES = 500;

		// setup
		ArrayList result = new ArrayList ();
		if (!checkInfo (username, password)) {	// make sure we're the right user
			return result;
		}
		Student user = Database.get_student (username);
		Date today = Date.get_today ();

		// figure out which dimension we're looking to increase
		bool IA = false;
		bool GA = false;
		bool WB = false;
		bool SCIC = false;
		bool PPE = false;

		// get our current dimension scores
		ArrayList dimensions = new ArrayList ();
		dimensions.Add (new DictionaryEntry (user.score.GA, "GA"));
		dimensions.Add (new DictionaryEntry (user.score.WB, "WB"));
		dimensions.Add (new DictionaryEntry (user.score.SCIC, "SCIC"));
		dimensions.Add (new DictionaryEntry (user.score.IA, "IA"));
		dimensions.Add (new DictionaryEntry (user.score.PPE, "PPE"));

		// sort by score - the first two (smallest!) dimensions are what we're trying to increase
		dimensions.Sort (new DictionarySort ());
		for (int j = 0; j < 2; j++) {
			string dimension = (string)((DictionaryEntry)dimensions [j]).Value;
			if (dimension == "GA")
				GA = true;
			if (dimension == "WB")
				WB = true;
			if (dimension == "SCIC")
				SCIC = true;
			if (dimension == "IA")
				IA = true;
			if (dimension == "PPE")
				PPE = true;
		}

		// iterate through first 500? opportunities
		int i = 0;
		foreach (DictionaryEntry pair in Database.opportunityHash) {
			Opportunity op = (Opportunity)pair.Value;
			// skip opportunities we've already done or that are expired
			if (user.opportunity_history.Contains (pair.Key) || 
				today > op.end_date) {
				// do nothing
			} else {

				// store each valid opportunity along with it's score for the two
				// dimensions we're looking at
				Score s = op.get_base_score ();
				int score_multiplier = (int)op.engagement * (int)op.length;
				s *= score_multiplier;
				int op_value = 0;
				if (GA)
					op_value += s.GA;
				if (WB)
					op_value += s.WB;
				if (IA)
					op_value += s.IA;
				if (SCIC)
					op_value += s.SCIC;
				if (PPE)
					op_value += s.PPE;
				result.Add (new DictionaryEntry (op_value, op.opportunityID));

			}
			// exit after the max num of entries
			if (i++ > MAX_RETURNED_OPPORTUNITIES) {
				break;
			}
		}
		// sort our result by their stored scores: earlier entires will offer better
		// rewards in the desired dimensions
		result.Sort (new ReverseDictionarySort ());

		// strip out all of the score values; we just need IDs
		for (i = 0; i < result.Count; i++) {
			result [i] = ((DictionaryEntry)result [i]).Value;
		}
		return result;
	}
	/*
	 * Retreives a list of ID of all available opportunites
	 * */
	public static ArrayList get_all_opportunities (string username, string password)
	{

		ArrayList opList = new ArrayList ();
		if (!checkInfo (username, password)) {	// make sure we're the right user
			return opList;
		}

		// Iterate through opporunity Hash and add Opportunity ID into list
		foreach (DictionaryEntry opid in Database.opportunityHash) {
			Debug.Log ("Adding opportunity ID to the list: " + opid.Key);
			opList.Add (opid.Key);
			Debug.Log ("Length of opportunity list: " + opList.Count);
		}
		return opList;
	}

	/*
	 * Build a string description of the given Opportunity for general searching purpose
	 * */
	public static string general_search_string (Opportunity op)
	{
		string result = "";
		string op_id = op.opportunityID + " ";
		string op_name = op.get_name () + " ";
		ArrayList op_tags = op.get_tags ();
		Debug.Log ("Tag list length: " + op_tags.Count);
		result = result + op_id + op_name;
		foreach (string t in op_tags) {
			result = result + t + "/";
		}
		result = result.ToLower ();
		return result;
	}
	/*
	 * Build a string description of the given Opportunity for Advanced searching purpose
	 * */
	public static string advanced_search_string (Opportunity op)
	{
		string result = "";
		string op_id = op.opportunityID + " ";
		string op_name = op.get_name () + " ";
		ArrayList op_tags = op.get_tags ();
		Debug.Log ("Tag list length: " + op_tags.Count);
		result = result + op_id + op_name;
		foreach (string t in op_tags) {
			result = result + t + "/";
		}
		string op_loc = op.location + " ";
		string op_bd = op.begin_date.ToString () + " ";
		string op_ed = op.end_date.ToString () + " ";
		string type = "";

		if (op.opportunity_format == Opportunity.OPPORTUNITY_FORMATS.COURSE) {
			type = "COURSE" + " ";
		}
		if (op.opportunity_format == Opportunity.OPPORTUNITY_FORMATS.PROGRAM) {
			type = "PROGRAM" + " ";
		} else {
			type = "TRAINING" + " ";
		}

		result = result + op_loc + op_bd + op_ed + type;
		result = result.ToLower ();
		return result;
	}



	////Tests
	/// 
	/// 
	/// 
	public static void testDatabase ()
	{

		TestHarness.reset_testing();
		
		//Test addTag() Method;
		Tag t1 = new Tag ("Asian");
		Tag t2 = new Tag ("Peer");
		addTag (t1);
		addTag (t2);
		TestHarness.check_test ("Check adding the Tag: ", tagHash.Contains ("Asian"));
		TestHarness.check_test ("Check adding the Tag: ", tagHash.Contains ("Peer"));
		
		TestHarness.check_test ("get_tag() success test", get_tag ("Asian") != null);
		TestHarness.check_test ("get_tag() fails test", get_tag ("lkasd") == null);
		TestHarness.check_test ("get_tag() equality test 1", get_tag ("Asian") == t1);
		TestHarness.check_test ("get_tag() equality test 2", get_tag ("Asian") != t2);
		TestHarness.check_test ("get_tag() equality test 3", get_tag ("Peer") == t2);

		Student s = get_student ("ritter.g");
		Debug.Log (s == null);
		Score sc1 = s.score;
		TestHarness.check_test ("complete_opportunity() success test", Database.complete_opportunity ("ritter.g", "NUGOAL_1"));
		TestHarness.check_test ("complete_opportunity() failure test 1", !Database.complete_opportunity ("ritter.g", "NUGOAL_1"));
		TestHarness.check_test ("complete_opportunity() failure test 2", !Database.complete_opportunity ("rter.g", "NUGOAL_1"));
		TestHarness.check_test ("complete_opportunity() failure test 3", !Database.complete_opportunity ("ritter.g", "NOAL_1"));
		TestHarness.check_test ("complete_opportunity() failure test 4", !Database.complete_opportunity ("rer.g", "N1"));
		TestHarness.check_test ("complete_opportunity() affected database 1", s.opportunity_history.Contains ("NUGOAL_1"));
		TestHarness.check_test ("complete_opportunity() affected database 2", s.score == (sc1 + new Score (16, 8, 16, 12, 4)));

		TestHarness.check_test ("delete_opportunity() success test", Database.delete_opportunity ("ritter.g", "NUGOAL_1"));
		TestHarness.check_test ("delete_opportunity() failure test 1", !Database.delete_opportunity ("ritter.g", "NUGOAL_1"));
		TestHarness.check_test ("delete_opportunity() failure test 2", !Database.delete_opportunity ("rter.g", "NUGOAL_1"));
		TestHarness.check_test ("delete_opportunity() failure test 3", !Database.delete_opportunity ("ritter.g", "NOAL_1"));
		TestHarness.check_test ("delete_opportunity() failure test 4", !Database.delete_opportunity ("rer.g", "N1"));
		
		TestHarness.check_test ("delete_opportunity() affected database 1", !s.opportunity_history.Contains ("NUGOAL_1"));
		TestHarness.check_test ("delete_opportunity() affected database 2", s.score == sc1);

		TestHarness.check_test ("get_recommended_opportunities() 1", get_recommended_opportunities (s.huskyID, s.password).Contains ("HALL"));
		TestHarness.check_test ("get_recommended_opportunities() 2", get_recommended_opportunities (s.huskyID, s.password).Contains ("PEERMENTORING"));

		ArrayList allops = get_all_opportunities ("ritter.g", "admin");
		TestHarness.check_test ("get_all_opportunities() 1", allops.Contains ("HALL"));
		TestHarness.check_test ("get_all_opportunities() 2", allops.Contains ("NUGOAL_1"));
		TestHarness.check_test ("get_all_opportunities() 3", allops.Contains ("testID"));
		TestHarness.check_test ("get_all_opportunities() 4", allops.Contains ("PEERMENTORING"));
		TestHarness.check_test ("get_all_opportunities() 5", allops.Contains ("RA"));
		TestHarness.check_test ("get_all_opportunities() 6", allops.Count == 5);

		Debug.Log (general_search_string(get_opportunity("NUGOAL_1")));
		TestHarness.check_test ("general_search_string() 1", general_search_string(get_opportunity("NUGOAL_1")) == "nugoal_1 northeastern university growth opportunities for asian american leaders (nu goal) multicultural/leadership/community engagement/exploring identity/");
		TestHarness.check_test ("advanced_search_string() 1", advanced_search_string(get_opportunity("NUGOAL_1")) == "nugoal_1 northeastern university growth opportunities for asian american leaders (nu goal) multicultural/leadership/community engagement/exploring identity/boston campus 2015/12/1 2015/3/0 training ");

		TestHarness.print_progress();
	}

	public static void testDatabase02(){
		
		//Test addTag() Method;
		Tag t1 = new Tag ("Asian");
		t1.events = new ArrayList{"NUGOAL_1"} ;
		Tag t2 = new Tag ("Peer");
		t2.events = new ArrayList{"PEERMENTORING", "RA"};
		Tag t3 = new Tag ("Student");
		t3.events = new ArrayList{"PEERMENTORING", "RA","Hall"};
		addTag (t1);
		TestHarness.check_test ("Check adding the Tag with one opportunity: ", tagHash.Contains ("Asian")==true);
		addTag (t2);
		TestHarness.check_test ("Check adding the Tag with two opportunity: ", (tagHash.Contains ("Asian")&&tagHash.Contains ("Peer"))==true);
		addTag (t3);
		TestHarness.check_test ("Check adding the Tag with three opportunity ", (tagHash.Contains ("Student")&&tagHash.Contains ("Asian")&&tagHash.Contains ("Peer"))==true);
		
		
		//Test addStudent() Method;
		Student s1 = new Student ("ritter.g", "Graham Ritter", "admin", "ritter.g@husky.neu.edu");
		Student s2 = new Student ("zheng.q", "Qiaozhi Zheng", "admin", "zheng.q@husky.neu.edu");
		Student s3 = new Student ("chaoID", "Chao Fang", "admin", "fang.chao1@husky.neu.edu");
		addStudent (s1);
		TestHarness.check_test ("Check adding the new student: ", studentHash.Contains("ritter.g")==true);
		addStudent (s2);
		TestHarness.check_test ("Check adding two new students: ", (studentHash.Contains("zheng.q")&&studentHash.Contains("ritter.g"))==true);
		addStudent (s3);
		TestHarness.check_test ("Check adding three new students: ", (studentHash.Contains("zheng.q")&&studentHash.Contains("ritter.g")&&studentHash.Contains("chaoID"))==true);
		
		
		
		
		//Test addOpportunity() Method;
		Opportunity e1 = new Opportunity ("NUGOAL_1", "Northeastern University Growth Opportunities for Asian American Leaders (NU GOAL)",
		                                  Opportunity.OPPORTUNITY_FORMATS.TRAINING, new ArrayList{"Multicultural", "Leadership", "Community Engagement", "Exploring Identity"} , "Northeastern University Growth and Opportunity for Asian American Leaders is a program specifically designed for first and second year Asian American students who are looking to increase and gain experiences to empower themselves as leaders at Northeastern University and beyond. A cohort of students will be chosen based on their potential as future leaders and need for leadership development. This seven week program will focus on the intersection of leadership and Asian American racial identity through discussions and projects. It will be facilitated by current Asian American student leaders and AAC staff. Apply by December 1, 2015. View web site for more information: Website", 
		new Date (2015, 12, 1), new Date (2015, 3, 0), Opportunity.OPPORTUNITY_LENGTH._3_499_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.ACTIVE, Opportunity.OPPORTUNITY_RECURRENCE.DAILY, "Boston Campus", 
		true, 0f, "either", "Self-identify as Asian-American", "Asian American Center", "Kristine Din", 
		"x5554", "k.din@neu.edu", new ArrayList{"Students will be able to define leadership in relationship to their own racial identity.", 
			"Students will be able to describe their leadership strengths.", "Students will be able to employ their leadership style and strengths in their daily lives.", "Students will be able to analyze leadership in the Asian American community.", "Students will be able to propose a meaningful intervention for building Asian American leadership capacity.", "Students will be able to assess the need for leadership development within the Asian American community at Northeastern."} ,
		new ArrayList{Communication, Collaboration_Teamwork, Social_Awareness, Networking, Organization, Planning});
		
		Opportunity e2 = new Opportunity ("PEERMENTORING", "Peer Mentoring Program", Opportunity.OPPORTUNITY_FORMATS.COURSE, new ArrayList{"Multicultural"} , "Asia Peer Mentoring program is a program for first year and transfer Asian-American students to connect with a community. Mentees will be paired with upper class students for support around themes of Asian-American identity and transition to Northeastern.", 
		new Date (2015, 9, 15), new Date (2016, 5, 0), Opportunity.OPPORTUNITY_LENGTH._180_23999_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.GENERATIVE, Opportunity.OPPORTUNITY_RECURRENCE.EACH_FALL, "Boston Campus", 
		true, 0f, "either", "", "", "", "", "", new ArrayList (), new ArrayList {Communication, Collaboration_Teamwork, Intercultural_Understanding, Socially_Integrated});
		;
		
		Opportunity e3 = new Opportunity ("RA", "Resident Assistant", Opportunity.OPPORTUNITY_FORMATS.PROGRAM, new ArrayList{"Leadership role", "Peer mentor", "Program facilitator", "Officer", "Student clubs/organizations"} , "The Resident Assistant position at Northeastern provides students to take on a leadership position within our campus residence halls.  Resident Assistants are responsible for engaging with residents individually, programming to the needs of their community, assisting with crisis and duty response, and performing administrative tasks.",
		new Date (2015, 8, 0), new Date (2015, 12, 0), Opportunity.OPPORTUNITY_LENGTH._30_5999_HOURS, Opportunity.LEVEL_OF_ENGAGEMENT.ACTIVE, Opportunity.OPPORTUNITY_RECURRENCE.EACH_SPRING, "Boston Campus", 
		false, 0f, "On-campus", "", "Residential Life", "David Grimes", "617-373-7590", "d.grimes@neu.edu",
		new ArrayList{"RAs will learn to be a mentor by providing support, resources, and guidance to the students residing in their community.", "RAs will gain empathy and understanding by engaging with residents individually and learn about them on a personal level.",
			"RAs will reflect on their own values and decision-making by responding to crises and incidents within their communities.", "RAs will navigate their leadership styles by working on a staff team for programming, duty response, training, and other administrative tasks."} , new ArrayList{Empathy, Open_Mindedness, Organization, Collaboration_Teamwork});
		
		
		
		addOpportunity (e1);
		TestHarness.check_test("Check adding one new opportunity", opportunityHash.Contains(e1.opportunityID)==true);
		
		addOpportunity (e2);
		TestHarness.check_test ("Check adding two new opportunities", (opportunityHash.Contains (e1.opportunityID) && opportunityHash.Contains (e2.opportunityID))==true);
		
		addOpportunity (e3);
		TestHarness.check_test ("Check adding two new opportunities", (opportunityHash.Contains (e1.opportunityID) && opportunityHash.Contains (e2.opportunityID) && opportunityHash.Contains (e3.opportunityID)) == true);
		
		
		
		//TestCheckInfo
		TestHarness.check_test ("check if the username and password are both correct: ",checkInfo ("ritter.g","admin") == true);
		
		TestHarness.check_test ("check if the username and password are both correct: ",checkInfo ("chaoID","admin") == true);
		
		TestHarness.check_test ("check if the username is correct but the password is wrong: ",checkInfo ("ritter.g","123") == false);
		
		TestHarness.check_test ("check if the username is correct but the password is wrong: ",checkInfo ("chaoID","234") == false);
		
		TestHarness.check_test ("check if we can't find the username: ",checkInfo ("qin.yue","admin") == false);
		
		
		
		//TestGetStudent
		
		TestHarness.check_test ("Check wheher we can get the student only given that student id: ", 
		                        (get_student("ritter.g") != null)&& (get_student("ritter.g") is Student)&&(get_student("ritter.g").huskyID.Equals("ritter.g"))==true);
		
		TestHarness.check_test ("Check wheher we can get the student only given that student id: ", 
		                        (get_student("zheng.q") != null)&& (get_student("zheng.q") is Student)&&(get_student("zheng.q").huskyID.Equals("zheng.q"))==true);
		
		TestHarness.check_test ("Check wheher we can get the student only given that student id: ", 
		                        (get_student("chaoID") != null)&& (get_student("chaoID") is Student)&&(get_student("chaoID").huskyID.Equals("chaoID"))==true);
		
		//Test AddFriend
		add_friend ("ritter.g","zheng.q");
		TestHarness.check_test ("Check whether one persoen can successfully add another friend as his friend :",
		                        ((get_student("ritter.g"))).friend_IDs.Contains("zheng.q")&&get_student("zheng.q").friend_IDs.Contains("ritter.g"));

		//Test remove_friend
		add_friend ("ritter.g","zhang.ze");
		remove_friend ("ritter.g","zheng.q");
		TestHarness.check_test ("Check whether one persoen can successfully remove another friend:",
		                        (((get_student("ritter.g"))).friend_IDs.Contains("zheng.q")||get_student("zheng.q").friend_IDs.Contains("ritter.g"))==false);
		


		//Test get_opportunity
		TestHarness.check_test ("Check whether we can get the opportunity only from id: ", get_opportunity(e1.opportunityID).opportunityID.Equals(e1.opportunityID));
		TestHarness.check_test ("Check whether we can get the opportunity only from id: ", get_opportunity(e2.opportunityID).opportunityID.Equals(e2.opportunityID));

		
		


	}












}