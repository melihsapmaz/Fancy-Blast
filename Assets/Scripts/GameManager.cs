using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    // Singleton pattern read-only property to get the instance of the GameManager
    public static GameManager Instance { get; private set; }
    
    // Read-only properties to store the game parameters
    public int RowCount { get; private set; }
    public int ColumnCount { get; private set; }
    public int NumberOfColors { get; private set; }
    public int ConditionA { get; private set; }
    public int ConditionB { get; private set; }
    public int ConditionC { get; private set; }
    
    // Reference to the input fields in the scene
    [Header("Input Fields")]
    [SerializeField] private TMPro.TMP_InputField rowCountInputField;
    [SerializeField] private TMPro.TMP_InputField columnCountInputField;
    [SerializeField] private TMPro.TMP_InputField numberOfColorsInputField;
    [SerializeField] private TMPro.TMP_InputField conditionAInputField;
    [SerializeField] private TMPro.TMP_InputField conditionBInputField;
    [SerializeField] private TMPro.TMP_InputField conditionCInputField;

    [Header("Game Parameter Screens")]
    [SerializeField] private GameObject gameParametersInputPanel;
    [SerializeField] private GameObject gameParametersTextPanel;
    
    [Header("In Game UI")]
    [SerializeField] private Image gameTable;

    private void Awake()
    {
        // If the instance of the GameManager is not set
        if (Instance is null)
        {
            // Set the instance of the GameManager to this instance
            Instance = this;
        }
        // If the instance of the GameManager is already set
        else
        {
            // Destroy this instance of the GameManager
            Destroy(gameObject);
        }
        
        // Keep the GameManager alive between scenes
        DontDestroyOnLoad(gameObject);
        
        // Set the default values for the game parameters
        RowCount = 9;
        ColumnCount = 10;
        NumberOfColors = 5;
        ConditionA = 3;
        ConditionB = 4;
        ConditionC = 5;
        gameTable.rectTransform.sizeDelta = new Vector2(ColumnCount * 100, RowCount * 100);
    }
    private void Start()
    {
        
        rowCountInputField?.onEndEdit.AddListener(ValidateRowCountInput);
        columnCountInputField?.onEndEdit.AddListener(ValidateColumnCountInput);
        numberOfColorsInputField?.onEndEdit.AddListener(ValidateNumberOfColorsInput);
        conditionAInputField?.onEndEdit.AddListener(ValidateConditionAInput);
        conditionBInputField?.onEndEdit.AddListener(ValidateConditionBInput);
        conditionCInputField?.onEndEdit.AddListener(ValidateConditionCInput);
        
    }
    private void ValidateRowCountInput(string input)
    {
        const int minValue = 2;
        const int maxValue = 10;
        if (int.TryParse(input, out int value))
        {
            // Clamp the value within the range
            value = Mathf.Clamp(value, minValue, maxValue);
            rowCountInputField.text = value.ToString();
        }
        else
        {
            // Reset to minimum if invalid input is given
            rowCountInputField.text = minValue.ToString();
        }
    }
    private void ValidateColumnCountInput(string input)
    {
        const int minValue = 2;
        const int maxValue = 10;
        if (int.TryParse(input, out int value))
        {
            // Clamp the value within the range
            value = Mathf.Clamp(value, minValue, maxValue);
            columnCountInputField.text = value.ToString();
        }
        else
        {
            // Reset to minimum if invalid input is given
            columnCountInputField.text = minValue.ToString();
        }
    }
    private void ValidateNumberOfColorsInput(string input)
    {
        const int minValue = 1;
        const int maxValue = 6;
        if (int.TryParse(input, out int value))
        {
            // Clamp the value within the range
            value = Mathf.Clamp(value, minValue, maxValue);
            numberOfColorsInputField.text = value.ToString();
        }
        else
        {
            // Reset to minimum if invalid input is given
            numberOfColorsInputField.text = minValue.ToString();
        }
    }
    private void ValidateConditionAInput(string input)
    {
        if (int.TryParse(input, out int value))
        {
            conditionAInputField.text = value.ToString();
            if (int.TryParse(conditionBInputField.text, out int conditionBValue))
            {
                if (value >= conditionBValue)
                {
                    conditionBInputField.text = (value + 1).ToString();
                    conditionCInputField.text = (value + 2).ToString();
                }
            }
        }
        else
        {
            conditionAInputField.text = "1";
        }
    }
    private void ValidateConditionBInput(string input)
    {
        if (int.TryParse(input, out int value))
        {
            conditionBInputField.text = value.ToString();
            if (int.TryParse(conditionCInputField.text, out int conditionCValue))
            {
                if (value >= conditionCValue)
                {
                    conditionCInputField.text = (value + 1).ToString();
                }
            }
            if (int.TryParse(conditionAInputField.text, out int conditionAValue))
            {
                if (value <= conditionAValue)
                {
                    conditionAInputField.text = (value - 1).ToString();
                }
            }
        }
        else
        {
            conditionBInputField.text = "1";
        }
    }
    private void ValidateConditionCInput(string input)
    {
        const int minValue = 3;
        if (int.TryParse(input, out int value))
        {
            // Clamp the value within the range
            value = Mathf.Max(value, minValue);
            conditionCInputField.text = value.ToString();
            if (int.TryParse(conditionBInputField.text, out int conditionBValue))
            {
                if (value <= conditionBValue)
                {
                    conditionBInputField.text = (value - 1).ToString();
                    if (int.TryParse(conditionAInputField.text, out int conditionAValue))
                    {
                        if (value <= conditionAValue)
                        {
                            conditionAInputField.text = (value - 2).ToString();
                        }
                    }
                }
            }
        }
        else
        {
            // Reset to minimum if invalid input is given
            conditionCInputField.text = minValue.ToString();
        }
    }
    public void OnStartButtonClick()
    {
        // Get the row count from the input field
        RowCount = int.Parse(rowCountInputField.text);
        // Get the column count from the input field
        ColumnCount = int.Parse(columnCountInputField.text);
        // Get the number of colors from the input field
        NumberOfColors = int.Parse(numberOfColorsInputField.text);
        // Get the condition A from the input field
        ConditionA = int.Parse(conditionAInputField.text);
        // Get the condition B from the input field
        ConditionB = int.Parse(conditionBInputField.text);
        // Get the condition C from the input field
        ConditionC = int.Parse(conditionCInputField.text);

        gameParametersInputPanel.SetActive(false);
        gameParametersTextPanel.SetActive(false);
        
        // Game Table's width and height will be equal to the 100 times of the RowCount and ColumnCount
        gameTable.rectTransform.sizeDelta = new Vector2(ColumnCount * 100, RowCount * 100);
        
    }
}
