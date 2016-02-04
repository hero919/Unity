using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/**
 * Controller for the Rankings page.
 */
public class RanksController : MonoBehaviour {

	// This is linked to the number of rank prefabs in the scene
	// if you increase it, you need to also add more prefabs
	const int NUM_RANKS_SHOWN = 25;
	// The entries in the Rankings list.
	List<StudentRankController> studentRanks;

	/**
	 * Initializer function.
	 */
	void Start () {
		InitializeStudentRanks();
		SetupForDimension(Score.Dimension.IA);
	}

	/**
	 * Initializes the ranking system.
	 */
	private void InitializeStudentRanks(){
		// Retrieve each of the StudentRankControllers parented to this controller, and save them
		// as a list
		StudentRankController[] rankArray = GetComponentsInChildren<StudentRankController>();
		studentRanks = new List<StudentRankController>(rankArray);
	}

	
	
	/**
	 * Setup functions for each of the dimensions we could sort by.
	 */
	public void SetupForDimension_IA () { SetupForDimension(Score.Dimension.IA); }
	public void SetupForDimension_GA () { SetupForDimension(Score.Dimension.GA); }
	public void SetupForDimension_SCIC () { SetupForDimension(Score.Dimension.SCIC); }
	public void SetupForDimension_PPE () { SetupForDimension(Score.Dimension.PPE); }
	public void SetupForDimension_WB () { SetupForDimension(Score.Dimension.WB); }

	/**
	 * Sets up the current ranking list based on a provided dimension.
	 */
	public void SetupForDimension(Score.Dimension dimension){

		// Retrieves and sorts the current user's friends
		List<Student> students = GenerateRankingsList();
		SortStudentsByDimension(students, dimension);

		// Sets students for visibility
		for(int i = 0; i < NUM_RANKS_SHOWN; i++){
			if(i < students.Count && students[i] != null){
				studentRanks[i].SetForStudent(students[i], dimension);
			}else{
				studentRanks[i].SetVisibility(false);
			}
		}
	}

	/**
	 * Sorting functions.s
	 */
	private void SortStudentsByDimension(List<Student> students, Score.Dimension dim){
		switch(dim){
		case Score.Dimension.IA:
			students.Sort (CompareStudentsByDimension_IA);
			break;
		case Score.Dimension.GA:
			students.Sort (CompareStudentsByDimension_GA);
			break;
		case Score.Dimension.SCIC:
			students.Sort (CompareStudentsByDimension_SCIC);
			break;
		case Score.Dimension.PPE:
			students.Sort (CompareStudentsByDimension_PPE);
			break;
		case Score.Dimension.WB:
			students.Sort (CompareStudentsByDimension_WB);
			break;
		}
	}

	/**************************************
	 * Comparators.
	 *************************************/
	private static int CompareStudentsByDimension(Student x, Student y, Score.Dimension dim){
		int xScore = x != null ? x.score.GetScoreForDimension(dim) : 0;
		int yScore = y != null ? y.score.GetScoreForDimension(dim) : 0;
		
		if(xScore < yScore){
			return 1;
		}else if(xScore == yScore){
			return 0;
		}else{
			return -1;
		}
	}
	private static int CompareStudentsByDimension_IA(Student x, Student y){
		return CompareStudentsByDimension(x, y, Score.Dimension.IA);
	}
	private static int CompareStudentsByDimension_GA(Student x, Student y){
		return CompareStudentsByDimension(x, y, Score.Dimension.GA);
	}
	private static int CompareStudentsByDimension_SCIC(Student x, Student y){
		return CompareStudentsByDimension(x, y, Score.Dimension.SCIC);
	}
	private static int CompareStudentsByDimension_PPE(Student x, Student y){
		return CompareStudentsByDimension(x, y, Score.Dimension.PPE);
	}
	private static int CompareStudentsByDimension_WB(Student x, Student y){
		return CompareStudentsByDimension(x, y, Score.Dimension.WB);
	}

	/**
	 * Returns a list of each student in the current user's friends list.
	 */
	private List<Student> GenerateRankingsList(){
		// Retrieves friends and the current student
		List<Student> friends = new List<Student>();
        friends.Add(Database.get_student(GlobalInfo.storedUserName));
        Student me = Database.get_student(GlobalInfo.storedUserName);

		// Adds friends to the list and returns
        foreach (var item in me.friend_IDs)
        {
            friends.Add(Database.get_student((string)item));  // Assumes a console application
        }
        return friends;
	}
}
