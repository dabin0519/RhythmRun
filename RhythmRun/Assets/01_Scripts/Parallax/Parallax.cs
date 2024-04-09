using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParallaxType
{
    NONE,
    SKY,
    BACK,
    MIDDLE,
    FRONT,
    NEAR
}

public class Parallax : MonoBehaviour
{
    [SerializeField] private ParallaxSO _parallaxInfo;
    [SerializeField] private ParallaxType _parallaxType;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _moveXPos = 6f;

    private float _moveSpeed;

    private void Awake()
    {
        SetMoveSpeed();
    }

    private void Update()
    {
        if(transform.localPosition.x < _xOffset)
        {
            transform.localPosition = new Vector2(_moveXPos, transform.localPosition.y);
        }

        Movement();
    }

    private void Movement()
    {
        Vector3 moveVec = Vector2.left * _moveSpeed * Time.deltaTime;
        transform.position += moveVec;
    }

    private void SetMoveSpeed()
    {
        switch (_parallaxType)
        {
            case ParallaxType.NONE:
                Debug.LogError("이거 None하면 안되용!!!");
                break;
            case ParallaxType.SKY:
                _moveSpeed = _parallaxInfo.skySpeed;
                break;
            case ParallaxType.BACK:
                _moveSpeed = _parallaxInfo.backSpeed;
                break;
            case ParallaxType.MIDDLE:
                _moveSpeed = _parallaxInfo.middleSpeed;
                break;
            case ParallaxType.FRONT:
                _moveSpeed = _parallaxInfo.frontSpeed;
                break;
            case ParallaxType.NEAR:
                _moveSpeed = _parallaxInfo.nearSpeed;
                break;
        }
    }
}
