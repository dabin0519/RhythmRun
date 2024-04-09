using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Parallax")]
public class ParallaxSO : ScriptableObject
{
    public float skySpeed;
    public float backSpeed;
    public float middleSpeed;
    public float frontSpeed;
    public float nearSpeed;
}
