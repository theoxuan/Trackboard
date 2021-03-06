﻿/*The MIT License (MIT)

Copyright (c) 2014 Sean/Zhang Xuan

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
 */
using System;
using System.Windows;
using System.Windows.Input;

namespace Trackboard
{
	/// <summary>
	/// Profile.xaml 的交互逻辑
	/// </summary>
	public partial class Profile : Window
	{
		public Profile()
		{
			InitializeComponent();

			if (Meth.CurrentUser != null)
				userName.Text = Meth.CurrentUser.UID;
		}

		private void Window_DragMove(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void btnDisc_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			if(string.IsNullOrWhiteSpace(pwdOld.Password))
			{
				Message.Show("请输入旧密码");
				return;
			}
			else if (pwdOld.Password != Meth.CurrentUser.UPwd)
			{
				Message.Show("旧密码错误");
				return;
			}
			else if (string.IsNullOrWhiteSpace(pwdNew.Password)||string.IsNullOrWhiteSpace(pwdCon.Password))
			{
				Message.Show("请输入/确认新密码");
				return;
			}
			else if (pwdNew.Password != pwdCon.Password)
			{
				Message.Show("两次输入不一致");
				return;
			}
			else
			{
				try
				{
					var user = new User();
					user = Meth.CurrentUser;
					user.UPwd = pwdCon.Password;
					Meth.UpdateUser(user);
					Message.Show("更新成功");
					Close();
				}
				catch (Exception ex)
				{
					Message.Show(String.Format("更新失败:\n{0}", ex.Message));
				}
			}		
		}

	}
}
