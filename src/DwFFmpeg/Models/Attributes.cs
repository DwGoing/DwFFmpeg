using System;

namespace DwFFmpeg
{
    public class PropertyAttribute : Attribute
    {
        public readonly string Name;

        public PropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
