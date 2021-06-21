using System;


class Enemy : INotifiable
{
    private const int KCoins = 5;
    private const float KPower = 1.5f;
    private const int MaxHealthPlayer = 20;
    private const int KCrimeRate = 2;

    private string _name;
    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;
    private int _crimeRate;

    public Enemy(string name)
    {
        _name = name;
    }

    public void Notify(DataPlayer dataPlayer)
    {
        switch (dataPlayer.DataType)
        {
            case DataType.Money:
                _moneyPlayer = dataPlayer.Value;
                break;

            case DataType.Health:
                _healthPlayer = dataPlayer.Value;
                break;

            case DataType.Power:
                _powerPlayer = dataPlayer.Value;
                break;

            case DataType.CrimeRate:
                _crimeRate = dataPlayer.Value;
                break;

            default:
                throw new ArgumentException($"Unsupported data type: {dataPlayer.DataType}.");
        }
    }

    public int Power
    {
        get
        {
            var kHealth = _healthPlayer > MaxHealthPlayer ? 100 : 5;
            var power = (int)(_moneyPlayer / KCoins + kHealth + _powerPlayer / KPower + _crimeRate / KCrimeRate);

            return power;
        }
    }
}
