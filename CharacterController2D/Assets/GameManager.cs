using UnityEngine;
using System.Collections;

/**
  Will handle a lot of bunch of stuffs like spawning a player, checkpoints etc.
**/

public class GameManager : MonoBehaviour {

    public GameObject player;

    private GameCamera cam;

	void Start () {

        cam = GetComponent<GameCamera>();
        SpawnPlayer();
	}
	
	private void SpawnPlayer()
    {
        cam.setTarget((Instantiate(player, Vector3.zero, Quaternion.identity)as GameObject).transform);
    }

	void Update () {
	
	}
}
