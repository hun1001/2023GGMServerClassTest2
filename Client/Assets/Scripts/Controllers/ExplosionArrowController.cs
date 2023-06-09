using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionArrowController : ArrowController, IRemoveEventHandler
{
    public void RemoveEvent()
    {
        GameObject effect = Managers.Resource.Instantiate("Effect/ExplosionEffect");
        effect.transform.position = transform.position;
        Destroy(effect, 2.0f);
    }
}
