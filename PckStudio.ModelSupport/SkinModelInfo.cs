using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PckStudio.Core.Skin;

namespace PckStudio.ModelSupport
{
    public sealed class SkinModelInfo
    {
        public SkinModel Model { get; }
        public SkinANIM Anim { get; }
        public SkinGameFlags SkinFlags { get; }
        public Image Texture { get; }

        public SkinModelInfo(Image texture, SkinANIM anim, SkinGameFlags skinFlags, SkinModel model)
        {
            Texture = texture;
            Anim = anim;
            SkinFlags = skinFlags;
            Model = model;
        }
    }
}
