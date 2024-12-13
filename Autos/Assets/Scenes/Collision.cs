using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.3f;
    private bool _hasPackage;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("GOLPEEE");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Entrando a trigger con {other.gameObject.name}");

        if (other.CompareTag("Paquete") && !_hasPackage)
        {
            Debug.Log("Paquete recogido");
            _hasPackage = true;
            _spriteRenderer.color = Color.yellow;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.CompareTag("Cliente") && _hasPackage)
        {
            Debug.Log("Paquete entregado");
            _hasPackage = false;
            _spriteRenderer.color = Color.red;
        }    
    }
}