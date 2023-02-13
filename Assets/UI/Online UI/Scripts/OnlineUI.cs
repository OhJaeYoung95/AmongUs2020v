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

    // �游��� ��ưŬ��
    public void OnClickCreateRoomButton()
    {
        // �г����� �������
        if (nicknameInputField.text != "")
        {
            PlayerSettings.nickname = nicknameInputField.text;
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else        // �г����� ���� ���
        {
            // �ִϸ��̼� ����
            nicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }
}
