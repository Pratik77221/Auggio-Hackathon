using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableCanvas : MonoBehaviour
{
    public GameObject Canvas;

    public void OnButtonClicked()
    {
       SceneManager.LoadScene("ARScene");
    }
}
