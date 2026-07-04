using System.IO;
using System.Text;
using PckStudio.Core.FileFormats;
using OMI.Workers;
using OMI;
using System;
using OpenTK;
using PckStudio.Core.Skin;
using System.Windows.Forms;

namespace PckStudio.ModelSupport.Internal.Format
{
    internal class PSMFileWriter : IDataFormatWriter
    {
        PSMFile _PSM;

        public PSMFileWriter(PSMFile csmb)
        {
            _PSM = csmb;
        }

        public void WriteToFile(string filename)
        {
            using(var fs = File.OpenWrite(filename))
            {
                WriteToStream(fs);
            }
        }

        public void WriteToStream(Stream stream)
        {
            using (var writer = new EndiannessAwareBinaryWriter(stream, Encoding.ASCII, leaveOpen: true, ByteOrder.LittleEndian))
            {
                writer.WriteString(PSMFile.HEADER_MAGIC);
                writer.Write(_PSM.Version);
                writer.Write(_PSM.SkinANIM.ToValue());
                writer.Write((byte)_PSM.SkinFlags.ToValue());
                writer.Write(_PSM.Parts.Count);
                foreach (SkinBOX part in _PSM.Parts)
                {
                    WritePart(writer, part);
                }
                writer.Write(_PSM.Offsets.Count);
                foreach (SkinPartOffset offset in _PSM.Offsets)
                {
                    writer.Write((byte)GetOffsetPart(offset.Type));
                    writer.Write(offset.Value);
                }
            }
        }

        private void WritePart(EndiannessAwareBinaryWriter writer, SkinBOX part)
        {
            byte armorMask = (byte)((part.ArmorMaskFlags.ToValue() >> 1) & 0x07);
            byte parentType = (byte)((int)GetParentPart(part.Type) & 0x1F);

            byte armorMaskAndParentType = (byte)((armorMask << 5) | parentType);
            writer.Write(armorMaskAndParentType);
            writer.Write(part.Pos.X);
            writer.Write(part.Pos.Y);
            writer.Write(part.Pos.Z);
            writer.Write(part.Size.X);
            writer.Write(part.Size.Y);
            writer.Write(part.Size.Z);

            byte uvX = (byte)MathHelper.Clamp((int)part.UV.X, 0, 64);
            byte uvY = (byte)MathHelper.Clamp((int)part.UV.Y, 0, 64);
            byte mirrorAndUvX = (byte)(Convert.ToByte(part.Mirror) << 7 | uvX);
            byte helmetMaskAndUvY = (byte)(Convert.ToByte(part.ArmorMaskFlags.ToValue()) << 7 | uvY);
            writer.Write(mirrorAndUvX);
            writer.Write(helmetMaskAndUvY);
            writer.Write(part.Scale);
        }

        private static PSMParentType GetParentPart(string type)
        {
            switch (type)
            {
                case "HEAD":
                    return PSMParentType.HEAD;
                case "BODY":
                    return PSMParentType.BODY;
                case "ARM0":
                    return PSMParentType.ARM0;
                case "ARM1":
                    return PSMParentType.ARM1;
                case "LEG0":
                    return PSMParentType.LEG0;
                case "LEG1":
                    return PSMParentType.LEG1;
                case "HEADWEAR":
                    return PSMParentType.HEADWEAR;
                case "JACKET":
                    return PSMParentType.JACKET;
                case "SLEEVE0":
                    return PSMParentType.SLEEVE0;
                case "SLEEVE1":
                    return PSMParentType.SLEEVE1;
                case "PANTS0":
                    return PSMParentType.PANTS0;
                case "PANTS1":
                    return PSMParentType.PANTS1;
                case "WAIST":
                    return PSMParentType.WAIST;
                case "LEGGING0":
                    return PSMParentType.LEGGING0;
                case "LEGGING1":
                    return PSMParentType.LEGGING1;
                case "SOCK0":
                    return PSMParentType.SOCK0;
                case "SOCK1":
                    return PSMParentType.SOCK1;
                case "BOOT0":
                    return PSMParentType.BOOT0;
                case "BOOT1":
                    return PSMParentType.BOOT1;
                case "ARMARMOR0":
                    return PSMParentType.ARMAMOR0;
                case "ARMARMOR1":
                    return PSMParentType.ARMAMOR1;
                case "BODYARMOR":
                    return PSMParentType.BODYARMOR;
                case "BELT":
                    return PSMParentType.BELT;
                default:
                    throw new InvalidDataException(type);
            }
        }

        private static PSMOffsetType GetOffsetPart(string type)
        {
            switch (type)
            {
                case "HEAD":
                    return PSMOffsetType.HEAD;
                case "BODY":
                    return PSMOffsetType.BODY;
                case "ARM0":
                    return PSMOffsetType.ARM0;
                case "ARM1":
                    return PSMOffsetType.ARM1;
                case "LEG0":
                    return PSMOffsetType.LEG0;
                case "LEG1":
                    return PSMOffsetType.LEG1;
                case "TOOL0":
                    return PSMOffsetType.TOOL0;
                case "TOOL1":
                    return PSMOffsetType.TOOL1;
                case "HELMET":
                    return PSMOffsetType.HELMET;
                case "SHOULDER0":
                    return PSMOffsetType.SHOULDER0;
                case "SHOULDER1":
                    return PSMOffsetType.SHOULDER1;
                case "CHEST":
                    return PSMOffsetType.CHEST;
                case "WAIST":
                    return PSMOffsetType.WAIST;
                case "PANTS0":
                    return PSMOffsetType.PANTS0;
                case "PANTS1":
                    return PSMOffsetType.PANTS1;
                case "BOOT0":
                    return PSMOffsetType.BOOT0;
                case "BOOT1":
                    return PSMOffsetType.BOOT1;
                default:
                    throw new InvalidDataException(type);
            }
        }
    }
}
