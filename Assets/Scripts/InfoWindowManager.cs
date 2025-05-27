using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InfoWindowManager : MonoBehaviour
{
    [Header("Prefab y tamaño")]
    public GameObject infoWindowPrefab;
    public Vector2 windowSize = new Vector2(200, 200);

    [Header("Imágenes y tiempos")]
    public List<Sprite> images;
    public float showDuration = 2f;
    public float cycleInterval = 5f;

    private GameObject windowInstance;
    private Image infoImage;
    private int currentIndex = 0;

    IEnumerator Start()
    {
        Canvas canvas = Object.FindFirstObjectByType<Canvas>();
        if (canvas == null) { Debug.LogError("No hay Canvas."); yield break; }

        windowInstance = Instantiate(infoWindowPrefab, canvas.transform);
        windowInstance.GetComponent<RectTransform>().sizeDelta = windowSize;
        infoImage = windowInstance.GetComponentInChildren<Image>();
        windowInstance.SetActive(false);

        while (images != null && images.Count > 0)
        {
            infoImage.sprite = images[currentIndex];
            windowInstance.SetActive(true);

            yield return new WaitForSeconds(showDuration);

            windowInstance.SetActive(false);
            currentIndex = (currentIndex + 1) % images.Count;

            float hiddenTime = cycleInterval - showDuration;
            if (hiddenTime > 0f)
                yield return new WaitForSeconds(hiddenTime);
        }
    }

    public void StopCycle()
    {
        StopAllCoroutines();
        if (windowInstance != null) windowInstance.SetActive(false);
    }
}
