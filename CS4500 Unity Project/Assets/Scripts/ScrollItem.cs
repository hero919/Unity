using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Abstract class representing an element in a DynamicScrollView. The two inheriting
 * subclasses load either an Opportunity with linkID or a Profile with linkID.
 */
public abstract class ScrollItem : MonoBehaviour
{

	// The text to be displayed on the item.
    public Text displayText;
	// The ID of the object to be loaded on click.
	public string linkID;
	// TODO Deprecated?
    public DynamicScrollView dynamicScrollView;
    
	// Sets text when the Item is ready for display.
    void OnEnable()
    {
        displayText.text = transform.name;
    }
    
	// Destructor.
    public void OnRemoveMe()
    {
        DestroyImmediate(gameObject);
        dynamicScrollView.SetContentHeight();
    }

	// Loads a new scene when clicked.
	abstract public void OnClick();
}
