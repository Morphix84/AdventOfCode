using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepTools.Model;
public class BarrelShiftRegister<T>
{
    private T[] _register;
    private int _registerSize;

    public BarrelShiftRegister(int registerSize)
    {
        _registerSize = registerSize;
        _register = new T[_registerSize];
    }

    public void ShiftLeft()
    {
        // Shift all elements in the register one position to the left
        for (int i = 0; i < _registerSize - 1; i++)
        {
            _register[i] = _register[i + 1];
        }

        // Set the last element in the register to the default value for the generic type
        _register[_registerSize - 1] = default(T);
    }

    public void ShiftRight()
    {
        // Shift all elements in the register one position to the right
        for (int i = _registerSize - 1; i > 0; i--)
        {
            _register[i] = _register[i - 1];
        }

        // Set the first element in the register to the default value for the generic type
        _register[0] = default(T);
    }

    public void SetValue(int index, T value)
    {
        // Set the value at the specified index in the register
        _register[index] = value;
    }

    public T GetValue(int index)
    {
        // Return the value at the specified index in the register
        return _register[index];
    }
}