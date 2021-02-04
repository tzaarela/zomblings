using System;
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
    private bool isPickedFromPlatform;

    public Action onCreated;

    private void Awake()
    {
        onCreated += PickUp;
        m_PlatformLayer = 1 << LayerMask.NameToLayer("Platform");
        
    }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && m_IsDragged)
            Release();

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

    private void OnMouseDown()
    {
        PickUp();
        isPickedFromPlatform = true;
    }

    public void PickUp()
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

    public void Release()
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
            if (isPickedFromPlatform)
                transform.position = m_startPosition;
            else
            {
                Destroy(this.gameObject);
                InventoryController.Instance.AddItem(this.gameObject.GetComponent<Dropper>().itemType);
            }
            SoundController.Instance.PlaySound("PlaceBlock1");
        }
    }
    private void OnMouseUp()
    {
        
    }

    private void DragObject()
    {
        if (m_IsDragged)
        {
            gameObject.transform.position = m_InitialPositionObject + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_InitialPositionMouse;
            gameObject.transform.position += Vector3.down;
        }
    }
}
