using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class haraket : MonoBehaviour
{
    [SerializeField] private Text score_uı;
    [SerializeField] private GameObject _kuyrukPref;
    private List<GameObject> _kuyruk = new List<GameObject>();
    private int skore = 0;
    Vector2 donduYon;
    void Start()
    {
        Reset();
        Resetkuyruk();
    }

    private void Reset()
    {
        donduYon = Vector2.right; 
        Time.timeScale = 0.1f;
    }

    private void FixedUpdate()
    {
        haraketet();
        kuyrukharaketi();
    }
    void Update()
    {
        yon();
    }
    public void kuyrukolustur()
    {
        if (_kuyruk.Count <= 0)
        {
            GameObject _yenikuyruk = Instantiate(_kuyrukPref);
            _yenikuyruk.transform.position = gameObject.transform.position;
            _yenikuyruk.GetComponent<SpriteRenderer>().sortingLayerName = "kuyruk";
        }
        else
        {
            GameObject _yenikuyruk = Instantiate(_kuyrukPref);
            _yenikuyruk.transform.position = _kuyruk[_kuyruk.Count - 1].transform.position;
            _kuyruk.Add(_yenikuyruk);
            
        }
        if (_kuyruk.Count > 4)
        {
            skore++;
            score_uı.text = skore.ToString();
        }
        for (int i = _kuyruk.Count - 1; i > 2; i--)
        {
            _kuyruk[i].gameObject.tag = "dead";
        }

    }
    private void Resetkuyruk()
    {
        for (int i = 1; i < _kuyruk.Count; i++)
        {
            Destroy(_kuyruk[i]);
        }

        _kuyruk.Clear();
        _kuyruk.Add(gameObject);
        for (int i = 0; i < 2; i++)
        {
            kuyrukolustur();

        }
    }
    private void kuyrukharaketi()
    {
        for (int i = _kuyruk.Count - 1; i > 0; i--)
        {
            _kuyruk[i].transform.position = _kuyruk[i - 1].transform.position;

        }
    }
    private void haraketet()
    {
        float x, y;
        x = transform.position.x + donduYon.x;
        y = transform.position.y + donduYon.y;

        transform.position = new Vector2(x,y);
    }
    private void yon()
    {
        if (donduYon.y >= 0f && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            donduYon = Vector2.up;
        }
        else if (donduYon.y <= 0f && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            donduYon = Vector2.down;
        }
        else if (donduYon.x <= 0f && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            donduYon = Vector2.left;
        }
        else if (donduYon.x >= 0f && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            donduYon = Vector2.right;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("dead"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
