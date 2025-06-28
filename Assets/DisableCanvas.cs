using UnityEngine;

public class DisableCanvas : MonoBehaviour
{
    public GameObject Canvas;

    public void OnButtonClicked()
    {
        Canvas.SetActive(false);
    }
}
