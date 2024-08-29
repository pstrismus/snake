using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yemekler : MonoBehaviour
{
    [SerializeField] private haraket yılan;
    [SerializeField] private float _minX, __maxX, _minY, __maxY;
    void Start()
    {
        randomyemek();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("yılan"))
        {
            randomyemek();
            yılan.kuyrukolustur();
        }
    }
    private void randomyemek()
    {
        transform.position = new Vector2(Mathf.Round(Random.Range(_minX, __maxX)) + 0.5f, Mathf.Round(Random.Range(_minY, __maxY)) + 0.5f) ;
    }
}
