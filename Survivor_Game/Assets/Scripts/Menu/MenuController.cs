using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	

		//#region Zenject

		//private SaveLoadSystem saveLoadSystem;

		//#endregion
		//[Inject]
		//private void Construct(SaveLoadSystem system)
		//{
		//	this.saveLoadSystem = system;
		//}
		/// <summary>
		/// Load level.
		/// </summary>s
		public void NewGame()
		{
			SceneManager.LoadScene("Scenes", LoadSceneMode.Single);
		}

		/// <summary>
		/// Close application.
		/// </summary>
		public void Quit()
		{
			Application.Quit();
		}
	
}
