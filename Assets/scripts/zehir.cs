using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zehir : MonoBehaviour
{
    [SerializeField] private float _zehirminX, _zehirmaxX, _zehirminY, _zehirmaxY;
    [SerializeField] private snake_control _snake;
    void Start()
    {
        RandomZehirPosition();
    }

    
    void Update()
    {
        
    }

    private void RandomZehirPosition() // zehirin sahnede rastgele deðiþmesi için fonksiyonumuz
    {
        transform.position = new Vector2(

            Mathf.Round(Random.Range(_zehirminX, _zehirmaxX)) + 0.5f,   // +0.5 ler tam kutuya otursaun diye 
            Mathf.Round(Random.Range(_zehirminY, _zehirmaxY)) + 0.5f

            );


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("snake"))      // yýlanýn çarptýpý zehir ise 
        {
            RandomZehirPosition();
            Time.fixedDeltaTime += 0.005f;
            
        }
    }


   






}
