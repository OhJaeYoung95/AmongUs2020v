using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private InputField nicknameInputField;
    [SerializeField]
    private GameObject createRoomUI;

    // 방만들기 버튼클릭
    public void OnClickCreateRoomButton()
    {
        // 닉네임이 있을경우
        if (nicknameInputField.text != "")
        {
            PlayerSettings.nickname = nicknameInputField.text;
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else        // 닉네임이 없을 경우
        {
            // 애니메이션 실행
            nicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }
}
