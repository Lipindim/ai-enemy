using System;
using UnityEngine.UI;


public class PeacefullyPathActivator : INotifiable
{
    private const int MAX_PEACEFULLY_VALUE = 2;

    private readonly Button _passPeacefully;

    public PeacefullyPathActivator(Button passPeacefully)
    {
        _passPeacefully = passPeacefully;
    }

    public void Notify(DataPlayer dataPlayer)
    {
        if(dataPlayer.DataType == DataType.CrimeRate)
        {
            if (dataPlayer.Value > MAX_PEACEFULLY_VALUE)
                DeactivatePeacefullyPath();
            else
                ActivatePeacefullyPath();
        }
    }

    private void ActivatePeacefullyPath()
    {
        _passPeacefully.gameObject.SetActive(true);
    }

    private void DeactivatePeacefullyPath()
    {
        _passPeacefully.gameObject.SetActive(false);
    }
}
