#region YourCompany (c) 2018
// =============================================================================
//
//  @file           BulkInserter.cs
//  
//  @date           30 Jul 2018
//  
//  First Author    Andrew Servania
//
// =============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;

namespace BulkInsertProofOfConcept
{
    /// <summary>
    /// Responsible for inserting large quantities of data into a database.
    /// </summary>
    public class BulkInserter
    {
 
        // All class constructors, initialize, terminate and dispose methods.
        #region Construct / Init / Terminate / Dispose

        /// <summary>
        /// Default constructor for class
        /// </summary>
        public BulkInserter(string connectionString)
        {
            _connectionString = connectionString;
        }

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
        /// Insert a large batch of entities into the database.
        /// </summary>
        /// <typeparam name="T">The type of entities to insert into the database.</typeparam>
        /// <param name="tableName">the name of the table to insert data to.</param>
        /// <param name="entitiesToInsert">The actual Entities to insert into the table.</param>
        /// <returns><b>true</b> if insertion was successful. <b>false</b> if not.</returns>
        public bool Insert<T>(string tableName, List<T> entitiesToInsert)
        {
            bool inserted = false;

            try
            {
                DataTable dataTable = EntityToDataTable.Convert(entitiesToInsert);
                
                using (var destinationConnection = new SqlConnection(_connectionString))
                {
                    using (var sqlBulkCopy = new SqlBulkCopy(destinationConnection))
                    {
                        destinationConnection.Open();

                        sqlBulkCopy.DestinationTableName = tableName;

                        sqlBulkCopy.WriteToServer(dataTable);

                        destinationConnection.Close();

                        inserted = true;
                    }
                }
            }
            catch (Exception e )
            {
                Console.WriteLine(e);
            }

            return inserted;
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

        /// <summary>
        /// The connection string to the database to insert items to.
        /// </summary>
        private string _connectionString;

        #endregion
    }
}
