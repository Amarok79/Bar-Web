// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Diagnostics;
using System.Globalization;


namespace Bar.Web.Services
{
    /// <summary>
    ///     This value type represents the Id of a Bar.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public readonly struct BarId : IEquatable<BarId>
    {
        // data
        private readonly Guid mGuid;


        #region ++ Public Interface ++

        /// <summary>
        ///     Gets the Guid that is being wrapped.
        /// </summary>
        public Guid Guid => mGuid;


        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// 
        /// <param name="guid">
        ///     The Guid that should be wrapped.
        /// </param>
        public BarId(Guid guid)
        {
            mGuid = guid;
        }


        /// <summary>
        ///     Returns a string that represents the current instance. This method returns a string in upper
        ///     case to make returned strings equatable.
        /// </summary>
        public override String ToString()
        {
            return mGuid.ToString("B", CultureInfo.InvariantCulture).ToUpperInvariant();
        }

        #endregion

        #region ++ Public Interface (Equality) ++

        /// <summary>
        ///     Returns the hash code for the current instance.
        /// </summary>
        public override Int32 GetHashCode()
        {
            return mGuid.GetHashCode();
        }


        /// <summary>
        ///     Determines whether the specified instance is equal to the current instance.
        /// </summary>
        /// 
        /// <param name="obj">
        ///     The instance to compare with the current instance.
        /// </param>
        /// 
        /// <returns>
        ///     True, if the specified instance is equal to the current instance; otherwise, False.
        /// </returns>
        public override Boolean Equals(Object obj)
        {
            return obj is BarId id && Equals(id);
        }

        /// <summary>
        ///     Determines whether the specified instance is equal to the current instance.
        /// </summary>
        /// 
        /// <param name="other">
        ///     The instance to compare with the current instance.
        /// </param>
        /// 
        /// <returns>
        ///     True, if the specified instance is equal to the current instance; otherwise, False.
        /// </returns>
        public Boolean Equals(BarId other)
        {
            // determine equality from fields
            return mGuid.Equals(other.mGuid);
        }


        /// <summary>
        ///     Determines whether the specified instances are equal.
        /// </summary>
        /// 
        /// <param name="a">
        ///     The first instance to compare.
        /// </param>
        /// <param name="b">
        ///     The second instance to compare.
        /// </param>
        /// 
        /// <returns>
        ///     True, if the specified instances are equal; otherwise, False.
        /// </returns>
        public static Boolean operator ==(BarId a, BarId b)
        {
            return a.Equals(b);
        }

        /// <summary>
        ///     Determines whether the specified instances are unequal.
        /// </summary>
        /// 
        /// <param name="a">
        ///     The first instance to compare.
        /// </param>
        /// <param name="b">
        ///     The second instance to compare.
        /// </param>
        /// 
        /// <returns>
        ///     True, if the specified instances are unequal; otherwise, False.
        /// </returns>
        public static Boolean operator !=(BarId a, BarId b)
        {
            return !a.Equals(b);
        }

        #endregion

        #region ~~ Internal Interface ~~

        /// <summary>
        ///     This member serves the infrastructure and is not intended to be used directly.
        /// </summary>
        internal String DebuggerDisplay => ToString();

        #endregion
    }
}
