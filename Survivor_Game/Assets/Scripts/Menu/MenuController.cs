using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	

		public void NewGame()
		{
			SceneManager.LoadScene(1);
		}

		/// <summary>
		/// Close application.
		/// </summary>
		public void Quit()
		{
			Application.Quit();
		}
	
}
