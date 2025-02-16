/*
	Copyright © Bryan Apellanes 2015  
*/

using Bam.Encryption;

namespace Bam.ServiceProxy.Encryption
{
    /// <summary>
    /// Attribute used to adorn classes or methods that require
    /// invocation calls include HMAC signature.  Implicitly requires
    /// application level encryption.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiHmacKeyRequiredAttribute: EncryptAttribute
    {
    }
}
