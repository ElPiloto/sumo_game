using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform {

	public Platform(GameObject players, float scale){
	}

	public void InstantiateGeometry() {

	}
}

// Higher level platform classes:
// Timed
/* Survival:
needs to have 
-Eliminated(eliminatedPlayer, eliminatingPlayer=null) function, needs to launch GameOver event
*/


public class SumoMaster : MonoBehaviour {
	public enum GameObjective {
		//All of these need to have an OnGameEnded event() 
		Survival = 0, // Needs to have "terminated" event for each player
		Collection = 1, // Needs to have pick-up event for each player: PickupEvent(player, changeInScore)
		ReverseHotPotato = 2, // Needs to have event where someone becomes "it"
		HotPotato = 3, // Needs to have event where someone becomes "it"
		RoadKill = 4 
	}

	public GameObjective gameObjective;

	// Use this for initialization
	void Start () {
		/*  Pseudo-code:
			Start() {
			SumoGameSettings = MenuInterface.Prompt();
			List<Player> players = SumoGameSettings.getPlayers();
			Platform, GameObjective = MergePlatformAndObjective(SumoGameSettings.PlatformType, SumoGameSettings.GameObjective)
			Platform.InstantiateGeometry();
			GameObjective.InstantiatePlayers(players);
			GameObjective.gameEndListeners += DisplayWinner();
			}
			Update() {
				Platform.Update()
			}

			void DisplayWinner() // go back to MenuInterface
		 */
	}

	// Update is called once per frame
	void Update () {
		
	}
}
