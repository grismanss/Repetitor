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
        //функция определяет есть ли пользователь с таким логином и паролем в базе
       public int GetUSER(string login, string password)
        {
            var k= db.USERs.ToList().Where(i => i.login==login && i.password==password).ToList();
            if (k.Count > 0)
            {
                return k[0].user_code_ID;
            }
            else
            {
                return 0;
            }
                 
        }
        //определяет есть ли пользовательс таким логином
        public bool GetUSER(string login)
        {
            var k = db.USERs.ToList().Where(i => i.login == login ).ToList();
            if (k.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
        public void CreateINCOME(INCOME_Model i)

        {
            db.INCOMEs.Add(new INCOME()
            {
                income_code_ID = i.income_code_ID,
                income_user_FK = i.income_user_FK,
                income_guide_FK = i.income_guide_FK,
                income_date = i.income_date,
                income_size = i.income_size
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
