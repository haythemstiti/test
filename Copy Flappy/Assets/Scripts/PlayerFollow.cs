using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

    Transform playerTransform;
    GameObject player;
    float offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("couldn't find the player");
            return;
        }
        playerTransform = player.transform;

        offset = transform.position.x - playerTransform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        position.x = playerTransform.position.x + offset;
        transform.position = position;
	}
}
