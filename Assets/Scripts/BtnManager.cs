using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnManager : MonoBehaviour
{

    private SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        StartGame();
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

}
