﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Configuration;

namespace Trackboard
{
    /// <summary>
    /// 值转换器，返回SID.jpg文件路径
    /// </summary>
    [ValueConversion(typeof(object), typeof(string))]
    public class IMGPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format(@"{0}\{1}.jpg", ConfigurationManager.AppSettings["ImagePath"], value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class DatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("yyyy-MM-dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "♂" : "♀";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(object))]
    public class GradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Meth().GetGradesByStudent(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class ClassConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Meth().GetClassName(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(List<KeyValuePair<string, int>>))]
    public class CourseGradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gs = new Meth().GetGradesByCourse(value.ToString());


            return new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("优秀",gs.Count(g => g.GMark >=80)),
                new KeyValuePair<string,int>("良好",gs.Count(g => g.GMark < 80 && g.GMark >= 70)),
                new KeyValuePair<string,int>("及格",gs.Count(g => g.GMark < 70 && g.GMark >= 60)),
                new KeyValuePair<string,int>("不及格",gs.Count(g => g.GMark < 60)),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
