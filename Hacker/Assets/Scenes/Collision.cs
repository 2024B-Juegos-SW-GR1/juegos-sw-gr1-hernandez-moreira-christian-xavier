using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.3f;
    [SerializeField] private float shrinkFactor = 0.8f;  // Factor de reducción de tamaño al chocar con un guardia
    [SerializeField] private float growFactor = 1.2f;  // Factor de aumento de tamaño al entregar el paquete
    private bool _hasPackage;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Chocaste con un guardia");
        _spriteRenderer.color = Color.red;
        // Reducir el tamaño del jugador
        transform.localScale *= shrinkFactor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Entrando a trigger con {other.gameObject.name}");

        if (other.CompareTag("Paquete") && !_hasPackage)
        {
            Debug.Log("Paquete recogido");
            _hasPackage = true;
            _spriteRenderer.color = Color.cyan;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.CompareTag("Cliente") && _hasPackage)
        {
            Debug.Log("Paquete entregado");
            _hasPackage = false;
            _spriteRenderer.color = Color.green;
            
            // Aumentar el tamaño del jugador al entregar el paquete
            transform.localScale *= growFactor;
        }    
    }
}