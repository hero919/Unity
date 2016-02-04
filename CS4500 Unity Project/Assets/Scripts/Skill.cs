using UnityEngine;
using System.Collections;

/**
 * Class representing one of the skills an Opportunity might contain.
 */
public class Skill {
	// These are all private because we don't want ANYONE changing them after
	// they've been constructed.
	private bool IA;
	private bool GA;
	private bool SCIC;
	private bool PPE;
	private bool WB;
	
	// Constructor.
	public Skill (bool IA, bool GA, bool SCIC, bool PPE, bool WB)
	{
		this.IA = IA;
		this.GA = GA;
		this.SCIC = SCIC;
		this.PPE = PPE;
		this.WB = WB;
	}
	
	/**      Getters for each field       **/
	public bool get_IA ()
	{
		return IA;
	}
	public bool get_GA ()
	{
		return GA;
	}
	public bool get_SCIC ()
	{
		return SCIC;
	}
	public bool get_PPE ()
	{
		return PPE;
	}
	public bool get_WB ()
	{
		return WB;
	}


	//Given a array of skills, calculate the corresponding IA. (Used to fill the scores of the opportunity)
	public static int calculateIA(ArrayList skills){
		int IA = 0;
		foreach(Skill s in skills){
			 if(s.get_IA()){
				IA = IA + 1;
			}
		}
		return IA;
	}

	public static int calculateGA(ArrayList skills){
		int GA = 0;
		foreach(Skill s in skills){
			if(s.get_GA()){
				GA = GA + 1;
			}
		}
		return GA;
	}
	public static int calculateSCIC(ArrayList skills){
		int SCIC = 0;
		foreach(Skill s in skills){
			if(s.get_SCIC()){
				SCIC = SCIC + 1;
			}
		}
		return SCIC;
	}
	public static int calculatePPE(ArrayList skills){
		int PPE = 0;
		foreach(Skill s in skills){
			if(s.get_PPE()){
				PPE = PPE + 1;
			}
		}
		return PPE;
	}
	public static int calculateWB(ArrayList skills){
		int WB = 0;
		foreach(Skill s in skills){
			if(s.get_WB()){
				WB = WB + 1;
			}
		}
		return WB;
	}
}
