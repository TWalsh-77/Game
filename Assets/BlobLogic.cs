using System;
using UnityEngine;
    public class BlobLogic : MonoBehaviour
    {
        public MainCharacterLogic mainCharacter;
        public float timeDestruction = 5.0f;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("MainCharacter")) return;
            mainCharacter = other.gameObject.GetComponent<MainCharacterLogic>();
            mainCharacter.hp = mainCharacter.hp - 10;
            Destroy(gameObject);
        }

        private void Update()
        {
            Destroy(gameObject, timeDestruction);
        }
    }