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

namespace EasyImages.Method
{
  public  class FontFamilyHelper
    {


      public List<FontFamilyData> LoadFont()
      {
          List<FontFamilyData> list = new List<FontFamilyData>();
          for (int i = 0; i < 20; i++)
          {
              list.Add(new FontFamilyData()
                  {
                      FontFamilyKey = "BRADHITC",
                      FontFamilyUrl = "",
                      FontName = "Bradley Hand ITC",
                  });
          }
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
