#region Copyright
///////////////////////////////////////////////////////////////////////////////////
// The following FIT Protocol software provided may be used with FIT protocol
// devices only and remains the copyrighted property of Garmin International, Inc.
// The software is being provided on an "as-is" basis and as an accommodation,
// and therefore all warranties, representations, or guarantees of any kind
// (whether express, implied or statutory) including, without limitation,
// warranties of merchantability, non-infringement, or fitness for a particular
// purpose, are specifically disclaimed.
//
// Copyright 2022 Garmin International, Inc.
///////////////////////////////////////////////////////////////////////////////////
// ****WARNING****  This file is auto-generated!  Do NOT edit this file.
// Profile Version = 21.84Release
// Tag = production/akw/21.84.00-0-g894a113c
///////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.IO;

namespace Dynastream.Fit
{
    public class DeveloperField
        : FieldBase
    {
        #region Fields
        private readonly DeveloperFieldDefinition m_definition;
        #endregion

        #region Properties

        public bool IsDefined
        {
            get { return m_definition.IsDefined; }
        }

        public byte Num
        {
            get { return m_definition.FieldNum; }
        }

        public byte DeveloperDataIndex
        {
            get { return m_definition.DeveloperDataIndex; }
        }

        public uint AppVersion
        {
            get
            {
                if (m_definition.IsDefined)
                {
                    return m_definition.DeveloperIdMesg.GetApplicationVersion() ?? 0;
                }

                return 0;
            }
        }

        public byte[] AppId
        {
            get
            {
                if (m_definition.IsDefined)
                {
                    var msg = m_definition.DeveloperIdMesg;
                    byte[] appId = new byte[msg.GetNumApplicationId()];

                    for (int i = 0; i < appId.Length; i++)
                    {
                        appId[i] = msg.GetApplicationId(i) ?? 0xFF;
                    }

                    return appId;
                }

                return null;
            }
        }

        public override string Name
        {
            get
            {
                return m_definition.IsDefined ?
                    m_definition.DescriptionMesg.GetFieldNameAsString(0) : null;
            }
        }

        public override byte Type
        {
            get
            {
                if (m_definition.IsDefined)
                {
                    return m_definition.DescriptionMesg.GetFitBaseTypeId() ?? Fit.UInt8;
                }

                return Fit.UInt8;
            }
        }

        public override double Scale
        {
            get
            {
                if (m_definition.IsDefined)
                {
                    return m_definition.DescriptionMesg.GetScale() ?? 1.0;
                }

                return 1.0;
            }
        }

        public override double Offset
        {
            get
            {
                if (m_definition.IsDefined)
                {
                    return m_definition.DescriptionMesg.GetOffset() ?? 0.0;
                }

                return 0.0;
            }
        }

        public override string Units
        {
            get
            {
                return m_definition.IsDefined ?
                    m_definition.DescriptionMesg.GetUnitsAsString(0) : null;
            }
        }

        /// <summary>
        /// Retrieve the Native Field Number that this Developer Field Overrides
        /// </summary>
        /// <returns>
        /// Native Field Number that is overridden if applicable,
        /// <see cref="Fit.FieldNumInvalid"/> otherwise
        /// </returns>
        public byte NativeOverride
        {
            get
            {
                if (m_definition.IsDefined)
                {
                    return m_definition.DescriptionMesg.GetNativeFieldNum() ?? Fit.FieldNumInvalid;
                }

                return Fit.FieldNumInvalid;
            }
        }

        #endregion

        #region Constructors
        public DeveloperField(DeveloperField other)
            : base(other)
        {
            m_definition = other.m_definition;
        }

        internal DeveloperField(DeveloperFieldDefinition definition)
        {
            m_definition = definition;
        }

        public DeveloperField(FieldDescriptionMesg description, DeveloperDataIdMesg developerDataIdMesg)
        {
            m_definition = new DeveloperFieldDefinition(description, developerDataIdMesg, 0);
        }

        #endregion

        #region Methods
        internal override Subfield GetSubfield(string subfieldName)
        {
            // Developer Fields do not currently support Sub Fields
            return null;
        }

        internal override Subfield GetSubfield(int subfieldIndex)
        {
            // Developer Fields do not currently support Sub Fields
            return null;
        }

        #endregion
    }
} // namespace
