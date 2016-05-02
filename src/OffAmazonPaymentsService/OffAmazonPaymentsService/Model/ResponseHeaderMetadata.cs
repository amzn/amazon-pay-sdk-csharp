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
using System.Text;

namespace OffAmazonPaymentsService.Model
{
  /// <summary>
  /// Metadata summary from response headers
  /// </summary>
  public class ResponseHeaderMetadata
  {
    private String requestId;
    private String responseContext;
    private String timestamp;

    public ResponseHeaderMetadata() 
    {
      requestId = responseContext = timestamp = null;
    }

    public ResponseHeaderMetadata(String requestId, String responseContext, String timestamp)
    {
      this.requestId = requestId;
      this.responseContext = responseContext;
      this.timestamp = timestamp;
    }

    /// <summary>
    /// Gets the x-mws-request-id header value.
    /// </summary>
    public String RequestId
    {
      get { return this.requestId; }
    }

    /// <summary>
    /// Gets the x-mws-response-context header value.
    /// </summary>
    public String ResponseContext
    {
      get { return this.responseContext; }
    }

    /// <summary>
    /// Gets the x-mws-timestamp header value.
    /// </summary>
    public String Timestamp
    {
      get { return this.timestamp; }
    }

    public override string ToString() 
    {
      return "[RequestId: " + requestId + ", ResponseContext: " + responseContext + ", Timestamp: " + timestamp + "]";
    }
  }
}
