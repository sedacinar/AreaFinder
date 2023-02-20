using TMPro;
using UnityEngine;
using SedaCinar.AreaFinder.Core;
namespace SedaCinar.AreaFinder.UI
{
    public class SizeFieldBase : MonoBehaviour
    {
        #region Fields
        protected int width;
        protected int height;
        protected MapCreator mapCreator;
        TMP_InputField inputField;
        #endregion
        #region Unity Methods
        protected virtual void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            mapCreator = FindObjectOfType<MapCreator>();
            inputField.onValueChanged.AddListener(GetInput);
        }
        #endregion
        #region Private Methods
        protected virtual void GetInput(string input)
        {
            mapCreator.GetSize(out width, out height);
        }
        #endregion
    }
}
