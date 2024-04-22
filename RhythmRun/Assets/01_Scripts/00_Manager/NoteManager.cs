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
    public int Combo => _combo; // 뭐 나중에 MaxCombo를 밖으로 뺄수 있지 않을까?

    [SerializeField]
    [Tooltip("다음 배율을 가기 위한 콤보 갯수")]
    private int _comboApplyCount;

    [SerializeField]
    [Tooltip("최대 배율")]
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

        Debug.LogError("이거 심상치 않은데? 음,..");
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
