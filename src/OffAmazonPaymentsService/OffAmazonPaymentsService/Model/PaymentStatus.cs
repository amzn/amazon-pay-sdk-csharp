/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Off Amazon Payments Service CSharp Library
 *  API Version: 2013-01-01
 * 
 */


using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;


namespace OffAmazonPaymentsService.Model
{
    [XmlTypeAttribute(Namespace = "http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01")]
    [XmlRootAttribute(Namespace = "http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01", IsNullable = false)]
    public enum PaymentStatus
    {
        [XmlEnum(Name = "Pending")]
        PENDING,
        [XmlEnum(Name = "Open")]
        OPEN,
        [XmlEnum(Name = "Declined")]
        DECLINED,
        [XmlEnum(Name = "Closed")]
        CLOSED,
        [XmlEnum(Name = "Completed")]
        COMPLETED,
        [XmlEnum(Name = "MerchantCollection")]
        MERCHANTCOLLECTION,
        [XmlEnum(Name = "BadDebt")]
        BADDEBT

    }

}