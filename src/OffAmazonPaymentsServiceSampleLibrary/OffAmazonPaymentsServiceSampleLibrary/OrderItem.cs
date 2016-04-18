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
using System.Text;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    /// <summary>
    /// Container class to hold details about an order
    /// </summary>
    public class OrderItem
    {
        private string _name;
        private float _price;
        private int _number;

        /// <summary>
        /// Create a new instance of the Order Item class
        /// </summary>
        /// <param name="name">item name</param>
        /// <param name="price">item price</param>
        /// <param name="number">item quantity</param>
        public OrderItem(string name, float price, int number)
        {
            this.Name = name;
            this.Price = price;
            this.Number = number;
        }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name
        {
            set {this._name = value;}
            get {return this._name;}
        }

        /// <summary>
        /// Item price
        /// </summary>
        public float Price
        {
            set { this._price = value; }
            get { return this._price; }
        }

        /// <summary>
        /// Quantity of items in this order
        /// </summary>
        public int Number
        {
            set { this._number = value; }
            get { return this._number; }
        }
    }
}

