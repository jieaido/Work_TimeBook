using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isok = false;
            var sss= MyEncrypt.EncryptStringToString_Aes("asdasdasdfergf@!@#!$@!$", "qwerasdfzxqwer",out isok);
            if (isok)
            {
                var ssss2 = MyEncrypt.DecryptStringFromString_Aes(sss, "qwerasdfzxcvqwer",out isok);
            }
            
           byte[] keys= Encoding.UTF8.GetBytes("abcdef123456u890");
           

           var IV1= System.Text.Encoding.UTF8.GetBytes("abcdef1234567890");
            var result= Class1.EncryptStringToBytes_Aes("山不在高，有仙则名。水不在深，有龙则灵。斯是陋室，惟吾德馨。苔痕上阶绿，草色入帘青。谈笑有鸿儒，往来无白丁。可以调素琴，阅金经。无丝竹之乱耳，无案牍之劳形。南阳诸葛庐，西蜀子云亭。孔子云：何陋之有？", keys, IV1);
            var r_str = Convert.ToBase64String(result);
            var result2 = Class1.DecryptStringFromBytes_Aes(Convert.FromBase64String(r_str), keys, IV1);
            Console.WriteLine(r_str);
            Console.WriteLine(result2);
            Console.ReadKey();
        }
    }
}
