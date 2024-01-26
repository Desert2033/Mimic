using System;

public interface IHealth
{
    event Action<float, float> OnChangeHP;
    event Action OnHealthRunOut;
}