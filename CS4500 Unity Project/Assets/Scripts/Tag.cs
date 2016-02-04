using UnityEngine;
using System.Collections;

/**
 * Class comprising a keyword for some group of events, and IDs for every 
 * Opportunity connected to this tag.
 */
public class Tag
{
	public string tag_name;
	public ArrayList events; // event IDs
	
	public Tag(string tag_name) {
		this.tag_name = tag_name;
	}
}
