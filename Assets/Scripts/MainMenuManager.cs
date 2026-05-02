using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("LabScene");
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}