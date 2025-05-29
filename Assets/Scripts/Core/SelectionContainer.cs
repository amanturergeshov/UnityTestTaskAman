using System;

public class SelectionContainer<T> where T : ISelectableData
{
    private T _currentSelection;
    public T Current => _currentSelection;

    public event Action<T> OnSelectionChanged;

    public void Select(T newSelection)
    {
        if (_currentSelection?.Id == newSelection?.Id)
            return;

        _currentSelection = newSelection;
        _currentSelection.Load();
        OnSelectionChanged?.Invoke(_currentSelection);
    }
}
