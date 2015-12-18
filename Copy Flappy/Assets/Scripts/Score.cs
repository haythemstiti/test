using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {




    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            //    Manage.score++;
            EventManager.TriggerEvent("Increment");
            Invoke("Destroy", 2f);
           
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
