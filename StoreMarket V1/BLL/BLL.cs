﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEE;
using DAL;

namespace BLL
{
    public class BLLCode
    {
        DBCLASS DB = new DBCLASS();
        DALCODE dlc = new DALCODE();

        #region OWNER
        public int PublicKey(String Key)
        {   //  کلید کلی برای باز کردن فرم
            return (dlc.PublicKey(Key));
        }
        public bool CreateNewOwner(OWNER owner)
        {   // برای ساخت مالک در اولین اجرا برنامه میباشد وبعد از آن کاربردی ندارد
            if (!dlc.SelectOwnerStatus(owner))
            {
                dlc.CreateOwner(owner);
                return true;
            }
            return false;
        }
        public int CheckAccessOwner(OWNER owner, String AdminName)
        {   //  کنترل دسترسی میباشد اگر کلید وارد شود اجازه ورود بدهد
            //  اگر وضعیت کامل فعال بود ثبت نام و ورود انجام شود
            return (dlc.SelectOwnerStatusAccess(owner, AdminName));
        }
        public OWNER SelectOwner(String Name)
        {
            return (dlc.SelectOwner(Name));
        }
        public void ChangeOwnerStatus(OWNER owner)
        {   // وضعیت مالک تغییر میدهد و غیر فعال میکند
            dlc.ChangeStatusOwner(owner);
        }
        public bool OwnerKey(String Key)
        {
            return (dlc.OwmerAccessKey(Key));
        }
        #endregion
        // Login Load Code
        #region LogForm
        public void ALoginfor(ALogInformation log)
        {
            dlc.ALoginfor(log);
        }
        public void BLoginfor(BLogInformation log)
        {
            dlc.BLoginfor(log);
        }
        public List<ALogInformation> aLogInformation()
        {
            return (from i in DB.aLogInformation select i).ToList();
        }
        public List<BLogInformation> bLogInformation()
        {
            return (from i in DB.bLogInformation select i).ToList();
        }
        public int LoginCodeAdmin(String Access, String UserName, String Password)
        {
            return (dlc.LoginCodeAdmin(Access, UserName, Password));
        }
        #endregion
        // Admin Log Form
        #region LogSearch
        public List<ALogInformation> LogSearchEnterA(String Word)
        {
            return (from i in DB.aLogInformation where Word.Contains(i.Enter) select i).ToList();
        }
        public List<BLogInformation> LogSearchEnterB(String Word)
        {
            return (from i in DB.bLogInformation where Word.Contains(i.Enter) select i).ToList();
        }
        #endregion
        // Control Account
        #region Control

        public int AdminKey(String Key, String ADMINNAME)
        {
            return (dlc.AdminKey(Key, ADMINNAME));
        }

        public List<AAdmin> ReadAdminA()
        {
            return (dlc.readadminA().ToList());
        }
        public List<BAdmin> ReadAdminB()
        {
            return (dlc.readadminB().ToList());
        }

        public String FullNameA(int id)
        {
            foreach (var item in DB.aAdmins)
            {
                if (item.id == id)
                {
                    return (item.Name + " " + item.Family);
                }
            }
            return "";
        }
        public String FullNameB(int id)
        {
            foreach (var item in DB.bAdmins)
            {
                if (item.id == id)
                {
                    return (item.Name + " " + item.Family);
                }
            }
            return "";
        }

        public void ChangeStatusAdminA(int ID)
        {
            dlc.ChangeStatusAdminA(ID);
        }
        public void ChangeStatusAdminB(int ID)
        {
            dlc.ChangeStatusAdminB(ID);
        }

        public List<AAdmin> ShowSearchResultA(String AdminNumber, String Word)
        {
            return (dlc.ShowSearchResultA(AdminNumber, Word)).ToList();
        }
        public List<BAdmin> ShowSearchResultB(String AdminNumber, String Word)
        {
            return (dlc.ShowSearchResultB(AdminNumber, Word)).ToList();
        }

        public void DeleteAdminA(int ID)
        {
            dlc.DeleteAdminA(ID);
        }
        public void DeleteAdminB(int ID)
        {
            dlc.DeleteAdminB(ID);
        }

        public List<AAdmin> ShowAllAdminDataA()
        {
            return (dlc.ShowAllAdminDataA()).ToList();
        }
        public List<BAdmin> ShowAllAdminDataB()
        {
            return (dlc.ShowAllAdminDataB()).ToList();
        }

        public List<AAdmin> ShowActiveDataA()
        {
            return (from i in DB.aAdmins where !i.DeleteStatus && i.IsActive select i).ToList();
        }
        public List<BAdmin> ShowActiveDataB()
        {
            return (from i in DB.bAdmins where !i.DeleteStatus && i.IsActive select i).ToList();
        }

        public bool SelectAdminA(AAdmin admin)
        {
            return (dlc.SelectAdminA(admin));
        }
        public bool SelectAdminB(BAdmin admin)
        {
            return (dlc.SelectAdminB(admin));
        }

        public bool RegisterAdminA(AAdmin admin)
        {
            foreach (var item in DB.aAdmins)
            {
                if (item.Name == admin.Name && item.Family == admin.Family)
                {
                    return false;
                }
            }
            dlc.RegisterAdminA(admin);
            return true;
        }
        public bool RegisterAdminB(BAdmin admin)
        {
            foreach (var item in DB.bAdmins)
            {
                if (item.Name == admin.Name && item.Family == admin.Family)
                {
                    return false;
                }
            }
            dlc.RegisterAdminB(admin);
            return true;
        }

        public AAdmin EditAdminA(int ID)
        {
            return (dlc.SelectAdminAccountA(ID));
        }
        public BAdmin EditAdminB(int ID)
        {
            return (dlc.SelectAdminAccountB(ID));
        }

        #endregion
        // Company Form
        #region Company
        public bool CreatCompanyA(ACompany company)
        {
            if (dlc.SelectionCompanyA(company))
            {
                dlc.CreateCompanyA(company);
                return true;
            }
            return false;
        }
        public bool CreatCompanyB(BCompany company)
        {
            if (dlc.SelectionCompanyB(company))
            {
                dlc.CreateCompanyB(company);
                return true;
            }
            return false;
        }
        //  نمایش همه شرکت ها
        public List<ACompany> ShowAllDataCompanyA()
        {
            return (dlc.ShowAllDataCompanyA()).ToList();
        }
        public List<BCompany> ShowAllDataCompanyB()
        {
            return (dlc.ShowAllDataCompanyB()).ToList();
        }
        // نمایش شرکت های  فعال
        public List<ACompany> ShowAllActiveDataCompanyA()
        {
            return (dlc.ShowAllActiveDataCompanyA()).ToList();
        }
        public List<BCompany> ShowAllActiveDataCompanyB()
        {
            return (dlc.ShowAllActiveDataCompanyB()).ToList();
        }
        //  نمایش شرکت های غیر فعال
        public List<ACompany> ShowAllDisActiveDataCompanyA()
        {
            return (dlc.ShowAllDisActiveDataCompanyA()).ToList();
        }
        public List<BCompany> ShowAllDisActiveDataCompanyB()
        {
            return (dlc.ShowAllDisActiveDataCompanyB()).ToList();
        }

        public ACompany SelectCompanyA(int ID)
        {
            return (dlc.SelectionCompanyA(ID));
        }
        public BCompany SelectCompanyB(int ID)
        {
            return (dlc.SelectionCompanyB(ID));
        }

        public bool SaveEditCompanyA(ACompany company)
        {
            if (!dlc.SelectionCompanyA(company))
            {
                dlc.SaveEditCompanyA(company);
                return true;
            }
            return false;
        }
        public bool SaveEditCompanyB(BCompany company)
        {
            if (!dlc.SelectionCompanyB(company))
            {
                dlc.SaveEditCompanyB(company);
                return true;
            }
            return false;
        }

        public void DeleteCompany(String Admin, int ID)
        {
            dlc.DeleteCompany(Admin, ID);
        }

        public void ChangeStatusCompany(String Admin, int ID)
        {
            dlc.ChangeStatusCompany(Admin, ID);
        }
        #endregion
        //  Product Control Form
        #region Product
        public List<AProduct> ShowAllProductA()
        {
            return (from i in DB.aProducts where !i.DeleteStatus select i).ToList();
        }
        public List<BProduct> ShowAllProductB()
        {
            return (from i in DB.bProducts where !i.DeleteStatus select i).ToList();
        }

        public List<ATypeProduct> ATypes()
        {
            return (from i in DB.atypeProducts select i).ToList();
        }
        public List<BTypeProduct> BTypes()
        {
            return (from i in DB.btypeProducts select i).ToList();
        }


        public List<AAgent> AgentA()
        {
            return (from i in DB.aAgents select i).ToList();
        }
        public List<BAgent> AgentB()
        {
            return (from i in DB.bAgents select i).ToList();
        }


        public List<AProduct> ProductA(int ID)
        {
            return (from i in DB.aProducts where i.id == ID select i).ToList();
        }
        public List<BProduct> ProductB(int ID)
        {
            return (from i in DB.bProducts where i.id == ID select i).ToList();
        }

        public bool CreateProductA(AProduct product)
        {
            foreach (var item in DB.aProducts)
            {
                if (item.Name == product.Name && item.Type == product.Type)
                {
                    return true;
                }
            }
            dlc.CreateProductA(product);
            return false;
        }
        public bool CreateProductB(BProduct product)
        {
            foreach (var item in DB.bProducts)
            {
                if (item.Name == product.Name && item.Type == product.Type)
                {
                    return true;
                }
            }
            dlc.CreateProductB(product);
            return false;
        }

        public bool ExistProductA(int ID, AProduct product)
        {
            foreach (var item in DB.aProducts)
            {
                if (item.id != ID && item.Name == product.Name && item.Type == product.Type)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExistProductB(int ID, BProduct product)
        {
            foreach (var item in DB.bProducts)
            {
                if (item.id != ID && item.Name == product.Name && item.Type == product.Type)
                {
                    return true;
                }
            }
            return false;
        }

        public AProduct ProductEditA(int ID)
        {
            AProduct product = DB.aProducts.Where(c => c.id == ID).First();
            if (!ExistProductA(ID, product))
            {
                dlc.EditProductA(product);
            }
            return product;
        }
        public BProduct ProductEditB(int ID)
        {
            BProduct product = DB.bProducts.Where(c => c.id == ID).First();
            if (!ExistProductB(ID, product))
            {
                dlc.EditProductB(product);
            }
            return product;
        }

        public void DeleteProductA(int ID)
        {
            AProduct product = DB.aProducts.Where(c => c.id == ID).First();
            dlc.DeleteProductA(product);
        }
        public void DeleteProductB(int ID)
        {
            BProduct product = DB.bProducts.Where(c => c.id == ID).First();
            dlc.DeleteProductB(product);
        }

        public void SAVEDB()
        {
            dlc.SAVEDB();
        }
        #endregion
        //  Admin Control Register Form
        #region AdminControl
        public bool ExistAdminA(AAdmin admin)
        {
            foreach (var item in DB.aAdmins)
            {
                if (item.Name == admin.Name && item.Family == admin.Family && item.OwnerName == admin.OwnerName)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExistAdminB(BAdmin admin)
        {
            foreach (var item in DB.bAdmins)
            {
                if (item.Name == admin.Name && item.Family == admin.Family && item.OwnerName == admin.OwnerName)
                {
                    return true;
                }
            }
            return false;
        }
        public String ResetAdminPassword(AAdmin adminA, BAdmin adminB)
        {
            return (dlc.GetPassA(adminA, adminB));
        }
        // AdminAccount Bank Form
        public List<AAdminBankAccount> ReadAdminbankA()
        {
            return (dlc.ReadBankAccountA().ToList());
        }
        public List<BAdminBankAccount> ReadAdminbankB()
        {
            return (dlc.ReadBankAccountB().ToList());
        }

        public bool CreateAdminBankA(AAdminBankAccount adminbank)
        {
            foreach (var item in DB.aAdminBankAccounts)
            {
                if (item.NameBank == adminbank.NameBank && item.AccountNumber == adminbank.AccountNumber)
                {
                    return false;
                }
            }
            dlc.CreateAdminBankAccountA(adminbank);
            return true;
        }
        public bool CreateAdminBankB(BAdminBankAccount adminbank)
        {
            foreach (var item in DB.bAdminBankAccounts)
            {
                if (item.NameBank == adminbank.NameBank && item.AccountNumber == adminbank.AccountNumber)
                {
                    return true;
                }
            }
            dlc.CreateAdminBankAccountB(adminbank);
            return false;
        }

        public AAdminBankAccount adminbankacountA(int ID)
        {
            return (dlc.SelectAdminBankAccountA(ID));
        }
        public BAdminBankAccount adminbankacountB(int ID)
        {
            return (dlc.SelectAdminBankAccountB(ID));
        }

        public void DeleteAdminBankAccountA(int ID)
        {
            dlc.DeleteAdminBankAccountA(ID);
        }
        public void DeleteAdminBankAccountB(int ID)
        {
            dlc.DeleteAdminBankAccountB(ID);
        }

        public AAdminBankAccount SelectAdminBankAccountA(int ID)
        {
            return (dlc.SelectAdminBankAccountA(ID));
        }
        public BAdminBankAccount SelectAdminBankAccountB(int ID)
        {
            return (dlc.SelectAdminBankAccountB(ID));
        }

        public void ExistAdminBankA(AAdminBankAccount AdminBank)
        {
            if (!dlc.ExistAdminBankA(AdminBank))
            {
                dlc.SaveEditAdminBankAccountA(AdminBank);
            }
        }
        public void ExistAdminBankB(BAdminBankAccount AdminBank)
        {
            if (!dlc.ExistAdminBankB(AdminBank))
            {
                dlc.SaveEditAdminBankAccountB(AdminBank);
            }
        }

        #endregion
        //  Agent Register
        public bool CreatAgentA(AAgent agent)
        {
            if (dlc.SelectionAgentA(agent))
            {
                return (dlc.CreateAgentA(agent));
            }
            return false;
        }
        public bool CreatAgentB(BAgent agent)
        {
            if (dlc.SelectionAgentB(agent))
            {
                return (dlc.CreateAgentB(agent));
            }
            return false;
        }

        public List<AAgent> ShowAllAgentA()
        {
            return (dlc.ShowAllAgentA()).ToList();
        }
        public List<BAgent> ShowAllAgentB()
        {
            return (dlc.ShowAllAgentB()).ToList();
        }

        public List<AAgent> ShowAllActiveAgentA()
        {
            return (dlc.ShowAllActiveAgentA()).ToList();
        }
        public List<BAgent> ShowAllActiveAgentB()
        {
            return (dlc.ShowAllActiveAgentB()).ToList();
        }

        public List<AAgent> ShowAllDisActiveAgentA()
        {
            return (dlc.ShowAllDisActiveAgentA()).ToList();
        }
        public List<BAgent> ShowAllDisActiveAgentB()
        {
            return (dlc.ShowAllDisActiveAgentB()).ToList();
        }

        public AAgent SelectAgentA(int ID)
        {
            return (dlc.SelectAgentA(ID));
        }
        public BAgent SelectAgentB(int ID)
        {
            return (dlc.SelectAgentB(ID));
        }

        public bool SaveEditAgentA(AAgent agent)
        {
            return (dlc.SaveEditAgentA(agent));
        }
        public bool SaveEditAgentB(BAgent agent)
        {
            return (dlc.SaveEditAgentB(agent));
        }

        public void DeleteAgent(String Admin, int ID)
        {
            dlc.DeleteAgent(Admin, ID);
        }

        public void ChangeStatusAgent(String Admin, int ID)
        {
            dlc.ChangeStatusAgent(Admin, ID);
        }

        //  Agent Bank Account

        public bool CreateAgentBankA(AAgentBankAccount agentBank)
        {
            return (dlc.CreateAgentBankA(agentBank));
        }
        public bool CreateAgentBankB(BAgentBankAccount agentBank)
        {
            return (dlc.CreateAgentBankB(agentBank));
        }

        public List<AAgentBankAccount> ShowAllDataAgentBankA()
        {
            return (dlc.ShowAllDataAgentBankA()).ToList();
        }
        public List<BAgentBankAccount> ShowAllDataAgentBankB()
        {
            return (dlc.ShowAllDataAgentBankB()).ToList();
        }

        public List<AAgentBankAccount> ShowAllActiveDataAgentBankA()
        {
            return (dlc.ShowAllActiveDataAgentBankA()).ToList();
        }
        public List<BAgentBankAccount> ShowAllActiveDataAgentBankB()
        {
            return (dlc.ShowAllActiveDataAgentBankB()).ToList();
        }

        public List<AAgentBankAccount> ShowAllDisActiveDataAgentBankA()
        {
            return (dlc.ShowAllDisActiveDataAgentBankA()).ToList();
        }
        public List<BAgentBankAccount> ShowAllDisActiveDataAgentBankB()
        {
            return (dlc.ShowAllDisActiveDataAgentBankB()).ToList();
        }

        public AAgentBankAccount SelectAgentBankAccountA(int ID)
        {
            return (dlc.SelectAgentBankAccountA(ID));
        }
        public BAgentBankAccount SelectAgentBankAccountB(int ID)
        {
            return (dlc.SelectAgentBankAccountB(ID));
        }

        public bool SaveEditAgentBankA(AAgentBankAccount agentBank)
        {
            return (dlc.SaveEditAgentBankA(agentBank));
        }
        public bool SaveEditAgentBankB(BAgentBankAccount agentBank)
        {
            return (dlc.SaveEditAgentBankB(agentBank));
        }

        public void DeleteBankAccountAgent(String Admin, int ID)
        {
            dlc.DeleteBankAccountAgent(Admin, ID);
        }


        public void ChangeStatusAgentBank(String Admin,int ID)
        {
            dlc.ChangeStatusAgentBank(Admin, ID);
        }

        public List<ACompany> SearchResult0A(String Word)
        {
            return (dlc.SearchResult0A(Word));
        }
        public List<BCompany> SearchResult0B(String Word)
        {
            return (dlc.SearchResult0B(Word));
        }

        public List<AAgent> SearchResult1A(String Word)
        {
            return (dlc.SearchResult1A(Word));
        }
        public List<BAgent> SearchResult1B(String Word)
        {
            return (dlc.SearchResult1B(Word));
        }

        public List<AAgentBankAccount> SearchResult2A(String Word)
        {
            return (dlc.SearchResult2A(Word));
        }
        public List<BAgentBankAccount> SearchResult2B(String Word)
        {
            return (dlc.SearchResult2B(Word));
        }


    }
}
