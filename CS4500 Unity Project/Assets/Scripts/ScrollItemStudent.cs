using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Implementation of ScrollItem for listing Students.
 */
public class ScrollItemStudent : ScrollItem
{
	public override void OnClick ()
	{
		new NavigationHandler().LoadProfile (linkID);    
	}

	public void Remove ()
	{
		Database.get_student (GlobalInfo.storedUserName).remove_friend (linkID);
	}
}
