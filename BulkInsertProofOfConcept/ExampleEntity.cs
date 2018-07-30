#region YourCompany (c) 2018
// =============================================================================
//
//  @file           ExampleEntity.cs
//  
//  @date           30 Jul 2018
//  
//  First Author    Andrew Servania
//
// =============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BulkInsertProofOfConcept
{
    /// <summary>
    /// A simple entity class used to persist some sample data.
    /// </summary>
    public class ExampleEntity
    {
        // All class constructors, initialize, terminate and dispose methods.
        #region Construct / Init / Terminate / Dispose

        /// <summary>
        /// Default constructor for class
        /// </summary>
        public ExampleEntity()
        {
        }

        #endregion

        // Use this region to implement interface members for the given interface.
        #region <interface name> Members
        #endregion

        // Properties for this class.
        #region Properties

        public int Id { get; set; }

        public string SomeValue { get; set; }

        public string SomeOtherValue { get; set; }

        #endregion

        // Events for this class.
        #region Events
        #endregion

        // All public methods for this class.
        #region Methods
        #endregion

        // All protected / private methods for this class.
        #region Helper methods
        #endregion

        // All event handlers for this class.
        #region Event handlers
        #endregion

        // Private fields
        #region Fields

        //// Fields MUST start with an underscore, e.g. int _number;

        #endregion
    }
}
