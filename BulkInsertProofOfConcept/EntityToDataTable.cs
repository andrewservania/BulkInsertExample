#region YourCompany (c) 2018
// =============================================================================
//
//  @file           EntityToDataTablecs.cs
//  
//  @date           30 Jul 2018
//  
//  First Author    Andrew Servania
//
// =============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace BulkInsertProofOfConcept
{
    /// <summary>
    /// Responsible for converting a list of entities into a DataTable
    /// so that it can be inserted using SqlBulkCopy.
    /// </summary>
    public static class EntityToDataTable
    {
        // All class constructors, initialize, terminate and dispose methods.
        #region Construct / Init / Terminate / Dispose

        #endregion

        // Use this region to implement interface members for the given interface.
        #region <interface name> Members
        #endregion

        // Properties for this class.
        #region Properties
        #endregion

        // Events for this class.
        #region Events
        #endregion

        // All public methods for this class.
        #region Methods

        /// <summary>
        /// Convert a list with Entities into a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of the entity to convert into a DataTable</typeparam>
        /// <param name="listWithEntities">The list containing the actual entities.</param>
        /// <returns>A DataTable object containing the entities</returns>
        public static DataTable Convert<T>(this List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];

            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }
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
