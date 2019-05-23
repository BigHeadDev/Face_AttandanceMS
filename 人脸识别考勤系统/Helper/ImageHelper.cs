using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace 人脸识别考勤系统.Helper
{
    public static class ImageHelper
    {
        public static byte[] GetBtyes(this string filePath)
        {
            try
            {
                byte[] bytes = null;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, bytes.Length);
                }
                return bytes;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        /// <summary>
        /// 将图片处理对象转图片字节数组
        /// </summary>
        /// <param name="bitmapImage">图片处理对象</param>
        /// <returns>图片字节数组</returns>
        public static byte[] GetBytes(this BitmapImage bitmapImage)
        {
            byte[] byteArray = null;
            try
            {
                Stream stream = bitmapImage.StreamSource;
                if (stream != null && stream.Length > 0)
                {
                    //很重要，因为Position经常位于Stream的末尾，导致下面读取到的长度为0。 
                    stream.Position = 0;
                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        byteArray = binaryReader.ReadBytes((int)stream.Length);
                    }
                }
                return byteArray;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }
        /// <summary>
        /// 将Base64String转byte数组
        /// </summary>
        /// <param name="base64">base64String</param>
        /// <returns>byte数组</returns>
        public static byte[] GetBytesByBase64String(this string base64)
        {
            var result = Convert.FromBase64String(base64);
            return result;
        }
        /// <summary>
        /// 传入图片所在的绝对路径获取图片处理对象 请勿用于大文件
        /// </summary>
        /// <param name="filePath">图片所在的绝对路径</param>
        /// <returns>图片处理对象</returns>
        public static BitmapImage GetBitmapImage(this string filePath)
        {
            var bytes = filePath.GetBtyes();
            var result = bytes.GetBitmapImage();
            return result;
        }
        /// <summary>
        /// 图片字节数组转图片处理对象
        /// </summary>
        /// <param name="byteArray">图片字节数组</param>
        /// <returns>图片处理对象</returns>
        public static BitmapImage GetBitmapImage(this byte[] byteArray)
        {
            BitmapImage bmp = null;
            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(byteArray);
                bmp.EndInit();
                return bmp;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        /// <summary>
        /// 将Base64String转图片处理对象
        /// </summary>
        /// <param name="base64">base64String</param>
        /// <returns>图片处理对象</returns>
        public static BitmapImage GetBitmapImageByBase64String(this string base64)
        {
            var bytes = base64.GetBytesByBase64String();
            var bitmapImage = bytes.GetBitmapImage();
            return bitmapImage;
        }
        /// <summary>
        /// 将图片字节数组转base64string
        /// </summary>
        /// <param name="imageBytes">图片字节数组</param>
        /// <returns>base64string</returns>
        public static string GetBase64String(this byte[] imageBytes)
        {
            var result = Convert.ToBase64String(imageBytes);
            return result;
        }
        /// <summary>
        /// 传入图片所在的绝对路径将图片转为base64string 请勿用于大文件
        /// </summary>
        /// <param name="filePath">图片所在的绝对路径</param>
        /// <returns>base64string</returns>
        public static string GetBase64String(this string filePath)
        {
            var bytes = filePath.GetBtyes();
            var result = bytes.GetBase64String();
            return result;
        }
        /// <summary>
        /// 将图片处理对象转为base64string
        /// </summary>
        /// <param name="bitmapImage">图片处理对象</param>
        /// <returns>base64string</returns>
        public static string GetBase64String(this BitmapImage bitmapImage)
        {
            var bytes = bitmapImage.GetBytes();
            var result = bytes.GetBase64String();
            return result;
        }
        /// <summary>
        /// WPFmediakit获取base64
        /// </summary>
        /// <param name="visual"></param>
        /// <returns></returns>
        public static string GetCameraImg(this Visual visual)
        {
            string base64 = "";
            try
            {
                RenderTargetBitmap bmp = new RenderTargetBitmap(748, 418, 96, 96, PixelFormats.Default);
                bmp.Render(visual);
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    byte[] captureData = ms.ToArray();//获取到byte数组
                    base64 = captureData.GetBase64String();
                }
            }
            catch
            {

            }
            return base64;
        }
    }
}
