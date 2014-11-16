using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Needed for namespace 'List'

// ---- GAME MANAGER ----
// Contains a reference to active game important elements:
//  + Teams
//  + Players
//  + Time
//  + Score
// ----------------------

public class Game : MonoBehaviour {

    public static List<Team> teams = new List<Team>();
    public static List<Player> players = new List<Player>();

    public bool displayGUI = true;
    public Rect windowRect = new Rect(10, 10, 300, 200);


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnGUI () {
        if (displayGUI)
            windowRect = GUILayout.Window(2, windowRect, displayWindow, "Game Infos");
    }

    void displayWindow(int windowID) {
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
        GUILayout.Label("Active Players");
        foreach (Player player in players) {
            GUILayout.Label(player.id + ": " + player.name);
        }
    }

    public static void addPlayer(Player player) {
        players.Add(player);
    }

    public static bool removePlayer(Player player) {
        return players.Remove(player);
    }

    public static Player getPlayerById(int id) {
        foreach (Player player in players) {
            if (player.id == id)
                return player;
        }
        return null;
    }

    public static void listPlayers() {
        Debug.Log("Players in game: ");
        foreach (Player player in players) {
            Debug.Log(player.id + ": " + player.name);
        }
    }

    public static Player getPlayerByName(string name) {
        foreach (Player player in players) {
            if (player.name == name)
                return player;
        }
        return null;
    }
}
