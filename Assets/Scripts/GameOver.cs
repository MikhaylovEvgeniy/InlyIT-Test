using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject joystickCanvas;

    private void Awake()
    {
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
        
        ItemsSaving.Instance.AllListClosed();
        joystickCanvas.SetActive(false);
    }

    private void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
