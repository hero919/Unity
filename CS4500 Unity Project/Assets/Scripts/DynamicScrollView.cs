using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Abstract class for implementations of scrollable, vertical lists of variable size. Unity
 * takes care of most of the actual UI elements; this script and the implementing subclasses
 * are mostly used to govern how and where to add new elements to the scroll view.
 */
public abstract class DynamicScrollView : MonoBehaviour
{
	// The initial number of items to populate this scroll view with.
	public int noOfItems;
	// The source item to use as a base for new added objects.
	public GameObject item;
	// The layout to add items to.
	public GridLayoutGroup gridLayout;
	// UI Sizing.
	public RectTransform scrollContent;
	public ScrollRect scrollRect;

	// MonoBehavior function used for initialization.
	public abstract void OnEnable();

	// Initializer function, usually wrapped by OnEnable().
	protected abstract void InitializeList();

	// Initializes a new entry in the list based on some object in the database
	// with the given ID.
	protected abstract void InitializeNewItem(string ID);

	// Adds a newly initialized object to the list and resizes as necessary.
	public abstract void AddNewElement();

	/**
	 * Cleanup function for clearing the scroll view when necessary.
	 */
	protected void ClearOldElements ()
	{
		for (int i = 0; i < gridLayout.transform.childCount; i++) {
			Destroy (gridLayout.transform.GetChild (i).gameObject);
		}
	}

	/**
	 * Sets the height of this scrollable content in this scroll view, based on 
	 * the number of elements in the list.
	 */
    public virtual void SetContentHeight()
    {
        float scrollContentHeight = (gridLayout.transform.childCount * gridLayout.cellSize.y) + 
			((gridLayout.transform.childCount - 1) * gridLayout.spacing.y);
        scrollContent.sizeDelta = new Vector2(520, scrollContentHeight);
    }

	/**
	 * Smoothing function to help with adding new elements to the list.
	 * TODO
	 */
    protected IEnumerator MoveTowardsTarget(float time,float from,float target) {
        float i = 0;
        float rate = 1 / time;
        while(i<1){
            i += rate * Time.deltaTime;
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(from,target,i);
            yield return 0;
        }
    }
}
