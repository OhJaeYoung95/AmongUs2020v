using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 컨트롤 타입
public enum EControlType
{
    Mouse,
    KeyboardMouse
}

public class PlayerSettings
{
    public static EControlType controlType;
}
