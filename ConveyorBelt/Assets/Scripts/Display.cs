using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _currentNumberText;
    [SerializeField]
    private TextMeshPro _totalNumberText;

    private uint _currentNumberOfItems = 0;
    private uint _totalNumberOfItems = 0;

    public uint CurrentNumberOfItems
    {
        get => _currentNumberOfItems;
        set
        {
            if (value != _currentNumberOfItems)
            {
                _currentNumberOfItems = value;
                if (_currentNumberText != null)
                    _currentNumberText.text = $"Current: {_currentNumberOfItems}";
            }
        }
    }

    public uint TotalNumberOfItems
    {
        get => _totalNumberOfItems;
        set
        {
            if (value != _totalNumberOfItems)
            {
                _totalNumberOfItems = value;
                if (_totalNumberText != null)
                    _totalNumberText.text = $"Total: {_totalNumberOfItems}";
            }
        }
    }
}
