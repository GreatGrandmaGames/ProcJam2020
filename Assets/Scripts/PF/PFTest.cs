using Grandma.PF;
using UnityEngine;

public class PFTest : MonoBehaviour
{
    [SerializeField]
    private PF m_PF;

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
