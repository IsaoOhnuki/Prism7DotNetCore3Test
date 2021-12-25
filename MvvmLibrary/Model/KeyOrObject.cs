using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MvvmCommonLibrary.Model
{
    public class KeyOrObject<TLeft, TRight>
    {
        public TLeft Key { get; set; }

        public TRight Element { get; set; }

        public KeyOrObject()
        {
        }

        public KeyOrObject(TLeft key)
        {
            Key = key;
        }

        public KeyOrObject(TRight element)
        {
            Element = element;
        }

        public static bool operator ==(KeyOrObject<TLeft, TRight> l, KeyOrObject<TLeft, TRight> r)
        {
            return l.Element.Equals(r.Element) || l.Key.Equals(r.Key);
        }

        public static bool operator !=(KeyOrObject<TLeft, TRight> l, KeyOrObject<TLeft, TRight> r)
        {
            return !l.Element.Equals(r.Element) != !l.Key.Equals(r.Key);
        }

        public static bool operator ==(KeyOrObject<TLeft, TRight> l, TRight r)
        {
            return l.Element.Equals(r);
        }

        public static bool operator !=(KeyOrObject<TLeft, TRight> l, TRight r)
        {
            return !l.Element.Equals(r);
        }

        public static bool operator ==(KeyOrObject<TLeft, TRight> l, TLeft r)
        {
            return l.Key.Equals(r);
        }

        public static bool operator !=(KeyOrObject<TLeft, TRight> l, TLeft r)
        {
            return !l.Key.Equals(r);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            KeyOrObject<TLeft, TRight> elementStringKey = obj as KeyOrObject<TLeft, TRight>;
            return this == elementStringKey;
        }

        public override int GetHashCode()
        {
            return new Tuple<TLeft, TRight>(Key, Element).GetHashCode();
        }
    }
}
