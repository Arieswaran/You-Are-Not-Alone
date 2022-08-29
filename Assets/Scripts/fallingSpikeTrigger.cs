using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingSpikeTrigger : MonoBehaviour
{
  [SerializeField] public GameObject spike;

  void start()
  {

  }
  void OnTriggerEnter2D(Collider2D other)
  {
    spike.GetComponent<fallingSpike>().gravityOn();
  }
}
