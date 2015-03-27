using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Animation;
using System.Windows.Media;
using Microsoft.Phone.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Markup;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Phone;
using Microsoft.Devices;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework.Media;
using EasyImages.Controls;
using EasyImages.Method;
using EasyImages.Model;

//using Brain.Animate;
//using Brain.Animate.Extensions;

namespace YiWen.Controls
{
    public partial class SideBar : UserControl
    {
        public event EventHandler OnChanged;
        public event EventHandler OnFavoritesClick;
        public event EventHandler OnOfflineClick;
        public event EventHandler OnAboutUsClick;
        public event EventHandler OnPathMenuClick;

        List<string> colorstrs = new List<string>() 
        { 
            "#FF1BA1E2",
            "#FFA05000",
            "#FF339933",
            "#FFE671B8",
            "#FFA200FF",
            "#FFE51400",
        };
        public SideBar()
        {
            InitializeComponent();
            ShowOrHidePage(false, null);
           

            //Random ran = new Random();
            //int displayIndex= ran.Next(0, colorstrs.Count);
            //if (displayIndex==colorstrs.Count)
            //{ 
                
                rectangle.Fill = new SolidColorBrush(Colors.White);
            //}
            //else
            //{
            //    rectangle.Fill = new SolidColorBrush(ConvertFromString(colorstrs[displayIndex]));
            //}
            //gridMain.MouseMove += gridMain_MouseMove;
            FontFamilyHelper helper=new FontFamilyHelper ();
            this.listFont.ItemsSource = helper.LoadFont();
            this.listFont.DataContext = helper.LoadFont();      
        }

      



        void ShowOrHidePage(bool isKeyframe, Action action = null)
        {
            if (!isKeyframe)
            {
                double to = (uptansform.TranslateX == 0) ? 380 : 0;
                TranslateStory(uptansform.TranslateX, to, TimeSpan.FromSeconds(0.3), action);
            }
            else
            {
                TranslateWithKeyframe(TimeSpan.FromSeconds(0.6), action);
            }
        }

        void TranslateStory(double from, double to, Duration duration, Action action, bool isout = true)
        {
            Storyboard sb = new Storyboard();
            sb.Duration = duration;

            var da = new DoubleAnimation();
            da.From = from;
            da.To = to;
            da.Duration = duration;
            da.EasingFunction = new CubicEase { EasingMode = isout ? EasingMode.EaseOut : EasingMode.EaseIn };
            Storyboard.SetTarget(da, uptansform);
            Storyboard.SetTargetProperty(da, new PropertyPath(CompositeTransform.TranslateXProperty));
            sb.Children.Add(da);
            sb.Begin();
            sb.Completed += (o, a) =>
            {
                sb.Stop();
                uptansform.TranslateX = to;
                sb.Children.Clear();
                sb = null;
                if (action != null)
                    action();
            };
        }


        void TranslateWithKeyframe(Duration duration, Action action)
        {
            var sb = new Storyboard();
            sb.Duration = duration;

            var frames = new DoubleAnimationUsingKeyFrames();
            frames.Duration = duration;
            var keyFrame = new EasingDoubleKeyFrame { Value = uptansform.TranslateX, KeyTime = TimeSpan.FromSeconds(0) };
            frames.KeyFrames.Add(keyFrame);

            keyFrame = new EasingDoubleKeyFrame { Value = 480, KeyTime = TimeSpan.FromSeconds(0.2) };
            frames.KeyFrames.Add(keyFrame);

            keyFrame = new EasingDoubleKeyFrame { Value = 480, KeyTime = TimeSpan.FromSeconds(0.4) };
            frames.KeyFrames.Add(keyFrame);

            keyFrame = new EasingDoubleKeyFrame { Value = 0, KeyTime = TimeSpan.FromSeconds(0.6) };
            frames.KeyFrames.Add(keyFrame);

            Storyboard.SetTarget(frames, uptansform);
            Storyboard.SetTargetProperty(frames, new PropertyPath(CompositeTransform.TranslateXProperty));
            sb.Children.Add(frames);
            sb.Begin();
            sb.Completed += (o, a) =>
            {
                sb.Stop();
                sb.Children.Clear();
                sb = null;
                frames.KeyFrames.Clear();
                frames = null;
                uptansform.TranslateX = 0;
                if (action != null)
                    action();
            };
        }


        private void GestureListener_DragStarted(object sender, DragStartedGestureEventArgs e)
        {

        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (uptansform.TranslateX >= 0 && uptansform.TranslateX <= 380)
            {
                uptansform.TranslateX += e.HorizontalChange;
                uptansform.TranslateX = (uptansform.TranslateX < 0) ? 0 : uptansform.TranslateX;
                uptansform.TranslateX = (uptansform.TranslateX > 380) ? 380 : uptansform.TranslateX;
            }
        }
        
        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {

            if (uptansform.TranslateX == 0 || uptansform.TranslateX == 380)
                return;
            if (e.HorizontalChange < 0)
                //uptansform.TranslateX = 0;
                TranslateStory(uptansform.TranslateX, 0, TimeSpan.FromSeconds(0.3), null);
            else
            {
                if (uptansform.TranslateX < 120)
                    TranslateStory(uptansform.TranslateX, 0, TimeSpan.FromSeconds(0.2), null);
                else
                    TranslateStory(uptansform.TranslateX, 380, TimeSpan.FromSeconds(0.3), null);
            }
        }



        private void gridMainGestureListener_DragStarted(object sender, DragStartedGestureEventArgs e)
        {

        }

        private void gridMainGestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            //switch (e.Direction)
            //{
            //    case Orientation.Horizontal:
            //        txtMsg.TextAlignment = TextAlignment.Right;
            //        break;
            //    case Orientation.Vertical:
            //        break;
            //    default:
            //        break;
            //}


        }

        private void gridMainGestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {

        }


        private void UpdateTextBoxFontSize(Point delta)
        {
            //var newPosition=new Point()
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OnPathMenuClick != null)
            {
                OnPathMenuClick(this, e);
            }
            ShowOrHidePage(false, null);
        }



        #region MyRegion

        public class Province : IComparable<Province>
        {
            public string Name
            {

                get;
                set;
            }

            public List<City> Citys
            {
                get;
                set;
            }

            public int CompareTo(Province other)
            {
                return this.Name.CompareTo(other.Name);
            }
        }
        public class ProvinceSelector : IComparable<ProvinceSelector>
        {
            public string Name
            {
                get;
                set;

            }




            public int CompareTo(ProvinceSelector other)
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        public class City : IComparable<City>
        {
            public string Name
            {
                get;
                set;
            }

            public int CompareTo(City other)
            {
                return this.Name.CompareTo(other.Name);
            }
        }


        public class CityComparer : IComparer<City>
        {

            public int Compare(City x, City y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }


        // abstract the reusable code in a base class
        // this will allow us to concentrate on the specifics when implementing deriving looping data source classes
        public abstract class LoopingDataSourceBase : ILoopingSelectorDataSource
        {
            private object selectedItem;

            #region ILoopingSelectorDataSource Members

            public abstract object GetNext(object relativeTo);

            public abstract object GetPrevious(object relativeTo);

            public object SelectedItem
            {
                get
                {
                    return this.selectedItem;
                }
                set
                {
                    // this will use the Equals method if it is overridden for the data source item class
                    if (!object.Equals(this.selectedItem, value))
                    {
                        // save the previously selected item so that we can use it 
                        // to construct the event arguments for the SelectionChanged event
                        object previousSelectedItem = this.selectedItem;
                        this.selectedItem = value;
                        // fire the SelectionChanged event
                        this.OnSelectionChanged(previousSelectedItem, this.selectedItem);
                    }
                }
            }

            public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

            protected virtual void OnSelectionChanged(object oldSelectedItem, object newSelectedItem)
            {
                EventHandler<SelectionChangedEventArgs> handler = this.SelectionChanged;
                if (handler != null)
                {
                    handler(this, new SelectionChangedEventArgs(new object[] { oldSelectedItem }, new object[] { newSelectedItem }));
                }
            }

            #endregion
        }

        public class ListLoopingDataSource<T> : LoopingDataSourceBase
        {
            private LinkedList<T> linkedList;
            private List<LinkedListNode<T>> sortedList;
            private IComparer<T> comparer;
            private NodeComparer nodeComparer;

            public ListLoopingDataSource()
            {
            }

            public IEnumerable<T> Items
            {
                get
                {
                    return this.linkedList;
                }
                set
                {
                    this.SetItemCollection(value);
                }
            }

            private void SetItemCollection(IEnumerable<T> collection)
            {
                this.linkedList = new LinkedList<T>(collection);

                this.sortedList = new List<LinkedListNode<T>>(this.linkedList.Count);
                // initialize the linked list with items from the collections
                LinkedListNode<T> currentNode = this.linkedList.First;
                while (currentNode != null)
                {
                    this.sortedList.Add(currentNode);
                    currentNode = currentNode.Next;
                }

                IComparer<T> comparer = this.comparer;
                if (comparer == null)
                {
                    // if no comparer is set use the default one if available
                    if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                    {
                        comparer = Comparer<T>.Default;
                    }
                    else
                    {
                        throw new InvalidOperationException("There is no default comparer for this type of item. You must set one.");
                    }
                }

                this.nodeComparer = new NodeComparer(comparer);
                this.sortedList.Sort(this.nodeComparer);
            }

            public IComparer<T> Comparer
            {
                get
                {
                    return this.comparer;
                }
                set
                {
                    this.comparer = value;
                }
            }

            public override object GetNext(object relativeTo)
            {
                // find the index of the node using binary search in the sorted list
                int index = this.sortedList.BinarySearch(new LinkedListNode<T>((T)relativeTo), this.nodeComparer);
                if (index < 0)
                {
                    return default(T);
                }

                // get the actual node from the linked list using the index
                LinkedListNode<T> node = this.sortedList[index].Next;
                if (node == null)
                {
                    // if there is no next node get the first one
                    node = this.linkedList.First;
                }
                return node.Value;
            }

            public override object GetPrevious(object relativeTo)
            {
                int index = this.sortedList.BinarySearch(new LinkedListNode<T>((T)relativeTo), this.nodeComparer);
                if (index < 0)
                {
                    return default(T);
                }
                LinkedListNode<T> node = this.sortedList[index].Previous;
                if (node == null)
                {
                    // if there is no previous node get the last one
                    node = this.linkedList.Last;
                }
                return node.Value;
            }

            private class NodeComparer : IComparer<LinkedListNode<T>>
            {
                private IComparer<T> comparer;

                public NodeComparer(IComparer<T> comparer)
                {
                    this.comparer = comparer;
                }

                #region IComparer<LinkedListNode<T>> Members

                public int Compare(LinkedListNode<T> x, LinkedListNode<T> y)
                {
                    return this.comparer.Compare(x.Value, y.Value);
                }

                #endregion
            }

        }

        #endregion

        private void selectorCity_IsExpandedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }



        public object selectorProvince_SelectionChanged { get; set; }

      

        private void txtFavorites_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (OnFavoritesClick!=null)
            {
                OnFavoritesClick(this, e);
            }
        }

        private void txtOffline_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (OnOfflineClick!=null)
            {
                OnOfflineClick(this, e);
            }

          
        }

        private void txtAboutUs_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (OnAboutUsClick!=null)
            {
                OnAboutUsClick(this, e);
            }
        }

        private void Path_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (OnPathMenuClick!=null)
            {
                OnPathMenuClick(this, e);
            }

            ShowOrHidePage(false, null);
        }

        int tapIndex = 0;
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (image.Source!=null)
            {
                pivotPanel.SelectedIndex = 0;
                return;
            }
            if (tapIndex < colorstrs.Count)
            {
                tapIndex++;
            }

            if (tapIndex==colorstrs.Count)
            {
                tapIndex = -1;
                rectangle.Fill = new SolidColorBrush(Colors.White);
                return;
            }
            if (tapIndex>colorstrs.Count)
            {
                tapIndex = 0;
            }
            
                rectangle.Fill = new SolidColorBrush(ConvertFromString(colorstrs[tapIndex]));
           
        }



        public static Color ConvertFromString(string colorString)
        {
            Color color;
            try
            {
                Line line = (Line)XamlReader.Load("<Line xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Fill=\"" + colorString + "\" />");
                color = (Color)line.Fill.GetValue(SolidColorBrush.ColorProperty);
            }
            catch
            {
                color = new Color();
            }

            return color;
        }

        PhotoChooserTask photoTask;
        private void ImageButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (photoTask==null)
            {
                photoTask = new PhotoChooserTask();
            }
            photoTask = new PhotoChooserTask();
            photoTask.PixelHeight = 480;
            photoTask.PixelWidth = 480;
            photoTask.ShowCamera = true;
            photoTask.Completed += photoTask_Completed;
            photoTask.Show();
        }

        void photoTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.Cancel || e.TaskResult == TaskResult.None)
                {
                    return;
                }
            else if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();  
               try  
               {  
                   bmp.SetSource(e.ChosenPhoto);  
                   Dispatcher.BeginInvoke(() => {  
                       this.image.Source = bmp;  
                   });  
               }  
               catch (Exception ex)  
               {  
                   //MessageBox.Show(ex.Message);  
               }  
            }
        }
        TextBlock txt;
        private void gridMain_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
             //txt= new TextBlock();
             //Point point=  e.GetPosition(gridMain);
             //txt.Text = "双击。。。";
             //txt.FontSize = 30;
             //txt.Foreground = new SolidColorBrush(Colors.Black);
             ////Canvas.SetLeft(txt, point.X);
             ////Canvas.SetTop(txt, point.Y);
             //txt.Margin = new Thickness(point.X, point.Y, 0, 0);
             //gridMain.Children.Add(txt);
             //txt.Tap += txt_Tap;
             //txt.MouseLeftButtonDown += txt_MouseLeftButtonDown;
             //txt.MouseMove += txt_MouseMove;
             //txt.MouseLeave += txt_MouseLeave;
        }

        void txt_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //(sender as TextBlock).Margin = new Thickness(e.GetPosition((sender as TextBlock)).X, e.GetPosition((sender as TextBlock)).Y, 0, 0);
        }

        void txt_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
           
            txt=(sender as TextBlock);//.Margin = new Thickness(point.X, point.Y, 0, 0);
        }

        void txt_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //(sender as TextBlock).Margin = new Thickness(e.GetPosition((sender as TextBlock)).X, e.GetPosition((sender as TextBlock)).Y, 0, 0);

        }

        void txt_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (sender as TextBlock).Text += "!";

        }

        void gridMain_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point point = e.GetPosition((sender as TextBlock));
            Debug.WriteLine("MouseMove:{0},{1}", point.X, point.Y);
            if (txt!=null)
            {
                
            txt.Margin = new Thickness(point.X, point.Y, 0, 0);
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            image.Source = null;

        }

        private PhotoCamera _camera;
        private int _currentResolutionIndex = 0;

        int btnTap = 0;

        private void btnCamera_Click(object sender, RoutedEventArgs e)
        {
            //CameraCaptureTask cameraTask = new CameraCaptureTask();
            //cameraTask.Completed += cameraTask_Completed;
            
            //cameraTask.Show();

            if (photoTask == null)
            {
                photoTask = new PhotoChooserTask();
            }
            photoTask = new PhotoChooserTask();
            photoTask.PixelHeight = 480;
            photoTask.PixelWidth = 480;
            photoTask.ShowCamera = true;
            photoTask.Completed += photoTask_Completed;
            photoTask.Show();


            #region MyRegion
            //if (btnTap%2==0)
            //{

            //    if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary) ||
            //  (PhotoCamera.IsCameraTypeSupported(CameraType.FrontFacing) == true))
            //    {

            //        _camera = new PhotoCamera(CameraType.Primary);


            //        // 获取主摄像头，并注册相关事件
            //        _camera.Initialized += _camera_Initialized;
            //        _camera.CaptureStarted += _camera_CaptureStarted;
            //        _camera.CaptureCompleted += _camera_CaptureCompleted;
            //        _camera.CaptureImageAvailable += _camera_CaptureImageAvailable;
            //        _camera.CaptureThumbnailAvailable += _camera_CaptureThumbnailAvailable;
            //        //_camera.Focus();
            //        // 在 VideoBrush 上显示摄像头捕获到的实时信息

            //        _previewVideo.SetSource(_camera);
            //        this.Dispatcher.BeginInvoke(() =>
            //            {
            //                _previewTransform.Rotation = _camera.Orientation;
            //                imageTransform.Rotation = _camera.Orientation;
            //            });
            //    }
            //}
            //if (btnTap % 2==1)
            //{

            //    if (_camera != null)
            //    {
            //        try
            //        {

            //            // 拍摄摄像头当前捕获的图片
            //            _camera.CaptureImage();

            //        }
            //        catch (Exception ex)
            //        {
            //            Debug.WriteLine("拍摄失败：" + ex.Message);
            //        }
            //    }

            //}
            //btnTap++;
            
            #endregion
          


        }

        #region Camera
        private void _camera_CaptureThumbnailAvailable(object sender, ContentReadyEventArgs e)
        {

        }

        private void _camera_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            // 获得了所拍摄的图片
            this.Dispatcher.BeginInvoke(delegate()
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(e.ImageStream);

                image.Source = bitmapImage;

            });
        }


        private void _camera_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            // 拍照完成
            this.Dispatcher.BeginInvoke(delegate()
            {
                Debug.WriteLine("图片捕获完成");
            });

        }

        private void _camera_CaptureStarted(object sender, EventArgs e)
        {
            // 开始捕获
            this.Dispatcher.BeginInvoke(delegate()
            {
                Debug.WriteLine("图片开始捕获");
            });

        }

        private void _camera_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                this.Dispatcher.BeginInvoke(delegate()
                {
                    // 初始化闪光灯模式
                    _camera.FlashMode = FlashMode.Auto;

                    // 初始化分辨率设置
                    _camera.Resolution = _camera.AvailableResolutions.ElementAt<Size>(1);

                    Debug.WriteLine("分辨率：" + _camera.AvailableResolutions.ElementAt<Size>(_currentResolutionIndex));

                    Debug.WriteLine("主摄像头初始化成功");
                });
            }

        }

        void cameraTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.Cancel || e.TaskResult == TaskResult.None)
            {
                return;
            }
            else if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();
                try
                {
                    bmp.SetSource(e.ChosenPhoto);
                    Dispatcher.BeginInvoke(() =>
                    {
                        this.image.Source = bmp;
                    });
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);  
                }
            }
        }     
        #endregion

        private void btnShare_Click(object sender, RoutedEventArgs e)
        {
            

            WriteableBitmap bmp = new WriteableBitmap(480, 480);
            bmp.Render(gridMain, null);
            bmp.Invalidate();

            MemoryStream stream = new MemoryStream();
            bmp.SaveJpeg(stream, bmp.PixelWidth, bmp.PixelHeight, 0, 80);
            stream.Seek(0, SeekOrigin.Begin);

            MediaLibrary library = new MediaLibrary();
            string fileName = "EImage_" + DateTime.Now.ToString("yyyy-mm-dd_hh:mm:ss")+".jpg";
            library.SavePicture(fileName, stream);
            stream.Close();


            MessageBox.Show("已保存","",MessageBoxButton.OK);

        }

        private void btnText_Click(object sender, RoutedEventArgs e)
        {
            //光标移到最后
            txtMsg.SelectionStart = txtMsg.Text.Length;
            txtMsg.SelectionLength = 0;
            txtMsg.Focus();
            pivotPanel.SelectedIndex = 1;
        }

        private void btnTextAlignmentLeft_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.TextAlignment = TextAlignment.Left;
        }

        private void btnTextAlignmentRight_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.TextAlignment = TextAlignment.Right;
        }

        private void btnTextAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.TextAlignment = TextAlignment.Center;
        }

        private void btnTextAlignmentBottom_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.VerticalAlignment = VerticalAlignment.Bottom;
        }

        private void btnTextAlignmentTop_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.VerticalAlignment = VerticalAlignment.Top;
        }

        private void btnTextAlignment_Click(object sender, RoutedEventArgs e)
        {
            ImageButton button=(sender as ImageButton);

            switch (button.Tag.ToString())
            {
                case "TextAlignmentLeft":
                    txtMsg.TextAlignment = TextAlignment.Left;
                    break;
                case "TextAlignmentRight":
                    txtMsg.TextAlignment = TextAlignment.Right;
                    break;
                case "TextAlignmentCenter":
                    txtMsg.TextAlignment = TextAlignment.Center;
                    break;
                case "TextAlignmentJustify"://不支持Justify
                    txtMsg.VerticalContentAlignment = VerticalAlignment.Center;
                    txtMsg.HorizontalContentAlignment = HorizontalAlignment.Center;
                    break;
                case "TextAlignmentTop":
                    txtMsg.VerticalContentAlignment = VerticalAlignment.Top;
                    break;
                case "TextAlignmentBottom":
                    txtMsg.VerticalContentAlignment = VerticalAlignment.Bottom;
                    break;
                case "TextAlignmentHLeft":
                    txtMsg.HorizontalContentAlignment = HorizontalAlignment.Left;
                    break;
                case "TextAlignmentHRight":
                    txtMsg.HorizontalContentAlignment = HorizontalAlignment.Right;
                    break;
                case "TextLight":
                    txtMsg.Foreground = new SolidColorBrush(Colors.White);
                    break;
                case "TextBlack":
                    txtMsg.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                default:
                    break;
            }

        }

        private void ColorSlider_ColorChanged(object sender, Color color)
        {
            textBlock.Foreground = new SolidColorBrush(color);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //FontFamilyHelper.LoadIsoFontFamilyFile("msyhbd.TTC", "Microsoft YaHei UI", textBlock);
            //FontFamilyHelper.LoadIsoFontFamilyFile("msyhbd.TTC", "Microsoft YaHei UI", txtMsg);
             FontFamilyData font=(sender as ListBox).SelectedItem as FontFamilyData;

            textBlock.FontFamily= txtMsg.FontFamily = new FontFamily(font.FontFamilyUrl);
        }



//        public void CaptureScreen(object sender, EventArgs e) 
// 2         {
// 3             WriteableBitmap bmp = new WriteableBitmap(480, 800);
// 4             bmp.Render(App.Current.RootVisual, null);
// 5             bmp.Invalidate();
// 6 
// 7             MemoryStream stream = new MemoryStream();
// 8             bmp.SaveJpeg(stream, bmp.PixelWidth, bmp.PixelHeight, 0, 80);
// 9             stream.Seek(0, SeekOrigin.Begin);
//10 
//11             MediaLibrary library = new MediaLibrary();
//12             string fileName = "ScreenShot_" + DateTime.Now.ToString("yyyy-mm-dd_hh:mm:ss");
//13             library.SavePicture(fileName, stream);
//14             stream.Close();
//15 
//16 
//17             Dispatcher.BeginInvoke(() => 
//18             {
//19                 PictureCollection picCollection = library.Pictures;
//20                 foreach (Picture item in picCollection)
//21                 {
//22                     if (item!=null)
//23                     {
//24                         BitmapImage bitmap = new BitmapImage();
//25                         bitmap.SetSource(item.GetImage());
//26                         ScreenShot.Source = bitmap;
//27                         PicName.Text ="图片名称 ："+ item.Name;
//28                     }
//29                    
//30                 }
//31             });
//32 

    }
}
