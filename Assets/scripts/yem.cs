using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yem : MonoBehaviour
{

    [SerializeField] private snake_control _snake;
    
    
    
    [SerializeField] private float _minX, _maxX, _minY, _maxY;     // yemimizin eksenlerde rastgele yer deðiþtirmesi için deðiþkenlerimiz
    void Start()
    {

        RandomYemPosition();   // oyun baþladýðýnda yemi rastgele atýyacak



    }



    

    private void RandomYemPosition() // yemin sahnede rastgele deðiþmesi için fonksiyonumuz
    {
        transform.position = new Vector2(

            Mathf.Round(Random.Range(_minX,_maxX)) + 0.5f,   // +0.5 ler tam kutuya otursaun diye 
            Mathf.Round(Random.Range(_minY,_maxY)) +0.5f

            );


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("snake"))      // çarptýpý yem ise tekrar yem ürettik
        {
            RandomYemPosition();
            _snake.CreateSegment();
        }
    }









}
