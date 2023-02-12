using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor playerColor;        // ����

    private SpriteRenderer spriteRenderer;  // ��������Ʈ
    private Vector3 direction;              // ����
    private float floatingSpeed;            // �̵��ӵ�
    private float rotateSpeed;              // ȸ���ӵ�

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // ũ��� ����(��������Ʈ , ����, �̵�����, �̵��ӵ�, ȸ���ӵ�, ������)
    public void SetFloatingCrew(Sprite sprite, EPlayerColor playerColor, Vector3 direction, 
        float floatingSpeed, float rotateSpeed, float size)
    {
        // ������ ����
        this.playerColor = playerColor;         // ����
        this.direction = direction;             // ����
        this.floatingSpeed = floatingSpeed;     // �̵��ӵ�
        this.rotateSpeed = rotateSpeed;         // ȸ���ӵ�

        spriteRenderer.sprite = sprite;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));    // ũ��� ������

        transform.localScale = new Vector3(size, size, size);       // ũ��� ������ ����
        spriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, size);      // ����� ���� ���� ����, ũ�� ���� ũ��� ��, ū ũ����� ������ ���ͼ� ���� ũ��� ����
    }

    // Update is called once per frame
    void Update()
    {   
        // ũ��� �̵� ȸ��
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}