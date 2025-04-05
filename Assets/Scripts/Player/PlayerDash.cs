using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashTime = 0.2f;
    private Rigidbody rb;
    private bool onDash = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !onDash)
        {
            StartCoroutine(RealizarDash());
        }
    }

    private IEnumerator RealizarDash()
    {
        onDash = true;
        Vector3 direccion = transform.forward * dashForce;
        rb.AddForce(direccion, ForceMode.Impulse);
        yield return new WaitForSeconds(dashTime);
        onDash = false;
    }
}
