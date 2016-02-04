using UnityEngine;
using System.Collections;

/**
 * Class controlling the movement of the Sidebar object. The sidebar is really 
 * composed of two components - the top Sidebar object, which has links and
 * buttons, and an occlusion panel, which covers up the remainder of the screen
 * while the sidebar is open.
 */
public class SidebarDisplay : MonoBehaviour
{

	// Track whether or not the sidebar is open.
	private bool is_open = false;
	// how long it's been since this panel has been opened or closed
	private float time_since_changed = -5; 
	// roughly, how many frames it'll take to open/close this panel
	private float max_time = 10; 
	// The panel used to fade out the background
	public GameObject occlusion_panel;
	// The actual image component of the above panel
	private UnityEngine.UI.Image occlusion_image;

	// UI information for this sidebar
	private RectTransform sidebar_transform;
	private float sidebar_width;

	/**
	 * Initialization method.
	 */
	void Start ()
	{
		// Set up and assign variables.
		occlusion_image = occlusion_panel.GetComponent<UnityEngine.UI.Image> ();
		sidebar_transform = this.gameObject.GetComponent<RectTransform> ();
		sidebar_width = sidebar_transform.offsetMax.x - sidebar_transform.offsetMin.x;
	}

	/**
	 * Update function. Controls the movement of the panel.
	 */
	void Update ()
	{
		if (is_open) {
			occlusion_panel.SetActive(true);

			// Update panel time and alpha of the occlusion panel
			if (time_since_changed > max_time - 1) {
			} else {
				time_since_changed++;
			}
			occlusion_image.color = new Color (0, 0, 0, (time_since_changed / max_time) * .5f);
		} else { // close the panel

			// Update panel time and alpha of the occlusion panel
			if (time_since_changed == -5) {
				occlusion_panel.SetActive (false);
				time_since_changed--;
				occlusion_image.color = new Color (0, 0, 0, (time_since_changed / max_time) * .5f);
			} else if (time_since_changed <= -6) {

			} else {
				time_since_changed--;
				occlusion_image.color = new Color (0, 0, 0, (time_since_changed / max_time) * .5f);
			}
		}

		// Move the actual panel based on time
		sidebar_transform.offsetMin = new Vector2(((max_time - time_since_changed) / max_time) * 
		                                          sidebar_width, sidebar_transform.offsetMin.y);
		sidebar_transform.offsetMax = new Vector2(sidebar_transform.offsetMin.x + sidebar_width, 
		                                          sidebar_transform.offsetMin.y);
	}

	/**
	 * Opens the sidebar.
	 */
	public void open_panel ()
	{
		occlusion_panel.SetActive (true);
		is_open = true;
	}

	/**
	 * Closes the sidebar.
	 */
	public void close_panel ()
	{
		is_open = false;
	}
}
