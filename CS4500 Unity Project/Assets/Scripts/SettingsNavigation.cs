using UnityEngine;
using System.Collections;

/**
 * Class controlling movement and navigation in the Settings menu. This code
 * is really old and kind of outdated and should probably be replaced (if
 * it's even still in use). As it is, it controls the movement of a menu system
 * underneath the camera, sliding each menu into the camera view.
 */
public class SettingsNavigation : MonoBehaviour
{
	// The parent object for the entire system	
	public GameObject menuSystem;

	// The height and width of our menu (should be screen height and width, with allowances for
	// header menus et al. This requires that all traversed menus be the same height and width.)
	private float menuWidth = Screen.width;
	private float menuHeight = Screen.height;
	// The position within the menu system that you are currently at. 0, 0 is the root menu,
	// 1, 0 is the menu just to the right, etc.
	private int menuPosX;
	private int menuPosY;
	// The actual position and destination of the menu system. Used for scrolling.
	private float xPos;
	private float xDest;
	private const float moveSpeed = 10;

	/**
	 * Initializer function.
	 */
	void Start ()
	{
		menuPosX = 0;
		menuPosY = 0;
		xPos = 0;
		xDest = 0;
	}

	/**
	 * Update function. Moves the menu to the desired position.
	 */
	void Update ()
	{
		if (xPos == xDest) {	// no movement necessary
			return;
		} else if (Mathf.Abs (xPos - xDest) < moveSpeed) { // dont overcorrect
			xPos = xDest;
		} else if (xPos < xDest) { // move right
			xPos += moveSpeed;
		} else if (xPos > xDest) { // move left
			xPos -= moveSpeed;
		}
		menuSystem.transform.position = new Vector3 (xPos, menuSystem.transform.position.y, menuSystem.transform.position.z);
	}

	/**
	 * Sets the new destination for the menu.
	 */
	void SetDestination (float newMenuPosX, float newMenuPosY)
	{
		menuPosX = (int)newMenuPosX;
		menuPosY = (int)newMenuPosY;
		xPos = menuSystem.transform.position.x;
		xDest = -(newMenuPosX * menuWidth);
	}

	/**
	 * On Click functions. Mostly unimplemented right now.
	 */
	public void OnClickMyProfile ()
	{
		SetDestination (1, 0);
		// do stuff
	}
	public void OnClickNotificationsToggle (bool value)
	{
		// do stuff
	}
	public void OnClickPrivacyStatement ()
	{
		// do stuff
	}
	public void OnClickPicture ()
	{
		// do stuff
	}
	public void OnClickUpdateProfile ()
	{
		SetDestination (0, 0);
		// do stuff
	}
}
