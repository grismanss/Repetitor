using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Models;

namespace BLL
{
    public class DBDataOperation
    {
        
            private Model1 db;
            public DBDataOperation()
            {
                db = new Model1();

            }
            public List<EXPENSE_Model> GetEXPENSE()
            {
                return db.EXPENSEs.ToList().Select(i => new EXPENSE_Model(i)).ToList();

            }
            public List<EXPENSE_GUIDE_Model> GetEXPENSE_GUIDE()
            {
                return db.EXPENSE_GUIDEs.ToList().Select(i => new EXPENSE_GUIDE_Model(i)).ToList();

            }
            public List<INCOME_Model> GetINCOME()
            {
                return db.INCOMEs.ToList().Select(i => new INCOME_Model(i)).ToList();

            }
            public List<INCOME_GUIDE_Model> GetINCOME_GUIDE()
            {
                return db.INCOME_GUIDEs.ToList().Select(i => new INCOME_GUIDE_Model(i)).ToList();

            }
            public List<USER_Model> GetUSER()
            {
                return db.USERs.ToList().Select(i => new USER_Model(i)).ToList();

            }
        public bool GetUSER(string login, string password)
        {
            var k=db.USERs.ToList().Where(i => i.login==login && i.password==password).ToList();
            if (k.Count > 0)
            {
                return true;
            }
            else return false;

        }



        public bool Save()
            {
                if (db.SaveChanges() > 0) return true;
                return false;
            }

            public void DeleteEXPENSE_GUIDE(int id)
            {
            EXPENSE_GUIDE e = db.EXPENSE_GUIDEs.Find(id);
                if (e != null)
                {
                    db.EXPENSE_GUIDEs.Remove(e);
                    Save();
                }
            }
            public void CreateEXPENSE_GUIDE(EXPENSE_GUIDE_Model e)
            {
                db.EXPENSE_GUIDEs.Add(new EXPENSE_GUIDE()
                {
                    expense_guide_code_ID = e.expense_guide_code_ID,
                    expense_type = e.expense_type
        });
                Save();

            }
        public void CreateUSER(USER_Model u)
        {
            db.USERs.Add(new USER()
            {
            user_code_ID = u.user_code_ID,
            name = u.name,
            surname = u.surname,
            login = u.login,
            password = u.password,
            limit_size = 0
        });
            Save();

        }


        public void UpdateEXPENSE_GUIDE(EXPENSE_GUIDE_Model e)
            {
            EXPENSE_GUIDE ph = db.EXPENSE_GUIDEs.Find(e.expense_guide_code_ID);

            ph.expense_guide_code_ID = e.expense_guide_code_ID;
            ph.expense_type = e.expense_type;
                Save();
            }

        }
    }
