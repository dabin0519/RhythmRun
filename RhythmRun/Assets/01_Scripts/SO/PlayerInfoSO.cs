using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class PlayerInfoSO : ScriptableObject
{
    [Header("--MoveInfo--")]
    public float moveSpeed;

    [Header("--SlideInfo--")]
    public float slideTime;         // �����̵� ���� �ð�
    public float slideDuration;     // �����̵� ���� �ð�

    [Header("--JumpInfo--")]
    public float jumpTime;          // ���� ���� �ð�
    public float checkLandDistance; // Land üũ �Ÿ�
    public float jumpForce;
    public float doubleJumpForce;
    public float checkTime;         // jumpCheckDistance�� �Ѿ�� �ð� 0.001 ���� ������
    public float jumpCheckDistance;

    [Header("--DownInfo--")]
    public float downForce;

    [Header("--KeyInfo--")]
    public KeyCode jumpKey;
    public KeyCode slideKey;
    public KeyCode downKey;
}
