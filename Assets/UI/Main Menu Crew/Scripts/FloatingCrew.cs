using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor playerColor;        // 색상

    private SpriteRenderer spriteRenderer;  // 스프라이트
    private Vector3 direction;              // 방향
    private float floatingSpeed;            // 이동속도
    private float rotateSpeed;              // 회전속도

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 크루원 설정(스프라이트 , 색상, 이동방향, 이동속도, 회전속도, 사이즈)
    public void SetFloatingCrew(Sprite sprite, EPlayerColor playerColor, Vector3 direction, 
        float floatingSpeed, float rotateSpeed, float size)
    {
        // 설정값 대입
        this.playerColor = playerColor;         // 색상
        this.direction = direction;             // 방향
        this.floatingSpeed = floatingSpeed;     // 이동속도
        this.rotateSpeed = rotateSpeed;         // 회전속도

        spriteRenderer.sprite = sprite;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));    // 크루원 색상설정

        transform.localScale = new Vector3(size, size, size);       // 크루원 사이즈 설정
        spriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, size);      // 사이즈에 따른 정렬 순서, 크기 작은 크루원 뒤, 큰 크루원이 앞으로 나와서 작은 크루원 가림
    }

    // Update is called once per frame
    void Update()
    {   
        // 크루원 이동 회전
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}
