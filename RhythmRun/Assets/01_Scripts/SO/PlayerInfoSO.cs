using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class PlayerInfoSO : ScriptableObject
{
    [Header("--MoveInfo--")]
    public float moveSpeed;

    [Header("--SlideInfo--")]
    public float slideTime;         // 슬라이드 재사용 시간
    public float slideDuration;     // 슬라이드 지속 시간

    [Header("--JumpInfo--")]
    public float jumpTime;          // 점프 재사용 시간
    public float checkLandDistance; // Land 체크 거리
    public float jumpForce;
    public float doubleJumpForce;
    public float checkTime;         // jumpCheckDistance로 넘어가는 시간 0.001 아주 작은값
    public float jumpCheckDistance;

    [Header("--DownInfo--")]
    public float downForce;

    [Header("--KeyInfo--")]
    public KeyCode jumpKey;
    public KeyCode slideKey;
    public KeyCode downKey;
}
