using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructableTiles : MonoBehaviour
{
    public Tilemap destructableTilemap;
    Audio audio;


    void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }
    // Start is called before the first frame update
    void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
                audio.playbloc();
            }
            Destroy(collision.gameObject);
        }
        
    }
}
