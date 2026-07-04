using System;
using System.Collections.Generic;
using PckStudio.Core.Skin;

namespace PckStudio.ModelSupport.Internal.Format
{
    /*
     * VERSION 1
        Magic - 3 bytes("psm")
        Version - 1 byte [u8]
        Anim - 4 bytes[int32]
        NumberOfParts - 4 bytes[int32]
        {
            part parent - 1 byte (HEAD=0, BODY=1, LEG0=2, LEG1=3, ARM0=4, ARM1=5)
            Position-X - 4 bytes (float32)
            Position-Y - 4 bytes (float32)
            Position-Z - 4 bytes (float32)
            Size-X - 4 bytes (float32)
            Size-Y - 4 bytes (float32)
            Size-Z - 4 bytes (float32)
            MirrorAndUvX - 1 bit flag 7 bits uv.x value(0-64) (s8)
            HideWithArmorAndUvY - 1 bit flag 7 bits uv.y value(0-64) (s8)
            Inflation - 4 bytes (float32)
        }
        NumberOfOffsets - 4 bytes[int32]
        {
            offset part - 1 byte 
            vertical offset - 4 bytes[float]
        }

     * VERSION 2
        Magic - 3 bytes("psm")
        Version - 1 byte [u8]
        Anim - 4 bytes [int32]
        Game Flags - 1 byte [u8]
        NumberOfParts - 4 bytes[int32]
        {
            ArmorMaskAndParParent - 3 bits Armor Mask 5 bits (Box Parent Type)
            Position-X - 4 bytes (float32)
            Position-Y - 4 bytes (float32)
            Position-Z - 4 bytes (float32)
            Size-X - 4 bytes (float32)
            Size-Y - 4 bytes (float32)
            Size-Z - 4 bytes (float32)
            MirrorAndUvX - 1 bit flag 7 bits uv.x value(0-64) (s8)
            ArmorMaskingAndUvY - 1 bit Helmet Mask 7 bits uv.y value(0-64) (s8)
            Inflation - 4 bytes (float32)
        }
        NumberOfOffsets - 4 bytes[int32]
        {
            offset part - 1 byte 
            vertical offset - 4 bytes[float]
        }
    */
    public sealed class PSMFile
    {
		internal static readonly string HEADER_MAGIC = "psm";
		internal const byte CurrentVersion = 2;

        public readonly byte Version;

        internal PSMFile(byte version)
        {
            Version = version;
        }

        internal PSMFile(byte version, SkinANIM skinANIM, SkinGameFlags skinFlags)
            : this(version)
        {
            SkinANIM = skinANIM;
            SkinFlags = skinFlags;
        }

        public SkinANIM SkinANIM { get; private set; }
        public SkinGameFlags SkinFlags { get; private set; }

        public readonly List<SkinBOX> Parts = new List<SkinBOX>();
		public readonly List<SkinPartOffset> Offsets = new List<SkinPartOffset>();
	}

	public enum PSMOffsetType : byte
    {
		HEAD = 0,
        BODY = 1,
        ARM0 = 2,
        ARM1 = 3,
        LEG0 = 4,
        LEG1 = 5,

        TOOL0 = 6,
        TOOL1 = 7,

        HELMET = 8,
        SHOULDER0 = 9,
        SHOULDER1 = 10,
        CHEST = 11,
        WAIST = 12,
        PANTS0 = 13,
        PANTS1 = 14,
        BOOT0 = 15,
        BOOT1 = 16,
    }

	public enum PSMParentType : byte
	{
		HEAD = 0,
		BODY = 1,
		ARM0 = 2,
		ARM1 = 3,
		LEG0 = 4,
		LEG1 = 5,
		HEADWEAR = 6,
		JACKET = 7,
		SLEEVE0 = 8,
		SLEEVE1 = 9,
		PANTS0 = 10,
		PANTS1 = 11,
		WAIST = 12,
		LEGGING0 = 13,
		LEGGING1 = 14,
		SOCK0 = 15,
		SOCK1 = 16,
		BOOT0 = 17,
		BOOT1 = 18,
		ARMAMOR0 = 19,
		ARMAMOR1 = 20,
		BODYARMOR = 21,
		BELT = 22,
	}
}
