using UnityEngine;
using System.Collections;

/**
 * A class containing rankings for each of the five dimensions. May be used
 * to represent the scores of a specific student, or the points
 * awarded for completing an opportunity.
 */
public class Score
{
	public enum Dimension{
		IA,
		GA,
		SCIC,
		PPE,
		WB
	}

	// The score for Intellectual Agility.
	public int IA;
	// The score for Global Awareness.
	public int GA;
	// The score for Social Consciousness and Interpersonal Commitment.
	public int SCIC;
	// The score for Professional and Personal Effectiveness.
	public int PPE;
	// The score for Well-Being.
	public int WB;
	
	// Constructor.
	public Score (int IA, int GA, int SCIC, int PPE, int WB)
	{
		this.IA = IA;
		this.GA = GA;
		this.SCIC = SCIC;
		this.PPE = PPE;
		this.WB = WB;
	}
	
	public static Score operator + (Score s1, Skill s2) {
		if (s2.get_IA()) s1.IA++;
		if (s2.get_GA()) s1.GA++;
		if (s2.get_SCIC()) s1.SCIC++;
		if (s2.get_PPE()) s1.PPE++;
		if (s2.get_WB()) s1.WB++;
		return s1;
	}

	public static Score operator + (Score s1, Score s2) {
		s1.IA += s2.IA;
		s1.PPE += s2.PPE;
		s1.SCIC += s2.SCIC;
		s1.GA += s2.GA;
		s1.WB += s2.WB;
		return s1;
	}

	public static Score operator * (Score s1, int i) {
		s1.IA *= i;
		s1.GA *= i;
		s1.WB *= i;
		s1.SCIC *= i;
		s1.PPE *= i;
		return s1;
	}
	
	
	public override string ToString() {
		return "IA(" + IA + ") GA(" + GA + ") SCIC(" + SCIC + ") PPE(" + PPE + ") WB(" + WB + ")";
	}

	//Returns the score for a given dimension
	public int GetScoreForDimension(Dimension dim){
		switch(dim){
		case Dimension.IA:
			return IA;
		case Dimension.GA:
			return GA;
		case Dimension.SCIC:
			return SCIC;
		case Dimension.PPE:
			return PPE;
		case Dimension.WB:
			return WB;
		default:
			return 0;
		}
	}





	//s1 is the scores the student has for now.
	public static Score addScores(Score s1, Score s2){
		Score finalOne = new Score(0,0,0,0,0);
		finalOne.IA = s1.IA + s2.IA;
		finalOne.GA = s1.GA + s2.GA;
		finalOne.SCIC = s1.SCIC + s2.SCIC;
		finalOne.PPE = s1.PPE + s2.PPE;
		finalOne.WB = s1.WB + s2.WB;
		return finalOne;
	}


	//s1 is the scores the student has for now.
	public static Score minusScores(Score s1, Score s2){
		Score finalOne = new Score(0,0,0,0,0);
		finalOne.IA = s1.IA - s2.IA;
		finalOne.GA = s1.GA - s2.GA;
		finalOne.SCIC = s1.SCIC - s2.SCIC;
		finalOne.PPE = s1.PPE - s2.PPE;
		finalOne.WB = s1.WB - s2.WB;
		return finalOne;
	}








}

