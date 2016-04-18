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

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OffAmazonPaymentsService;
using OffAmazonPaymentsServiceSampleLibrary;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsNotifications.Samples
{
    public partial class PaymentsNotificationMultipleShipment : PaymentsNotificationSample
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handle the form submisson
        /// </summary>
        /// <param name="sender">reference to the sender</param>
        /// <param name="e">arguments for the event</param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentsNotificationMultipleShipment_2.aspx?orderReferenceId=" + this.tb_ORId.Text + "&number=" + this.ddl_itemNumber.SelectedValue);
        }

    }
}
