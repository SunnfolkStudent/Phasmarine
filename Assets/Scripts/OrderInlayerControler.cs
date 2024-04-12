using System;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class OrderInlayerControler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.sortingOrder = -(int)transform.position.z;
    }
}
