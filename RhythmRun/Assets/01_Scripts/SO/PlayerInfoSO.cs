using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class PlayerInfoSO : ScriptableObject
{
    [Header("--SlideInfo--")]
    public float slideTime;         // �����̵� ���� �ð�
    public float slideDuration;     // �����̵� ���� �ð�

    [Header("--JumpInfo--")]
    public float jumpTime;          // ���� ���� �ð�
    public float checkLandDistance; // Land üũ �Ÿ�
    public float jumpForce;

    [Header("--KeyInfo--")]
    public KeyCode jumpKey;
    public KeyCode slideKey;
}
