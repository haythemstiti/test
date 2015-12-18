using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {

    int pannelNum = 5;

	void OnTriggerEnter2D(Collider2D col)
    {
        

        float backgroundWidth = ((BoxCollider2D)col).size.x;
        Vector3 pos = new Vector3(col.transform.position.x + backgroundWidth * pannelNum,col.transform.position.y,col.transform.position.z);
        col.transform.position = pos;
    }
}
