using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainWindowObserver : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _playerMoney;

    [SerializeField]
    private TMP_Text _playerHealth;

    [SerializeField]
    private TMP_Text _playerPower;

    [SerializeField]
    private TMP_Text _playerCrimeRate;

    [SerializeField]
    private TMP_Text _enemyPower;


    [SerializeField]
    private Button _increaseMoney;

    [SerializeField]
    private Button _decreaseMoney;


    [SerializeField]
    private Button _increaseHealth;

    [SerializeField]
    private Button _decreaseHealth;


    [SerializeField]
    private Button _increasePower;

    [SerializeField]
    private Button _decreasePower;


    [SerializeField]
    private Button _increaseCrimeRate;

    [SerializeField]
    private Button _decreaseCrimeRate;


    [SerializeField]
    private Button _fight;

    [SerializeField]
    private Button _passPeacefully;


    private Money _money;
    private Health _heath;
    private Power _power;
    private CrimeRate _crimeRate;

    private Enemy _enemy;
    private PeacefullyPathActivator _peacefullyPathActivator;


    private void Start()
    {
        _enemy = new Enemy("Enemy Skull");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _heath = new Health(nameof(Health));
        _heath.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        _crimeRate = new CrimeRate(nameof(CrimeRate));
        _crimeRate.Attach(_enemy);

        _peacefullyPathActivator = new PeacefullyPathActivator(_passPeacefully);
        _crimeRate.Attach(_peacefullyPathActivator);

        _increaseMoney.onClick.AddListener(() => IncreaseValue(_money));
        _decreaseMoney.onClick.AddListener(() => DecreaseValue(_money));

        _increaseHealth.onClick.AddListener(() => IncreaseValue(_heath));
        _decreaseHealth.onClick.AddListener(() => DecreaseValue(_heath));

        _increasePower.onClick.AddListener(() => IncreaseValue(_power));
        _decreasePower.onClick.AddListener(() => DecreaseValue(_power));

        _increaseCrimeRate.onClick.AddListener(() => IncreaseValue(_crimeRate));
        _decreaseCrimeRate.onClick.AddListener(() => DecreaseValue(_crimeRate));

        _fight.onClick.AddListener(Fight);
        _passPeacefully.onClick.AddListener(PassPeacefully);
    }

    private void OnDestroy()
    {
        _increaseMoney.onClick.RemoveAllListeners();
        _decreaseMoney.onClick.RemoveAllListeners();

        _increaseHealth.onClick.RemoveAllListeners();
        _decreaseHealth.onClick.RemoveAllListeners();

        _increasePower.onClick.RemoveAllListeners();
        _decreasePower.onClick.RemoveAllListeners();

        _increaseCrimeRate.onClick.RemoveAllListeners();
        _decreaseCrimeRate.onClick.RemoveAllListeners();

        _fight.onClick.RemoveAllListeners();
        _passPeacefully.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _power.Detach(_enemy);
        _crimeRate.Detach(_enemy);
        _crimeRate.Detach(_peacefullyPathActivator);
    }

    private void IncreaseValue(DataPlayer dataPlayer)
    {
        dataPlayer.Value++;
        ChangeDataWindow(dataPlayer);
    }

    private void DecreaseValue(DataPlayer dataPlayer)
    {
        dataPlayer.Value--;
        ChangeDataWindow(dataPlayer);
    }

    private void Fight()
    {
        Debug.Log(_power.Value >= _enemy.Power
           ? "<color=#07FF00>Win!!!</color>"
           : "<color=#FF0000>Lose!!!</color>");
    }

    private void PassPeacefully()
    {
        Debug.Log("<color=#07FF00>Passed peacefully!!!</color>");
    }

    private void ChangeDataWindow(DataPlayer dataPlayer)
    {
        switch (dataPlayer.DataType)
        {
            case DataType.Money:
                _playerMoney.text = $"Money: {dataPlayer.Value}";
                break;

            case DataType.Health:
                _playerHealth.text = $"Health: {dataPlayer.Value}";
                break;

            case DataType.Power:
                _playerPower.text = $"Power: {dataPlayer.Value}";
                break;

            case DataType.CrimeRate:
                _playerCrimeRate.text = $"Crime rate: {dataPlayer.Value}";
                break;

            default:
                throw new ArgumentException($"Unsupported data type: {dataPlayer.DataType}");
        }

        _enemyPower.text = $"Enemy Power: {_enemy.Power}";
    }
}
