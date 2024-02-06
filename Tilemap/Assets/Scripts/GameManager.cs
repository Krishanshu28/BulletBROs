using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text player1Score;
    public Text player2Score;

    public Timer timer;

    public GameObject EventText;

    //public Rigidbody2D player1;
    //public Rigidbody2D player2;

     //Player1 player1;
     Player2 player2;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Event1());

    }

    // Update is called once per frame
    void Update()
    {
        if(timer.remainingTime <= 230 && timer.remainingTime >= 225 && Player1.instance.myrigidbody2D != null && Player2.instance.myrigidbody2D != null)
        {
            Player1.instance.myrigidbody2D.gravityScale = 4.0f;
            Player2.instance.myrigidbody2D.gravityScale = 4.0f;
            
        }
        else if(timer.remainingTime <=220)
        {
            Player1.instance.myrigidbody2D.gravityScale = 8.0f;
            Player2.instance.myrigidbody2D.gravityScale = 8.0f;
        }
       
    }

    IEnumerator Event1()
    {
        print("Cot");
        yield return new WaitForSeconds(10);
        EventText.SetActive(true);

    }

}
