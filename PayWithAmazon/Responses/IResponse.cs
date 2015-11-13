using System;
namespace PayWithAmazon.Responses
{
    /// <summary>
    /// Interface for common Response methods 
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Response in Dictionary format
        /// </summary>
        /// <returns>Dictionary<string,object></returns>
        System.Collections.IDictionary GetDictionary();

        /// <summary>
        /// Response in Json format
        /// </summary>
        /// <returns>string json</returns>
        string GetJson();

        /// <summary>
        /// Returns true or false if API call was a success/failure
        /// </summary>
        /// <returns>bool true or false</returns>
        bool GetSuccess();

        /// <summary>
        /// Response in XML format
        /// </summary>
        /// <returns>string xml</returns>
        string GetXml();

        /// <summary>
        /// Errorcode as string
        /// </summary>
        /// <returns>string Error code</returns>
        string GetErrorCode();

        /// <summary>
        /// Error Message 
        /// </summary>
        /// <returns>Error Message</returns>
        string GetErrorMessage();
    }
}
