using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NoteOffsetType
{
    PERFECT     = 4,
    GOOD        = 3,
    NORMAL      = 2,
    BAD         = 1,
    MISS        = 0
}

public class NoteManager : MonoSingleton<NoteManager>
{
    public int Perfect
    {
        get { return _perfect; }
        set { ApplyScore(NoteOffsetType.PERFECT, value); }
    }
    public int Good
    {
        get { return _good; }
        set { ApplyScore(NoteOffsetType.GOOD, value); }
    }
    public int Normal
    {
        get { return _normal; }
        set { ApplyScore(NoteOffsetType.NORMAL, value); }
    }
    public int Bad
    {
        get { return _bad; }
        set { ApplyScore(NoteOffsetType.BAD, value); }
    }
    public int Miss
    {
        get { return _miss; }
        set
        {
            ApplyScore(NoteOffsetType.MISS, value);
        }
    }

    public int Score => _score;
    public int Combo => _combo; // �� ���߿� MaxCombo�� ������ ���� ���� ������?

    [SerializeField]
    [Tooltip("���� ������ ���� ���� �޺� ����")]
    private int _comboApplyCount;

    [SerializeField]
    [Tooltip("�ִ� ����")]
    private int _maxApplyAmount;

    private int _perfect;
    private int _good;
    private int _normal;
    private int _bad;
    private int _miss;
    [SerializeField] private int _score;
    [SerializeField] private int _combo;
    [SerializeField] private int _maxCombo = 0;
    private int _applyAmount;

    private void ApplyScore(NoteOffsetType noteType, int value)
    {
        CalculateApplyAmount(noteType);
        int score = CalculateScore(noteType, value);
        _score += score * _applyAmount;
    }

    private int CalculateScore(NoteOffsetType noteType, int value)
    {
        switch (noteType)
        {
            case NoteOffsetType.PERFECT:
                _perfect = value;
                return (int)NoteOffsetType.PERFECT;
            case NoteOffsetType.GOOD:
                _good = value;
                return (int)NoteOffsetType.GOOD;
            case NoteOffsetType.NORMAL:
                _normal = value;
                return (int)NoteOffsetType.NORMAL;
            case NoteOffsetType.BAD:
                _bad = value;
                return (int)NoteOffsetType.BAD;
            case NoteOffsetType.MISS:
                _miss = value;
                if(_maxCombo < _combo)
                    _maxCombo = _combo;
                _combo = 0;
                return (int)NoteOffsetType.MISS;
        }

        Debug.LogError("�̰� �ɻ�ġ ������? ��,..");
        return 0;
    }

    private void CalculateApplyAmount(NoteOffsetType noteType)
    {
        if(noteType != NoteOffsetType.MISS)
            _combo++;
        int num = _combo / _comboApplyCount + 1;
        if (num < _maxApplyAmount)
        {
            _applyAmount = num;
        }
    }
}
