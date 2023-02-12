using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Button MouseControlButton;              // 마우스 컨트롤 설정버튼
    [SerializeField]
    private Button KeyboardMouseControlButton;      // 키보드 + 마우스 컨트롤 설정버튼
    private Animator animator;                      // 애니메이션

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // 활성화시 컨트롤 타입에 따른 버튼 색 설정
        switch(PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;
            case EControlType.KeyboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    // 버튼 클릭에 따른 버튼 색 설정
    public void SetControlMode(int controlType)
    {
        PlayerSettings.controlType = (EControlType)controlType;
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;
            case EControlType.KeyboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    // UI 닫기
    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    // UI 닫기 애니메이션 설정
    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
