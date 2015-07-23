#region Chris/Shawn
using UnityEngine;
using System.Collections;

public class PCGGameManager : MonoBehaviour {
	
	private void Start () {
		BeginGame();
	}
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
			RestartGame();
		}
	}
	public Maze mazePrefab;
	
	private Maze mazeInstance;
	
	private void BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		StartCoroutine(mazeInstance.Generate());
	}
	
	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}
#endregion