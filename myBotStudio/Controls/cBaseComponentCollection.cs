using MoonSharp.Interpreter;
using myBotStudio.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

using UserData = MoonSharp.Interpreter.UserData;

namespace myBotStudio.Controls
{
    [MoonSharpUserData]
    public abstract class cBaseComponentCollection<TComponent, TCollection, TUserData>
        where TComponent : Component
        where TCollection : BaseComponentCollection<TComponent, TCollection>
        where TUserData : cComponent
    {
        private BaseComponentCollection<TComponent, TCollection> obj;

        public cBaseComponentCollection(BaseComponentCollection<TComponent, TCollection> ele)
        {
            obj = ele;
        }

        public virtual DynValue this[int index]
        {
            get { return UserData.Create((TUserData)Activator.CreateInstance(typeof(TUserData), obj[index - 1])); }
        }

        public virtual int Count
        {
            get { return obj.Count; }
        }

        public virtual bool Exists(DynValue findBy, DynValue s1, DynValue s2)
        {
            return obj.Exists(Helpers.ParseConstraint(findBy, s1, s2));
        }

        public virtual TUserData[] Filter(DynValue findBy, DynValue s1, DynValue s2)
        {
            TCollection coll = obj.Filter(Helpers.ParseConstraint(findBy, s1, s2));
            List<TUserData> ncoll = new List<TUserData>();

            for (int i = 0; i < coll.Count; i++)
                ncoll.Add((TUserData)Activator.CreateInstance(typeof(TUserData), coll[i]));

            return ncoll.ToArray();
        }

        public virtual TUserData First()
        {
            return (TUserData)Activator.CreateInstance(typeof(TUserData), obj.First());
        }

        public virtual TUserData First(DynValue findBy, DynValue s1, DynValue s2)
        {
            return (TUserData)Activator.CreateInstance(typeof(TUserData), obj.First(Helpers.ParseConstraint(findBy, s1, s2)));
        }
    }
}
