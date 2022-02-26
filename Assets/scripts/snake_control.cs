using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snake_control : MonoBehaviour
{
    private Vector2 _direction;   // yön için deðiþken tanýmladým
    [SerializeField] private GameObject _segmentPrefab;
    private List<GameObject> _segments = new List<GameObject>();
    void Start()
    {
        Reset(); // oyun her baþladýðýnda saða doðru yýlanýmýz hareket edicek
        ResetSegment();
        Time.fixedDeltaTime = 0.009f;
    }




    void Update()
    {
        GetUserInput();   // kullanýcýdan aldýpýmýz inputlar sürekli burada çalýþýcak
    }


    private void FixedUpdate()
    {
        SnakeMouve();
        MoveSegment();
    }







    public void CreateSegment()   // yýlaný çoðaltma iþlemini yapýyoruz
    {
        GameObject _newSegment = Instantiate(_segmentPrefab);
        _newSegment.transform.position = _segments[_segments.Count - 1].transform.position;
        _segments.Add(_newSegment);
        _segments[1].gameObject.tag = "Untagged";
    }




    private void ResetSegment()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i]);
        }
        _segments.Clear();
        _segments.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            CreateSegment();
        }

    }




    private void MoveSegment()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }
    }









    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }







    private void Reset() // oyun baþladýðýnda yýlan ilk olarak saða doðru hareket edicek 
    {
        _direction = Vector2.right;
        Time.timeScale = 0.1f;
    }






    private void SnakeMouve()  //yýlanýn hareketi için fonksiyonum
    {
        float x, y;
        x = transform.position.x + _direction.x;
        y = transform.position.y + _direction.y;

        transform.position = new Vector2(x, y);

    }



   
   
        


    
    






    private void GetUserInput()     // kullanýcýnýn klavyeden giriþini alýyoruz
    {
        if (!(_direction == Vector2.down))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector2.up;
            }
        }
        if (!(_direction == Vector2.up))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector2.down;
            }
        }

        
        if(!(_direction==Vector2.left))
        {

            if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector2.right;
            }
        }



        if(!(_direction==Vector2.right)) 
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector2.left;
            }
        }


        





    }




    private void OnTriggerEnter2D(Collider2D other)   // duvara çarpýnca oyun yeniden baþlýyacak
    {
        if (other.gameObject.CompareTag("duvar"))
        {
            RestartGame();
        }
        if (other.gameObject.CompareTag("segment"))
        {
            Time.timeScale = 0;
            print("bitti");


        }
    }













}
