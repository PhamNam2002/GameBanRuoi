using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
     Rigidbody2D rb;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down*moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
            controller.SetGameoverState(true);
            Debug.Log("Enemy ?a? va cha?m v??i DeathZone tro? ch?i kê?t thu?c");
        }
    }
}
