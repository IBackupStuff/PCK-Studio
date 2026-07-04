using System.Diagnostics;
using System.IO;
using System.Text;
using OMI;
using OMI.Workers;
using PckStudio.Core.FileFormats;
using PckStudio.Core;
using PckStudio.Core.Skin;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PckStudio.ModelSupport.Internal.Format
{
    internal class PSMFileReader : IDataFormatReader<PSMFile>, IDataFormatReader
    {
        public PSMFile FromFile(string filename)
        {
            if (File.Exists(filename))
            {
                using (var fs = File.OpenRead(filename))
                {
                    return FromStream(fs);
                }
            }
            throw new FileNotFoundException(filename);
        }

        public PSMFile FromStream(Stream stream)
        {
            using var reader = new EndiannessAwareBinaryReader(stream, Encoding.ASCII, leaveOpen: true, ByteOrder.LittleEndian);
            
            var magic = reader.ReadString(3);
            if (magic != PSMFile.HEADER_MAGIC)
            {
                Trace.TraceError("PSMFileReader.FromStream - Failed to load csmb.\n\tReason: Header magic mismatch.");
                return new PSMFile(byte.MaxValue);
            }
            
            byte version = reader.ReadByte();
            if (version < 1 || version > PSMFile.CurrentVersion)
            {
                Trace.TraceError("PSMFileReader.FromStream - Failed to load csmb.\n\tReason: Unsupported version.");
                return new PSMFile(byte.MaxValue);
            }

            var skinANIM = SkinANIM.FromValue(reader.ReadInt32());
            var skinFlags = SkinGameFlags.Empty;
            
            if(version > 1)
                skinFlags = SkinGameFlags.FromValue(reader.ReadByte());

            PSMFile psmFile = new PSMFile(version, skinANIM, skinFlags);
            int numOfParts = reader.ReadInt32();
            for (int i = 0; i < numOfParts; i++)
            {
                SkinBOX part = ReadPart(reader, version);
                psmFile.Parts.Add(part);
            }
            int numOfOffsets = reader.ReadInt32();
            for (int i = 0; i < numOfOffsets; i++)
            {
                SkinPartOffset offset = ReadOffset(reader);
                psmFile.Offsets.Add(offset);
            }
            
            return psmFile;
        }

        private SkinBOX ReadPart(EndiannessAwareBinaryReader reader, int version)
        {
            int armorMask = 0;
            string type = "";
            if(version == 1)
                type = GetParentType((PSMParentType)reader.ReadByte());
            else
            {
                byte armorMaskAndParentType = reader.ReadByte();

                type = GetParentType((PSMParentType)(armorMaskAndParentType & 0x1F)); // get first 5 bits
                armorMask = (armorMaskAndParentType & 0xE0) >> 5; // get last 3 bits
            }

            float posX = reader.ReadSingle();
            float posY = reader.ReadSingle();
            float posZ = reader.ReadSingle();
            float sizeX = reader.ReadSingle();
            float sizeY = reader.ReadSingle();
            float sizeZ = reader.ReadSingle();
            byte mirrorAndUvX = reader.ReadByte();
            byte hideWithArmorAndUvY = reader.ReadByte();
            int uvX = mirrorAndUvX & 0x7f;
            int uvY = hideWithArmorAndUvY & 0x7f;
            bool mirror = (mirrorAndUvX & 0x80) != 0;
            armorMask = (armorMask << 1) | ((hideWithArmorAndUvY >> 7) & 1);
            float scale = reader.ReadSingle();
            return new SkinBOX(type, new System.Numerics.Vector3(posX, posY, posZ), new System.Numerics.Vector3(sizeX, sizeY, sizeZ), new System.Numerics.Vector2(uvX, uvY), armorMask, mirror, scale);
        }

        private SkinPartOffset ReadOffset(EndiannessAwareBinaryReader reader)
        {
            PSMOffsetType type = (PSMOffsetType)reader.ReadByte();
            float value = reader.ReadSingle();
            return new SkinPartOffset(GetOffsetType(type), value);
        }

        private static string GetParentType(PSMParentType type)
        {
            switch (type)
            {
                case PSMParentType.HEAD:
                    return "HEAD";
                case PSMParentType.BODY:
                    return "BODY";
                case PSMParentType.ARM0:
                    return "ARM0";
                case PSMParentType.ARM1:
                    return "ARM1";
                case PSMParentType.LEG0:
                    return "LEG0";
                case PSMParentType.LEG1:
                    return "LEG1";
                case PSMParentType.HEADWEAR:
                    return "HEADWEAR";
                case PSMParentType.JACKET:
                    return "JACKET";
                case PSMParentType.SLEEVE0:
                    return "SLEEVE0";
                case PSMParentType.SLEEVE1:
                    return "SLEEVE1";
                case PSMParentType.PANTS0:
                    return "PANTS0";
                case PSMParentType.PANTS1:
                    return "PANTS1";
                case PSMParentType.WAIST:
                    return "WAIST";
                case PSMParentType.LEGGING0:
                    return "LEGGING0";
                case PSMParentType.LEGGING1:
                    return "LEGGING1";
                case PSMParentType.SOCK0:
                    return "SOCK0";
                case PSMParentType.SOCK1:
                    return "SOCK1";
                case PSMParentType.BOOT0:
                    return "BOOT0";
                case PSMParentType.BOOT1:
                    return "BOOT1";
                case PSMParentType.ARMAMOR0:
                    return "ARMARMOR0";
                case PSMParentType.ARMAMOR1:
                    return "ARMARMOR1";
                case PSMParentType.BODYARMOR:
                    return "BODYARMOR";
                case PSMParentType.BELT:
                    return "BELT";
                default:
                    throw new InvalidDataException(type.ToString());
            }
        }

        private static string GetOffsetType(PSMOffsetType type)
        {
            switch (type)
            {
                case PSMOffsetType.HEAD:
                    return "HEAD";
                case PSMOffsetType.BODY:
                    return "BODY";
                case PSMOffsetType.ARM0:
                    return "ARM0";
                case PSMOffsetType.ARM1:
                    return "ARM1";
                case PSMOffsetType.LEG0:
                    return "LEG0";
                case PSMOffsetType.LEG1:
                    return "LEG1";
                case PSMOffsetType.TOOL0:
                    return "TOOL0";
                case PSMOffsetType.TOOL1:
                    return "TOOL1";
                case PSMOffsetType.HELMET:
                    return "HELMET";
                case PSMOffsetType.SHOULDER0:
                    return "SHOULDER0";
                case PSMOffsetType.SHOULDER1:
                    return "SHOULDER1";
                case PSMOffsetType.CHEST:
                    return "CHEST";
                case PSMOffsetType.WAIST:
                    return "WAIST";
                case PSMOffsetType.PANTS0:
                    return "PANTS0";
                case PSMOffsetType.PANTS1:
                    return "PANTS1";
                case PSMOffsetType.BOOT0:
                    return "BOOT0";
                case PSMOffsetType.BOOT1:
                    return "BOOT1";
                default:
                    throw new InvalidDataException(type.ToString());
            }
        }

        object IDataFormatReader.FromStream(Stream stream) => FromStream(stream);

        object IDataFormatReader.FromFile(string filename) => FromFile(filename);
    }
}
