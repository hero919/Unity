using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of the ScrollItem for listing Opportunities.
 */
public class ScrollItemOpportunity : ScrollItem
{
	public override void OnClick() {
		new NavigationHandler().LoadActivity(linkID);    
	}
}
