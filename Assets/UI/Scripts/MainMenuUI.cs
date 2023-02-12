using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    // ���θ޴� UI �¶��� ��ư Ŭ��
    public void OnClickOnlineButton()
    {
        Debug.Log("Click Online");
    }

    // ���θ޴� UI ���� ��ư Ŭ��
    public void OnClickQuitButton()
    {
        // ������ �󿡼��� ��Ÿ�� ����, �������Ͽ����� ��������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
