using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    public float lifetime = 5f;
    Audio audio;


    void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyammo", lifetime);
        audio.playpistol();

    } 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime * -1, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    public void destroyammo()
    {
        Destroy(gameObject);
    }
}
