#region Assembly WebDriver, Version=3.141.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Rainbow\.nuget\packages\selenium.webdriver\3.141.0\lib\netstandard2.0\WebDriver.dll
#endregion

using System.Reflection;

namespace OpenQA.Selenium
{
    //
    // Summary:
    //     Capabilities of the browser that you are going to use
    [DefaultMember("Item")]
    public interface ICapabilities
    {
        //
        // Summary:
        //     Gets the capability value with the specified name.
        //
        // Parameters:
        //   capabilityName:
        //     The name of the capability to get.
        //
        // Returns:
        //     The value of the capability.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The specified capability name is not in the set of capabilities.
        object this[string capabilityName] { get; }

        //
        // Summary:
        //     Gets a capability of the browser.
        //
        // Parameters:
        //   capability:
        //     The capability to get.
        //
        // Returns:
        //     An object associated with the capability, or null if the capability is not set
        //     on the browser.
        object GetCapability(string capability);
        //
        // Summary:
        //     Gets a value indicating whether the browser has a given capability.
        //
        // Parameters:
        //   capability:
        //     The capability to get.
        //
        // Returns:
        //     Returns true if the browser has the capability; otherwise, false.
        bool HasCapability(string capability);
    }
}
