using System.Runtime.Serialization;

namespace Glare.Loader.Class.Shared
{
    [DataContract]
    public class LoginCredentials
    {
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string User { get; set; }
    }
}