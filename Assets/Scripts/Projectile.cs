using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    Rigidbody2D m_rb;
    GameController m_gc;
    AudioSource aus;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        Destroy(gameObject, timeToDestroy);
        aus = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            m_gc.ScoreIncrement();
            if (aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Viên ?a?n ?a? va cha?m v??i enemy");
        }
        else if (collision.CompareTag("SceneTopLimit"))
        {
            Destroy(gameObject);
        }
    }

}
