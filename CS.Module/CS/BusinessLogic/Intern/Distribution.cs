// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.ComponentModel;
using DevExpress.Persistent.Base.Security;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Intern
    {

        [ImageName("BO_Position")]
        public class Distribution : XPObject
            //, ITreeNode, ITreeNodeImageProvider
        {



            public Distribution(Session session)
                : base(session)
            {
            }
            public override void AfterConstruction()
            {
                base.AfterConstruction();
            }

            private string fName;
            public string Name1
            {
                get
                {
                    return fName;
                }
                set
                {
                    fName = value;
                }
            }

            private BusinessLogic.Basis.Land fLand;
            public BusinessLogic.Basis.Land Land
            {
                get
                {
                    return fLand;
                }
                set
                {
                    fLand = value;
                }
            }

            private string fTag;
            public string Tag
            {
                get
                {
                    return fTag;
                }
                set
                {
                    fTag = value;
                }
            }

            private Distribution fParentDistribution;
            [Browsable(false), Association("Distribution-Distribution")]
            public Distribution ParentDistribution
            {
                get
                {
                    return fParentDistribution;
                }
                set
                {
                    SetPropertyValue<Distribution>("ParentDistribution", ref fParentDistribution, value);
                }
            }
            [Association("Distribution-Distribution"), Aggregated()]
            public XPCollection<Distribution> NestedDistribution
            {
                get
                {
                    return GetCollection<Distribution>("NestedDistribution");
                }
            }

            [Association("Mitarbeiter-Distribution")]
            public XPCollection<Mitarbeiter> Mitarbeiter
            {
                get
                {
                    return GetCollection<Mitarbeiter>("Mitarbeiter");
                }
            }

            //public IBindingList Children
            //{
            //    get
            //    {
            //        //check this
            //        return NestedDistribution != null && NestedDistribution.Count > 0 ? NestedDistribution : Mitarbeiter;
            //    }
            //}

            //string ITreeNode.Name
            //{
            //    get
            //    {
            //        return this.TreeName;
            //    }
            //}

            //public string TreeName
            //{
            //    get
            //    {
            //        return Name1;
            //    }
            //}

            //public ITreeNode Parent
            //{
            //    get
            //    {
            //        return ParentDistribution;
            //    }
            //}

            //public System.Drawing.Image GetImage(out string imageName)
            //{
            //    if (NestedDistribution != null && NestedDistribution.Count > 0)
            //    {
            //        if (Parent == null)
            //        {
            //            imageName = "BO_Category";
            //        }
            //        else
            //        {
            //            if (Parent.Parent == null)
            //            {
            //                imageName = "BO_Customer";
            //            }
            //            else
            //            {
            //                imageName = "BO_Position";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        imageName = "BO_Position";
            //    }
            //    return ImageLoader.Instance.GetImageInfo(imageName).Image;
            //}

        }

    }
}
