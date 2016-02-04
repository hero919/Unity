using UnityEngine;
using System.Collections;

/**
 * Class containing profile information for a student.
 */
public class Student
{
	// This student's Husky ID. Used for login and as a primary key in the database.
	public string huskyID;
	// This student's full name. Maybe editable?
	public string student_name;
	// This student's password.
	public string password = "admin";
	// This student's current score across each of the five dimensions.
	public Score score = new Score (0, 0, 0, 0, 0);
	// Tracks the player's current progress in each of the skills. Keys are Skills,
	// Values are integer scores. Maps Skills to Ints
	public Hashtable skills = new Hashtable();
	// This student's NEU email address.
	public string email;
	// A profile picture for the user, if one exists.
	public Texture profile_pic = new Texture ();
	// This student's major
	public string major = "Undeclared";
	//This student's year
	public int year = 1;
	// The husky IDs of each student this student has added as a friend. Strings only.
	public ArrayList friend_IDs = new ArrayList ();
	// The IDs of each of the user's finished Opportunities. Most recent Opportunities
	// are at the back.
	public ArrayList opportunity_history = new ArrayList ();
	// Indicates whether or not this player has already finished their self-assessment.
	public bool has_finished_quiz = false;
	
	/**
	 * Constructor for a new Student.
	 * 
	 * @param huskyID The ID for the new student.
	 * @param student_name The name for the new student.
	 * @param password The initial password for the new student.
	 * @param email The email address of the new student.
	 */
	public Student (string huskyID, string student_name, string password, string email)
	{
		this.huskyID = huskyID;
		this.student_name = student_name;
		this.password = password;
		this.email = email;
	}

	/**
	 * Returns this student's opportunity history.
	 */
	public ArrayList get_opportunity_history(){
		return opportunity_history;
	}

	/**
	 * Adds a new friend ID to this student's friends list.
	 * 
	 * @param new_friend_id The ID of the new friend.
	 */
	public void add_friend (string new_friend_id)
	{
		if (!this.friend_IDs.Contains(new_friend_id)) {
			this.friend_IDs.Add (new_friend_id);
		}
	}

	/**
	 * Removes a friend ID from this student's friends list.
	 * 
	 * @param new_friend_id The ID of the new friend.
	 */
    public void remove_friend(string new_friend_id)
    {
        if (this.friend_IDs.Contains(new_friend_id))
        {
            this.friend_IDs.Remove(new_friend_id);
        }
    }
}
