using UnityEngine;
using System.Collections;

/**
 * Represents an Opportunity that a student can undertake, and contains some related enums.
 */
public class Opportunity
{
	// TODO move these enums out?
	
	/**
	 * The myriad formats that an opportunity can take.
	 */
	public enum OPPORTUNITY_FORMATS
	{
		PROGRAM,
		COURSE,
		TRAINING
	}
	
	/**
	 * Each of the different periods of recurrence that an Opportunity can have.
	 */
	public enum OPPORTUNITY_RECURRENCE
	{
		DAILY,
		WEEKLY,
		MONTHLY,
		EACH_FALL,
		EACH_SPRING,
		EACH_SUMMER,
		EACH_YEAR
	}
	
	
	public enum OPPORTUNITY_LENGTH
	{
		_1_299_HOURS = 1,
		_3_499_HOURS = 2,
		_5_899_HOURS = 3,
		_9_1599_HOURS = 4,
		_16_2999_HOURS = 5,
		_30_5999_HOURS = 6,
		_60_8999_HOURS = 7,
		_90_11999_HOURS = 8,
		_120_17999_HOURS = 9,
		_180_23999_HOURS = 10,
		_240_29999_HOURS = 11,
		_300_39999_HOURS = 12,
		_400_OR_MORE = 13,
	}
	
	public enum LEVEL_OF_ENGAGEMENT {
		PASSIVE = 1,
		ACTIVE = 2,
		GENERATIVE = 3
	}
	
	/**
	 * Different kinds of academic standing that a student must be able to 
	 * satisfy before they can take part in this event.
	 * 
	 * TODO do we actually have to check these?
	 */
	public enum ACADEMIC_STANDING
	{
		ANY,
		FIRST_YEAR,
		SECOND_YEAR,
		THIRD_YEAR,
		FOURTH_YEAR,
		FIFTH_YEAR,
		TRANSFER,
		NU_IN,
		LAST_YEAR,
		LAST_SEMESTER
	}
	
	// The unique ID of this opportunity. Only used internally.
	public string opportunityID = "testID";
	// The public display name of this opportunity.
	public string opportunity_name = "test_opportunity";
	// The format of this opportunity.
	public OPPORTUNITY_FORMATS opportunity_format = OPPORTUNITY_FORMATS.COURSE;
	// A collection of IDs for tags associated with this opportunity.
	public ArrayList tags = new ArrayList();
	// The description of this opportunity.
	public string description = "this is a description";
	// Start and end dates that this opportunity is available.
	public Date begin_date = new Date (1970, 1, 1);
	public Date end_date = new Date (1993, 9, 1);
	// The approximate length that this opportunity will take to complete.
	public OPPORTUNITY_LENGTH length = OPPORTUNITY_LENGTH._1_299_HOURS;
	// The level of engagement for this opportunity.
	public LEVEL_OF_ENGAGEMENT engagement = LEVEL_OF_ENGAGEMENT.PASSIVE;
	// How frequently this opportunity occurs.
	public OPPORTUNITY_RECURRENCE recurrence = OPPORTUNITY_RECURRENCE.DAILY; // TODO make this an array list, change the constructor
	// The location of this opportunity.
	public string location = "Boston, MA, 440 Huntington Ave";
	// Can you participate in this opportunity while on co-op?
	public bool is_coop_friendly = true;
	// Minimum GPA required for participation
	public float minimum_gpa = 2.0f;
	public string resident_status = "not required"; 
	public string other_requirements = "none";
	public string college_or_department = "College of Computer and Information Science";
	public string contact_name = "Jane Doe";
	public string contact_phone = "555-5555";
	public string contact_email = "admin@www.org";
	public ArrayList learning_outcomes = new ArrayList{"Students will learn cool stuff!"} ;
	public ArrayList skills;
	public ArrayList possible_majors;
	
	/** 
	 * Default constructor. Should only used for testing.
	 */
	public Opportunity ()
	{
	}
	
	/**
	 * The Big Constructor. Pretty self-explanatory.
	 * 
	 * TODO add majors
	 */
	public Opportunity (string opportunityID, string opportunity_name, OPPORTUNITY_FORMATS opportunity_format, ArrayList tags, string description, Date begin_date, 
	                    Date end_date, OPPORTUNITY_LENGTH length, LEVEL_OF_ENGAGEMENT engagement, OPPORTUNITY_RECURRENCE recurrence, string location, bool is_coop_friendly, float minimum_gpa, string resident_status,
	                    string other_requirements, string college_or_department, string contact_name, string contact_phone,
	                    string contact_email, ArrayList learning_outcomes, ArrayList skills)
	{
		this.opportunityID = opportunityID;
		this.opportunity_name = opportunity_name;
		this.opportunity_format = opportunity_format;
		this.tags = tags;
		this.description = description;
		this.begin_date = begin_date;
		this.end_date = end_date;
		this.length = length;
		this.engagement = engagement;
		this.recurrence = recurrence;
		this.location = location;
		this.is_coop_friendly = is_coop_friendly;
		this.minimum_gpa = minimum_gpa;
		this.resident_status = resident_status;
		this.other_requirements = other_requirements;
		this.college_or_department = college_or_department;
		this.contact_name = contact_name;
		this.contact_phone = contact_phone;
		this.contact_email = contact_email;
		this.learning_outcomes = learning_outcomes;
		this.skills = skills;
		
		//		// Add tags
		//		for (int i = 0; i < tags.Count; i++) {
		//			this.tag_opportunity ((string)tags [i]);
		//		}
	}

	/**
	 * Retrieves the opportunity score (unscaled by engagement or length)
	 * based on the contained skills.
	 */
	public Score get_base_score() {
		Score s = new Score(0, 0, 0, 0, 0);
		foreach (Skill skill in skills) {
			s += skill;
		}
		return s;
	}

	/******* GETTERS***********/
	public ArrayList get_tags() {
		return this.tags;
	}
	public string get_name(){
		return this.opportunity_name;
	}	
	public string get_location(){
		return this.location;
	}
	public ArrayList get_skills(){
		return skills;	
	}
	public Date get_begin_date(){
		return begin_date;
	}
	public Date get_end_date(){
		return end_date;
	}
	public float get_minimum_gpa(){
		return minimum_gpa;
	}
	public string get_description(){
		return description;
	}
	public string get_contact_email(){
		return contact_email;
	}
	public string get_contact_phone(){
		return contact_phone;
	}
	public string get_contact_name(){
		return contact_name;
	}
	
	/**
	 * Adds a tag to this opportunity. Fails if there's already an entry in the 
	 * database that isn't a tag. If there aren't any entries in the database
	 * with the given name, a new tag is created.
	 * 
	 * @param tag_name The name of the tag to be added to this opportunity.
	 * @return A bool indicating the success of the method.
	 */
	public bool tag_opportunity (string tag_name)
	{
		// TODO we should probably use accessors here, but this is safer right now
		if (Database.tagHash.ContainsKey(tag_name)) {
			object hash_value = Database.tagHash[tag_name];
			if (hash_value is Tag) {
				if (((Tag) hash_value).events.Contains(this.opportunityID)) {
					// do nothing
				}  else {
					((Tag) hash_value).events.Add(this.opportunityID);
				}
			}  else {
				return false;
			}
		}  else {
			Database.tagHash.Add(tag_name, new Tag(tag_name));
			((Tag) Database.tagHash[tag_name]).events.Add(this.opportunityID);
		}
		if (!this.tags.Contains(tag_name)) {
			this.tags.Add(tag_name);
		}
		return true;
	}
}



