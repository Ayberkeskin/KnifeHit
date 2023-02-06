using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    private KnifeManeger knifeManeger;
    
    private Rigidbody2D knifeRb;
    [SerializeField] private float moveSpeed;

    private bool canShoot;
    private void Start()
    {
        GetComponentValues();

    }

    private void Update()
    {
        HandleShootInput();
    }
    private void FixedUpdate()
    {
        shoot();
    }


    private void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knifeManeger.SetDisableKnifeIConColor();
            canShoot = true;
        }
    }
    private void shoot()
    {
        if (canShoot)
        {
            knifeRb.AddForce(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            knifeManeger.SetActiveKnife();  
            canShoot = false;
            knifeRb.isKinematic = true;
            transform.SetParent(collision.gameObject.transform);
        }
        if (collision.gameObject.CompareTag("Knife"))
        {
            SceneManager.LoadScene(0);
        }
    }



    private void GetComponentValues()
    {
        knifeRb = GetComponent<Rigidbody2D>();
        knifeManeger = GameObject.FindObjectOfType<KnifeManeger>();
    }


}
