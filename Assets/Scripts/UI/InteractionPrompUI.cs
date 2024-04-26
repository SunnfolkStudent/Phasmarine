using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPrompUI : MonoBehaviour
{
    //public UnityEvent InteractableFound = new UnityEvent();
    
    private Camera _mainCam;
    [SerializeField]private GameObject _UIPanel;
    [SerializeField] private TextMeshProUGUI _promtText;
    private void Start()
    {
        //InteractableFound.AddListener(PlayerMeetsInteractable);
        _mainCam = Camera.main;
        _UIPanel.SetActive(false);
    }

    private void Update()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool isDisplayed;
    
    
    public void SetUp(string promptText)
    {
        _promtText.text = promptText;
        _UIPanel.SetActive(true);
        isDisplayed = true;

    }

    public void Close()
    {
        _UIPanel.SetActive(false);
        isDisplayed = false;
    }
}