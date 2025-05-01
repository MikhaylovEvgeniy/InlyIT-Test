using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemsSaving : MonoBehaviour
{
    public static ItemsSaving Instance { get; set; }
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject listMenu;
    private string loadedItemName;
    private string path;

    private void Awake()
    {
        Instance = this;
        path = Path.Combine(Application.persistentDataPath, "items.txt");
        File.WriteAllText(path, "");
        // listMenu.SetActive(false);
        // closeButton.gameObject.SetActive(false);
        // openButton.gameObject.SetActive(true);
    }

    private void Start()
    {
        openButton.onClick.AddListener(OpenList);
        closeButton.onClick.AddListener(CloseList);
    }

    public void SaveItemName(string itemName)
    {
        File.AppendAllText(path, itemName + "\n");
        Debug.Log("Файл сохранен: " + path);

        loadedItemName = File.ReadAllText(path);
        Debug.Log("Прочитано: " + loadedItemName);

        text.text = loadedItemName;
    }

    private void OpenList()
    {
        listMenu.SetActive(true);
        openButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    private void CloseList()
    {
        listMenu.SetActive(false);
        closeButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
    }

    public void AllListClosed()
    {
        listMenu.SetActive(false);
        closeButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(false);
    }

    public void OpenListButtonActive()
    {
        openButton.gameObject.SetActive(true);
    }
}

