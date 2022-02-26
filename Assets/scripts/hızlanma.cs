using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hızlanma : MonoBehaviour
{


    private float Hızlimiti=0.005f;


    [SerializeField] private float _hizlanmaminX, _hizlanmamaxX, _hizlanmaminY, _hizlanmamaxY;
    [SerializeField] private snake_control _snake;







    void Start()
    {

        RandomHizlanmaPosition();



    }

    void Update()
    {
        




    }



    private void RandomHizlanmaPosition() // zehirin sahnede rastgele değişmesi için fonksiyonumuz
    {
        transform.position = new Vector2(

            Mathf.Round(Random.Range(_hizlanmaminX, _hizlanmamaxX)) + 0.5f,   // +0.5 ler tam kutuya otursaun diye 
            Mathf.Round(Random.Range(_hizlanmaminY, _hizlanmamaxY)) + 0.5f

            );


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("snake"))      // yılanın çarptıpı zehir ise 
        {
            RandomHizlanmaPosition();
           
                       
                Time.fixedDeltaTime -= 0.002f;





           

        }
    }







}
