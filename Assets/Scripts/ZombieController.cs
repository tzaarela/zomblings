using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public ZombieData zombieData;
    public Vector3 direction;

    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;

    private bool spawnAnimationFinished;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        SpriteRenderer.sprite = zombieData.sprite;

        var random = Random.Range(0, 2);
        direction = random == 0 ? Vector3.right : Vector3.left;

        animator.Play("ZombieGraveSpawn");
        StartCoroutine(OnCompleteSpawnAnimation());
    }

    public void FixedUpdate()
    {
        if (spawnAnimationFinished)
        {
            rb.isKinematic = false;
            MoveRight();
        }
    }

    IEnumerator OnCompleteSpawnAnimation()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;
        spawnAnimationFinished = true;
    }

    public void MoveRight()
    {
        rb.velocity = new Vector3(zombieData.moveSpeed * direction.x, rb.velocity.y, 0);
    }

    public void FlipDirection()
    {
        direction = direction * -1;
    }

    public void Die()
    {
        Destroy(this.gameObject);
        GameController.Instance.CheckIfZombiesDead();
    }

    public void Dance()
    {
        Debug.Log("Play dance animation");
    }

    public void EatBrain(Brain brain)
    {
        //wait for play animation TO FINISH
        SoundController.Instance.PlaySound("ZombieEating");
        StartCoroutine(WaitForEating(brain));
    }

    private IEnumerator WaitForEating(Brain brain)
    {
        direction = Vector2.zero;
        yield return new WaitForSeconds(2);
        brain.onEatAnimationFinished.Invoke(this);
    }

}
