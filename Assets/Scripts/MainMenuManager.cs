using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lab");
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

	public void QuitGame()
	{
		Debug.Log("Quit Game");

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}