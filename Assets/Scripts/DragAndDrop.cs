using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private bool m_SmartDrag = true;
    [SerializeField] private bool m_IsDraggable = true;
    [SerializeField] private bool m_IsDragged = false;
    [SerializeField] private float m_SnappingDiscante = 20;
    [SerializeField] private float m_DropOffset = 10;
    [SerializeField] private LayerMask m_PlatformLayer;
    private Vector2 m_InitialPositionMouse;
    private Vector2 m_InitialPositionObject;
    private Vector2 m_startPosition;
    private GameObject[] m_Zombies;
    private void Update()
    {
        DragObject();
        m_Zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if (m_IsDragged)
        {
            foreach (GameObject zombie in m_Zombies)
            {
            Physics2D.IgnoreCollision(zombie.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            }
        }
        else if (!m_IsDragged)
        {
            foreach (GameObject zombie in m_Zombies)
            {
                Physics2D.IgnoreCollision(zombie.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
        }

    }

    private void OnMouseOver()
    {
        if (m_IsDraggable && Input.GetMouseButtonDown(0))
        {
            SoundController.Instance.PlaySound("ButtonClick");
            if (m_SmartDrag)
            {
                m_InitialPositionMouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_InitialPositionObject = transform.position;
            }
            m_IsDragged = true;
            m_startPosition = transform.position;
        }
    }

    private void OnMouseUp()
    {
        m_IsDragged = false;
        var hit = Physics2D.Raycast(transform.position, Vector2.down, m_SnappingDiscante, m_PlatformLayer);

        if (hit)
        {           
            transform.position = hit.point + new Vector2(0, m_DropOffset);
            SoundController.Instance.PlaySound("PlaceBlock1");
        }
        else
        {
            transform.position = m_startPosition;
            SoundController.Instance.PlaySound("PlaceBlock1");
        }
    }

    private void DragObject()
    {
        if (m_IsDragged)
        {
            if (!m_IsDragged)
            {
                gameObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                gameObject.transform.position = m_InitialPositionObject + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_InitialPositionMouse;
            }

        }
    }
}
