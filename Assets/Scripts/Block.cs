using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockSound;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Because this is a 3d effect, Camera.main, to access Main Camera
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
