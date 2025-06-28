using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TapHandler : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;
    public RawImage imageDisplay;
    public Button viewARButton;

    public BuildingInfo defaultPOI;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShowInfo(defaultPOI);
        }
    }

    void ShowInfo(BuildingInfo info)
    {
        titleText.text = info.title;
        descText.text = info.description;

        Texture2D tex = Resources.Load<Texture2D>("POIImages/" + info.imageName);
        imageDisplay.texture = tex;

        viewARButton.onClick.RemoveAllListeners();
        viewARButton.onClick.AddListener(() =>
        {
            Debug.Log("Trigger AR scene switch for: " + info.title);
        });

        panel.SetActive(true);
        Handheld.Vibrate();
    }

}
