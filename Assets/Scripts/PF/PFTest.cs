using Grandma.PF;
using UnityEngine;

public class PFTest : MonoBehaviour
{
    [SerializeField]
    private PF m_PF;
    [SerializeField]
    private PFData m_PFData;

    private void Start()
    {
        m_PF.SetData(m_PFData);

        m_PF.CurrentAmmo.Subscribe(ammo => Debug.Log(ammo));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_PF.Fire();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            m_PF.CancelFire();
        }
    }
}
