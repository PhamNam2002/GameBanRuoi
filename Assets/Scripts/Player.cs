using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed ;
    public GameObject projectile;
    public Transform shootingPoint;
    public AudioSource aus;
    public AudioClip shootingSound;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.IsGameOver())
        {
            return;
        }
        float xDir = Input.GetAxisRaw("Horizontal");
        if (xDir < 0 && transform.position.x <= -8 || xDir > 0 && transform.position.x >= 8)
        {
            return;
        }
        transform.position = transform.position + Vector3.right * moveSpeed * xDir * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
      
    }
    public void Shoot()
    {
        if (projectile &&  shootingPoint)
        {
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            controller.SetGameoverState(true);
            Destroy(collision.gameObject);
            Debug.Log("Enemy ?a? va cha?m v??i player tro? ch?i kê?t thu?c");

        }
    }
}
