using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public bool IsStartBtn;
    public bool IsTutBtn;
    public bool IsBackBtn;
    public GameObject MainScreen;
    public GameObject TutorialScreen;
    private SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        if (IsStartBtn)
        {
            StartGame();
        }
        else if (IsTutBtn)
        {
            StartTutorialScreen();
        }
        else if (IsBackBtn)
        {
            StartMainMenuScreen();
        }
        m_SpriteRenderer.color = Color.white;
    }

    private void OnMouseOver()
    {
        m_SpriteRenderer.color = Color.grey;
    }
    private void OnMouseExit()
    {
        m_SpriteRenderer.color = Color.white;

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMainMenuScreen()
    {
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
    }

    public void StartTutorialScreen()
    {
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(true);
    }

}
