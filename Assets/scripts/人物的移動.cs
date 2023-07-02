using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class 人物的移動 : MonoBehaviour
{
    


    [Header("移動速度"), Range(0.5f, 50.0f)]
    public float moveSpeed = 5f;

    [Header("2D 剛體")]
    public Rigidbody2D rig;

    [Header("跳躍次數")]
    public int maxJumps = 2;

    [Header("跳躍力量"), Range(0.5f, 10)]
    public float jumpForce = 1f;// 跳躍力量
     [Header("跳躍高度"), Range(0.75f, 3)]
    public float jumpHeight = 0.8f;             // 跳躍高度

    private bool isJumping = false;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 按下空白鍵跳躍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            rig.velocity = new Vector2(rig.velocity.x, jumpVelocity);
            isJumping = true;
        }

        // 左右移動
        float moveInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moveInput * moveSpeed, rig.velocity.y);
    }

    private void FixedUpdate()
    {
        // 執行跳躍
        if (isJumping)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
