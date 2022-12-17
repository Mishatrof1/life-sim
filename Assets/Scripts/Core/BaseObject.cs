using System.Security.AccessControl;

namespace Core
{
    public abstract class BaseObject
    {
        public string Id { get; }

        public BaseObject(string id)
        {
            Id = id;
        }
    }
}