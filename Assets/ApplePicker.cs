using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public RoundCounter roundCounter;
    public GameObject restartButtonPrefab;
    public Transform canvasTransform;

    void Start()
    {
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        GameObject roundGO = GameObject.Find("RoundCounter");
        roundCounter = roundGO.GetComponent<RoundCounter>();
    }
    
    public void AppleMissed() {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }

        if (basketList.Count > 0) {
            int basketIndex = basketList.Count - 1;
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
            roundCounter.round += 1;
        }

        if (basketList.Count == 0) {
            roundCounter.round = 0;
            GameObject restartButtonGO = Instantiate<GameObject>(restartButtonPrefab);
            restartButtonGO.transform.SetParent(canvasTransform, false);
            //SceneManager.LoadScene("_Scene_0");
        }

    }

    public void EvilAppleCollected() {
        while (basketList.Count > 0) {
            int basketIndex = basketList.Count - 1;
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
        }
        
        roundCounter.round = 0;
        GameObject restartButtonGO = Instantiate<GameObject>(restartButtonPrefab);
        restartButtonGO.transform.SetParent(canvasTransform, false);
    }
}

