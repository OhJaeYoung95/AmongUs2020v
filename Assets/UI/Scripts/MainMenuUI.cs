using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    // 메인메뉴 UI 온라인 버튼 클릭
    public void OnClickOnlineButton()
    {
        Debug.Log("Click Online");
    }

    // 메인메뉴 UI 종료 버튼 클릭
    public void OnClickQuitButton()
    {
        // 에디터 상에서는 런타임 종료, 빌드파일에서는 실행종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
