/****************************************************
	文件：ProtocolTool.cs
	作者：Jwp
	邮箱: 2604591896@qq.com
	日期：2022/06/13 12:03   	
	功能：常规序列化工具
*****************************************************/
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetProtocol {
    public class ProtocolTool {
       public static byte[] Serialize(Pkg msg) {
            byte[] data = null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            try {
                bf.Serialize(ms, msg);
                ms.Seek(0, SeekOrigin.Begin);
                data = ms.ToArray();
            }
            catch (SerializationException e) {
                Console.WriteLine("Exception :Faild to Serialize,Reson:{0}", e.Message);
                throw;
            }
            finally {
                ms.Close();
            }
            return data;
        }

      public  static Pkg DeSerialize(byte[] bytes) {
            Pkg msg = null;
            MemoryStream ms = new MemoryStream(bytes);
            BinaryFormatter bf = new BinaryFormatter();
            try {
                msg = (Pkg)bf.Deserialize(ms);
            }
            catch (SerializationException e) {
                Console.WriteLine("Exception :Faild to DeSerialize,Reson:{0}", e.Message);
                throw;
            }
            finally {
                ms.Close();
            }
            return msg;
        }
    }

}
