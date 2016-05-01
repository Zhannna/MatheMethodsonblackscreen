using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflekisaMathmetods
{
    class mathmethods
    {
        public static void RelieMethod(string str)
        {
            int index1 = 0, index2 = 0;
            char[] st = str.ToCharArray();
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == '(')
                    index1 = i;
           
                if (st[i] == ',')
                    index2 = i;
            }
           
            string name = str.Substring(0, index1);
            string param1 = " ";
            string param2 = " ";
            int count = 0;
            if (index2 != 0)
            {
                param1 = str.Substring(index1 + 1, index2 - index1 - 1);
                param2 = str.Substring(index2 + 1, str.Length - 2 - index2);
                count=2;
               
            }
            else
            {
                param1 = str.Substring(index1 + 1, str.Length - 2 - index1);
                count = 1;
                
            }
            object[]  ob = new object[] { double.Parse(param1) };
            
            if (count == 2)
                ob = new object[] { double.Parse(param1), Double.Parse(param2) };
               



            MethodInfo m = null;
            foreach (MethodInfo item in typeof(Math).GetMethods())
            {
                if (item.Name.Equals(name) && item.GetParameters().Length == count)
                {
                    m = item;
                    break;
                }


            }

            if (m != null)
            {
                object output = m.Invoke(name, ob);
                Console.WriteLine("{0}", output);


            }
            else
            {
                Console.WriteLine("method not found");
            }

        }
    }
}
