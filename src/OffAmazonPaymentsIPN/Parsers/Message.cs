/*******************************************************************************
 *  Copyright 2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License");	
 *
 *  You may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at:
 *  http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License
 *  for the
 *  specific language governing permissions and limitations under the
 *  License.
 * *****************************************************************************	
 */
using Newtonsoft.Json.Linq;
using System;

namespace OffAmazonPaymentsNotifications
{
   
    /// <summary>
    /// Represents an internal wrapper for a message that is protocol
    /// independent
    /// Format is key/value pairs
    /// </summary>
    internal class Message
    {
        /// <summary>
        /// Parsed json message
        /// </summary>
        private Newtonsoft.Json.Linq.JObject _parsedMessage;

        /// <summary>
        /// Metadata associated with this message
        /// </summary>
        private INotificationMetadata _metadata;

        /// <summary>
        /// Error message for invalid json string
        /// </summary>
        private const string InvalidJsonErrMsg = "Error with message - content is not in json format";

        /// <summary>
        /// Error message for a missing mandatory field
        /// </summary>
        private const string MissingMandatoryFieldErrMsg = "Error with message - mandatory field {0} cannot be found";

        /// <summary>
        /// Error message for invalid cast to a date time object for a field value
        /// </summary>
        private const string FieldNotDateTimeErrMsgFormatString = "Error with message - expected field {0} to be DateTime object";

        /// <summary>
        /// Create a new message the acts as a wrapper
        /// around the json string
        /// </summary>
        /// <throws>NotificationException if the string is not valid json</throws>
        /// <param name="json">A valid json string</param>
        public Message(string json)
        {
            try
            {
                this._parsedMessage = JObject.Parse(json);
            }
            catch (Exception ex)
            {
                throw new NotificationsException(InvalidJsonErrMsg, ex);
            }
        }

        /// <summary>
        /// Metadata associated with this message
        /// </summary>
        public INotificationMetadata Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        /// <summary>
        /// Return the value associated with the field name,
        /// throws an exception if it cannot be found
        /// </summary>
        /// <param name="fieldName">Name of the field to retrieve</param>
        /// <returns>value of the field</returns>
        public string GetMandatoryField(string fieldName)
        {
            JToken value = GetValueAsToken(fieldName);
            return value.ToString();
        }

        /// <summary>
        /// Return the value of the field as a timestamp
        /// </summary>
        /// <param name="fieldName">Field name containing timestamp data</param>
        /// <returns>DateTime representation of the object</returns>
        public DateTime GetMandatoryFieldAsDateTime(string fieldName)
        {
            try
            {
                return (DateTime)GetValueAsToken(fieldName);
            }
            catch (FormatException fe)
            {
                throw new NotificationsException(String.Format(FieldNotDateTimeErrMsgFormatString, fieldName), fe);
            }
        }

        /// <summary>
        /// Return the JToken associated with this field,
        /// otherwise throw an exception
        /// </summary>
        /// <param name="fieldName">Name of the field to retrieve</param>
        /// <returns>Filed as JToken</returns>
        private JToken GetValueAsToken(string fieldName)
        {
            JToken value = this._parsedMessage.GetValue(fieldName);

            if (value == null)
            {
                throw new NotificationsException(String.Format(MissingMandatoryFieldErrMsg, fieldName));
            }
            return value;
        }

        /// <summary>
        /// Get the value associated with this field,
        /// or return null if not present
        /// </summary>
        /// <param name="fieldName">Name of the field to retrieve</param>
        /// <returns>String or null if not defined</returns>
        public String GetField(string fieldName)
        {
            JToken value = this._parsedMessage.GetValue(fieldName);
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return null;
            }
        }
    }

}
