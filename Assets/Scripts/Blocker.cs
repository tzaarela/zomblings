using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public BlockerData blockerData;
    [SerializeField] private Sprite m_FullDura;
    [SerializeField] private Sprite m_DamagedDura;
    [SerializeField] private Sprite m_CriticalDura;
    [SerializeField] private GameObject m_Flame;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    private float durability;


    private void Start()
    {
        durability = blockerData.durability;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            var zombie = collision.gameObject.GetComponent<ZombieController>();
            ReduceDurability(zombie);
            zombie.FlipDirection();
        }
    }

    private void ReduceDurability(ZombieController zombie)
    {
        //TODO - Change sprite depending on state
        durability -= zombie.zombieData.damage;
        if (durability >= 36)
        {
            m_SpriteRenderer.sprite = m_FullDura;
        }
        else if (durability <= 24 && durability > 12)
        {
            m_SpriteRenderer.sprite = m_DamagedDura;
            m_Flame.SetActive(false);
        }
        else if (durability <= 12)
        {
            m_SpriteRenderer.sprite = m_CriticalDura;
        }

        if (durability <= 0 && !gameObject.CompareTag("Empower"))
            Destroy(this.gameObject);
    }
}
