// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base.Security;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Drawing;


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Intern
    {

        [DefaultProperty("MitarbeiterName"), ImageName("BO_Customer")]
        public class Mitarbeiter : XPObject, ISecurityUser, IAuthenticationStandardUser, IAuthenticationActiveDirectoryUser, ISecurityUserWithRoles, IOperationPermissionProvider,  DevExpress.Persistent.Base.General.IResource 
            //ITreeNode, ITreeNodeImageProvider,
        {



            public Mitarbeiter(Session session)
                : base(session)
            {
            }

            [VisibleInDetailView(false), VisibleInListView(false)]
            public Stopwatch Watch = new Stopwatch();

            private string fEmail;
            [VisibleInListView(false), VisibleInLookupListView(false)]
            public string Email
            {
                get
                {
                    return fEmail;
                }
                set
                {
                    fEmail = value;
                }
            }

            private bool fTageskalenderAboniert;
            [VisibleInListView(false), VisibleInLookupListView(false)]
            public bool TageskalenderAboniert
            {
                get
                {
                    return fTageskalenderAboniert;
                }
                set
                {
                    fTageskalenderAboniert = value;
                }
            }

            public override void AfterConstruction()
            {
                base.AfterConstruction();
                MitarbeiterUniqueId = Guid.NewGuid();

                var se = Session.GetObjectByKey<MainModel.StandardEinstellungen>(1);

                if (!(se == null))
                {
                    if (!(se.StandardBenutzerRolle == null))
                    {
                        var role = Session.GetObjectByKey<BusinessLogic.Intern.MitarbeiterRolle>(se.StandardBenutzerRolle.Oid);
                        MitarbeiterRollen.Add(role);
                    }
                    if (!(se.StandardDistribution == null))
                    {
                        var dist = Session.GetObjectByKey<BusinessLogic.Intern.Distribution>(se.StandardDistribution.Oid);
                        Distribution = dist;
                    }
                }

            }
            protected override void OnLoaded()
            {
                base.OnLoaded();

                if (!IsKunde.HasValue)
                {
                    Watch.Start();
                }
                else
                {
                    Watch = null;
                }

            }

            private bool fIsCalenderVisible;
            [VisibleInDetailView(false), VisibleInListView(false)]
            public bool IsCalenderVisible
            {
                get
                {
                    return fIsCalenderVisible;
                }
                set
                {
                    fIsCalenderVisible = value;
                }
            }

            private string fSelectedResourceName;
            [VisibleInDetailView(false), VisibleInListView(false)]
            public string SelectedResourceName
            {
                get
                {
                    return fSelectedResourceName;
                }
                set
                {
                    fSelectedResourceName = value;
                }
            }

            private bool fHasWorked;
            public bool HasWorked
            {
                get
                {
                    return fHasWorked;
                }
                set
                {
                    fHasWorked = value;
                    if (value == true)
                    {
                        System.Threading.Thread th = new System.Threading.Thread(() =>
                        {
                            for (int i = 1; i <= 5; i++)
                            {
                                System.Threading.Thread.Sleep(1000);
                            }
                            fHasWorked = false;
                        });
                        th.IsBackground = true;
                        th.Start();
                    }
                }
            }

            private System.Guid fMitarbeiterUniqueId;
            [Browsable(false), Indexed(Unique = false)]
            public System.Guid MitarbeiterUniqueId
            {
                get
                {
                    return fMitarbeiterUniqueId;
                }
                set
                {
                    fMitarbeiterUniqueId = value;
                }
            }


            #region ISecurityUser Members

            public void SetUserName(string pUserName)
            {
                _userName = pUserName;
            }

            private string _userName = string.Empty;
            [System.ComponentModel.DisplayName("Benutzername")]
            public string UserName
            {
                get
                {
                    return this.UserName_;
                }
            }

            string IAuthenticationStandardUser.UserName
            {
                get
                {
                    return this.UserName_;
                }
            }

            public string UserName_
            {
                get
                {
                    return _userName;
                }
            }

            private bool? fIsKunde;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public bool? IsKunde
            {
                get
                {
                    return fIsKunde;
                }
                set
                {
                    fIsKunde = value;
                }
            }

            [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save),
            RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "Ein Benutzer mit dem selben Benutzernamen ist bereits vorhanden.")]
            [System.ComponentModel.DisplayName("Benutzername")]
            string IAuthenticationActiveDirectoryUser.UserName
            {
                get
                {
                    return this._userName;
                }
                set
                {
                    this._userName = value;
                }
            }

            //public string UserName1
            //{
            //    get
            //    {
            //        return _userName;
            //    }
            //    set
            //    {
            //        SetPropertyValue("UserName", ref _userName, DateTime.Parse(value));
            //    }
            //}

            private bool _isActive = true;
            [System.ComponentModel.DisplayName("Aktiv")]
            bool ISecurityUser.IsActive
            {
                get
                {
                    return this.IsActive_;
                }
            }

            public bool IsActive_
            {
                get
                {
                    return _isActive;
                }
            }

            [System.ComponentModel.DisplayName("Aktiv")]
            public bool IsActive1
            {
                get
                {
                    return _isActive;
                }
                set
                {
                    SetPropertyValue("IsActive", ref _isActive, value);
                }
            }

            #endregion

            #region IAuthenticationStandardUser Members

            private bool _changePasswordOnFirstLogon;
            public bool ChangePasswordOnFirstLogon
            {
                get
                {
                    return _changePasswordOnFirstLogon;
                }
                set
                {
                    SetPropertyValue("ChangePasswordOnFirstLogon", ref _changePasswordOnFirstLogon, value);
                }
            }

            private string _storedPassword;
            [Browsable(false), Size(SizeAttribute.Unlimited), Persistent(), SecurityBrowsable()]
            protected string StoredPassword
            {
                get
                {
                    return _storedPassword;
                }
                set
                {
                    _storedPassword = value;
                }
            }

            public bool ComparePassword(string password)
            {
                return SecurityUserBase.ComparePassword(this._storedPassword, password);
            }

            public void SetPassword(string password)
            {
                this._storedPassword = System.Convert.ToString((new PasswordCryptographer()).GenerateSaltedPassword(password));
                OnChanged("StoredPassword");
            }

            #endregion

            #region ISecurityUserWithRoles Members

            IList<ISecurityRole> ISecurityUserWithRoles.Roles
            {
                get
                {
                    return this.ISecurityUserWithRoles_Roles;
                }
            }

            public IList<ISecurityRole> ISecurityUserWithRoles_Roles
            {
                get
                {
                    IList<ISecurityRole> result = new List<ISecurityRole>();
                    foreach (MitarbeiterRolle role in MitarbeiterRollen)
                    {
                        result.Add(role);
                    }
                    return result;
                }
            }

            [Association("Employees-EmployeeRoles"), RuleRequiredField("EmployeeRoleIsRequired", DefaultContexts.Save, TargetCriteria = "IsActive", CustomMessageTemplate = "Ein Aktiver Mitarbeiter muss mindestens eine Mitarbeiter Rolle aufweisen.")]
            public XPCollection<MitarbeiterRolle> MitarbeiterRollen
            {
                get
                {
                    return GetCollection<MitarbeiterRolle>("MitarbeiterRollen");
                }
            }

            #endregion

            #region IOperationPermissionProvider Members

            IEnumerable<IOperationPermission> IOperationPermissionProvider.GetPermissions()
            {
                return this.IOperationPermissionProvider_GetPermissions();
            }

            public IEnumerable<IOperationPermission> IOperationPermissionProvider_GetPermissions()
            {
                return new IOperationPermission[] { };
            }
            IEnumerable<IOperationPermissionProvider> IOperationPermissionProvider.GetChildren()
            {
                return this.IOperationPermissionProvider_GetChildren();
            }

            public IEnumerable<IOperationPermissionProvider> IOperationPermissionProvider_GetChildren()
            {
                return new EnumerableConverter<IOperationPermissionProvider, MitarbeiterRolle>(MitarbeiterRollen);
            }

            #endregion

            #region Audit Trail Log

            private XPCollection<AuditDataItemPersistent> m_userAuditTrail;
            public XPCollection<AuditDataItemPersistent> BenutzerLog
            {
                get
                {
                    if (m_userAuditTrail == null)
                    {
                        m_userAuditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                    }
                    return m_userAuditTrail;
                }
            }

            #endregion

            #region Collections

            [Association("Mitarbeiter-Adresse", typeof(BusinessLogic.Basis.Adresse))]
            public XPCollection<BusinessLogic.Basis.Adresse> Adressen
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Adresse>("Adressen");
                }
            }

            [Association("Mitarbeiter-Termine", typeof(BusinessLogic.Basis.Termin))]
            public XPCollection<BusinessLogic.Basis.Termin> Termine
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Termin>("Termine");
                }
            }

            [Association("Mitarbeiter-Anrufprotokoll")]
            public XPCollection<MainModel.Anrufprotokoll> Anrufprotokolle
            {
                get
                {
                    return GetCollection<MainModel.Anrufprotokoll>("Anrufprotokolle");
                }
            }

            [Association("Benutzer-Notizen")]
            public XPCollection<BusinessLogic.Basis.Notiz> Notizen
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Notiz>("Notizen");
                }
            }

            #endregion

            #region Custom

            private Formal.Anrede fAnrede;
            public Formal.Anrede Anrede
            {
                get
                {
                    return fAnrede;
                }
                set
                {
                    SetPropertyValue("Anrede", ref fAnrede, value);
                }
            }

            private string fVorname;
            public string Vorname
            {
                get
                {
                    return fVorname;
                }
                set
                {
                    SetPropertyValue("Vorname", ref fVorname, value);
                }
            }

            private string fNachname;
            public string Nachname
            {
                get
                {
                    return fNachname;
                }
                set
                {
                    SetPropertyValue("Nachname", ref fNachname, value);
                }
            }

            [PersistentAlias("[Vorname] + \' \' + [Nachname]")]
            [Appearance("CategoryColoredInDetailView", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "IsActive = 0", Context = "ListView", FontColor = "DarkGray", Enabled = false)]
            public string MitarbeiterName
            {
                get
                {
                    return System.Convert.ToString(EvaluateAlias("MitarbeiterName"));
                }
            }

            [PersistentAlias("[Vorname] + \' \' + [Nachname]")]
            [Browsable(false)]
            public string DisMitarbeiterName
            {
                get
                {
                    return System.Convert.ToString(EvaluateAlias("DisMitarbeiterName"));
                }
            }

            #endregion

            //#region TreeNode

            private Distribution fDistibution;
            [Association("Mitarbeiter-Distribution")]
            public Distribution Distribution
            {
                get
                {
                    return fDistibution;
                }
                set
                {
                    fDistibution = value;
                }
            }

            //[Browsable(false)]
            //public IBindingList Children
            //{
            //    get
            //    {
            //        return new BindingList<object>();
            //    }
            //}


            //private string fFakeName;
            //[NonPersistent, Browsable(false)]
            //public string FakeName
            //{
            //    get
            //    {
            //        return fFakeName;
            //    }
            //    set
            //    {
            //        fFakeName = value;
            //    }
            //}

            //public string Name
            //{
            //    get
            //    {

            //        string currentRole = "";
            //        if (string.IsNullOrEmpty(Caption))
            //        {
            //            Caption = MitarbeiterName;
            //        }
            //        if (MitarbeiterRollen.Count > 0)
            //        {
            //            currentRole = "(" + MitarbeiterRollen[0].Name + ")";
            //        }
            //        return Caption + " " + currentRole;

            //    }
            //}

            //public ITreeNode Parent
            //{
            //    get
            //    {
            //        return Distribution;
            //    }
            //}

            //public System.Drawing.Image GetImage(out string imageName)
            //{
            //    imageName = "BO_User";
            //    return ImageLoader.Instance.GetImageInfo(imageName).Image;
            //}


            //#endregion

            public string Caption
            {
                get
                {
                    return MitarbeiterName;
                }
                set
                {

                }
            }

            public dynamic Id
            {
                get
                {
                    return MitarbeiterUniqueId;
                }
            }

            public int OleColor
            {
                get
                {
                    return ColorTranslator.ToOle(Color.FromKnownColor(KnownColor.White));
                }
            }

            ~Mitarbeiter()
            {
                //base.Finalize();
            }

            private object fLastMaFilter;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastMaFilter
            {
                get
                {
                    return fLastMaFilter;
                }
                set
                {
                    fLastMaFilter = value;
                }
            }

            private object fLastPlzFilter;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastPlzFilter
            {
                get
                {
                    return fLastPlzFilter;
                }
                set
                {
                    fLastPlzFilter = value;
                }
            }

            private object fLastPhonerangeFilter;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastPhonerangeFilter
            {
                get
                {
                    return fLastPhonerangeFilter;
                }
                set
                {
                    fLastPhonerangeFilter = value;
                }
            }

            private object fLastPhonerangeFilterString;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastPhonerangeFilterString
            {
                get
                {
                    return fLastPhonerangeFilterString;
                }
                set
                {
                    fLastPhonerangeFilterString = value;
                }
            }

            private object fLastSelectedMa;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastSelectedMa
            {
                get
                {
                    return fLastSelectedMa;
                }
                set
                {
                    fLastSelectedMa = value;
                }
            }

            private object fLastStatusFilter;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastStatusFilter
            {
                get
                {
                    return fLastStatusFilter;
                }
                set
                {
                    fLastStatusFilter = value;
                }
            }

            private int fLastStatusId;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int LastStatusId
            {
                get
                {
                    return fLastStatusId;
                }
                set
                {
                    fLastStatusId = value;
                }
            }

            private object fLastProduktFilter;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastProduktFilter
            {
                get
                {
                    return fLastProduktFilter;
                }
                set
                {
                    fLastProduktFilter = value;
                }
            }

            private object fLastSelectedProdukt;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastSelectedProdukt
            {
                get
                {
                    return fLastSelectedProdukt;
                }
                set
                {
                    fLastSelectedProdukt = value;
                }
            }

            private object fLastFullTextSearch;
            [Browsable(false), NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public dynamic LastFullTextSearch
            {
                get
                {
                    return fLastFullTextSearch;
                }
                set
                {
                    fLastFullTextSearch = value;
                }
            }

        }

    }
}
