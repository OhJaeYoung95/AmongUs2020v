using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 조작방법
public enum EControlType
{
    Mouse,
    KeyboardMouse
}

// 조작방법, 닉네임
public class PlayerSettings
{
    public static EControlType controlType;
    public static string nickname;
}
