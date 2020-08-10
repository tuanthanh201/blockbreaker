using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Level level;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit = 0;
    [SerializeField] Sprite[] hitSprite;

    LoseCollider loseCollider;

    public void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }

        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
