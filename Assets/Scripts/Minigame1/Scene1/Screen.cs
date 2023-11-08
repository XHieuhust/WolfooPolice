using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Screen : MonoBehaviour
    {
        [SerializeField] Image imageMap;
        [SerializeField] GameObject Light;

        public void SetActiveImageMap()
        {
            imageMap.gameObject.SetActive(true);
        }
    }

