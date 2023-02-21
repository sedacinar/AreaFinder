using UnityEngine;
using UnityEngine.UI;
using SedaCinar.AreaFinder.IO;

namespace SedaCinar.AreaFinder.UI
{
    public class SaveButton : MonoBehaviour
    {
        #region Fields
        Button button;
        IOManager ioManager;
        #endregion
        #region Unity Methods
        void Start()
        {
            button = GetComponent<Button>();
            ioManager = FindObjectOfType<IOManager>();
            button.onClick.AddListener(ButtonAction);
        }
        #endregion
        #region Private Methods
        void ButtonAction()
        {
            ioManager.Save();
        }
        #endregion
    }
}