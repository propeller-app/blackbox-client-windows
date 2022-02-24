using System;

namespace Blackbox
{
    [Serializable]
    public class Device : IEquatable<Device>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Device() { }

        public Device(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool Equals(Device d) => d.Id == this.Id;

        public override bool Equals(object obj)
        {
            return Equals(obj as Device);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
