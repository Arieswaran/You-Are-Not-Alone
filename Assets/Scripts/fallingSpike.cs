using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingSpike : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = transform.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gravityOn()
    {
      rb.simulated = true;
    }
}
