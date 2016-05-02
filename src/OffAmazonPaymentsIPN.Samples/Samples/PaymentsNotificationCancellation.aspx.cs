using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;

namespace OffAmazonPaymentsNotifications.Samples
{
    public partial class PaymentsNotificationCancellation : PaymentsNotificationSample
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handle the form submisson
        /// </summary>

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string orderReferenceId = tb_ORId.Text;
            string orderAmount = tb_OrderAmount.Text;
            OffAmazonPaymentsServiceSimpleCheckout instance = new OffAmazonPaymentsServiceSimpleCheckout(orderReferenceId);
            RunSample(orderReferenceId, orderAmount, instance);
        }

        private void RunSample(string orderReferenceId, string orderAmount, OffAmazonPaymentsServiceSimpleCheckout instance)
        {
            /************************************************************************
             * Invoke Set Order Reference Details Action
             ***********************************************************************/
            SetOrderReferenceDetailsResponse setOrderDetailsResponse = instance.SetOrderReferenceDetails(orderAmount);
            if (setOrderDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from SetOrderReference request is null");
    
            /************************************************************************
             * Invoke Confirm Order Reference Action
             ***********************************************************************/
            if (instance.ConfirmOrderReferenceObject() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmOrderResponse request is null");

            /************************************************************************
             * Invoke Authorize Action
             ***********************************************************************/
            AuthorizeResponse authResponse = instance.AuthorizeAction(setOrderDetailsResponse, 1);
            if (authResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from Authorization Response request is null");

            /************************************************************************
             * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
             ***********************************************************************/
            lblNotification.Text += WaitAndGetNotificationDetails(authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId + "_Authorize");

            instance.CheckAuthorizationStatus(authResponse);
            
            OffAmazonPaymentsServiceCancellation cancelInstance = new OffAmazonPaymentsServiceCancellation();

            /************************************************************************
             * Invoke Cancel Order Reference Action
             ***********************************************************************/
            CancelOrderReferenceResponse cancelResponse = cancelInstance.CancelOrderReference(orderReferenceId);
            
            if (cancelResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from the CancelOrderReference request is null");
        }
    }
}
