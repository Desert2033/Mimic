using System;

public interface ICargoRecipient
{
    public int MaxCargo { get; }
    public int CurrentCargo { get; }

    public event Action<int, int> OnCargoCountChanged;
}
