using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro; 

public class Church : MonoBehaviour
{
    public Bombing bombingScript; 
    public int collisionLimit = 20;
    private int collisionCount = 0;
    private bool bombingStopped = false;

    [Header("Church Models")]
    public GameObject normalChurch; 
    public GameObject burntChurch; 

    public float fadeDuration = 2f;

    [Header("UI")]
    public GameObject guidePanel; 
    public TMP_Text guideText;   
    public Button okButton;       

    private void Start()
    {
        if (guidePanel != null)
            guidePanel.SetActive(false);

        burntChurch.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (bombingStopped)
            return;

        collisionCount++;
        Debug.Log($"Church collision count: {collisionCount}");

        if (collisionCount >= collisionLimit)
        {
            StopBombingScript();
            bombingStopped = true;
        }
    }

    private void StopBombingScript()
    {
        if (bombingScript != null)
        {
            bombingScript.enabled = false;
            Debug.Log("Bombing stopped by Church after 20 collisions.");
            StartCoroutine(FadeChurches());
        }
        else
        {
            Debug.LogWarning("Bombing script reference not set on Church.");
        }
    }

    private IEnumerator FadeChurches()
    {
        if (burntChurch != null)
        {
            burntChurch.SetActive(true);
            SetAlpha(burntChurch, 0f);
        }

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            SetAlpha(normalChurch, 1f - t);
            if (burntChurch != null)
                SetAlpha(burntChurch, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        SetAlpha(normalChurch, 0f);
        if (burntChurch != null)
            SetAlpha(burntChurch, 1f);

        if (normalChurch != null)
            normalChurch.SetActive(false);

        ShowGuidePanel();
    }

    private void ShowGuidePanel()
    {
        if (guidePanel != null)
        {
            guidePanel.SetActive(true);
            if (guideText != null)
                guideText.text = "You can now talk with the guide and ask your questions.";
            if (okButton != null)
            {
                okButton.onClick.RemoveAllListeners();
                okButton.onClick.AddListener(HideGuidePanel);
            }
        }
    }

    private void HideGuidePanel()
    {
        if (guidePanel != null)
            guidePanel.SetActive(false);
    }

    // Helper to set alpha for all renderers in a GameObject
    private void SetAlpha(GameObject obj, float alpha)
    {
        if (obj == null) return;
        foreach (var renderer in obj.GetComponentsInChildren<Renderer>())
        {
            foreach (var mat in renderer.materials)
            {
                if (mat.HasProperty("_Color"))
                {
                    Color c = mat.color;
                    c.a = alpha;
                    mat.color = c;
                    if (mat.HasProperty("_Mode"))
                        mat.SetFloat("_Mode", 2f); 
                    mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    mat.SetInt("_ZWrite", 0);
                    mat.DisableKeyword("_ALPHATEST_ON");
                    mat.EnableKeyword("_ALPHABLEND_ON");
                    mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    mat.renderQueue = 3000;
                }
            }
        }
    }
}