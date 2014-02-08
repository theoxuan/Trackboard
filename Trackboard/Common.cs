﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Trackboard
{
    //身份
    public enum Auth
    {
        Visitor, //访客
        Editor, //编辑
        Admin //管理员
    }

    //学生
    [Table(Name = "Student")]
    public class Student
    {
        [Column]
        public string SID { get; set; } //学号(10)<P>
        [Column]
        public string SName { get; set; } //姓名(8)
        [Column]
        public Boolean SGender { get; set; } //性别
        [Column]
        public DateTime SBirth { get; set; } //出生日期<*>
        [Column]
        public string CID { get; set; } //班级号(10)
        [Column]
        public string SPhone { get; set; } //手机号(11)<*>
    }

    //课程
    [Table(Name = "Course")]
    public class Course
    {
        [Column]
        public string CoID { get; set; } //课程号(10)<P>
        [Column]
        public string CoName { get; set; } //课程名(12)
        [Column]
        public string TID { get; set; } //教师号(10)
    }

    //分数
    [Table(Name = "Grade")]
    public class Grade
    {
        [Column]
        public string SID { get; set; } //学号(10)<P>
        [Column]
        public string CoID { get; set; } //课程号(10)<P>
        [Column]
        public int GMark { get; set; } //分数<*>
    }

    //班级
    [Table(Name = "Class")]
    public class Class
    {
        [Column]
        public string CID { get; set; } //班级号(10)<P>
        [Column]
        public string CName { get; set; } //班级名(10)
        [Column]
        public string TID { get; set; } //教师号(10)
    }

    //教师
    [Table(Name = "Teacher")]
    public class Teacher
    {
        [Column]
        public string TID { get; set; } //教师号(10)<P>
        [Column]
        public string TName { get; set; } //教师名(8)
        [Column]
        public string TPhone { get; set; } //手机号(11)<*>
    }

    //用户
    [Table(Name = "User")]
    public class User
    {
        [Column]
        public string UID { get; set; } //用户名(10)<P>
        [Column]
        public string UPwd { get; set; } //密码(20)
        [Column]
        public int UAuth { get; set; } //身份(11)<*>
    }
}