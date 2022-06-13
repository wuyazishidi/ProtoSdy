/****************************************************
	文件：Program.cs
	作者：Jwp
	邮箱: 2604591896@qq.com
	日期：2022/06/10 11:27   	
	功能：
*****************************************************/
using PEUtils;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BasicPB {
    [Serializable]
    class Person { 
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    }
    [Serializable]
    class Address { 
    public string City { get; set; }
    public string Street { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            PELog.InitSettings();
            TestBasicNormal();
            Console.ReadKey();
        }

        static void TestBasicNormal() {
            var person = new Person {
                Id = 12345,
                Name = "Plane",
                Address = new Address {
                    City = "Shenzhen",
                    Street = "ShenNanDadao"
                }
            };
            byte[] data = Serialize(person);

            Person newPerson = DeSerialize(data);

            PELog.ColorLog(LogColor.Green,newPerson.Id);
            PELog.ColorLog(LogColor.Green,newPerson.Name);
            PELog.ColorLog(LogColor.Green,newPerson.Address.City);
            PELog.ColorLog(LogColor.Green,newPerson.Address.Street);
        }

        static byte[] Serialize(Person msg) {
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

        static Person DeSerialize(byte[]bytes) {
            Person msg = null;
            MemoryStream ms = new MemoryStream(bytes);
            BinaryFormatter bf = new BinaryFormatter();
            try {
                msg = (Person)bf.Deserialize(ms);
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
