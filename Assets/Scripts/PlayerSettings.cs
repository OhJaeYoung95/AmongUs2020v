using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���۹��
public enum EControlType
{
    Mouse,
    KeyboardMouse
}

// ���۹��, �г���
public class PlayerSettings
{
    public static EControlType controlType;
    public static string nickname;
}
