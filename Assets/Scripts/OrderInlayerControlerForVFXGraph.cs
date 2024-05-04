using UnityEngine;
using UnityEngine.VFX;

public class OrderInlayerControlerForVFXGraph : MonoBehaviour
{
    private VFXRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<VFXRenderer>();
    }

    private void Update()
    {
        _renderer.sortingOrder = -(int)transform.position.z;
    }
}
