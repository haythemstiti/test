using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{

    public GameObject[] pipes;
    public Text scoreText;
    GameObject player;
    Transform playerTransform;
    public static int score = 0;
    private UnityAction scoreListener;

    void Awake()
    {
        scoreListener = new UnityAction(ScoreAdd);
        
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        //   StartCoroutine("SpawnPipes");
        InvokeRepeating("SpawnPipes2", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score + "";
    }

    void OnEnable()
    {
        EventManager.StartListening("Increment", scoreListener);
    }

    void OnDisable()
    {
        EventManager.StopListening("Increment", scoreListener);
    }

        IEnumerator SpawnPipes()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("started");
            Vector3 pos = playerTransform.position;
            pos.x += 5;
            pos.y = 1.2f;
            int index = Random.Range(0, 5);
            Instantiate(pipes[index], pos, Quaternion.identity);
        }
        
    }

    void SpawnPipes2()
    {
        

            Debug.Log("started");
            Vector3 pos = playerTransform.position;
            pos.x += 5;
            pos.y = 1.2f;
            int index = Random.Range(0, 5);
            Instantiate(pipes[index], pos, Quaternion.identity);   

    }



    void ScoreAdd()
    {
        score++;
    }
}
