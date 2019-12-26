using System;

namespace Framework.Core.Objects.Components
{
    public class FieldNotSetException : Exception
    {
        public FieldNotSetException(string fieldName) : base($"Field {fieldName} is not set.")
        {
            
        }
    }
}