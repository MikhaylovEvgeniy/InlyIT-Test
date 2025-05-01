using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class NoteMenu : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject joystickCanvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    private void Start()
    {
        closeButton.onClick.AddListener(CloseNote);
        canvas.enabled = false;
    }

    public void OpenNote()
    {
        Player.Instance.isNoteOpened = true;
        canvas.enabled = true;
        ItemsSaving.Instance.AllListClosed();
        joystickCanvas.SetActive(false);
    }

    private void CloseNote()
    {
        Player.Instance.isNoteOpened = false;
        canvas.enabled = false;
        ItemsSaving.Instance.OpenListButtonActive();
        joystickCanvas.SetActive(true);
    }
}
