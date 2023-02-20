using SedaCinar.AreaFinder.Core;
using UnityEngine;
using UnityEngine.UI;

namespace SedaCinar.AreaFinder.UI
{
    public class GenerateButtton : MonoBehaviour
    {
        #region Fields
        Button button;
        MapArea mapArea;
        #endregion
        #region Unity Methods
        void Start()
        {
            button = GetComponent<Button>();
            mapArea = FindObjectOfType<MapArea>();
            button.onClick.AddListener(ButtonAction);
        }
        #endregion

        #region Private Methods
        void ButtonAction()
        {
            mapArea.GenerateMap();
        }
        #endregion
    }
}