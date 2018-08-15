using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CrossCuting.Serialization
{
    public interface ISerializer
    {

        T DeserializeObject<T>(string serializedObject);
        string SerializeObject<T>(T obj);

    }
}
