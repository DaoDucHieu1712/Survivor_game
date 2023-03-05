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
		/// </summary>
		public void NewGame()
		{
			SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
		}

		/// <summary>
		/// Close application.
		/// </summary>
		public void Quit()
		{
			Application.Quit();
		}
	
}
