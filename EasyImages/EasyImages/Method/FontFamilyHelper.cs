using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using Windows.Storage;
using System.Windows.Controls;
using EasyImages.Model;
using System.Windows;

namespace EasyImages.Method
{
  public  class FontFamilyHelper
    {


      public List<FontFamilyData> LoadFont()
      {

          //Application.GetResourceStream()

          List<FontFamilyData> list = new List<FontFamilyData>()
          {
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Segoe UI Light", FontName="Segoe UI Light"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Microsoft YaHei Light", FontName="Microsoft YaHei Light"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Harlow Solid Italic", FontName="Harlow Solid Italic"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Freestyle Script", FontName="Freestyle Script"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#French Script MT", FontName="French Script MT"},

              //new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#STCaiyun", FontName="STCaiyun"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Papyrus", FontName="Papyrus"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#STCaiyun", FontName="STCaiyun"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Old English Text MT", FontName="Old English Text MT"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Bradley Hand ITC", FontName="Bradley Hand ITC"},

              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#French Script MT", FontName="French Script MT"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Jokerman", FontName="Jokerman"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Kunstler Script", FontName="Kunstler Script"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Ravie", FontName="Ravie"},
              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Vladimir Script", FontName="Vladimir Script"},

              new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="/EasyImages;component/Fonts/Fonts.zip#Matura MT Script Capitals", FontName="Matura MT Script Capitals"},
              //new FontFamilyData(){ FontFamilyKey="", FontFamilyUrl="", FontName="atura MT Script Capitals"},
          };
       
             
          return list;
      }

      /// <summary>
      /// 加载本地存储字体
      /// </summary>
      /// <param name="fileName"></param>
      /// <param name="fontName"></param>
      /// <param name="textBox"></param>
      /// <returns></returns>
      public static TextBlock LoadIsoFontFamilyFile(string fileName, string fontName, TextBlock textBox)
      {
          using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
          {
              using(IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Open, storage))
              {

              textBox.FontSource = new System.Windows.Documents.FontSource(isoStream);
              textBox.FontFamily = new System.Windows.Media.FontFamily(fontName);
              isoStream.Flush();
              isoStream.Close();
                  return textBox;
              }
          } 
      }

      /// <summary>
      /// 加载本地存储字体
      /// </summary>
      /// <param name="fileName"></param>
      /// <param name="fontName"></param>
      /// <param name="textBox"></param>
      /// <returns></returns>
      public static TextBox LoadIsoFontFamilyFile(string fileName, string fontName, TextBox textBox)
      {
          using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
          {
              using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Open, storage))
              {

                  textBox.FontSource = new System.Windows.Documents.FontSource(isoStream);
                  textBox.FontFamily = new System.Windows.Media.FontFamily(fontName);
                  isoStream.Flush();
                  isoStream.Close();
                  return textBox;
              }
          }
      }

    }
}
