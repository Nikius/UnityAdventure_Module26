using UnityEngine;

namespace Project.Develop
{
    public class DeadZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Character character = other.GetComponent<Character>();
        
            if (character != null)
                character.OnDead();
        }
    }
}
