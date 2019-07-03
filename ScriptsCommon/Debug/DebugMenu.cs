using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu = null;
    [SerializeField]
    private Canvas menuCanvas = null;

    [SerializeField]
    private GameObject itemPrefab = null;
    private List<GameObject> itemList = new List<GameObject>();

    [SerializeField]
    private Transform itemGroup = null;

    [SerializeField]
    private Canvas debugButtonCanvas = null;


    private void Awake() {
        SetItemGroup();

        // menuCanvas.sortingOrder = App.LayerOrder.DEBUG_MENU;
        // debugButtonCanvas.sortingOrder = App.LayerOrder.DEBUG_BUTTON;
    }

    private void SetItemGroup() {
        // int posY = 200;

        // デバッグ対象にしたいクラスをAppに追加後有効
        // foreach (Type type in App.DebugMenu.DebugTypeList)
        // {
        //     GameObject item = Instantiate(itemPrefab, itemGroup);
        //     item.GetComponent<DebugItem>().Init(type);
        //     itemList.Add(item);

        //     item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY);
        //     posY -= 100;
        // }
    }

    public void ShowDebugMenu() {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideDebugMenu() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ConfirmDebug() {
        itemGroup.BroadcastMessage("Fix", SendMessageOptions.DontRequireReceiver);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HideDebugMenu();
    }

}

