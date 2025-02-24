using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace UIvertake
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Retrieves the handle to the foreground window (the window with which the user is currently working).
        /// </summary>
        /// <returns>The return value is a handle to the foreground window. The foreground window can be NULL in certain circumstances, such as when a window is losing activation.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getforegroundwindow
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Retrieves the handle to the top-level window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="hwndParent">A handle to the parent window whose child windows are to be searched.</param>
        /// <param name="hwndChildAfter">A handle to a child window. The search begins with the next child window in the Z order.</param>
        /// <param name="lpszClass">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="lpszWindow">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowa
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string? lpszClass, string? lpszWindow);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">The buffer that will receive the text.</param>
        /// <param name="nMaxCount">The maximum number of characters to copy to the buffer, including the null character.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. If the window is untitled, the return value is zero.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowtext
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Sends the specified message to a window or windows. 
        /// The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="Msg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        /// <summary>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function.
        /// </summary>
        /// <param name="lpEnumFunc">A pointer to an application-defined callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumwindows
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindowvisible
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
        /// </summary>
        /// <param name="hWnd">A handle to the window or control.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the text. Under certain conditions, this value may actually be greater than the length of the text.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowtextlength
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="lpClassName">The class name string.</param>
        /// <param name="nMaxCount">The length of the lpClassName buffer, in characters.</param>
        /// <returns>If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclassname
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// An application-defined callback function used with the EnumWindows or EnumDesktopWindows function.
        /// </summary>
        /// <param name="hWnd">A handle to a top-level window.</param>
        /// <param name="lParam">The application-defined value given in EnumWindows or EnumDesktopWindows.</param>
        /// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.</returns>
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-enumwindowsproc
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Sets the text of a window.
        /// https://docs.microsoft.com/en-us/windows/win32/controls/wm-settext
        /// </summary>
        const uint WM_SETTEXT = 0x000C;

        /// <summary>
        /// Handle of the currently selected window.
        /// </summary>
        private IntPtr selectedWindowHandle = IntPtr.Zero;

        /// <summary>
        /// List of handles of the text fields found in the selected window.
        /// </summary>
        private List<IntPtr> fieldHandles = [];

        /// <summary>
        /// Represents a window item.
        /// </summary>
        private class WindowItem
        {
            public IntPtr Handle { get; set; }
            public string Title { get; set; }

            public override string ToString()
            {
                return Title;
            }
        }

        /// <summary>
        /// Represents a field item.
        /// </summary>
        private class FieldItem
        {
            public IntPtr Handle { get; set; }
            public string? ClassName { get; set; }

            public override string ToString()
            {
                return $"{ClassName} - {Handle}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonAnalyze_Click(object sender, EventArgs e)
        {
            comboBoxWindows.Items.Clear();
            comboBoxFields.Items.Clear();
            fieldHandles.Clear();
            // Get the handle of the foreground window
            EnumWindows(new EnumWindowsProc(EnumTheWindows), IntPtr.Zero);
        }

        /// <summary>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function.
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumwindows
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>Returns true to continue the enumeration.</returns>
        private bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            if (IsWindowVisible(hWnd) && GetWindowTextLength(hWnd) > 0)
            {
                StringBuilder sb = new(256);
                GetWindowText(hWnd, sb, sb.Capacity);
                string windowTitle = sb.ToString();
                if (!string.IsNullOrEmpty(windowTitle))
                {
                    comboBoxWindows.Items.Add(new WindowItem { Handle = hWnd, Title = windowTitle });
                }
            }
            return true;
        }

        /// <summary>
        /// Occurs when the selected index changes. When the selected index changes, the selected window handle is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWindows.SelectedItem is WindowItem item)
            {
                selectedWindowHandle = item.Handle;
                FindTextFields(selectedWindowHandle);
            }
        }

        /// <summary>
        /// Finds text fields in the specified window. The text fields are added to the combo box.
        /// </summary>
        /// <param name="parentHandle">The handle of the window to search for text fields.</param>
        private void FindTextFields(IntPtr parentHandle)
        {
            fieldHandles.Clear();
            comboBoxFields.Items.Clear();

            Stack<IntPtr> handlesToCheck = new();
            handlesToCheck.Push(parentHandle);

            while (handlesToCheck.Count > 0)
            {
                IntPtr handle = handlesToCheck.Pop();
                IntPtr childHandle = IntPtr.Zero;

                while ((childHandle = FindWindowEx(handle, childHandle, null, null)) != IntPtr.Zero)
                {
                    StringBuilder classNameBuffer = new(256);
                    GetClassName(childHandle, classNameBuffer, classNameBuffer.Capacity);
                    string clsName = classNameBuffer.ToString();

                    // Partial match to catch variations like "WindowsForms10.EDIT.app..."
                    if (clsName.Contains("EDIT", StringComparison.OrdinalIgnoreCase)
                        || clsName.Contains("RICHEDIT", StringComparison.OrdinalIgnoreCase))
                    {
                        fieldHandles.Add(childHandle);
                        comboBoxFields.Items.Add(new FieldItem
                        {
                            Handle = childHandle,
                            ClassName = clsName
                        });
                    }

                    handlesToCheck.Push(childHandle);
                }
            }

            if (comboBoxFields.Items.Count > 0)
            {
                comboBoxFields.SelectedIndex = 0;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (selectedWindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Please select a window first.");
                return;
            }

            if (comboBoxFields.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a field.");
                return;
            }

            IntPtr fieldHandle = fieldHandles[comboBoxFields.SelectedIndex];
            SendMessage(fieldHandle, WM_SETTEXT, IntPtr.Zero, "Never gonna give you up...");
        }
    }
}