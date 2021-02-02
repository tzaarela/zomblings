using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalkTmp : MonoBehaviour
{
    [SerializeField] private float m_WalkSpeed;
    void Update()
    {
        Walk();
    }

    public void FlipVelocity()
    {
       m_WalkSpeed =  m_WalkSpeed * -1f;
    }

    private void Walk()
    {
        transform.Translate(Vector3.right * Time.deltaTime * m_WalkSpeed);
    }
}
