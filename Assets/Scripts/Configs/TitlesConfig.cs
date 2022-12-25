using Structures;
using UnityEngine;

[CreateAssetMenu(fileName = "Titles", menuName = "Titles", order = 0)]
public class TitlesConfig : ScriptableObject
{
    [SerializeField] private Titles[] _titles;
    public Titles[] Titles => _titles;
}