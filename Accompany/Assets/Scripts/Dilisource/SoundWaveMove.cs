﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveMove : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Transform waveTransform;
    private Vector3 startScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField]
    private Vector3 targetScale;

    [Range(0,2f)]
    [SerializeField]
    private float lifeTime;//声波到达最大值后存活时间

    [Range(0,0.1f)]
    [SerializeField]
    private float deltaColor;//协程中一帧增加的alpha值

    private void Awake()
    {
        waveTransform = this.transform;
    }
    private void Update()
    {
        //TODO
        //尺寸渐变
        waveTransform.localScale = Vector3.Lerp(waveTransform.localScale, targetScale, Time.time);
    }

    private void OnEnable()
    {
        StartCoroutine(LifeCycle());
    }
    private void OnDisable()
    {
        Color tempColor = sprite.color;
        tempColor.a = 0;
        sprite.color = tempColor;
        waveTransform.localScale = startScale;
    }

    private IEnumerator LifeCycle()
    {
        //TODO
        //颜色渐变
        for(float i = 0; i < 1f; i += deltaColor)
        {
            Color tempColor = sprite.color;
            tempColor.a += i;
            sprite.color = tempColor;
            yield return 0;
        }
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
        //怪物标签的统一
        if (collision.CompareTag(""))
        {
            gameObject.SetActive(false);
            //TODO
            //怪物造成伤害or死亡
        }
    }
}
