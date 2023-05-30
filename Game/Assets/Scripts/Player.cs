using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float velocidade = 10f;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(!gameManager.startGame)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal");
        Vector3 vector = new Vector3(x, 0, 0);
        transform.Translate(vector * velocidade * Time.deltaTime);

        if(transform.position.x < -8f)
        {
            transform.position = new Vector3(-8f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 8f)
        {
            transform.position = new Vector3(8f, transform.position.y, transform.position.z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit"))
        {
            gameManager.score += 10;
        }
        else if(other.CompareTag("Damage"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

        Destroy(other.gameObject);
    }
}
