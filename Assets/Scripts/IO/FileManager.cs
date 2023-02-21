using System;
using System.IO;
using UnityEngine;
namespace SedaCinar.AreaFinder.IO
{
    public class FileManager
    {
        #region Public Methods
        public string Load(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return null;

                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Debug.LogError($"FileManager.Load({path}) failed. Reason: {ex.ToString()}" + ex);
            }

            return null;
        }

        public bool Save(string path, string content)
        {
            try
            {
                string folderPath = Path.GetDirectoryName(path);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                File.WriteAllText(path, content);

                return true;
            }
            catch (Exception ex)
            {
               Debug.LogError($"FileManager.Save({path}, {content}) failed. Reason: {ex.ToString()}" + ex);
            }

            return false;
        }
        #endregion
    }
}