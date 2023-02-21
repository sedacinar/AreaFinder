using System;
using UnityEngine;
using Newtonsoft.Json;
namespace SedaCinar.AreaFinder.IO
{
    public class NewtonsoftSerializer
    {
        #region Components

        public JsonSerializerSettings SerializerSettings
        {
            get
            {
                return _serializerSettings;
            }
            set
            {
                _serializerSettings = value;
            }
        }
        private JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            DefaultValueHandling = DefaultValueHandling.Include,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
        #endregion

        #region Public Methods

        public object Deserialize(string serializedObj)
        {
            try
            {
                return JsonConvert.DeserializeObject(serializedObj, SerializerSettings);
            }
            catch (Exception ex)
            {
                Debug.LogError($"NewtonsoftSerializer.Deserialize({serializedObj}) has failed. Reason: {ex}" + ex);
            }

            return null;
        }

        public T Deserialize<T>(string serializedObj)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(serializedObj, SerializerSettings);
            }
            catch (Exception ex)
            {
                Debug.LogError($"NewtonsoftSerializer.Deserialize({serializedObj}) has failed. Reason: {ex}" + ex);
            }

            return default(T);
        }

        public string Serialize(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, SerializerSettings);
            }
            catch (Exception ex)
            {
                Debug.LogError($"NewtonsoftSerializer.Serialize({obj}) has failed. Reason: {ex.ToString()}" + ex);
            }

            return null;
        }

        public object Deserialize(string serializedObj, Type type)
        {
            if (type == null)
                return null;

            try
            {
                return JsonConvert.DeserializeObject(serializedObj, type, SerializerSettings);
            }
            catch (Exception ex)
            {
                Debug.LogError($"NewtonsoftSerializer.Deserialize({serializedObj}) has failed. Reason: {ex}" + ex);
            }

            return null;
        }

        public object GetSerializerSettings()
        {
            return SerializerSettings;
        }

        public void SetSerializerSettings(object serializerSettings)
        {
            if (serializerSettings == null)
                return;

            if (!(serializerSettings is JsonSerializerSettings))
            {
                Debug.LogWarning($"NewtonsoftSerializer.SetSerializerSettings(): serializerSettings type is not same as JsonSerializerSettings");
                return;
            }

            SerializerSettings = serializerSettings as JsonSerializerSettings;
        }

        #endregion
    }
}