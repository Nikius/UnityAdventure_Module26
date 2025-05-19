using UnityEngine;

namespace Project.Develop
{
    public class Cup : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Character character = other.GetComponent<Character>();
        
            if (character != null)
                Debug.Log("You are Winner!");
        }
    }
}
